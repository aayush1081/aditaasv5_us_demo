using aditaas_v5.Classes;
using aditaas_v5.Classes.Notification;
using aditaas_v5.Controllers;
using aditaas_v5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using V5WinService.Classes;

namespace V5WinService.BusinessLogic
{
    public static class CLS_SLA_Manager_Engine
    {

        public static async Task Set_Scheduler_Event(SignalR_MessageBE objNotifyBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                #region Cancel Pending Job

                foreach (var item in db_Context.TblScheduleEvent.Where(a => a.AdditionalRefId == objNotifyBE.additionalRefId
                                                                    && a.EventType == (int)Enum_EventTypes.SLA_Manager
                                                                    && a.Status == (int)Enum_Schedule_Event_Status.Pending))
                    item.Status = (int)Enum_Schedule_Event_Status.Cancel;
                await db_Context.SaveChangesAsync();

                #endregion

                var obj_TicketSLABE = db_Context.TblTrnTicketSla.FirstOrDefault(a => a.ModuleId == objNotifyBE.moduleId && a.RecordId == objNotifyBE.ticketId);
                if (obj_TicketSLABE != null)
                {
                    if (obj_TicketSLABE.ResponseSlaStatus == "Progress")
                    {
                        var query = db_Context.TblCnfSlaAction.Where(a => a.SlaId == obj_TicketSLABE.SlaId && a.BreachType == "Response" && a.SlaPercentage > 0).OrderBy(a => a.SlaPercentage);
                        var sla_Percentage = query.Select(a => a.SlaPercentage).FirstOrDefault();
                        var Coll_Action_BE = query.Where(a => a.SlaPercentage == sla_Percentage).ToList();
                        if (Coll_Action_BE.Count() > 0)
                            Add_ScheduleEvent_Entry(obj_TicketSLABE, Coll_Action_BE, null, db_Context);
                    }
                    if (obj_TicketSLABE.ResolveSlaStatus == "Progress")
                    {
                        var query = db_Context.TblCnfSlaAction.Where(a => a.SlaId == obj_TicketSLABE.SlaId && a.BreachType == "Resolution" && a.SlaPercentage > 0).OrderBy(a => a.SlaPercentage);
                        var sla_Percentage = query.Select(a => a.SlaPercentage).FirstOrDefault();
                        var Coll_Action_BE = query.Where(a => a.SlaPercentage == sla_Percentage).ToList();
                        if (Coll_Action_BE.Count() > 0)
                            Add_ScheduleEvent_Entry(obj_TicketSLABE, Coll_Action_BE, null, db_Context);
                    }
                }
            }
        }

