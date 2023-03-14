using aditaas_v5.Classes;
using aditaas_v5.Classes.Notification;
using aditaas_v5.Controllers;
using aditaas_v5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V5WinService.Classes;

namespace V5WinService.BusinessLogic
{
    public static class CLS_Ticket_Scheduler_Engine
    {

        public static async Task Set_Scheduler_Event(SignalR_MessageBE objNotifyBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                #region Cancel Pending Job

                foreach (var item in db_Context.TblScheduleEvent.Where(a => a.AdditionalRefId == objNotifyBE.additionalRefId
                                                                    && a.EventType == (int)Enum_EventTypes.TicketSchedule
                                                                    && a.Status == (int)Enum_Schedule_Event_Status.Pending))
                    item.Status = (int)Enum_Schedule_Event_Status.Cancel;
                await db_Context.SaveChangesAsync();

                #endregion

                if (objNotifyBE.actionType == (int)Enum_ActionTypes.TicketCreate || objNotifyBE.actionType == (int)Enum_ActionTypes.TicketUpdate)
                {
                    var obj_TicketSchBE = db_Context.TblCnfTicketSch.FirstOrDefault(a => a.ModuleId == objNotifyBE.moduleId && a.RecordId == objNotifyBE.ticketId && a.IsActive == true);
                    if (obj_TicketSchBE != null)
                        Add_ScheduleEvent_Entry(obj_TicketSchBE, null, true, db_Context);
                }
            }
        }

