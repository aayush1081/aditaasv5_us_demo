using aditaas_v5.Classes;
using aditaas_v5.Classes.Notification;
using aditaas_v5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using aditaas_v5.Controllers;
using System.Data;
using System.Collections;
using System.Net;
using System.IO;
using Microsoft.Extensions.Configuration;
using V5WinService.Classes;

namespace V5WinService.BusinessLogic
{
    public static class CLS_Ticket_Bus_Rule_Engine
    {

        public static async Task On_TicketCreate_P1_Ticket(SignalR_MessageBE objNotifyBE)
        {
            if (objNotifyBE.actionType == (int)Enum_ActionTypes.TicketCreate)
            {
                using (var db_Context = CLS_Global_Class.Get_db_Context())
                {
                    #region P1 Ticket Notification

                    int? int_PriorityId = null;
                    int? int_AssignGrpId = null;
                    int? int_CreatedById = null;
                    string str_MessageText = "";
                    if (objNotifyBE.moduleId == (int)Enum_ModuleTypes.Incident)
                    {
                        var obj_BE = await db_Context.TblTrnIncident.Where(a => a.IncidentId == objNotifyBE.ticketId && (a.IsDraft == null || a.IsDraft == false))
                                                               .Select(a => new { a.PriorityId, a.CurrAssignQueueId, a.IdNumber, a.ShortDesc, a.CreatedById })
                                                               .FirstOrDefaultAsync();
                        if (obj_BE != null)
                        {
                            int_PriorityId = obj_BE.PriorityId;
                            int_AssignGrpId = obj_BE.CurrAssignQueueId;
                            int_CreatedById = obj_BE.CreatedById;
                            str_MessageText = string.Format("ID: {0}, Subject: {1} ", obj_BE.IdNumber, obj_BE.ShortDesc);
                        }
                    }
                    else if (objNotifyBE.moduleId == (int)Enum_ModuleTypes.Request)
                    {
                        var obj_BE = await db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == objNotifyBE.ticketId && (a.IsDraft == null || a.IsDraft == false))
                                                                    .Select(a => new { a.PriorityId, a.CurrAssignQueueId, a.IdNumber, a.ShortDescription, a.CreatedById })
                                                                    .FirstOrDefaultAsync();
                        if (obj_BE != null)
                        {
                            int_PriorityId = obj_BE.PriorityId;
                            int_AssignGrpId = obj_BE.CurrAssignQueueId;
                            int_CreatedById = obj_BE.CreatedById;
                            str_MessageText = string.Format("ID: {0}, Subject: {1} ", obj_BE.IdNumber, obj_BE.ShortDescription);
                        }
                    }
                    if (int_PriorityId > 0)
                    {
                        var obj_Entity_BE = db_Context.TblMstEntityAttr.FirstOrDefault(a => a.EntityAttrId == int_PriorityId);
                        if (obj_Entity_BE != null && obj_Entity_BE.Name == "P1")
                        {
                            objNotifyBE.type = "P1 Ticket";
                            objNotifyBE.notifyType = "add";
                            objNotifyBE.title = "P1 Ticket created";
                            objNotifyBE.messageText = str_MessageText;
                            CLS_SignalR_Connection.SendWebNotification(objNotifyBE, db_Context, null, int_AssignGrpId);
                        }
                    }

                    #endregion
                }
            }
        }

        public static async Task Set_Scheduler_EventAsync(SignalR_MessageBE objNotifyBE, bool RunSyncRules = false)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                var int_OrgId = GlobalClass.Get_TicketOrgId_From_Id((Enum_ModuleTypes)objNotifyBE.moduleId, objNotifyBE.ticketId, db_Context);
                var int_ModuleId = objNotifyBE.moduleId;
                if (objNotifyBE.eventType == (int)Enum_EventTypes.TicketApproval)
                    int_ModuleId = (int)Enum_ModuleTypes.Approval;

