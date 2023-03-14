using aditaas_v5.Classes;
using aditaas_v5.Classes.Notification;
using aditaas_v5.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using aditaas_v5.Controllers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Newtonsoft.Json.Linq;
using aditaas_v5.Classes.Wrapper;
using MimeKit;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;
using MimeKit.Utils;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices.ComTypes;
using System.ServiceModel;
using Novell.Directory.Ldap;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Distributed;

namespace V5WinService.Classes
{
    public static class CLS_Global_Class
    {
        #region Application Veriable
        //static Dictionary<string, int?> ht_Ticket_Site_Mapper = new Dictionary<string, int?>();
        public static bool appIsDebug { get; set; }
        public static string apiUrl { get; set; }
        //public static string hubConnectionUrl { get; set; }
        public static string applicationUrl { get; set; }
        public static AntiForgeryToken apiToken { get; set; }
        public static string EmailSpliterTag { get; set; }
        public static int SLAIntervalMin { get; set; }
        public static EmailSettings emailSMSSettings { get; set; }
        public static ServiceProvider serviceProvider { get; set; }
        public static ILoggerFactory loggerFactory { get; set; }
        public static string[] hubConnectionUrls { get; set; }
        public static int ExportCheckIntervalMin { get; set; }
        public static string ExportBaseURL { get; set; }
        public static IDistributedCache DistributedCache { get; set; }

        private static DbContextOptionsBuilder<aditaas_v5Context> dbOptionsBuilder = null;        

        public static aditaas_v5Context Get_db_Context()
        {
            if (dbOptionsBuilder == null)
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
                dbOptionsBuilder = new DbContextOptionsBuilder<aditaas_v5Context>();
                dbOptionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
           
            var context = new aditaas_v5Context(dbOptionsBuilder.Options);
            context.ChangeTracker.CascadeDeleteTiming = Microsoft.EntityFrameworkCore.ChangeTracking.CascadeTiming.OnSaveChanges;
            context.ChangeTracker.DeleteOrphansTiming = Microsoft.EntityFrameworkCore.ChangeTracking.CascadeTiming.OnSaveChanges;

            return context;
        }

        #endregion

        #region Logger