        [Obsolete]
        public static async Task Start_Schedule_Event(TblScheduleEvent objSchEventBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                try
                {
                    var obj_TicketSLABE = await db_Context.TblTrnTicketSla.Where(a => a.ModuleId == objSchEventBE.ModuleId && a.RecordId == objSchEventBE.RecordId).AsNoTracking().FirstOrDefaultAsync();
                    var obj_SLAActionBE = await db_Context.TblCnfSlaAction.Where(a => a.SlaActionId == objSchEventBE.Counter).Include(a => a.Sla).FirstOrDefaultAsync();
                    if (obj_TicketSLABE != null && obj_SLAActionBE != null)
                    {
                        if ((obj_SLAActionBE.BreachType == "Response" && obj_TicketSLABE.ResponseSlaStatus == "Progress")
                            || (obj_SLAActionBE.BreachType == "Resolution" && obj_TicketSLABE.ResolveSlaStatus == "Progress"))
                        {
                            if (obj_SLAActionBE.ActionType == "Send Email")
                            {
                                await SLAManagerAction_SendEmail(objSchEventBE, obj_TicketSLABE, obj_SLAActionBE, db_Context);
                            }
                            else if (obj_SLAActionBE.ActionType == "Send SMS")
                            {
                                await SLAManagerAction_SendEmailSMS(objSchEventBE, obj_TicketSLABE, obj_SLAActionBE, db_Context);
                            }
                            else if (obj_SLAActionBE.ActionType == "Send Notification")
                            {
                                SLAManagerAction_SendNotification(objSchEventBE, obj_TicketSLABE, obj_SLAActionBE, db_Context);
                            }
                            else if (obj_SLAActionBE.ActionType == "API Call")
                            {
                                SLAManagerAction_APICall(objSchEventBE, obj_TicketSLABE, obj_SLAActionBE, db_Context);
                            }
                            else if (obj_SLAActionBE.ActionType == "Set Values")
                            {
                                SLAManagerAction_SetValues(objSchEventBE, obj_TicketSLABE, obj_SLAActionBE, db_Context);
                            }

                            #region Add Next Esacalation Entry

                            if (objSchEventBE.ErrorMessage == "-1")
                            {
                                var query = db_Context.TblCnfSlaAction.Where(a => a.SlaId == obj_TicketSLABE.SlaId && a.BreachType == obj_SLAActionBE.BreachType && a.SlaPercentage > obj_SLAActionBE.SlaPercentage).OrderBy(a => a.SlaPercentage);
                                var sla_Percentage = query.Select(a => a.SlaPercentage).FirstOrDefault();
                                var Coll_Action_BE = query.Where(a => a.SlaPercentage == sla_Percentage).ToList();
                                if (Coll_Action_BE.Count > 0)
                                    Add_ScheduleEvent_Entry(obj_TicketSLABE, Coll_Action_BE, objSchEventBE.ScheduleEventId, db_Context);
                            }

                            #endregion

                        }
                        objSchEventBE.Status = (int)Enum_Schedule_Event_Status.Success;
                    }
                    else
                        objSchEventBE.Status = (int)Enum_Schedule_Event_Status.Cancel;
                    db_Context.Entry(objSchEventBE).State = EntityState.Modified;
                    db_Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static void Add_ScheduleEvent_Entry(TblTrnTicketSla objTicketSLABE, List<TblCnfSlaAction> CollSLA_ActionBE, int? parent_schedule_event_id, aditaas_v5Context db_Context)
        {
            foreach (var objSLA_ActionBE in CollSLA_ActionBE)
            {
                DateTime? dt_Sch_Date = null;
                int? int_TargetMin = null;
                var controllerSLA = new TblTrnTicketSlaController(db_Context);
                //var siteId = GlobalClass.Get_TicketSiteId_From_Id((Enum_ModuleTypes)objTicketSLABE.ModuleId, objTicketSLABE.RecordId, db_Context);
                if (objSLA_ActionBE.BreachType == "Response")
                {
                    dt_Sch_Date = objTicketSLABE.ResponseStartOn;
                    int_TargetMin = objTicketSLABE.ResponseTargetMin;
                }
                else if (objSLA_ActionBE.BreachType == "Resolution")
                {
                    dt_Sch_Date = objTicketSLABE.ResolveStartOn;
                    int_TargetMin = objTicketSLABE.ResolveTargetMin;
                    var int_SLA_Pause_Min = (int?)db_Context.TblTrnTicketSpentTime.Where(a => a.ModuleId == objTicketSLABE.ModuleId && a.RecordId == objTicketSLABE.RecordId && a.IsSlaPause == true).Sum(a => a.SpentMinWork);
                    if (int_SLA_Pause_Min > 0)
                        dt_Sch_Date = controllerSLA.Get_Next_SLA_Target_Date(dt_Sch_Date, (int)int_SLA_Pause_Min, objTicketSLABE);
                }
                if (dt_Sch_Date != null && objSLA_ActionBE.SlaPercentage > 0)
                {
                    var sla_Min = int_TargetMin * objSLA_ActionBE.SlaPercentage / 100;
                    dt_Sch_Date = controllerSLA.Get_Next_SLA_Target_Date(dt_Sch_Date, (int)sla_Min, objTicketSLABE);
                    var objScheduleBE = new TblScheduleEvent()
                    {
                        Counter = objSLA_ActionBE.SlaActionId,
                        AdditionalRefId = objTicketSLABE.TicketSlaId,
                        ModuleId = objTicketSLABE.ModuleId,
                        RecordId = objTicketSLABE.RecordId,
                        CreatedOn = DateTime.UtcNow,
                        ScheduledOn = dt_Sch_Date,
                        Status = (int)Enum_Schedule_Event_Status.Pending,
                        EventType = (int)Enum_EventTypes.SLA_Manager,
                        ErrorMessage = (CollSLA_ActionBE.IndexOf(objSLA_ActionBE) == 0 ? "-1" : ""),
                        ParentScheduleEventId = parent_schedule_event_id,
                    };
                    db_Context.TblScheduleEvent.Add(objScheduleBE);
                    db_Context.SaveChanges();
                }
            }
        }

        [Obsolete]
        private static async Task SLAManagerAction_SendEmail(TblScheduleEvent objSchEventBE, TblTrnTicketSla obj_TicketSLABE, TblCnfSlaAction obj_SLAActionBE, aditaas_v5Context db_Context)
        {            
            int? orgId = (obj_TicketSLABE != null ? obj_TicketSLABE.OrgId : null);
            var coll_UserId = Get_Notify_UserIds(objSchEventBE, obj_SLAActionBE, db_Context, orgId);
            var coll_Field_Data = CLS_Global_Class.Get_Ticket_Field_Info(objSchEventBE, obj_SLAActionBE.MessageSubject, obj_SLAActionBE.MessageBody, null, db_Context);
            var str_Email_Subject = "";
            var str_From_Email_Id = "";
            if (coll_UserId.Count > 0)
            {
                var item_UserId = coll_UserId.FirstOrDefault();
                var coll_ToEmailId = new List<string>();
                foreach (var item in coll_UserId)
                {
                    var str_EmailId = CLS_Global_Class.Get_UserEmail_By_UserId(item, db_Context);
                    if (string.IsNullOrWhiteSpace(str_EmailId) != true)
                        coll_ToEmailId.Add(str_EmailId);
                }

                if (coll_ToEmailId.Count > 0)
                {
                    str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageSubject, item_UserId.UserId, db_Context);
                    var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageBody, item_UserId.UserId, db_Context);
                    str_From_Email_Id = await CLS_EmailSender.SendEmailAsync(obj_SLAActionBE.Sla.OrgId, string.Join(",", coll_ToEmailId), null, str_Email_Subject, str_Email_Body, db_Context);
                }
                //foreach (var item_UserId in coll_UserId)
                //{
                //    str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageSubject, item_UserId, db_Context);
                //    var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageBody, item_UserId, db_Context);
                //    var str_EmailId = CLS_Global_Class.Get_UserEmail_By_UserId(item_UserId, db_Context);
                //    str_From_Email_Id = await CLS_EmailSender.SendEmailAsync(obj_SLAActionBE.Sla.OrgId, str_EmailId, null, str_Email_Subject, str_Email_Body, db_Context);
                //}
            }

            #region Send Email to External Emails

            if (string.IsNullOrWhiteSpace(obj_SLAActionBE.NotifyExternalEmailIds) != true)
            {
                var siteId = GlobalClass.Get_TicketSiteId_From_Id((Enum_ModuleTypes)objSchEventBE.ModuleId, objSchEventBE.RecordId, db_Context);
                str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageSubject, 0, db_Context, siteId);
                var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageBody, 0, db_Context, siteId);
                str_From_Email_Id = await CLS_EmailSender.SendEmailAsync(obj_SLAActionBE.Sla.OrgId, obj_SLAActionBE.NotifyExternalEmailIds, null, str_Email_Subject, str_Email_Body, db_Context);
            }

            #endregion

            CLS_Global_Class.Add_SendEmail_ActivityLog(objSchEventBE.ModuleId, objSchEventBE.RecordId, "SLA Manager", str_Email_Subject, coll_UserId, obj_SLAActionBE.NotifyExternalEmailIds, str_From_Email_Id, db_Context);
        }

        [Obsolete]
        private static async Task SLAManagerAction_SendEmailSMS(TblScheduleEvent objSchEventBE, TblTrnTicketSla obj_TicketSLABE, TblCnfSlaAction obj_SLAActionBE, aditaas_v5Context db_Context)
        {
            int? orgId = (obj_TicketSLABE != null ? obj_TicketSLABE.OrgId : null);
            var coll_UserId = Get_Notify_UserIds(objSchEventBE, obj_SLAActionBE, db_Context, orgId);
            if (coll_UserId.Count > 0)
            {
                var coll_Field_Data = CLS_Global_Class.Get_Ticket_Field_Info(objSchEventBE, obj_SLAActionBE.MessageSubject, obj_SLAActionBE.MessageBody, null, db_Context);
                var str_Email_Subject = "";
                var str_From_EmailId = "";
                var coll_ToEmailId = new List<string>();
                var item_UserId = coll_UserId.FirstOrDefault();
                foreach (var item in coll_UserId)
                {
                    var str_EmailId = CLS_Global_Class.Get_UserContactNo_By_UserId(item, db_Context);
                    if (string.IsNullOrWhiteSpace(str_EmailId) != true)
                        coll_ToEmailId.Add(str_EmailId);
                }

                if (coll_ToEmailId.Count > 0)
                {
                    str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageSubject, item_UserId.UserId, db_Context);
                    var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageBody, item_UserId.UserId, db_Context);
                    str_From_EmailId = await CLS_EmailSMSSender.SendSMSViaEmailAsync(obj_SLAActionBE.Sla.OrgId, string.Join(",", coll_ToEmailId), str_Email_Subject, str_Email_Body, db_Context);
                    CLS_Global_Class.Add_SendEmailSMS_ActivityLog(objSchEventBE.ModuleId, objSchEventBE.RecordId, "SLA Manager", str_Email_Subject, coll_UserId, str_From_EmailId, db_Context);
                }

                //foreach (var item_UserId in coll_UserId)
                //{
                //    var str_MobileNo = CLS_Global_Class.Get_UserContactNo_By_UserId(item_UserId, db_Context);
                //    if (str_MobileNo != null && str_MobileNo.Trim() != "")
                //    {
                //        str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageSubject, item_UserId, db_Context);
                //        var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageBody, item_UserId, db_Context);
                //        str_From_EmailId = await CLS_EmailSMSSender.SendSMSViaEmailAsync(obj_SLAActionBE.Sla.OrgId, str_MobileNo, str_Email_Subject, str_Email_Body, db_Context);
                //    }
                //}
            }
        }

        private static void SLAManagerAction_SendNotification(TblScheduleEvent objSchEventBE, TblTrnTicketSla obj_TicketSLABE, TblCnfSlaAction obj_SLAActionBE, aditaas_v5Context db_Context)
        {
            int? orgId = (obj_TicketSLABE != null ? obj_TicketSLABE.OrgId : null);
            var coll_UserId = Get_Notify_UserIds(objSchEventBE, obj_SLAActionBE, db_Context, orgId);
            var coll_Field_Data = CLS_Global_Class.Get_Ticket_Field_Info(objSchEventBE, obj_SLAActionBE.MessageSubject, obj_SLAActionBE.MessageBody, null, db_Context);
            var str_Email_Subject = "";
            foreach (var item_UserId in coll_UserId)
            {
                str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageSubject, item_UserId.UserId, db_Context);
                var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_SLAActionBE.MessageBody, item_UserId.UserId, db_Context);
                var obj_MessageBE = new SignalR_MessageBE()
                {
                    moduleId = objSchEventBE.ModuleId,
                    ticketId = objSchEventBE.RecordId,
                    additionalRefId = objSchEventBE.AdditionalRefId,
                    title = str_Email_Subject,
                    messageText = str_Email_Body,
                };
                CLS_SignalR_Connection.SendWebNotification(obj_MessageBE, db_Context, item_UserId.UserId);
            }
        }

        private static void SLAManagerAction_APICall(TblScheduleEvent objSchEventBE, TblTrnTicketSla obj_TicketSLABE, TblCnfSlaAction obj_SLAActionBE, aditaas_v5Context db_Context)
        {

        }

        private static void SLAManagerAction_SetValues(TblScheduleEvent objSchEventBE, TblTrnTicketSla obj_TicketSLABE, TblCnfSlaAction obj_SLAActionBE, aditaas_v5Context db_Context)
        {
            CLS_Global_Class.Set_Ticket_FieldValue(objSchEventBE, obj_SLAActionBE.UpdateFieldJson, db_Context).Wait();
        }

        private static List<CLS_Notify_UserId_BE> Get_Notify_UserIds(TblScheduleEvent objSchEventBE, TblCnfSlaAction obj_SLAActionBE, aditaas_v5Context db_Context, int? orgId)
        {
            var coll_UserId = new List<CLS_Notify_UserId_BE>();
            if (string.IsNullOrWhiteSpace(obj_SLAActionBE.NotifyUserIds) != true)
                coll_UserId.AddRange(CLS_Global_Class.Get_Coll_From_CSV(obj_SLAActionBE.NotifyUserIds).Select(a => new CLS_Notify_UserId_BE() { UserId = a, isPrimary = true }));
            foreach (var item_FieldId in CLS_Global_Class.Get_Coll_From_CSV(obj_SLAActionBE.NotifyUserBusFieldIds))
                coll_UserId.AddRange(CLS_Global_Class.Get_Ticket_UserIds_By_BusField(objSchEventBE, item_FieldId, null, db_Context, orgId));
            if (string.IsNullOrWhiteSpace(obj_SLAActionBE.NotifyGroupIds) != true)
                foreach (var item in CLS_Global_Class.Get_Coll_From_CSV(obj_SLAActionBE.NotifyGroupIds))
                    coll_UserId.AddRange(CLS_Global_Class.Get_User_Ids_By_Group_Id(item, db_Context, orgId).Select(a => new CLS_Notify_UserId_BE() { UserId = a, isPrimary = true }));
            foreach (var item_FieldId in CLS_Global_Class.Get_Coll_From_CSV(obj_SLAActionBE.NotifyExcludeUserBusFieldIds))
                coll_UserId.RemoveAll(a => CLS_Global_Class.Get_Ticket_UserIds_By_BusField(objSchEventBE, item_FieldId, null, db_Context, orgId).Any(aa => aa.UserId == a.UserId));
            return coll_UserId;

        }
    }
}