                var coll_BusRule = db_Context.TblCnfBusRule.Where(a => a.ModuleId == int_ModuleId
                                                                    && a.OrgId == int_OrgId
                                                                    && a.IsActive == true
                                                                    && a.ActionType == objNotifyBE.actionType
                                                                    && (a.IsSyncOncreate == null ? false : a.IsSyncOncreate) == RunSyncRules).ToList();
                foreach (var item_BusRule in coll_BusRule)
                {
                    #region Cancel Stop Bus Rule 
                    var IsSyncOncreate = item_BusRule.IsSyncOncreate.GetValueOrDefault(false);

                    if (item_BusRule.StopBusRuleIds != null && item_BusRule.StopBusRuleIds != "")
                    {
                        foreach (var item_BusRuleId in item_BusRule.StopBusRuleIds.Split(','))
                        {
                            foreach (var item_Event in db_Context.TblScheduleEvent.Where(a => a.ModuleId == objNotifyBE.moduleId
                                                                                               && a.RecordId == objNotifyBE.ticketId
                                                                                               && a.AdditionalRefId == objNotifyBE.additionalRefId
                                                                                               && a.BusRuleId == int.Parse(item_BusRuleId)
                                                                                               && a.Status == (int)Enum_Schedule_Event_Status.Pending))
                            {
                                item_Event.Status = (int)Enum_Schedule_Event_Status.Cancel;
                                item_Event.ExecutedOn = DateTime.UtcNow;
                            }
                            await db_Context.SaveChangesAsync();
                        }
                    }

                    #endregion

                    #region Cancel Existing Bus Rule 

                    foreach (var item_Event in db_Context.TblScheduleEvent.Where(a => a.ModuleId == objNotifyBE.moduleId
                                                                                       && a.RecordId == objNotifyBE.ticketId
                                                                                       && a.AdditionalRefId == objNotifyBE.additionalRefId
                                                                                       && a.BusRuleId == item_BusRule.BusRuleId
                                                                                       && a.Status == (int)Enum_Schedule_Event_Status.Pending))
                    {
                        item_Event.Status = (int)Enum_Schedule_Event_Status.Cancel;
                        item_Event.ExecutedOn = DateTime.UtcNow;
                    }
                    db_Context.SaveChanges();

                    #endregion

                    var str_SqlQuerySelect = item_BusRule.SqlQuerySelect.Replace("#ticket_id#", objNotifyBE.ticketId.ToString());
                    if (objNotifyBE.moduleId > 0)
                        str_SqlQuerySelect = str_SqlQuerySelect.Replace("#module_id#", objNotifyBE.moduleId.ToString());
                    if (objNotifyBE.additionalRefId > 0)
                        str_SqlQuerySelect = str_SqlQuerySelect.Replace("#additional_ref_id#", objNotifyBE.additionalRefId.ToString());
                    var dt_Select = GlobalClass.Get_dt_From_SQL(str_SqlQuerySelect, db_Context);
                    if (dt_Select.Rows.Count > 0)
                    {
                        var obj_NewSchBE = new TblScheduleEvent()
                        {
                            ModuleId = objNotifyBE.moduleId,
                            RecordId = objNotifyBE.ticketId,
                            AdditionalRefId = objNotifyBE.additionalRefId,
                            CreatedOn = DateTime.UtcNow,
                            BusRuleId = item_BusRule.BusRuleId,
                            ActionType = objNotifyBE.actionType,
                            Status = (int)Enum_Schedule_Event_Status.Pending,
                            EventType = objNotifyBE.eventType,
                            ScheduledOn = DateTime.UtcNow,
                            IsSyncOncreate = IsSyncOncreate
                        };
                        if (item_BusRule.RecurringCount > 0)
                            obj_NewSchBE.Counter = 1;
                        if (item_BusRule.IntervalMinutes > 0 && item_BusRule.IntervalType == (int)Enum_BusRule_IntervalType.After)
                        {
                            var objController = new TblTrnTicketSlaController(db_Context);
                            var siteId = GlobalClass.Get_TicketSiteId_From_Id((Enum_ModuleTypes)objNotifyBE.moduleId, objNotifyBE.ticketId, db_Context);
                            obj_NewSchBE.ScheduledOn = objController.Get_Next_Operation_Target_Date(DateTime.UtcNow, (int)item_BusRule.IntervalMinutes, siteId);
                        }
                        db_Context.TblScheduleEvent.Add(obj_NewSchBE);
                        db_Context.SaveChanges();
                        if (IsSyncOncreate)
                        {
                            Start_Schedule_Event(obj_NewSchBE).Wait();
                        }
                    }
                }

            }
        }


        public static async Task Start_Schedule_Event(TblScheduleEvent objSchEventBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                try
                {
                    var obj_BusRuleBE = db_Context.TblCnfBusRule.Where(a => a.BusRuleId == objSchEventBE.BusRuleId).Include(a => a.TblCnfBusRuleAction).FirstOrDefault();
                    if (obj_BusRuleBE != null)
                    {
                        var str_SqlQuerySelect = obj_BusRuleBE.SqlQuerySelect.Replace("#ticket_id#", objSchEventBE.RecordId.ToString());
                        if (objSchEventBE.ModuleId > 0)
                            str_SqlQuerySelect = str_SqlQuerySelect.Replace("#module_id#", objSchEventBE.ModuleId.ToString());
                        if (objSchEventBE.AdditionalRefId > 0)
                            str_SqlQuerySelect = str_SqlQuerySelect.Replace("#additional_ref_id#", objSchEventBE.AdditionalRefId.ToString());
                        var dt_Select = GlobalClass.Get_dt_From_SQL(str_SqlQuerySelect, db_Context);
                        if (dt_Select.Rows.Count > 0)
                        {
                            var coll_Loop = new List<TblTrnTicketLink>();
                            if (str_SqlQuerySelect.Contains(" link.") == true || obj_BusRuleBE.TblCnfBusRuleAction.Count(a => string.IsNullOrEmpty(a.MessageSubject) == false && a.MessageSubject.Contains("#Link.") == true || string.IsNullOrEmpty(a.MessageBody) == false && a.MessageBody.Contains("#Link.") == true) > 0)
                            {
                                foreach (DataRow item in dt_Select.Rows)
                                {
                                    coll_Loop.Add(new TblTrnTicketLink()
                                    {
                                        TargetModuleId = CLS_Global_Class.Convert_Object_Int(item["target_module_id"]),
                                        TargetRecordId = CLS_Global_Class.Convert_Object_Int(item["target_record_id"]),
                                    });
                                }
                            }
                            else
                                coll_Loop.Add(new TblTrnTicketLink()
                                {
                                    TargetModuleId = 0,
                                    TargetRecordId = 0,
                                });

                            foreach (var item_Link in coll_Loop)
                            {
                                foreach (var item_BusAction in db_Context.TblCnfBusRuleAction.Where(a => a.BusRuleId == obj_BusRuleBE.BusRuleId
                                                                                                  && a.ActionType != null).OrderBy(a => a.RuleActionId).ToList())
                                {
                                    if (item_BusAction.ActionType == "Send Email")
                                        await BusRuleAction_SendEmailAsync(objSchEventBE, item_BusAction, item_Link, db_Context, obj_BusRuleBE.OrgId);
                                    else if (item_BusAction.ActionType == "Send Notification")
                                        BusRuleAction_SendNotification(objSchEventBE, item_BusAction, item_Link, db_Context, obj_BusRuleBE.OrgId);
                                    else if (item_BusAction.ActionType == "Send SMS")
                                        await BusRuleAction_SendEmailSMS(objSchEventBE, item_BusAction, item_Link, db_Context, obj_BusRuleBE.OrgId);
                                    else if (item_BusAction.ActionType == "Set Values")
                                        BusRuleAction_UpdateFormField(objSchEventBE, item_BusAction, item_Link);
                                    else if (item_BusAction.ActionType == "API Call")
                                        await BusRuleAction_APICall(objSchEventBE, item_BusAction, item_Link, db_Context);
                                    else if (item_BusAction.ActionType == "Push Notification")
                                        await BusRuleAction_Push_Notification(objSchEventBE, item_BusAction, item_Link, db_Context, obj_BusRuleBE.OrgId);
                                }
                            }

                            #region Created Nested Event

                            if (obj_BusRuleBE.RecurringCount > objSchEventBE.Counter)
                            {
                                var obj_NewSchBE = new TblScheduleEvent()
                                {
                                    ModuleId = objSchEventBE.ModuleId,
                                    RecordId = objSchEventBE.RecordId,
                                    AdditionalRefId = objSchEventBE.AdditionalRefId,
                                    CreatedOn = DateTime.UtcNow,
                                    BusRuleId = obj_BusRuleBE.BusRuleId,
                                    ActionType = objSchEventBE.ActionType,
                                    Status = (int)Enum_Schedule_Event_Status.Pending,
                                    EventType = objSchEventBE.EventType,
                                    ScheduledOn = DateTime.UtcNow,
                                    ParentScheduleEventId = objSchEventBE.ScheduleEventId,
                                };
                                obj_NewSchBE.Counter = objSchEventBE.Counter + 1;
                                if (obj_BusRuleBE.IntervalMinutes > 0)
                                    obj_NewSchBE.ScheduledOn = DateTime.UtcNow.AddMinutes((int)obj_BusRuleBE.IntervalMinutes);
                                db_Context.TblScheduleEvent.Add(obj_NewSchBE);
                                db_Context.SaveChanges();
                            }

                            #endregion

                            #region Execute Nested Bus Rule

                            if (obj_BusRuleBE.NestedBusRuleIds != null && obj_BusRuleBE.NestedBusRuleIds != "")
                            {
                                foreach (var item_Nested_BusRule_Id in CLS_Global_Class.Get_Coll_From_CSV(obj_BusRuleBE.NestedBusRuleIds))
                                {
                                    var obj_Nested_BusRule_BE = db_Context.TblCnfBusRule.FirstOrDefault(a => a.BusRuleId == item_Nested_BusRule_Id);
                                    if (obj_Nested_BusRule_BE == null)
                                        continue;
                                    if (string.IsNullOrEmpty(obj_BusRuleBE.NestedBusRuleSqlSelect) == true)
                                    {
                                        Add_Nested_Bus_Rule(obj_Nested_BusRule_BE, objSchEventBE, objSchEventBE.ModuleId, objSchEventBE.RecordId, objSchEventBE.AdditionalRefId, db_Context);
                                    }
                                    else
                                    {
                                        var str_SqlQueryNested = obj_BusRuleBE.NestedBusRuleSqlSelect;
                                        if (objSchEventBE.ModuleId > 0)
                                            str_SqlQueryNested = str_SqlQueryNested.Replace("#module_id#", objSchEventBE.ModuleId.ToString());
                                        if (objSchEventBE.RecordId > 0)
                                            str_SqlQueryNested = str_SqlQueryNested.Replace("#record_id#", objSchEventBE.RecordId.ToString());
                                        if (objSchEventBE.AdditionalRefId > 0)
                                            str_SqlQueryNested = str_SqlQueryNested.Replace("#additional_ref_id#", objSchEventBE.AdditionalRefId.ToString());
                                        var dt_Select_Nested = GlobalClass.Get_dt_From_SQL(str_SqlQueryNested, db_Context);
                                        for (int i = 0; i < dt_Select_Nested.Rows.Count; i++)
                                        {
                                            int? int_ModuleId = null;
                                            if (dt_Select_Nested.Columns.Contains("module_id"))
                                                int_ModuleId = CLS_Global_Class.Convert_Object_Int(dt_Select_Nested.Rows[i]["module_id"]);
                                            int? int_RecordId = null;
                                            if (dt_Select_Nested.Columns.Contains("record_id"))
                                                int_RecordId = CLS_Global_Class.Convert_Object_Int(dt_Select_Nested.Rows[i]["record_id"]);
                                            int? int_AdditionalRefId = null;
                                            if (dt_Select_Nested.Columns.Contains("additional_ref_id"))
                                                int_AdditionalRefId = CLS_Global_Class.Convert_Object_Int(dt_Select_Nested.Rows[i]["additional_ref_id"]);
                                            Add_Nested_Bus_Rule(obj_Nested_BusRule_BE, objSchEventBE, int_ModuleId, int_RecordId, int_AdditionalRefId, db_Context);
                                        }
                                    }
                                }
                            }

                            #endregion

                            objSchEventBE.Status = (int)Enum_Schedule_Event_Status.Success;
                            objSchEventBE.ExecutedOn = DateTime.UtcNow;
                            db_Context.Entry(objSchEventBE).State = EntityState.Modified;
                            db_Context.SaveChanges();
                        }
                        else
                        {
                            objSchEventBE.Status = (int)Enum_Schedule_Event_Status.Cancel;
                            objSchEventBE.ExecutedOn = DateTime.UtcNow;
                            db_Context.Entry(objSchEventBE).State = EntityState.Modified;
                            db_Context.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static void Add_Nested_Bus_Rule(TblCnfBusRule objBusRule, TblScheduleEvent objSchEventBE, int? moduleId, int? recordId, int? additionalRefId, aditaas_v5Context db_Context)
        {
            var obj_NewSchBE = new TblScheduleEvent()
            {
                ModuleId = moduleId,
                RecordId = recordId,
                AdditionalRefId = additionalRefId,
                CreatedOn = DateTime.UtcNow,
                BusRuleId = objBusRule.BusRuleId,
                ActionType = objBusRule.ActionType,
                Status = (int)Enum_Schedule_Event_Status.Pending,
                EventType = objSchEventBE.EventType,
                ScheduledOn = DateTime.UtcNow,
                ParentScheduleEventId = objSchEventBE.ScheduleEventId,
            };
            if (objBusRule.RecurringCount > 0)
                obj_NewSchBE.Counter = 1;
            if (objBusRule.IntervalMinutes > 0 && objBusRule.IntervalType == (int)Enum_BusRule_IntervalType.After)
            {
                var objController = new TblTrnTicketSlaController(db_Context);
                var siteId = GlobalClass.Get_TicketSiteId_From_Id((Enum_ModuleTypes)obj_NewSchBE.ModuleId, obj_NewSchBE.RecordId, db_Context);
                obj_NewSchBE.ScheduledOn = objController.Get_Next_Operation_Target_Date(DateTime.UtcNow, (int)objBusRule.IntervalMinutes, siteId);
            }
            db_Context.TblScheduleEvent.Add(obj_NewSchBE);
            db_Context.SaveChanges();
        }

        [Obsolete]
        private static async Task BusRuleAction_SendEmailAsync(TblScheduleEvent objSchEventBE, TblCnfBusRuleAction obj_BusActionBE, TblTrnTicketLink obj_LinkBE, aditaas_v5Context db_Context, int? orgId)
        {
            var coll_UserId = Get_Notify_UserIds(objSchEventBE, obj_BusActionBE, obj_LinkBE, db_Context, orgId);
            var coll_Field_Data = CLS_Global_Class.Get_Ticket_Field_Info(objSchEventBE, obj_BusActionBE.MessageSubject, obj_BusActionBE.MessageBody, obj_LinkBE, db_Context);
            if (coll_Field_Data != null)
            {
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
                        if (coll_ToEmailId.Count == 1)
                        {
                            str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageSubject, item_UserId.UserId, db_Context);
                            var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageBody, item_UserId.UserId, db_Context);

                            //str_From_Email_Id = await CLS_EmailSender.SendEmailAsync(obj_BusActionBE.BusRule.OrgId, string.Join(",", coll_ToEmailId), null, str_Email_Subject, str_Email_Body, db_Context);
                            str_From_Email_Id = await CLS_EmailSender.SendEmailUsingOrgOrSender(obj_BusActionBE.BusRule.OrgId, obj_BusActionBE.SenderProfileId, string.Join(",", coll_ToEmailId), null, str_Email_Subject, str_Email_Body, db_Context);
                        }
                        else
                        {
                            try
                            {
                                str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageSubject, item_UserId.UserId, db_Context, 0, orgId.GetValueOrDefault(0));
                                var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageBody, item_UserId.UserId, db_Context, 0, orgId.GetValueOrDefault(0));
                                str_From_Email_Id = await CLS_EmailSender.SendEmailUsingOrgOrSender(obj_BusActionBE.BusRule.OrgId, obj_BusActionBE.SenderProfileId, string.Join(",", coll_ToEmailId), null, str_Email_Subject, str_Email_Body, db_Context);
                            }
                            catch
                            {
                                str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageSubject, item_UserId.UserId, db_Context);
                                var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageBody, item_UserId.UserId, db_Context);
                                str_From_Email_Id = await CLS_EmailSender.SendEmailUsingOrgOrSender(obj_BusActionBE.BusRule.OrgId, obj_BusActionBE.SenderProfileId, string.Join(",", coll_ToEmailId), null, str_Email_Subject, str_Email_Body, db_Context);
                            }
                        }
                    }
                    //foreach (var item_UserId in coll_UserId)
                    //{
                    //    var str_EmailId = CLS_Global_Class.Get_UserEmail_By_UserId(item_UserId, db_Context);
                    //    if (str_EmailId != null && str_EmailId.Trim() != "")
                    //    {
                    //        str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageSubject, item_UserId, db_Context);
                    //        var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageBody, item_UserId, db_Context);
                    //        str_From_Email_Id = await CLS_EmailSender.SendEmailAsync(obj_BusActionBE.BusRule.OrgId, str_EmailId, null, str_Email_Subject, str_Email_Body, db_Context);
                    //    }
                    //}
                }


                #region Set Email to External Emails

                if (string.IsNullOrWhiteSpace(obj_BusActionBE.NotifyExternalEmailIds) != true)
                {
                    var siteId = GlobalClass.Get_TicketSiteId_From_Id((Enum_ModuleTypes)objSchEventBE.ModuleId, objSchEventBE.RecordId, db_Context);
                    str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageSubject, 0, db_Context, siteId);
                    var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageBody, 0, db_Context, siteId);
                    str_From_Email_Id = await CLS_EmailSender.SendEmailAsync(obj_BusActionBE.BusRule.OrgId, obj_BusActionBE.NotifyExternalEmailIds, null, str_Email_Subject, str_Email_Body, db_Context);
                }

                #endregion

                CLS_Global_Class.Add_SendEmail_ActivityLog(objSchEventBE.ModuleId, objSchEventBE.RecordId, "Business Rule Manager", str_Email_Subject, coll_UserId, obj_BusActionBE.NotifyExternalEmailIds, str_From_Email_Id, db_Context);
            }
        }

        private static void BusRuleAction_SendNotification(TblScheduleEvent objSchEventBE, TblCnfBusRuleAction obj_BusActionBE, TblTrnTicketLink obj_LinkBE, aditaas_v5Context db_Context, int? orgId)
        {
            var coll_UserId = Get_Notify_UserIds(objSchEventBE, obj_BusActionBE, obj_LinkBE, db_Context, orgId);
            var coll_Field_Data = CLS_Global_Class.Get_Ticket_Field_Info(objSchEventBE, obj_BusActionBE.MessageSubject, obj_BusActionBE.MessageBody, obj_LinkBE, db_Context);
            foreach (var item_UserId in coll_UserId)
            {
                var str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageSubject, item_UserId.UserId, db_Context);
                var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageBody, item_UserId.UserId, db_Context);
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

        [Obsolete]
        private static async Task BusRuleAction_SendEmailSMS(TblScheduleEvent objSchEventBE, TblCnfBusRuleAction obj_BusActionBE, TblTrnTicketLink obj_LinkBE, aditaas_v5Context db_Context, int? orgId)
        {
            var coll_UserId = Get_Notify_UserIds(objSchEventBE, obj_BusActionBE, obj_LinkBE, db_Context, orgId);
            var coll_Field_Data = CLS_Global_Class.Get_Ticket_Field_Info(objSchEventBE, obj_BusActionBE.MessageSubject, obj_BusActionBE.MessageBody, obj_LinkBE, db_Context);
            var str_Email_Subject = "";
            var str_From_Email_Id = "";
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
                str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageSubject, item_UserId.UserId, db_Context);
                var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageBody, item_UserId.UserId, db_Context);
                str_From_Email_Id = await CLS_EmailSMSSender.SendSMSViaEmailAsync(obj_BusActionBE.BusRule.OrgId, string.Join(",", coll_ToEmailId), str_Email_Subject, str_Email_Body, db_Context);
                CLS_Global_Class.Add_SendEmailSMS_ActivityLog(objSchEventBE.ModuleId, objSchEventBE.RecordId, "Business Rule Manager", str_Email_Subject, coll_UserId, str_From_Email_Id, db_Context);
            }

            //foreach (var item_UserId in coll_UserId)
            //{
            //    var str_MobileNo = CLS_Global_Class.Get_UserContactNo_By_UserId(item_UserId, db_Context);
            //    if (str_MobileNo != null && str_MobileNo.Trim() != "")
            //    {
            //        str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageSubject, item_UserId, db_Context);
            //        var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageBody, item_UserId, db_Context);
            //        str_From_Email_Id = await CLS_EmailSMSSender.SendSMSViaEmailAsync(obj_BusActionBE.BusRule.OrgId, str_MobileNo, str_Email_Subject, str_Email_Body, db_Context);
            //    }
            //}

        }

        private static void BusRuleAction_UpdateFormField(TblScheduleEvent objSchEventBE, TblCnfBusRuleAction obj_BusActionBE, TblTrnTicketLink obj_LinkBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                CLS_Global_Class.Set_Ticket_FieldValue(objSchEventBE, obj_BusActionBE.UpdateFieldJson, db_Context).Wait();
            }
        }

        private static async Task BusRuleAction_APICall(TblScheduleEvent objSchEventBE, TblCnfBusRuleAction obj_BusActionBE, TblTrnTicketLink obj_LinkBE, aditaas_v5Context db_Context)
        {
            JObject json = JObject.Parse(obj_BusActionBE.RestApiJson);
            var str_ApiType = json.Value<string>("ApiType");
            var str_ApiUrl = json.Value<string>("ApiUrl");
            str_ApiUrl = str_ApiUrl.Replace("#ticket_id#", objSchEventBE.RecordId.ToString());
            if (str_ApiUrl.StartsWith("http") == false)
                str_ApiUrl = CLS_Global_Class.apiUrl + str_ApiUrl;
            CLS_Global_Class.LogInformation(str_ApiUrl);
            if (str_ApiType == "Get")
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetStringAsync(str_ApiUrl);
                var jsonResponse = JsonConvert.DeserializeObject<object>(response);
            }
            else if (str_ApiType == "Post")
            {

            }
        }

        private static async Task BusRuleAction_Push_Notification(TblScheduleEvent objSchEventBE, TblCnfBusRuleAction obj_BusActionBE, TblTrnTicketLink obj_LinkBE, aditaas_v5Context db_Context, int? orgId)
        {
            var coll_UserId = Get_Notify_UserIds(objSchEventBE, obj_BusActionBE, obj_LinkBE, db_Context, orgId);
            var coll_Field_Data = CLS_Global_Class.Get_Ticket_Field_Info(objSchEventBE, obj_BusActionBE.MessageSubject, obj_BusActionBE.MessageBody, obj_LinkBE, db_Context);
            List<User_Notification_Details> Coll_Session_Ids = null;
            if (coll_Field_Data != null)
            {
                if (coll_UserId != null && coll_UserId.Count > 0)
                {
                    Coll_Session_Ids = Get_Firebase_Session_Id(coll_UserId, db_Context);
                }
                if (Coll_Session_Ids != null && Coll_Session_Ids.Count > 0)
                {
                    foreach (var item in Coll_Session_Ids)
                    {
                        //CLS_Global_Class.LogInformation("userId :" + item.Key + " Session Id :" + item.Value);
                        var str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageSubject, item.userId, db_Context);
                        var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, obj_BusActionBE.MessageBody, item.userId, db_Context);
                        //CLS_Global_Class.LogInformation("Subject :" + str_Email_Subject);
                        //CLS_Global_Class.LogInformation("Body :" + str_Email_Body);
                        Notification_BE obj = new Notification_BE()
                        {
                            Alert_Id = 0001,
                            Alert_No = "00-1",
                            device_TokenNo = item.sessionId,
                            platform = item.platform,
                            message = str_Email_Body,
                            title = str_Email_Subject
                        };
                        PushNotification(obj);

                    }
                }
            }
        }

        private static List<CLS_Notify_UserId_BE> Get_Notify_UserIds(TblScheduleEvent objSchEventBE, TblCnfBusRuleAction obj_BusActionBE, TblTrnTicketLink obj_LinkBE, aditaas_v5Context db_Context, int? orgId)
        {
            var coll_UserId = new List<CLS_Notify_UserId_BE>();
            if (string.IsNullOrWhiteSpace(obj_BusActionBE.NotifyUserIds) != true)
                coll_UserId.AddRange(CLS_Global_Class.Get_Coll_From_CSV(obj_BusActionBE.NotifyUserIds).Select(a => new CLS_Notify_UserId_BE() { UserId = a, isPrimary = true }));
            foreach (var item_FieldId in CLS_Global_Class.Get_Coll_From_CSV(obj_BusActionBE.NotifyUserBusFieldIds))
                coll_UserId.AddRange(CLS_Global_Class.Get_Ticket_UserIds_By_BusField(objSchEventBE, item_FieldId, obj_LinkBE, db_Context, orgId));
            if (string.IsNullOrWhiteSpace(obj_BusActionBE.NotifyGroupIds) != true)
                foreach (var item in CLS_Global_Class.Get_Coll_From_CSV(obj_BusActionBE.NotifyGroupIds))
                    coll_UserId.AddRange(CLS_Global_Class.Get_User_Ids_By_Group_Id(item, db_Context, orgId).Select(a => new CLS_Notify_UserId_BE() { UserId = a, isPrimary = true }));
            foreach (var item_FieldId in CLS_Global_Class.Get_Coll_From_CSV(obj_BusActionBE.NotifyExcludeUserBusFieldIds))
                coll_UserId.RemoveAll(a => CLS_Global_Class.Get_Ticket_UserIds_By_BusField(objSchEventBE, item_FieldId, obj_LinkBE, db_Context, orgId).Any(aa => aa == a));
            return coll_UserId;
        }
        private static List<User_Notification_Details> Get_Firebase_Session_Id(List<CLS_Notify_UserId_BE> Coll_Data, aditaas_v5Context db_Context)
        {
            List<User_Notification_Details> Coll_Session_Ids = new List<User_Notification_Details>();
            foreach (var item in Coll_Data)
            {
                var dt = db_Context.TblMstUserProfile.FirstOrDefault(a => a.UserId == item.UserId).FirebaseSessionIdAndroid;
                if (dt != null)
                    Coll_Session_Ids.Add(new User_Notification_Details() { userId = item.UserId, platform = "android", sessionId = dt });
                var dtIOS = db_Context.TblMstUserProfile.FirstOrDefault(a => a.UserId == item.UserId).FirebaseSessionIdIos;
                if (dtIOS != null)
                    Coll_Session_Ids.Add(new User_Notification_Details() { userId = item.UserId, platform = "ios", sessionId = dtIOS });
            }
            return Coll_Session_Ids;
        }

        #region Firebase Notification

        private static string PushNotification(Notification_BE obj_BE)
        {
            try
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
                var SERVER_API_KEY = configuration.GetSection("AppSettings").GetValue<string>("Firebase_Server_API_Key");
                var SENDER_ID = configuration.GetSection("AppSettings").GetValue<string>("Firebase_Sender_Id");
                //string SERVER_API_KEY = GlobleClass.str_Firebase_Server_API_Key;
                //var SENDER_ID = GlobleClass.str_Firebase_Sender_Id;


                string jsonNotificationFormat = "";
                if (obj_BE.platform == "ios")
                {
                    var objNotification = new
                    {
                        to = obj_BE.device_TokenNo,
                        notification = new
                        {
                            body = obj_BE.message,
                            obj_BE.title,
                            is_background = true,
                            image = "notification_icon",
                            appicon = "notification_icon",
                            sound = "default"
                        },
                        data = new
                        {
                            alert_Id = obj_BE.Alert_Id,
                            alert_No = obj_BE.Alert_No,
                        },
                        soundname = "default",
                        //icon = "notification_icon",
                    };
                    jsonNotificationFormat = JsonConvert.SerializeObject(objNotification);
                }
                else
                {
                    var objNotification = new
                    {
                        to = obj_BE.device_TokenNo,
                        notification = new
                        {
                            obj_BE.title,
                            body = obj_BE.message,
                            icon = "notification_icon",
                            sound = "Enabled",
                        },
                        data = new
                        {
                            alert_Id = obj_BE.Alert_Id,
                            alert_No = obj_BE.Alert_No,
                        },
                        android = new
                        {
                            priority = "normal",
                        }
                    };
                    jsonNotificationFormat = JsonConvert.SerializeObject(objNotification);
                }
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                tRequest.ContentLength = byteArray.Length;
                tRequest.ContentType = "application/json";

                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                string sResponseFromServer = tReader.ReadToEnd();


                tReader.Close();
                dataStream.Close();
                tResponse.Close();
                return sResponseFromServer;
            }
            catch (Exception ee)
            {
                return null;
            }
        }


        private class Notification_BE
        {
            public string device_TokenNo { get; set; }
            public int Alert_Id { get; set; }
            public string Alert_No { get; set; }
            public string title { get; set; }
            public string message { get; set; }
            public string platform { get; set; }

        }
        private class User_Notification_Details
        {
            public int? userId { get; set; }
            public string platform { get; set; }
            public string sessionId { get; set; }
        }
        #endregion
    }
}
