using aditaas_v5.Classes;
using aditaas_v5.Classes.Notification;
using aditaas_v5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V5WinService.Classes;

namespace V5WinService.BusinessLogic
{
    public static class CLS_Ticket_Reminder_Engine
    {

        public static async Task Set_Scheduler_Event(SignalR_MessageBE objNotifyBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {

                #region Cancel Pending Job

                foreach (var item in db_Context.TblScheduleEvent.Where(a => a.AdditionalRefId == objNotifyBE.additionalRefId
                                                                     && a.EventType == (int)Enum_EventTypes.TicketReminder
                                                                     && a.Status == (int)Enum_Schedule_Event_Status.Pending))
                    item.Status = (int)Enum_Schedule_Event_Status.Cancel;
                await db_Context.SaveChangesAsync();

                #endregion

                if (objNotifyBE.actionType == (int)Enum_ActionTypes.TicketCreate
                    || objNotifyBE.actionType == (int)Enum_ActionTypes.TicketUpdate)
                {
                    var obj_FollowupBE = db_Context.TblCnfFollowUp.FirstOrDefault(a => a.FollowUpId == objNotifyBE.additionalRefId);
                    if (obj_FollowupBE != null)
                    {
                        Add_ScheduleEvent_Entry(obj_FollowupBE, db_Context);
                    }
                }
                else if (objNotifyBE.actionType == (int)Enum_ActionTypes.TicketDelete)
                {

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
                    var obj_FollowBE = db_Context.TblCnfFollowUp.FirstOrDefault(a => a.FollowUpId == objSchEventBE.AdditionalRefId);
                    if (obj_FollowBE != null)
                    {
                        var str_UserIds = "";
                        int? int_UserGroupId = 0;
                        if (obj_FollowBE.FollowUpTypeId == 1)
                            str_UserIds = obj_FollowBE.SetById.ToString();
                        else if (obj_FollowBE.FollowUpTypeId == 2)
                        {
                            if (obj_FollowBE.UserDefineUserIds != null)
                                str_UserIds = obj_FollowBE.UserDefineUserIds.ToString();
                            if (str_UserIds != "")
                                int_UserGroupId = CLS_Global_Class.Get_AssignGroupId_From_Id((Enum_ModuleTypes)objSchEventBE.ModuleId, objSchEventBE.RecordId, db_Context);
                        }
                        else
                            str_UserIds = obj_FollowBE.UserDefineUserIds;
                        var str_Notification_Message = "";
                        var str_TicketNo = CLS_Global_Class.Get_IdNumber_From_RecordId((Enum_ModuleTypes)objSchEventBE.ModuleId, objSchEventBE.RecordId, db_Context);
                        str_Notification_Message += "ID: " + str_TicketNo;
                        if (obj_FollowBE.Subject != null && obj_FollowBE.Subject != "")
                        {
                            if (str_Notification_Message != "")
                                str_Notification_Message += "";
                            str_Notification_Message += "<br>Subject: " + obj_FollowBE.Subject;
                        }
                        if (obj_FollowBE.Notes != null && obj_FollowBE.Notes != "")
                        {
                            if (str_Notification_Message != "")
                                str_Notification_Message += "";
                            str_Notification_Message += "<br>Notes: " + obj_FollowBE.Notes;
                        }
                        var obj_MessageBE = new SignalR_MessageBE()
                        {
                            eventType = objSchEventBE.EventType,
                            moduleId = objSchEventBE.ModuleId,
                            ticketId = objSchEventBE.RecordId,
                            title = "Ticket Reminder",
                            messageText = str_Notification_Message,
                        };
                        if (obj_FollowBE.IsSendEmail == true)
                        {
                            var objEmailTemplate = db_Context.TblCnfEmailTemplate.FirstOrDefault(a => a.IsActive == true && a.TemplateType == "Ticket Reminder");
                            if (objEmailTemplate != null)
                            {
                                var orgId = GlobalClass.Get_TicketOrgId_From_Id((Enum_ModuleTypes)obj_FollowBE.ModuleId, obj_FollowBE.RecordId, db_Context);
                                var coll_Field_Data = CLS_Global_Class.Get_Ticket_Field_Info(objSchEventBE, objEmailTemplate.Subject, objEmailTemplate.Body, null, db_Context);
                                var coll_UserId = CLS_Global_Class.Get_Coll_From_CSV(str_UserIds);
                                if (int_UserGroupId > 0)
                                    coll_UserId.AddRange(GlobalClass.Get_UserIds_By_GroupId(db_Context, new int?[] { int_UserGroupId }, orgId));
                                var str_Email_Subject = "";
                                var str_Rem_SetBy = GlobalClass.Get_UserName_From_UserId(obj_FollowBE.SetById, db_Context);
                                var str_From_EmailId = "";
                                foreach (var item_UserId in coll_UserId)
                                {
                                    str_Email_Subject = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, objEmailTemplate.Subject, item_UserId, db_Context);
                                    var str_Email_Body = CLS_Global_Class.Get_BodyText_With_FieldData(coll_Field_Data, objEmailTemplate.Body, item_UserId, db_Context);
                                    var str_EmailId = CLS_Global_Class.Get_UserEmail_By_UserId(new CLS_Notify_UserId_BE() { UserId = item_UserId, isPrimary = true }, db_Context);
                                    str_Email_Body = str_Email_Body.Replace("#Reminder Subject#", obj_FollowBE.Subject);
                                    str_Email_Body = str_Email_Body.Replace("#Reminder Message#", obj_FollowBE.Notes);
                                    str_Email_Body = str_Email_Body.Replace("#Reminded By#", str_Rem_SetBy);
                                    str_From_EmailId = await CLS_EmailSender.SendEmailAsync(orgId, str_EmailId, null, str_Email_Subject, str_Email_Body, db_Context);
                                }
                                CLS_Global_Class.Add_SendEmail_ActivityLog(objSchEventBE.ModuleId, objSchEventBE.RecordId, "Ticket Reminder", str_Email_Subject, coll_UserId.Select(a=>new CLS_Notify_UserId_BE() { UserId=a, isPrimary = true }), null, str_From_EmailId, db_Context);
                            }
                        }
                        CLS_SignalR_Connection.SendWebNotification(obj_MessageBE, db_Context, CLS_Global_Class.Get_Coll_From_CSV(str_UserIds));
                        objSchEventBE.Status = (int)Enum_Schedule_Event_Status.Success;

                        obj_FollowBE.ExecutionDate = DateTime.UtcNow;
                        db_Context.Entry(obj_FollowBE).State = EntityState.Modified;
                       
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

        private static void Add_ScheduleEvent_Entry(TblCnfFollowUp obj_BE, aditaas_v5Context db_Context)
        {
            if (obj_BE.SchDateTime >= DateTime.UtcNow)
            {
                var objScheduleBE = new TblScheduleEvent()
                {
                    AdditionalRefId = obj_BE.FollowUpId,
                    ModuleId = obj_BE.ModuleId,
                    RecordId = obj_BE.RecordId,
                    CreatedOn = DateTime.UtcNow,
                    ScheduledOn = obj_BE.SchDateTime,
                    Status = (int)Enum_Schedule_Event_Status.Pending,
                    EventType = (int)Enum_EventTypes.TicketReminder,
                };
                db_Context.TblScheduleEvent.Add(objScheduleBE);
                db_Context.SaveChanges();
            }
        }

    }
}