        public static ILogger objLogger;
        public static void LogInformation(string message)
        {
            if (appIsDebug == true)
                Console.WriteLine(string.Format("{0} [Information] - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
            else
                objLogger.LogInformation(message);
        }

        public static void LogError(string message, Exception ex = null)
        {
            if (appIsDebug == true)
            {
                Console.WriteLine(string.Format("{0} [Error] - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
                if (ex != null)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine(ex.InnerException.ToString());
                    }
                }
            }
            else
            {
                objLogger.LogError(message);
                if (ex != null)
                {
                    objLogger.LogError(ex.Message);
                    if (ex.InnerException != null)
                        objLogger.LogError(ex.InnerException.ToString());
                }
            }
        }

        #endregion

        public static int Save_TblTrnUserNotification(int? userId, SignalR_MessageBE objMessageBE, aditaas_v5Context db_Context)
        {
            var obj_NotificationBE = new TblTrnUserNotification()
            {
                UserId = userId,
                EventType = objMessageBE.eventType,
                MessageText = objMessageBE.messageText,
                MessageHtml = objMessageBE.messageHTML,
                ModuleId = objMessageBE.moduleId,
                TicketId = objMessageBE.ticketId,
                AdditionalRefId = objMessageBE.additionalRefId,
                IsUnread = true,
                CreatedOn = objMessageBE.createdOn,
            };
            db_Context.TblTrnUserNotification.Add(obj_NotificationBE);
            db_Context.SaveChanges();
            return obj_NotificationBE.Uid;
        }

        public static string Get_IdNumber_From_RecordId(Enum_ModuleTypes moduleType, int? ticketId, aditaas_v5Context db_Context)
        {
            string ticketNo = null;

            if (moduleType == Enum_ModuleTypes.Incident)
                ticketNo = db_Context.TblTrnIncident.Where(a => a.IncidentId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                ticketNo = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                ticketNo = db_Context.TblTrnProblem.Where(a => a.ProblemId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                ticketNo = db_Context.TblTrnChange.Where(a => a.ChangeId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Kb)
                ticketNo = db_Context.TblTrnKb.Where(a => a.KbId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                ticketNo = db_Context.TblTrnTask.Where(a => a.TaskId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Approval)
                ticketNo = db_Context.TblTrnApproval.Where(a => a.ApproverId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Assets)
                ticketNo = db_Context.TblCmdbTrnCi.Where(a => a.CiId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Interaction)
                ticketNo = db_Context.TblTrnInteraction.Where(a => a.InteractionId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.FieldService)
                ticketNo = db_Context.TblTrnFieldService.Where(a => a.FieldServiceId== ticketId).Select(a => a.IdNumber).FirstOrDefault();
            return ticketNo;
        }

        public static int? Get_AssignGroupId_From_Id(Enum_ModuleTypes moduleType, int? ticketId, aditaas_v5Context db_Context)
        {
            int? UserGroupId = null;

            if (moduleType == Enum_ModuleTypes.Incident)
                UserGroupId = db_Context.TblTrnIncident.Where(a => a.IncidentId == ticketId).Select(a => a.CurrAssignQueueId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                UserGroupId = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == ticketId).Select(a => a.CurrAssignQueueId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                UserGroupId = db_Context.TblTrnProblem.Where(a => a.ProblemId == ticketId).Select(a => a.CurrAssignQueueId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                UserGroupId = db_Context.TblTrnChange.Where(a => a.ChangeId == ticketId).Select(a => a.CurrAssignQueueId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Kb)
                UserGroupId = db_Context.TblTrnKb.Where(a => a.KbId == ticketId).Select(a => a.AssignQueueId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                UserGroupId = db_Context.TblTrnTask.Where(a => a.TaskId == ticketId).Select(a => a.QueueId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Approval)
                UserGroupId = db_Context.TblTrnApproval.Where(a => a.ApproverId == ticketId).Select(a => a.ApprQueueId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Assets)
                UserGroupId = db_Context.TblCmdbTrnCi.Where(a => a.CiId == ticketId).Select(a => a.AssignQueueId).FirstOrDefault();
            return UserGroupId;
        }

        public static int? Get_Ticket_CreatedBy_Uid_From_TicketId(Enum_ModuleTypes moduleType, int? ticketId, aditaas_v5Context db_Context)
        {
            int? createdById = null;
            if (moduleType == Enum_ModuleTypes.Incident)
                createdById = db_Context.TblTrnIncident.Where(a => a.IncidentId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                createdById = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                createdById = db_Context.TblTrnProblem.Where(a => a.ProblemId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                createdById = db_Context.TblTrnChange.Where(a => a.ChangeId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Kb)
                createdById = db_Context.TblTrnKb.Where(a => a.KbId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                createdById = db_Context.TblTrnTask.Where(a => a.TaskId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Approval)
                createdById = db_Context.TblTrnApproval.Where(a => a.ApproverId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Assets)
                createdById = db_Context.TblCmdbTrnCi.Where(a => a.CiId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.FieldService)
                createdById = db_Context.TblTrnFieldService.Where(a => a.FieldServiceId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            return createdById;
        }

        public static IEnumerable<CLS_Notify_UserId_BE> Get_Ticket_UserIds_By_BusField(TblScheduleEvent objSchEventBE, int? busFieldId, TblTrnTicketLink obj_LinkBE, aditaas_v5Context db_Context, int? orgId)
        {
            var coll_UserId = new List<CLS_Notify_UserId_BE>();
            var obj_FieldBE = db_Context.TblCnfBusField.FirstOrDefault(a => a.BusFieldId == busFieldId);
            string str_User_Data = null;
            bool isPrimaryContact = false;
            str_User_Data = Get_Bus_Field_Data(objSchEventBE, busFieldId, obj_LinkBE, db_Context, out isPrimaryContact);
            if (string.IsNullOrWhiteSpace(str_User_Data) != true)
            {
                if (obj_FieldBE.FieldType == "User" || obj_FieldBE.FieldType == "AllOrgUser" || obj_FieldBE.FieldType == "Agent")
                    coll_UserId.Add(new CLS_Notify_UserId_BE() { UserId = int.Parse(str_User_Data), isPrimary = isPrimaryContact });
                else if (obj_FieldBE.FieldType == "User Group")
                {
                    coll_UserId.AddRange(GlobalClass.Get_UserIds_By_GroupId(db_Context, new int?[] { int.Parse(str_User_Data) }, orgId).Select(a => new CLS_Notify_UserId_BE()
                    {
                        UserId = a,
                        isPrimary = true
                    }));
                }
            }
            return coll_UserId.Distinct();
        }

        public static Dictionary<string, string> Get_Ticket_Field_Info(TblScheduleEvent objSchEventBE, string subjectText, string bodyText, TblTrnTicketLink obj_LinkBE, aditaas_v5Context db_Context)
        {
            if (bodyText == null) bodyText = "";
            var coll_Field_Data = new Dictionary<string, string>();
            int? int_moduleId1 = null;
            bool IsPrimaryContactTemp = false;

            if (objSchEventBE.EventType == (int)Enum_EventTypes.TicketApproval)
                int_moduleId1 = (int)Enum_ModuleTypes.Approval;
            if (objSchEventBE.ActionType == (int)Enum_ActionTypes.TicketAddNotes
                || objSchEventBE.ActionType == (int)Enum_ActionTypes.TicketAddNotes_Self
                || objSchEventBE.ActionType == (int)Enum_ActionTypes.TicketAddNotes_MailManager)
            {
                int_moduleId1 = (int)GlobalClass.Get_NotesModuleType(objSchEventBE.ModuleId);
            }
            var str_BusField_Names = "";
            foreach (var item in db_Context.TblCnfBusField.Where(a => a.ModuleId == objSchEventBE.ModuleId || a.ModuleId == int_moduleId1))
            {
                if (subjectText != null && subjectText.Contains("#" + item.Name + "#"))
                    str_BusField_Names += "," + item.Name;
                if (bodyText.Contains("#" + item.Name + "#"))
                    str_BusField_Names += "," + item.Name;
            }

            foreach (var item in str_BusField_Names.Split(',').Distinct().Where(a => a != ""))
            {
                var obj_FieldBE = db_Context.TblCnfBusField.FirstOrDefault(a => (a.ModuleId == objSchEventBE.ModuleId || a.ModuleId == int_moduleId1)
                                                                            && a.Name == item);
                if (obj_FieldBE != null)
                {
                    try
                    {
                        var str_FieldData = Get_Bus_Field_Data(objSchEventBE, obj_FieldBE.BusFieldId, obj_LinkBE, db_Context, out IsPrimaryContactTemp);
                        if (str_FieldData != null && str_FieldData != "" && obj_FieldBE.FieldType != null)
                        {
                            if (obj_FieldBE.FieldType == "User" || obj_FieldBE.FieldType == "AllOrgUser" || obj_FieldBE.FieldType == "Agent")
                                str_FieldData = Get_Master_User_Name_By_Id(int.Parse(str_FieldData), db_Context);
                            else if (obj_FieldBE.FieldType == "User Group")
                                str_FieldData = Get_Master_UserGroup_Name_By_Id(int.Parse(str_FieldData), db_Context);
                            else if (obj_FieldBE.FieldType == "Entity")
                                str_FieldData = Get_Master_Entity_Name_By_Id(int.Parse(str_FieldData), db_Context);
                            else if (obj_FieldBE.FieldType == "Org")
                                str_FieldData = Get_Master_Org_Name_By_Id(int.Parse(str_FieldData), db_Context);
                            else if (obj_FieldBE.FieldType == "Site")
                                str_FieldData = Get_Master_Site_Name_By_Id(int.Parse(str_FieldData), db_Context);
                            else if (obj_FieldBE.FieldType == "CI")
                                str_FieldData = Get_Master_CI_Name_By_Id(int.Parse(str_FieldData), db_Context);
                        }
                        coll_Field_Data.Add(item, str_FieldData);
                    }
                    catch (Exception ex)
                    {
                        string title = string.Format("Bus field error : moduleId: {0}, field Id:{1}, field Name:{2}", obj_FieldBE.ModuleId, obj_FieldBE.BusFieldId, obj_FieldBE.DbFieldName);
                        CLS_Global_Class.LogError(title, ex);
                    }
                }
            }
            if (bodyText.Contains("#view ticket#"))
            {
                coll_Field_Data.Add("view ticket", "<a  target='_blank' rel='noopener noreferrer' href='" + Get_ViewTicket_URL(objSchEventBE, db_Context) + "'>View Ticket</a>");
            }
            if (bodyText.Contains("#new survey link#"))
            {
                var surveyUrl = Get_New_SurveyLink_URL(objSchEventBE, db_Context); //.GetAwaiter().GetResult()
                if (surveyUrl != "")
                    coll_Field_Data.Add("new survey link", "<a  target='_blank' rel='noopener noreferrer' href='" + surveyUrl + "'>Survey Link</a>");
                else
                    coll_Field_Data = null;
            }
            if(coll_Field_Data != null)
            {
                if (bodyText.Contains("#survey link#"))
                {
                    var surveyUrl = Get_SurveyLink_URL(objSchEventBE, db_Context);
                    if (surveyUrl != "")
                        coll_Field_Data.Add("survey link", "<a  target='_blank' rel='noopener noreferrer' href='" + surveyUrl + "'>Survey Link</a>");
                }
            }
            return coll_Field_Data;
        }

        private static string Get_ViewTicket_URL(TblScheduleEvent objSchEventBE, aditaas_v5Context db_Context)
        {
            var int_ModuleId = objSchEventBE.ModuleId;
            string str_URL = applicationUrl;
            if (objSchEventBE.EventType == (int)Enum_EventTypes.TicketApproval)
                int_ModuleId = (int)Enum_ModuleTypes.Approval;

            if (int_ModuleId == (int)Enum_ModuleTypes.Incident)
                str_URL += "edit-incident/" + objSchEventBE.RecordId;
            else if (int_ModuleId == (int)Enum_ModuleTypes.Request)
                str_URL += "edit-request/" + objSchEventBE.RecordId;
            else if (int_ModuleId == (int)Enum_ModuleTypes.Change)
                str_URL += "edit-change/" + objSchEventBE.RecordId;
            else if (int_ModuleId == (int)Enum_ModuleTypes.Problem)
                str_URL += "edit-problem/" + objSchEventBE.RecordId;
            else if (int_ModuleId == (int)Enum_ModuleTypes.Task)
                str_URL += "edit-task/" + objSchEventBE.RecordId;
            else if (int_ModuleId == (int)Enum_ModuleTypes.Assets)
                str_URL += "edit-ci/" + objSchEventBE.RecordId;
            else if (int_ModuleId == (int)Enum_ModuleTypes.Approval)
            {
                var OrgId = GlobalClass.Get_TicketOrgId_From_Id((Enum_ModuleTypes)objSchEventBE.ModuleId, objSchEventBE.RecordId, db_Context);
                var TicketIdNumber = GlobalClass.Get_IdNumber_From_RecordId((Enum_ModuleTypes)objSchEventBE.ModuleId, objSchEventBE.RecordId, db_Context);
                str_URL += "edit-approval/" + objSchEventBE.AdditionalRefId + "/" + OrgId + "/" + TicketIdNumber;
            }
            return str_URL;
        }

        private static string Get_New_SurveyLink_URL(TblScheduleEvent objSchEventBE, aditaas_v5Context db_Context)
        {
            string str_URL = applicationUrl + "ticket-survey/";
            var controller = new TblTrnTicketSurveyController(db_Context, null, DistributedCache);
            var objSurveyBE = controller.Get_New_Ticket_Survey(objSchEventBE.ModuleId, objSchEventBE.RecordId);
            if (objSurveyBE != null)
            {
                str_URL += objSurveyBE.SurveyGuid + "?newtab=1";
                return str_URL;
            }
            else
                return "";
        }

        private static string Get_SurveyLink_URL(TblScheduleEvent objSchEventBE, aditaas_v5Context db_Context)
        {
            string str_URL = applicationUrl + "ticket-survey/";
            var controller = new TblTrnTicketSurveyController(db_Context, null, DistributedCache);
            var objSurveyBE = db_Context.TblTrnTicketSurvey.FirstOrDefault(a => a.ModuleId == objSchEventBE.ModuleId && a.RecordId == objSchEventBE.RecordId && a.SubmittedOn != null && a.IsOverride != true); //controller.Get_New_Ticket_Survey(objSchEventBE.ModuleId, objSchEventBE.RecordId);
            if (objSurveyBE != null)
            {
                str_URL += objSurveyBE.SurveyGuid + "?newtab=1";
                return str_URL;
            }
            else
                return "";
        }

        private static string Get_Bus_Field_Data(TblScheduleEvent objSchEventBE, int? busFieldId, TblTrnTicketLink obj_LinkBE, aditaas_v5Context db_Context, out bool IsContactPrimary)
        {
            string str_Result = null;
            IsContactPrimary = true;
            var obj_FieldBE = db_Context.TblCnfBusField.FirstOrDefault(a => a.BusFieldId == busFieldId);
            int? ticketId = null;
            if (obj_FieldBE.DbFieldName.StartsWith("link.") == true && obj_LinkBE != null && obj_LinkBE.TargetRecordId > 0)
            {
                obj_FieldBE = db_Context.TblCnfBusField.FirstOrDefault(a => a.Name == obj_FieldBE.Name.Replace("Link.", "") && a.ModuleId == obj_LinkBE.TargetModuleId);
                objSchEventBE = new TblScheduleEvent()
                {
                    RecordId = obj_LinkBE.TargetRecordId,
                    ModuleId = obj_LinkBE.TargetModuleId,
                    ActionType = objSchEventBE.ActionType,
                };
            }
            var moduleId = obj_FieldBE.ModuleId;
            if (obj_FieldBE != null)
            {
                if (moduleId == (int)Enum_ModuleTypes.Task && obj_FieldBE.DbFieldName.StartsWith("ticket.") == true)
                {
                    objSchEventBE = db_Context.TblTrnTask.Where(a => a.TaskId == objSchEventBE.RecordId && a.RecordId > 0).Select(a => new TblScheduleEvent
                    {
                        RecordId = a.RecordId,
                        ModuleId = a.ModuleId,
                        ActionType = objSchEventBE.ActionType,
                    }).FirstOrDefault();
                    if (objSchEventBE != null)
                    {
                        obj_FieldBE = db_Context.TblCnfBusField.FirstOrDefault(a => a.ModuleId == objSchEventBE.ModuleId && a.DbFieldName == obj_FieldBE.DbFieldName.Replace("ticket.", ""));
                        if (objSchEventBE != null && obj_FieldBE != null)
                            str_Result = Get_Bus_Field_Data(objSchEventBE, obj_FieldBE.BusFieldId, obj_LinkBE, db_Context, out IsContactPrimary);
                    }
                    return str_Result;
                }
                else if (moduleId == (int)Enum_ModuleTypes.FieldService && obj_FieldBE.DbFieldName.StartsWith("ticket.") == true)
                {
                    objSchEventBE = db_Context.TblTrnFieldService.Where(a => a.FieldServiceId == objSchEventBE.RecordId && a.RecordId > 0).Select(a => new TblScheduleEvent
                    {
                        RecordId = a.RecordId,
                        ModuleId = a.ModuleId,
                        ActionType = objSchEventBE.ActionType,
                    }).FirstOrDefault();
                    if (objSchEventBE != null)
                    {
                        obj_FieldBE = db_Context.TblCnfBusField.FirstOrDefault(a => a.ModuleId == objSchEventBE.ModuleId && a.DbFieldName == obj_FieldBE.DbFieldName.Replace("ticket.", ""));
                        if (objSchEventBE != null && obj_FieldBE != null)
                            str_Result = Get_Bus_Field_Data(objSchEventBE, obj_FieldBE.BusFieldId, obj_LinkBE, db_Context, out IsContactPrimary);
                    }
                    return str_Result;
                }
                else if (obj_FieldBE.DbFieldName.Contains(".") == true && (obj_FieldBE.FieldType == "User-SubField" || obj_FieldBE.FieldType == "User" || obj_FieldBE.FieldType == "AllOrgUser" || obj_FieldBE.FieldType == "Agent" || obj_FieldBE.FieldType == "Site"))
                {
                    var fieldName1 = obj_FieldBE.DbFieldName.Split(".")[0];
                    var fieldName2 = obj_FieldBE.DbFieldName.Split(".")[1];
                    var obj_FieldBE1 = db_Context.TblCnfBusField.FirstOrDefault(a => a.ModuleId == obj_FieldBE.ModuleId && a.DbFieldName == fieldName1);
                    str_Result = Get_Bus_Field_Data(objSchEventBE, obj_FieldBE1.BusFieldId, obj_LinkBE, db_Context, out IsContactPrimary);
                    if (str_Result != null && str_Result != "")
                        str_Result = GlobalClass.Get_UserMstFieldValue_By_UserId(db_Context, int.Parse(str_Result), fieldName2);
                    return str_Result;
                }
                else if ((moduleId == (int)Enum_ModuleTypes.Incident || moduleId == (int)Enum_ModuleTypes.Request
                        || moduleId == (int)Enum_ModuleTypes.Problem || moduleId == (int)Enum_ModuleTypes.Change
                        || moduleId == (int)Enum_ModuleTypes.Task || moduleId == (int)Enum_ModuleTypes.Kb || moduleId == (int)Enum_ModuleTypes.FieldService)
                        && obj_FieldBE.Name.StartsWith("Notes.") == false)
                {
                    ticketId = objSchEventBE.RecordId;
                }
                else
                {
                    if ((objSchEventBE.ActionType == (int)Enum_ActionTypes.TicketAddNotes
                        || objSchEventBE.ActionType == (int)Enum_ActionTypes.TicketAddNotes_Self
                        || objSchEventBE.ActionType == (int)Enum_ActionTypes.TicketAddNotes_MailManager))
                    {
                        if (obj_FieldBE.Name.StartsWith("Notes.") == true)
                        {
                            ticketId = objSchEventBE.AdditionalRefId;
                            if (moduleId == (int)Enum_ModuleTypes.Incident)
                                moduleId = (int)Enum_ModuleTypes.Incident_Notes;
                            else if (moduleId == (int)Enum_ModuleTypes.Request)
                                moduleId = (int)Enum_ModuleTypes.Request_Notes;
                            else if (moduleId == (int)Enum_ModuleTypes.Problem)
                                moduleId = (int)Enum_ModuleTypes.Problem_Notes;
                            else if (moduleId == (int)Enum_ModuleTypes.Change)
                                moduleId = (int)Enum_ModuleTypes.Change_Notes;
                            else if (moduleId == (int)Enum_ModuleTypes.Task)
                                moduleId = (int)Enum_ModuleTypes.Task_Notes;
                            else if (moduleId == (int)Enum_ModuleTypes.FieldService)
                                moduleId = (int)Enum_ModuleTypes.FieldService_Notes;
                            else if (moduleId == (int)Enum_ModuleTypes.Kb)
                                moduleId = (int)Enum_ModuleTypes.Kb_Notes;
                        }
                    }
                    else
                        ticketId = objSchEventBE.AdditionalRefId;
                }
                var obj_Module_BE = db_Context.TblMstModule.FirstOrDefault(a => a.ModuleId == moduleId);
                var str_Select_SQL = string.Format("select {0} from {1} where {2} = {3} AND {0} IS NOT NULL ", obj_FieldBE.DbFieldName, obj_Module_BE.MainTableName, obj_Module_BE.PkColumnName, ticketId);
                var dt_Data = GlobalClass.Get_dt_From_SQL(str_Select_SQL, db_Context);
                if (dt_Data.Rows.Count > 0)
                {
                    str_Result = dt_Data.Rows[0][0].ToString();
                    if (obj_FieldBE.DataType == "date" && str_Result != "")
                        str_Result = DateTime.Parse(str_Result).ToString("MM/dd/yyyy");
                    else if (obj_FieldBE.DataType == "datetime" && str_Result != "")
                        str_Result = string.Format("#Date({0})#", DateTime.Parse(str_Result).ToString("yyyy-MM-dd HH:mm"));
                }


                #region Contact Preferance (Primary/Secondary)

                if (obj_FieldBE.DbFieldName == "user_id" && (obj_Module_BE.ModuleId == (int)Enum_ModuleTypes.Incident || obj_Module_BE.ModuleId == (int)Enum_ModuleTypes.Problem))
                {
                    var str_Select_SQL1 = string.Format("select {0} from {1} where {2} = {3} AND {0} IS NOT NULL ", "preferred_contact", obj_Module_BE.MainTableName, obj_Module_BE.PkColumnName, ticketId);
                    var dt_Data1 = GlobalClass.Get_dt_From_SQL(str_Select_SQL1, db_Context);
                    if (dt_Data1.Rows.Count > 0 && dt_Data1.Rows[0][0].ToString().ToLower() == "secondary")
                    {
                        IsContactPrimary = false;
                    }
                }

                #endregion

            }
            return str_Result;
        }

        #region Get Master Name by Id


        private static string Get_Master_Org_Name_By_Id(int? orgId, aditaas_v5Context db_Context)
        {
            var str_Name = db_Context.TblMstOrg.Where(a => a.OrgId == orgId).Select(a => a.Name).FirstOrDefault();
            if (str_Name == null)
                str_Name = "";
            return str_Name;
        }


        private static string Get_Master_Site_Name_By_Id(int? siteId, aditaas_v5Context db_Context)
        {
            var str_Name = db_Context.TblMstSite.Where(a => a.SiteId == siteId).Select(a => a.Name).FirstOrDefault();
            if (str_Name == null)
                str_Name = "";
            return str_Name;
        }

        private static string Get_Master_CI_Name_By_Id(int? CIId, aditaas_v5Context db_Context)
        {
            var str_CiName = "";
            var obj_Data = db_Context.TblCmdbTrnCi.Where(a => a.CiId == CIId).Select(a => new { a.IdNumber, a.CiName }).FirstOrDefault();
            if (obj_Data != null)
                str_CiName = string.Format("{0} ({1})", obj_Data.CiName, obj_Data.IdNumber);
            return str_CiName;
        }

        private static string Get_Master_User_Name_By_Id(int? userId, aditaas_v5Context db_Context)
        {
            var str_Name = "";
            var obj_BE = db_Context.TblMstUser.Where(a => a.UserId == userId).Select(a => new { a.FirstName, a.LastName }).FirstOrDefault();
            if (obj_BE != null)
                str_Name = string.Format("{0} {1}", obj_BE.FirstName, obj_BE.LastName);
            return str_Name;
        }

        private static string Get_Master_UserGroup_Name_By_Id(int? userGroupId, aditaas_v5Context db_Context)
        {
            var str_Name = "";
            var obj_BE = db_Context.TblMstQueue.Where(a => a.QueueId == userGroupId).Select(a => new { a.Name }).FirstOrDefault();
            if (obj_BE != null)
                str_Name = obj_BE.Name;
            return str_Name;
        }

        public static List<int?> Get_User_Ids_By_Group_Id(int? userGroupId, aditaas_v5Context db_Context, int? orgId)
        {
            if (orgId != null)
            {
                var retlist = (from userQueueMap in db_Context.TblMstUserQueueMap
                               join useOrgMap in db_Context.TblMstUserOrgMap on userQueueMap.UserId equals useOrgMap.UserId
                               where useOrgMap.OrgId == orgId && userQueueMap.QueueId == userGroupId
                               select userQueueMap.UserId).ToList();

                return retlist;
            }
            else
            {
                return db_Context.TblMstUserQueueMap.Where(a => a.QueueId == userGroupId)
                                                    .Select(a => a.UserId)
                                                    .ToList();

            }
        }

        public static List<string> Get_UserEmail_By_UserId(IEnumerable<CLS_Notify_UserId_BE> coll_UserId, aditaas_v5Context db_Context)
        {
            //var coll_Email = (from user in db_Context.TblMstUser
            //                  join id in coll_UserId on user.UserId equals id.UserId
            //                  where user.EmailId != null
            //                  select ((id.isPrimary == true ? user.EmailId.ToLower() : user.SecondaryEmailId.ToLower()) ?? "").ToLower()).Distinct().ToList();

            var userIds = coll_UserId.Select(s => s.UserId);
            var coll_EmailA = (from user in db_Context.TblMstUser
                              where user.EmailId != null && userIds.Contains(user.UserId)
                              select new { UserId = user.UserId, EmailId = user.EmailId.ToLower(), SecondaryEmailId = user.SecondaryEmailId.ToLower() }).Distinct().AsEnumerable();

            var coll_Email = (from user in coll_EmailA
                              join id in coll_UserId on user.UserId equals id.UserId
                              where user.EmailId != null
                              select ((id.isPrimary == true ? user.EmailId.ToLower() : user.SecondaryEmailId.ToLower()) ?? "").ToLower()).Distinct().ToList();
            return coll_Email;
        }

        public static string Get_UserEmail_By_UserId(CLS_Notify_UserId_BE int_UserId, aditaas_v5Context db_Context)
        {
            var str_Email = (from user in db_Context.TblMstUser
                             where user.UserId == int_UserId.UserId && user.EmailId != null
                             select (int_UserId.isPrimary == true ? user.EmailId : user.SecondaryEmailId)).FirstOrDefault();
            return (str_Email != null ? str_Email.ToLower() : "");
        }

        public static List<string> Get_UserContactNo_By_UserId(IEnumerable<CLS_Notify_UserId_BE> coll_UserId, aditaas_v5Context db_Context)
        {
            //var coll_Email = (from user in db_Context.TblMstUser
            //                  join id in coll_UserId on user.UserId equals id.UserId
            //                  select ((id.isPrimary ? user.ContactNo : user.SecondaryContactNo) ?? "").ToLower()).Distinct().ToList();

            var userIds = coll_UserId.Select(s => s.UserId);
            var coll_EmailA = (from user in db_Context.TblMstUser
                               where user.EmailId != null && userIds.Contains(user.UserId)
                               select new { UserId = user.UserId, ContactNo = user.ContactNo, SecondaryContactNo = user.SecondaryContactNo }).Distinct().AsEnumerable();

            var coll_Email = (from user in coll_EmailA
                              join id in coll_UserId on user.UserId equals id.UserId
                              select ((id.isPrimary ? user.ContactNo : user.SecondaryContactNo) ?? "").ToLower()).Distinct().ToList();

            return coll_Email.Where(a => string.IsNullOrWhiteSpace(a) != true).ToList();
        }

        public static string Get_UserContactNo_By_UserId(CLS_Notify_UserId_BE int_UserId, aditaas_v5Context db_Context)
        {
            var str_MobileNo = (from user in db_Context.TblMstUser
                                where user.UserId == int_UserId.UserId && user.ContactNo != null
                                select (int_UserId.isPrimary ? user.ContactNo : user.SecondaryContactNo) ?? "").FirstOrDefault();
            return (str_MobileNo != null ? str_MobileNo : "");
        }

        private static string Get_Master_Entity_Name_By_Id(int? EntityAttrId, aditaas_v5Context db_Context)
        {
            var str_Name = "";
            var obj_BE = db_Context.TblMstEntityAttr.Where(a => a.EntityAttrId == EntityAttrId).Select(a => new { a.Name }).FirstOrDefault();
            if (obj_BE != null)
                str_Name = obj_BE.Name;
            return str_Name;
        }

        #endregion

        public static List<int?> Get_Coll_From_CSV(string str_CSV)
        {
            var Coll_Data = new List<int?>();
            if (str_CSV != null)
                foreach (var item in str_CSV.Split(','))
                {
                    if (item != "")
                        Coll_Data.Add(int.Parse(item));
                }
            return Coll_Data;
        }

        public static List<string> Get_Str_Coll_From_CSV(string str_CSV)
        {
            var Coll_Data = new List<string>();
            if (str_CSV != null)
                foreach (var item in str_CSV.Split(',').Distinct())
                {
                    if (item != "")
                        Coll_Data.Add(item);
                }
            return Coll_Data;
        }

        public static int? Convert_Object_Int(object o)
        {
            int? num = null;
            if (o != null && o.ToString() != null)
                num = int.Parse(o.ToString());
            return num;
        }


        public static string Get_DateText_By_TimeZone(string dateText, int? userId, aditaas_v5Context _context, int? siteId = 0)
        {
            var tzone = GlobalClass.Get_TimeZone_By_UserId_WinService(userId, _context);
            //if (userId == 0 && siteId > 0)
            //    GlobalClass.Get_TimeZone_By_SiteId(siteId, _context);
            dateText = dateText.Replace("#Date(", "").Replace(")#", "");
            var dt_UTC_Date = DateTime.ParseExact(dateText, "yyyy-MM-dd HH:mm", null);
            var tzTime = TimeZoneInfo.ConvertTimeFromUtc(dt_UTC_Date, tzone);
            var dateTimeFormat = GlobalClass.Get_UserDateTime_Format(userId, _context);
            return tzTime.ToString(dateTimeFormat);
        }

        public static string GetDateTextByOrgTimeZone(string dateText, int? userId, int orgId, aditaas_v5Context _context)
        {
            var tzone = GlobalClass.GetTimeZoneByOrgIdWinService(orgId, _context);
        
            dateText = dateText.Replace("#Date(", "").Replace(")#", "");
            var dt_UTC_Date = DateTime.ParseExact(dateText, "yyyy-MM-dd HH:mm", null);
            var tzTime = TimeZoneInfo.ConvertTimeFromUtc(dt_UTC_Date, tzone);
            var dateTimeFormat = GlobalClass.Get_UserDateTime_Format(userId, _context);
            return tzTime.ToString(dateTimeFormat);
        }

        public static string Get_BodyText_With_FieldData(Dictionary<string, string> coll_Field_Data, string str_Body, int? userId, aditaas_v5Context db_Context, int? siteId = 0, int orgId = 0)
        {
            foreach (var item in coll_Field_Data)
            {
                var str_Value = item.Value;
                if (str_Value != null && str_Value.StartsWith("#Date("))
                {
                    if(orgId > 0)
                    {
                        str_Value = CLS_Global_Class.GetDateTextByOrgTimeZone(str_Value, userId, orgId, db_Context);
                    }
                    else
                        str_Value = CLS_Global_Class.Get_DateText_By_TimeZone(str_Value, userId, db_Context, siteId);
                }
                   
                str_Body = str_Body.Replace("#" + item.Key + "#", str_Value);
            }
            return str_Body;
        }

        public static void Set_MailBody(BodyBuilder builder, string bodyHtml)
        {
            var coll_Image = FetchImgsFromSource(bodyHtml);
            foreach (var item in coll_Image)
            {
                var imageParts = item.Split(',');
                if (imageParts.Length > 1)
                {
                    var imageData = Convert.FromBase64String(imageParts[1]);
                    var contentId = MimeUtils.GenerateMessageId();

                    var image = (MimePart)builder.LinkedResources.Add(contentId + ".jpg", imageData);
                    image.ContentId = contentId;
                    image.IsAttachment = false;
                    bodyHtml = bodyHtml.Replace(item, "cid:" + contentId);
                }                    
            }
            builder.HtmlBody = bodyHtml;
        }

        private static List<string> FetchImgsFromSource(string htmlSource)
        {
            List<string> listOfImgdata = new List<string>();
            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
            MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match m in matchesImgSrc)
            {
                string href = m.Groups[1].Value;
                if (listOfImgdata.Contains(href) == false)
                    listOfImgdata.Add(href);
            }
            return listOfImgdata;
        }

        #region Update Ticket Field

        public static void Add_SendEmail_ActivityLog(int? moduleId, int? recordId, string eventName, string subject, IEnumerable<CLS_Notify_UserId_BE> coll_UserIds, string str_External_EmailId, string str_From_Email_Id, aditaas_v5Context db_Context)
        {
            if (string.IsNullOrEmpty(str_From_Email_Id) == false)
            {
                var coll_EmailIds = CLS_Global_Class.Get_UserEmail_By_UserId(coll_UserIds, db_Context);
                if (string.IsNullOrEmpty(str_External_EmailId) == false)
                    coll_EmailIds.Add(str_External_EmailId);
                Add_SendEmail_ActivityLog(moduleId, recordId, eventName, subject, coll_EmailIds, str_From_Email_Id, db_Context);
            }
        }


        public static void Add_SendEmailSMS_ActivityLog(int? moduleId, int? recordId, string eventName, string subject, List<CLS_Notify_UserId_BE> coll_UserIds, string str_From_Email_Id, aditaas_v5Context db_Context)
        {
            if (string.IsNullOrEmpty(str_From_Email_Id) == false)
            {
                var coll_EmailIds = CLS_Global_Class.Get_UserContactNo_By_UserId(coll_UserIds, db_Context);
                Add_SendEmail_ActivityLog(moduleId, recordId, eventName, subject, coll_EmailIds, str_From_Email_Id, db_Context, true);
            }
        }

        private static void Add_SendEmail_ActivityLog(int? moduleId, int? recordId, string eventName, string subject, List<string> coll_EmailIds, string str_From_Email_Id, aditaas_v5Context db_Context, bool isSMS = false)
        {
            db_Context = CLS_Global_Class.Get_db_Context();
            var sysUserName = CLS_Global_Class.Get_System_UserName(db_Context);
            string str_Title = "<strong><b><font color = 'brown'>" + (isSMS == false ? "#EmailSentOn#" : "SMS Sent On") + " </font></b><b>#SentOnTimeStamp#</b> #ByUser# = <b><font color='green'>" + sysUserName + "</font></b></strong>";
            string str_Description = "<strong><b>From :- </b></strong> " + str_From_Email_Id + "<br>"
                            + "<strong><b>To :- </b></strong>" + string.Join(", ", coll_EmailIds) + "<br>"
                            + "<strong><b>Subject :- </b></strong>" + subject + "<br>"
                            + "<strong><b>Event Name :- </b></strong>" + eventName;

            var strActionType = "Send Mail";
            if (moduleId == (int)Enum_ModuleTypes.Incident)
            {
                var tblActivityLogBE = new TblTrnIncActivityLog()
                {
                    ActionType = strActionType,
                    LogTitle = str_Title,
                    Description = str_Description,
                    DescriptionHtml = str_Description,
                    LogTime = DateTime.UtcNow,
                    RecordId = recordId,
                    PerformedById = GlobalClass.Get_UserId_System_Admin(db_Context)
                };
                db_Context.TblTrnIncActivityLog.Add(tblActivityLogBE);
            }
            else if (moduleId == (int)Enum_ModuleTypes.Request)
            {
                var tblActivityLogBE = new TblTrnSrActivityLog()
                {
                    ActionType = strActionType,
                    LogTitle = str_Title,
                    Description = str_Description,
                    DescriptionHtml = str_Description,
                    LogTime = DateTime.UtcNow,
                    RecordId = recordId,
                    PerformedById = GlobalClass.Get_UserId_System_Admin(db_Context)
                };
                db_Context.TblTrnSrActivityLog.Add(tblActivityLogBE);
            }
            else if (moduleId == (int)Enum_ModuleTypes.Change)
            {
                var tblActivityLogBE = new TblTrnCrActivityLog()
                {
                    ActionType = strActionType,
                    LogTitle = str_Title,
                    Description = str_Description,
                    DescriptionHtml = str_Description,
                    LogTime = DateTime.UtcNow,
                    RecordId = recordId,
                    PerformedById = GlobalClass.Get_UserId_System_Admin(db_Context)
                };
                db_Context.TblTrnCrActivityLog.Add(tblActivityLogBE);
            }
            else if (moduleId == (int)Enum_ModuleTypes.Problem)
            {
                var tblActivityLogBE = new TblTrnPrActivityLog()
                {
                    ActionType = strActionType,
                    LogTitle = str_Title,
                    Description = str_Description,
                    DescriptionHtml = str_Description,
                    LogTime = DateTime.UtcNow,
                    RecordId = recordId,
                    PerformedById = GlobalClass.Get_UserId_System_Admin(db_Context)
                };
                db_Context.TblTrnPrActivityLog.Add(tblActivityLogBE);
            }
            else if (moduleId == (int)Enum_ModuleTypes.Kb)
            {
                var tblActivityLogBE = new TblTrnKbActivityLog()
                {
                    ActionType = strActionType,
                    LogTitle = str_Title,
                    Description = str_Description,
                    DescriptionHtml = str_Description,
                    LogTime = DateTime.UtcNow,
                    RecordId = recordId,
                    PerformedById = GlobalClass.Get_UserId_System_Admin(db_Context)
                };
                db_Context.TblTrnKbActivityLog.Add(tblActivityLogBE);
            }
            else if (moduleId == (int)Enum_ModuleTypes.Task)
            {
                var tblActivityLogBE = new TblTrnTaskActivityLog()
                {
                    ActionType = strActionType,
                    LogTitle = str_Title,
                    Description = str_Description,
                    DescriptionHtml = str_Description,
                    LogTime = DateTime.UtcNow,
                    RecordId = recordId,
                    PerformedById = GlobalClass.Get_UserId_System_Admin(db_Context)
                };
                db_Context.TblTrnTaskActivityLog.Add(tblActivityLogBE);
            }
            else if (moduleId == (int)Enum_ModuleTypes.Assets)
            {
                var tblActivityLogBE = new TblCmdbTrnActivityLog()
                {
                    ActionType = strActionType,
                    LogTitle = str_Title,
                    Description = str_Description,
                    DescriptionHtml = str_Description,
                    LogTime = DateTime.UtcNow,
                    RecordId = recordId,
                    PerformedById = GlobalClass.Get_UserId_System_Admin(db_Context)
                };
                db_Context.TblCmdbTrnActivityLog.Add(tblActivityLogBE);
            }
            db_Context.SaveChanges();
        }

        public static async Task Set_Ticket_FieldValue(TblScheduleEvent objSchEventBE, string UpdateFieldJson, aditaas_v5Context db_Context)
        {
            if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Incident)
            {
                var obj_TicketBE = db_Context.TblTrnIncident.Where(a => a.IncidentId == objSchEventBE.RecordId).AsNoTracking().FirstOrDefault();
                if (obj_TicketBE != null)
                {
                    Set_JSONValue_To_TicketObj(UpdateFieldJson, obj_TicketBE, db_Context);
                    obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_Context);
                    var objinc = new WebIncidentController(db_Context, CLS_Global_Class.DistributedCache);
                    //var result = await objinc.UpdateIncident((int)objSchEventBE.RecordId, obj_TicketBE);
                    var result = await CLS_v4API.Put_ApiRequest(string.Format("WebIncident/UpdateIncident/{0}", objSchEventBE.RecordId), obj_TicketBE);
                }
                else
                {
                    throw new Exception("TblTrnIncident Record not found with Record Id : " + (objSchEventBE.RecordId == null ? 0 : objSchEventBE.RecordId).ToString());
                }
            }
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Request)
            {
                var obj_TicketBE = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == objSchEventBE.RecordId).AsNoTracking().FirstOrDefault();
                if (obj_TicketBE != null)
                {
                    Set_JSONValue_To_TicketObj(UpdateFieldJson, obj_TicketBE, db_Context);
                    obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_Context);
                    var result = await CLS_v4API.Put_ApiRequest(string.Format("WebRequest/UpdateRequest/{0}", objSchEventBE.RecordId), obj_TicketBE);
                }
                else
                {
                    throw new Exception("TblTrnServiceRequest Record not found with Record Id : " + (objSchEventBE.RecordId == null ? 0 : objSchEventBE.RecordId).ToString());
                }
            }
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Change)
            {
                var obj_TicketBE = db_Context.TblTrnChange.Where(a => a.ChangeId == objSchEventBE.RecordId).AsNoTracking().FirstOrDefault();
                if (obj_TicketBE != null)
                {
                    Set_JSONValue_To_TicketObj(UpdateFieldJson, obj_TicketBE, db_Context);
                    obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_Context);
                    var result = await CLS_v4API.Put_ApiRequest(string.Format("WebChange/UpdateChange/{0}", objSchEventBE.RecordId), obj_TicketBE);
                }
                else
                {
                    throw new Exception("TblTrnChange Record not found with Record Id : " + (objSchEventBE.RecordId == null ? 0 : objSchEventBE.RecordId).ToString());
                }
            }
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Problem)
            {
                var obj_TicketBE = db_Context.TblTrnProblem.Where(a => a.ProblemId == objSchEventBE.RecordId).AsNoTracking().FirstOrDefault();
                if (obj_TicketBE != null)
                {
                    Set_JSONValue_To_TicketObj(UpdateFieldJson, obj_TicketBE, db_Context);
                    obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_Context);
                    var result = await CLS_v4API.Put_ApiRequest(string.Format("WebProblem/UpdateProblem/{0}", objSchEventBE.RecordId), obj_TicketBE);
                }
                else
                {
                    throw new Exception("TblTrnProblem Record not found with Record Id : " + (objSchEventBE.RecordId == null ? 0 : objSchEventBE.RecordId).ToString());
                }
            }
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Kb)
            {
                var obj_TicketBE = db_Context.TblTrnKb.Where(a => a.KbId == objSchEventBE.RecordId).AsNoTracking().FirstOrDefault();
                if (obj_TicketBE != null)
                {
                    Set_JSONValue_To_TicketObj(UpdateFieldJson, obj_TicketBE, db_Context);
                    obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_Context);
                    var result = await CLS_v4API.Put_ApiRequest(string.Format("WebKnowledge/UpdateKb/{0}", objSchEventBE.RecordId), obj_TicketBE);
                }
                else
                {
                    throw new Exception("TblTrnKb Record not found with Record Id : " + (objSchEventBE.RecordId == null ? 0 : objSchEventBE.RecordId).ToString());
                }
            }
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Task)
            {

                var obj_TicketBE = db_Context.TblTrnTask.Where(a => a.TaskId == objSchEventBE.RecordId).AsNoTracking().FirstOrDefault();
                if (obj_TicketBE != null)
                {
                    Set_JSONValue_To_TicketObj(UpdateFieldJson, obj_TicketBE, db_Context);
                    obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_Context);
                    var result = await CLS_v4API.Put_ApiRequest(string.Format("WebTask/UpdateTask/{0}", objSchEventBE.RecordId), obj_TicketBE);
                }
                else
                {
                    throw new Exception("TblTrnTask Record not found with Record Id : " + (objSchEventBE.RecordId == null ? 0 : objSchEventBE.RecordId).ToString());
                }
            }
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Assets)
            {
                var obj_TicketBE = db_Context.TblCmdbTrnCi.Where(a => a.CiId == objSchEventBE.RecordId).AsNoTracking().FirstOrDefault();
                if (obj_TicketBE != null)
                {
                    var objBE = new CLS_Wrapper_tblCmdbTrnCi_BE();
                    objBE.objBE = obj_TicketBE;
                    objBE.collDet = db_Context.TblCmdbTrnCiDetail.Where(a => a.CiId == objSchEventBE.RecordId).AsNoTracking().ToList();
                    Set_JSONValue_To_TicketObj(UpdateFieldJson, obj_TicketBE, db_Context);
                    obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_Context);
                    var result = await CLS_v4API.Put_ApiRequest(string.Format("TblCmdbTrnCi/Insert_Update"), obj_TicketBE);
                }
                else
                {
                    throw new Exception("TblCmdbTrnCi Record not found with Record Id : " + (objSchEventBE.RecordId == null ? 0 : objSchEventBE.RecordId).ToString());
                }
            }
        }

        private static void Set_JSONValue_To_TicketObj(string json, object obj_TicketBE, aditaas_v5Context db_Context)
        {
            var objJArray = JArray.Parse(json);
            foreach (JToken jtoken in objJArray)
            {
                var int_fieldId = (int)jtoken["fieldId"];
                var str_PropName = Get_PropName_From_BusFieldId(int_fieldId, db_Context);
                var obj_Field_BE = db_Context.TblCnfBusField.FirstOrDefault(a => a.BusFieldId == int_fieldId);
                object obj_PropValue = null;
                if (obj_Field_BE.DataType == "number")
                    obj_PropValue = (int)jtoken["fieldValue"];
                else
                    obj_PropValue = (string)jtoken["fieldValue"];
                if (obj_PropValue != null && obj_PropValue.ToString().ToLower() == "#datetime.now#")
                    obj_PropValue = DateTime.UtcNow;
                GlobalClass.SetObjectProperty(str_PropName, obj_PropValue, obj_TicketBE);
            }
        }

        public static string Get_PropName_From_BusFieldId(int BusFieldId, aditaas_v5Context db_Context)
        {
            var str_dbFieldName = db_Context.TblCnfBusField.Where(a => a.BusFieldId == BusFieldId).Select(a => a.DbFieldName).FirstOrDefault();
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            string str_FieldName = str_dbFieldName.Replace("_", " ");
            str_FieldName = myTI.ToTitleCase(str_FieldName);
            return str_FieldName.Replace(" ", "");
        }

        public static string Get_System_UserName(aditaas_v5Context db_Context)
        {
            var systemUserId = GlobalClass.Get_UserId_System_Admin(db_Context);
            var userName = db_Context.TblMstUser.Where(a => a.UserId == systemUserId).Select(a => string.Format("{0} {1}", a.FirstName, a.LastName)).FirstOrDefault();
            if (userName == null)
                userName = "SYSTEM.ADMIN";
            return userName;
        }

        #endregion


        public static EmailSettings Get_EmailSetting_By_Org(int? orgId, aditaas_v5Context db_context)
        {
            var obj_New = new EmailSettings();
            var obj_MailSettingBE = db_context.TblCnfMailOutgoing.Where(a => a.OrgId == orgId && a.IsActive == true).FirstOrDefault();

            if (obj_MailSettingBE == null)
            {
                LogInformation("Sender email account is not configured for Org Id:- " + orgId);
                return null;
            }

            obj_New.MailServer = obj_MailSettingBE.MailServer;
            obj_New.MailPort = (int)obj_MailSettingBE.Port;
            obj_New.EnableSsl = (obj_MailSettingBE.IsSslEnable == true);
            obj_New.SenderName = obj_MailSettingBE.SenderName;
            obj_New.SenderMail = obj_MailSettingBE.SenderEmail;
            obj_New.UserName = obj_MailSettingBE.Username;
            obj_New.Password = obj_MailSettingBE.Password;
            obj_New.RequiresAuth = obj_MailSettingBE.RequiresAuth.GetValueOrDefault(false);
            obj_New.ExchangeUrl = obj_MailSettingBE.ExchangeUrl;
            obj_New.IsExchangeApi = obj_MailSettingBE.IsExchangeApi.GetValueOrDefault(false);
            return obj_New;
        }
        //binu start
        public static EmailSettings GetEmailSettingBySenderProfileId(int? uid, aditaas_v5Context db_context)
        {
            var obj_New = new EmailSettings();
            var obj_MailSettingBE = db_context.TblCnfMailOutgoing.Where(a => a.Uid == uid && a.IsActive == true).FirstOrDefault();

            if (obj_MailSettingBE == null)
            {
                LogInformation("Sender email account is not configured for uid:- " + uid);
                return null;
            }


            obj_New.MailServer = obj_MailSettingBE.MailServer;
            obj_New.MailPort = (int)obj_MailSettingBE.Port;
            obj_New.EnableSsl = (obj_MailSettingBE.IsSslEnable == true);
            obj_New.SenderName = obj_MailSettingBE.SenderName;
            obj_New.SenderMail = obj_MailSettingBE.SenderEmail;
            obj_New.UserName = obj_MailSettingBE.Username;
            obj_New.Password = obj_MailSettingBE.Password;
            obj_New.RequiresAuth = obj_MailSettingBE.RequiresAuth.GetValueOrDefault(false);
            return obj_New;
        }
    }

    public class CLS_Notify_UserId_BE
    {
        public int? UserId { get; set; }

        public bool isPrimary { get; set; }
    }

  
}