        public static async Task Start_Schedule_Event(TblScheduleEvent objSchEventBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                try
                {
                    var obj_RptSchBE = db_Context.TblCnfTicketSch.FirstOrDefault(a => a.ModuleId == objSchEventBE.ModuleId && a.RecordId == objSchEventBE.RecordId);
                    if (obj_RptSchBE != null && obj_RptSchBE.IsActive == true)
                    {
                        #region Create Copy Ticket

                        string result = null;
                        if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Incident)
                        {
                            var objSourceBE = db_Context.TblTrnIncident.FirstOrDefault(a => a.IncidentId == objSchEventBE.RecordId);
                            if (objSourceBE != null)
                            {
                                var obj_TargetBE = new TblTrnIncident();
                                PropertyCopier<TblTrnIncident, TblTrnIncident>.Copy(objSourceBE, obj_TargetBE);
                                obj_TargetBE.IncidentId = 0;
                                obj_TargetBE.IdNumber = null;
                                obj_TargetBE.IsDraft = false;
                                obj_TargetBE.CreatedOn = DateTime.UtcNow;
                                result = await CLS_v4API.Post_ApiRequest("WebIncident/CreateIncident", obj_TargetBE);
                            }
                        }
                        else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Request)
                        {
                            var objSourceBE = db_Context.TblTrnServiceRequest.FirstOrDefault(a => a.ServiceRequestId == objSchEventBE.RecordId);
                            if (objSourceBE != null)
                            {
                                var obj_TargetBE = new TblTrnServiceRequest();
                                PropertyCopier<TblTrnServiceRequest, TblTrnServiceRequest>.Copy(objSourceBE, obj_TargetBE);
                                obj_TargetBE.ServiceRequestId = 0;
                                obj_TargetBE.IdNumber = null;
                                obj_TargetBE.IsDraft = false;
                                obj_TargetBE.CreatedOn = DateTime.UtcNow;
                                result = await CLS_v4API.Post_ApiRequest("WebRequest/CreateRequest", obj_TargetBE);
                            }
                        }
                        else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Problem)
                        {
                            var objSourceBE = db_Context.TblTrnProblem.FirstOrDefault(a => a.ProblemId == objSchEventBE.RecordId);
                            if (objSourceBE != null)
                            {
                                var obj_TargetBE = new TblTrnProblem();
                                PropertyCopier<TblTrnProblem, TblTrnProblem>.Copy(objSourceBE, obj_TargetBE);
                                obj_TargetBE.ProblemId = 0;
                                obj_TargetBE.IdNumber = null;
                                obj_TargetBE.IsDraft = false;
                                obj_TargetBE.CreatedOn = DateTime.UtcNow;
                                result = await CLS_v4API.Post_ApiRequest("WebProblem/CreateProblem", obj_TargetBE);
                            }
                        }
                        else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Change)
                        {
                            var objSourceBE = db_Context.TblTrnChange.FirstOrDefault(a => a.ChangeId == objSchEventBE.RecordId);
                            if (objSourceBE != null)
                            {
                                var obj_TargetBE = new TblTrnChange();
                                PropertyCopier<TblTrnChange, TblTrnChange>.Copy(objSourceBE, obj_TargetBE);
                                obj_TargetBE.ChangeId = 0;
                                obj_TargetBE.IdNumber = null;
                                obj_TargetBE.IsDraft = false;
                                obj_TargetBE.CreatedOn = DateTime.UtcNow;
                                result = await CLS_v4API.Post_ApiRequest("WebChange/CreateChange", obj_TargetBE);
                            }
                        }
                        else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Task)
                        {
                            var objSourceBE = db_Context.TblTrnTask.FirstOrDefault(a => a.TaskId == objSchEventBE.RecordId);
                            if (objSourceBE != null)
                            {
                                var obj_TargetBE = new TblTrnTask();
                                PropertyCopier<TblTrnTask, TblTrnTask>.Copy(objSourceBE, obj_TargetBE);
                                obj_TargetBE.TaskId = 0;
                                obj_TargetBE.IdNumber = null;
                                obj_TargetBE.IsDraft = false;
                                obj_TargetBE.CreatedOn = DateTime.UtcNow;
                                result = await CLS_v4API.Post_ApiRequest("WebTask/CreateTask", obj_TargetBE);
                            }
                        }
                        else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Kb)
                        {
                            var objSourceBE = db_Context.TblTrnKb.FirstOrDefault(a => a.KbId == objSchEventBE.RecordId);
                            if (objSourceBE != null)
                            {
                                var obj_TargetBE = new TblTrnKb();
                                PropertyCopier<TblTrnKb, TblTrnKb>.Copy(objSourceBE, obj_TargetBE);
                                obj_TargetBE.KbId = 0;
                                obj_TargetBE.IdNumber = null;
                                obj_TargetBE.IsDraft = false;
                                obj_TargetBE.CreatedOn = DateTime.UtcNow;
                                result = await CLS_v4API.Post_ApiRequest("WebKnowledge/CreateKB", obj_TargetBE);
                            }
                        }

                        #endregion

                        #region Get Ticket Information


                        string strNewIdNumber = "";
                        int? intNewTicketId = null;
                        if (result != null)
                        {
                            //dynamic okResult = result;
                            if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Incident)
                            {
                                var objResultBE = JsonConvert.DeserializeObject<TblTrnIncident>(result);
                                intNewTicketId = objResultBE.IncidentId;
                                strNewIdNumber = objResultBE.IdNumber;
                            }
                            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Request)
                            {
                                var objResultBE = JsonConvert.DeserializeObject<TblTrnServiceRequest>(result);
                                intNewTicketId = objResultBE.ServiceRequestId;
                                strNewIdNumber = objResultBE.IdNumber;

                            }
                            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Problem)
                            {
                                var objResultBE = JsonConvert.DeserializeObject<TblTrnProblem>(result);
                                intNewTicketId = objResultBE.ProblemId;
                                strNewIdNumber = objResultBE.IdNumber;
                            }
                            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Change)
                            {
                                var objResultBE = JsonConvert.DeserializeObject<TblTrnChange>(result);
                                intNewTicketId = objResultBE.ChangeId;
                                strNewIdNumber = objResultBE.IdNumber;
                            }
                            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Task)
                            {
                                var objResultBE = JsonConvert.DeserializeObject<TblTrnTask>(result);
                                intNewTicketId = objResultBE.TaskId;
                                strNewIdNumber = objResultBE.IdNumber;
                            }
                            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Kb)
                            {
                                var objResultBE = JsonConvert.DeserializeObject<TblTrnKb>(result);
                                intNewTicketId = objResultBE.KbId;
                                strNewIdNumber = objResultBE.IdNumber;
                            }
                        }

                        #endregion

                        #region Push Notification

                        var obj_MessageBE = new SignalR_MessageBE()
                        {
                            eventType = objSchEventBE.EventType,
                            moduleId = objSchEventBE.ModuleId,
                            ticketId = intNewTicketId,
                            additionalRefId = objSchEventBE.AdditionalRefId,
                            title = strNewIdNumber,
                            messageText = string.Format("New Ticket ID: {0} created by scheduler..", strNewIdNumber),
                        };
                        var int_CreatedBy = CLS_Global_Class.Get_Ticket_CreatedBy_Uid_From_TicketId((Enum_ModuleTypes)obj_RptSchBE.ModuleId, obj_RptSchBE.RecordId, db_Context);
                        CLS_SignalR_Connection.SendWebNotification(obj_MessageBE, db_Context, int_CreatedBy);

                        CLS_Global_Class.LogInformation(string.Format("New Ticket ID: {0} created by scheduler..", strNewIdNumber));

                        #endregion

                        Add_ScheduleEvent_Entry(obj_RptSchBE, objSchEventBE, false, db_Context);

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

        private static void Add_ScheduleEvent_Entry(TblCnfTicketSch objTicketBE, TblScheduleEvent objSchEventBE, bool IsNewSch, aditaas_v5Context db_Context)
        {
            var dt_Sch_Date = Get_Next_Schedule_Date(objTicketBE, IsNewSch);
            if (dt_Sch_Date != null)
            {
                var objScheduleBE = new TblScheduleEvent()
                {
                    AdditionalRefId = objTicketBE.TicketSchId,
                    ModuleId = objTicketBE.ModuleId,
                    RecordId = objTicketBE.RecordId,
                    CreatedOn = DateTime.UtcNow,
                    ScheduledOn = dt_Sch_Date,
                    Status = (int)Enum_Schedule_Event_Status.Pending,
                    EventType = (int)Enum_EventTypes.TicketSchedule,
                    ParentScheduleEventId = (objSchEventBE != null ? (int?)objSchEventBE.ScheduleEventId : null),
                };
                db_Context.TblScheduleEvent.Add(objScheduleBE);
                db_Context.SaveChanges();
            }
        }

        private static DateTime? Get_Next_Schedule_Date(TblCnfTicketSch obj_BE, bool IsNewSch)
        {
            DateTime? dt_Next_Date = null;
            var dt_Start_Date = DateTime.Today;
            if (obj_BE.StartFrom > DateTime.Today)
                dt_Start_Date = obj_BE.StartFrom.Value;

            if (obj_BE.ScheduleType == "Once")
            {
                if (obj_BE.StartFrom > DateTime.UtcNow)
                    dt_Next_Date = obj_BE.StartFrom;
            }
            else if (obj_BE.ScheduleType == "Daily")
            {
                if (obj_BE.StartFrom > DateTime.UtcNow && IsNewSch == true)
                    dt_Next_Date = obj_BE.StartFrom;
                else
                {
                    dt_Next_Date = DateTime.UtcNow.AddDays(1).Date;
                    dt_Next_Date = dt_Next_Date.Value.Add(obj_BE.StartFrom.Value.TimeOfDay);
                }
            }
            else if (obj_BE.ScheduleType == "Weekly" && CLS_Global_Class.Get_Str_Coll_From_CSV(obj_BE.SchDetail).Count > 0)
            {
                var int_Counter = (IsNewSch == true ? 0 : 1);
                for (int i = int_Counter; i < 10; i++)
                {
                    var dt = dt_Start_Date.AddDays(i);
                    if (dt > DateTime.Today && obj_BE.SchDetail.Split(",").Count(a => a.ToLower() == dt.ToString("dddd").ToLower()) > 0)
                    {
                        dt_Next_Date = dt;
                        if (obj_BE.StartFrom != null)
                            dt_Next_Date = dt_Next_Date.Value.Add(obj_BE.StartFrom.Value.TimeOfDay);
                        break;
                    }
                }
            }
            else if (obj_BE.ScheduleType == "Monthly" && CLS_Global_Class.Get_Str_Coll_From_CSV(obj_BE.SchDetail).Count > 0)
            {
                var int_Counter = (IsNewSch == true ? 0 : 1);
                for (int i = int_Counter; i < 12; i++)
                {
                    var dt = dt_Start_Date.AddMonths(i);
                    if (obj_BE.SchDetail.Split(",").Count(a => a.ToLower() == dt.ToString("MMMM").ToLower()) > 0)
                    {
                        dt_Next_Date = dt;
                        var days = obj_BE.StartFrom.Value.Day;
                        if (days > DateTime.DaysInMonth(dt_Next_Date.Value.Year, dt_Next_Date.Value.Month))
                            days = DateTime.DaysInMonth(dt_Next_Date.Value.Year, dt_Next_Date.Value.Month);
                        dt_Next_Date = DateTime.Parse(dt_Next_Date.Value.ToString("yyyy-MM-" + days.ToString()));
                        dt_Next_Date = dt_Next_Date.Value.Add(obj_BE.StartFrom.Value.TimeOfDay);
                        break;
                    }
                }
            }
            return dt_Next_Date;
        }




    }
}
