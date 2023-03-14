using aditaas_v5.Classes;
using aditaas_v5.Controllers;
using aditaas_v5.Models;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Search;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MimeKit;
using Newtonsoft.Json;
using OfficeOpenXml.Drawing.Slicer.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Text.RegularExpressions;

using System.Threading.Tasks;
using System.Timers;
using V5WinService.Classes;

namespace V5WinService.BusinessLogic
{
    public static class CLS_Mail_Manager_Engine
    {
        static Dictionary<Timer, TblCnfEmailMgr> coll_Mail_Timer = new Dictionary<Timer, TblCnfEmailMgr>();
        static Dictionary<TblCnfEmailMgr, List<string>> coll_Pop3_Mail_Count = new Dictionary<TblCnfEmailMgr, List<string>>();
        private static System.Threading.CancellationToken cancellationToken;

        public static void Set_Scheduler_Event()
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                #region Cancel All Timer

                foreach (var item in coll_Mail_Timer)
                {
                    item.Value.IsActive = false;
                    item.Key.Stop();
                }
                coll_Mail_Timer.Clear();

                #endregion

                #region Start Timer

                foreach (var item in db_Context.TblCnfEmailMgr.Include(a => a.TblCnfEmailMgrRule).Include(a => a.TblCnfEmailMgrExtractField).Where(a => a.IsActive == true && a.IntervalMin > 0))
                {
                    var tmr = new Timer();
                    try
                    {
                        db_Context.Entry(item).State = EntityState.Detached;
                        tmr.Interval = (double)(1000 * 60 * item.IntervalMin);
                        tmr.Elapsed += mail_Tmr_Elapsed;
                        coll_Mail_Timer.Add(tmr, item);
                        tmr.Start();
                        mail_Tmr_Elapsed(tmr, null);
                    }
                    catch (Exception ex)
                    {
                        CLS_Global_Class.LogError(string.Format("**Email manager start error EmailMgrId : {0}, {1} ", item.EmailMgrId, item.Name), ex);
                        tmr.Stop();
                    }
                }

                #endregion

                CLS_Global_Class.LogInformation("Email Manager started..");
            }
        }

        private static void mail_Tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            var objTimer = (Timer)sender;
            objTimer.Stop();
            if (coll_Mail_Timer.ContainsKey(objTimer) == false)
                return;
            else
            {
                var objCnfMailMgrBE = coll_Mail_Timer[objTimer];

                #region Email Receive code

                if (objCnfMailMgrBE.Protocol == "pop3")
                {
                    _ = ReceiveMail_POP3(objCnfMailMgrBE, objTimer);
                }
                else if (objCnfMailMgrBE.Protocol == "imap")
                {
                    _ = ReceiveMail_IMAP(objCnfMailMgrBE, objTimer);
                }

                #endregion

            }
        }

        private static async Task ReceiveMail_POP3(TblCnfEmailMgr tblCnfEmailMgr, Timer objTimer)
        {
            try
            {
                using (var client = new Pop3Client())
                {
                    client.Timeout = 1000 * 60 * 2;
                    if (tblCnfEmailMgr.IsSsl == true)
                    {
                        //client.ServerCertificateValidationCallback = (mysender, certificate, chain, sslPolicyErrors) => { return true; };
                        client.ServerCertificateValidationCallback = GlobalClass.MySslCertificateValidationCallback;
                        client.CheckCertificateRevocation = false;
                        await client.ConnectAsync(tblCnfEmailMgr.MailServer, (int)tblCnfEmailMgr.Port, SecureSocketOptions.Auto);
                        //client.AuthenticationMechanisms.Remove("XOAUTH2");
                    }
                    else
                    {
                        await client.ConnectAsync(tblCnfEmailMgr.MailServer, (int)tblCnfEmailMgr.Port, SecureSocketOptions.None);
                    }
                    client.Authenticate(tblCnfEmailMgr.Username, tblCnfEmailMgr.Password);
                    var uids = client.GetMessageUids();
                    if (coll_Pop3_Mail_Count.ContainsKey(tblCnfEmailMgr) == false)
                        coll_Pop3_Mail_Count.Add(tblCnfEmailMgr, uids.ToList());
                    var coll_Old_Uid = coll_Pop3_Mail_Count[tblCnfEmailMgr];
                    for (int i = 0; i < uids.Count; i++)
                    {
                        if (coll_Old_Uid.Contains(uids[i]))
                            continue;
                        var message = client.GetMessage(i);
                        //if (message.To.Mailboxes.Count(a => a.Address.ToLower() == tblCnfEmailMgr.EmailId.ToLower()) > 0)
                        //{
                            try
                            {
                                await MailManager_Email_Process(message, tblCnfEmailMgr);
                            }
                            catch (Exception mex)
                            {
                                CLS_Global_Class.LogError("Error in MailManager_Email_Process function : ", mex);
                            }
                        //}
                    }
                    coll_Pop3_Mail_Count[tblCnfEmailMgr] = uids.ToList();
                    if (client.IsConnected)
                        client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("Email manager mail reading error " + tblCnfEmailMgr.Name + " : ", ex);
            }
            if (tblCnfEmailMgr.IsActive == true)
                objTimer.Start();
        }

        private static async Task ReceiveMail_IMAP(TblCnfEmailMgr tblCnfEmailMgr, Timer objTimer)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.Timeout = 1000 * 60 * 2;
                    if (tblCnfEmailMgr.IsSsl == true)
                    {
                        //client.ServerCertificateValidationCallback = (mysender, certificate, chain, sslPolicyErrors) => { return true; };
                        client.ServerCertificateValidationCallback = GlobalClass.MySslCertificateValidationCallback;
                        client.CheckCertificateRevocation = false;
                        await client.ConnectAsync(tblCnfEmailMgr.MailServer, (int)tblCnfEmailMgr.Port, SecureSocketOptions.SslOnConnect);
                    }
                    else
                    {
                        await client.ConnectAsync(tblCnfEmailMgr.MailServer, (int)tblCnfEmailMgr.Port, SecureSocketOptions.None);
                    }
                    if (tblCnfEmailMgr.ClientId == null) tblCnfEmailMgr.ClientId = "";

                    if(tblCnfEmailMgr.ClientId.Trim() != "")
                    {
                        var app = PublicClientApplicationBuilder.Create(tblCnfEmailMgr.ClientId).WithAuthority(AadAuthorityAudience.AzureAdMultipleOrgs).Build();
                        var scopes = new string[] { "https://outlook.office365.com/IMAP.AccessAsUser.All" };
                        var authToken = await app.AcquireTokenByUsernamePassword(scopes, tblCnfEmailMgr.Username, tblCnfEmailMgr.Password).ExecuteAsync(cancellationToken);
                        var oauth2 = new SaslMechanismOAuth2(tblCnfEmailMgr.Username, authToken.AccessToken);

                        await client.AuthenticateAsync(oauth2);
                    }
                    else
                    {
                        client.Authenticate(tblCnfEmailMgr.Username, tblCnfEmailMgr.Password);
                    }                  
                    var inbox = client.Inbox;
                    //var inbox = client.GetFolder("TestMail");
                    inbox.Open(FolderAccess.ReadWrite);

                    var uids = inbox.Search(SearchQuery.NotSeen);

                    inbox.AddFlags(uids, MessageFlags.Seen, true);
                    foreach (var item in uids)
                    {
                        var message = inbox.GetMessage(item);
                        //if (message.To.Mailboxes.Count(a => a.Address.ToLower() == tblCnfEmailMgr.EmailId.ToLower()) > 0)
                        //{
                        CLS_Global_Class.LogInformation("Email Manager :: Calling MailManager_Email_Process start");
                        try
                        {
                            await MailManager_Email_Process(message, tblCnfEmailMgr);
                            var destFolder = client.GetFolder("New");
                            client.Inbox.MoveTo(item, destFolder);
                        }
                        catch (Exception mex)
                        {
                            CLS_Global_Class.LogError("Error in MailManager_Email_Process function : ", mex);
                        }
                        CLS_Global_Class.LogInformation("Email Manager :: Calling MailManager_Email_Process end");
                        //}
                    }
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("Email manager mail reading error : ", ex);
            }
            if (tblCnfEmailMgr.IsActive == true)
                objTimer.Start();
        }

        private static async Task MailManager_Email_Process(MimeKit.MimeMessage message, TblCnfEmailMgr tblCnfEmailMgr)
        {
            var originalModuleId = tblCnfEmailMgr.ModuleId;
            using (var db_context = CLS_Global_Class.Get_db_Context())
            {
                var userId = tblCnfEmailMgr.DefaultUserId;
                foreach (var item in message.From.Mailboxes)
                {
                    //var mail_UserId = db_context.TblMstUser.Where(a => a.EmailId != null && a.EmailId.ToLower() == item.Address.ToLower()).Select(a => a.UserId).FirstOrDefault();
                    var mail_UserId = (from usr in db_context.TblMstUser
                                       join orgmap in db_context.TblMstUserOrgMap on usr.UserId equals orgmap.UserId
                                       where usr.EmailId.ToLower() == item.Address.ToLower() 
                                       && usr.IsActive == true
                                       && orgmap.OrgId == tblCnfEmailMgr.OrgId
                                       select usr.UserId).FirstOrDefault();

                    if (mail_UserId > 0)
                        userId = mail_UserId;
                }

                #region Ignore mail on Email Manager rule apply

                var str_MailBody_Text = message.HtmlBody;
                if (message.HtmlBody != null)
                {
                    if (message.HtmlBody.Contains("</style>") == true)
                        str_MailBody_Text = message.HtmlBody.Split("</style>")[1].ToLower();
                    else
                        str_MailBody_Text = message.HtmlBody.ToLower();
                    str_MailBody_Text = RemoveHtmlTag.StripTags(str_MailBody_Text);
                }
                else
                    str_MailBody_Text = "";

                var str_EmailText = ((message.Subject != null ? message.Subject : "") + " " + str_MailBody_Text).ToLower();

                var coll = new string[] { "Auto Reply", "Automatic Reply", "Out of the office", "Out of office", "Delivery has failed to these", "Undeliverable", "Delivery Status", "Leave" };
                foreach (var item in coll)
                {
                    var itemLower = item.ToLower();
                    if (str_EmailText.Contains(itemLower))
                        return;
                }

                if (tblCnfEmailMgr.IsApplyRule == true && tblCnfEmailMgr.TblCnfEmailMgrRule.Count > 0)
                {
                    var predicate = "";
                    var obj_Email_Detail_BE = new CLS_Email_Details_BE()
                    {
                        emailid = string.Join(",", message.From.Mailboxes.Select(a => a.Address)).ToLower(),
                        subject = (message.Subject != null ? message.Subject.ToLower() : ""),
                        body = str_MailBody_Text,
                    };

                    var collMail = new List<CLS_Email_Details_BE>() { obj_Email_Detail_BE };
                    foreach (var item in tblCnfEmailMgr.TblCnfEmailMgrRule)
                    {
                        if (string.IsNullOrWhiteSpace(item.AndOr) == false && string.IsNullOrWhiteSpace(predicate) == false)
                            predicate += (item.AndOr == "and" ? " && " : " || ");
                        if (string.IsNullOrWhiteSpace(item.StartBrackets) == false)
                            predicate += item.StartBrackets;

                        if (item.Operator == "starts with")
                            predicate += string.Format(" {0}.StartsWith(\"{1}\")== true ", item.Name, item.Value.ToLower());
                        else if (item.Operator == "ends with")
                            predicate += string.Format(" {0}.EndsWith(\"{1}\")== true ", item.Name, item.Value.ToLower());
                        else if (item.Operator == "does not contain")
                            predicate += string.Format(" {0}.Contains(\"{1}\") == false ", item.Name, item.Value.ToLower());
                        else if (item.Operator == "contain")
                            predicate += string.Format(" {0}.Contains(\"{1}\") == true ", item.Name, item.Value.ToLower());

                        if (string.IsNullOrWhiteSpace(item.EndBrackets) == false)
                            predicate += item.EndBrackets;
                    }
                    if (collMail.AsQueryable().Where(predicate).Count() == 0)
                    {
                        return;
                    }
                }

                #endregion

                #region Prepare HTML Body 

                var bodyHtml = message.HtmlBody;
                //bodyHtml = PopulateInlineImages(message, bodyHtml);
                if (bodyHtml != null)
                {
                    bodyHtml = PopulateInlineImages(message, bodyHtml);
                }
                else if (message.TextBody != null)
                {
                    bodyHtml = message.TextBody.Replace(@"\r\n", "<br >");
                }

                #region Set Default Subject Body Text

                if (bodyHtml == null || bodyHtml.Trim() == "")
                {
                    bodyHtml = string.Format("<div>{0}</div>", (message.Subject == null ? "" : message.Subject));
                }

                #region Remove Unwanted tags from Body

                if (bodyHtml != null)
                {
                    var exprComments = @"(?=<!--)([\s\S]*?)-->";
                    bodyHtml = Regex.Replace(bodyHtml, exprComments, "");
                }
                #endregion

                if (message.Subject == null || message.Subject == "")
                {
                    try
                    {
                        message.Subject = message.TextBody.Trim().Substring(0, 30);
                    }
                    catch (Exception exi)
                    {
                        message.Subject = "NO SUBJECT";
                        CLS_Global_Class.LogError(exi.Message);
                    }
                }

                #endregion

                #endregion

                #region Load Attachments

                var int_AttachedById = (userId == tblCnfEmailMgr.DefaultUserId ? GlobalClass.Get_UserId_System_Admin(db_context) : userId);
                var str_AttachedBy = db_context.TblMstUser.Where(a => a.UserId == int_AttachedById)
                                                          .Select(a => string.Format("{0} {1}", a.FirstName, a.LastName)).FirstOrDefault();

                var coll_Attachments = new List<AddAttachment>();

                if (message.HtmlBody == null && message.TextBody != null)
                {
                    try
                    {
                        GetAttachmentsFromPlainTextMail(message, coll_Attachments, tblCnfEmailMgr, int_AttachedById, str_AttachedBy);
                    }
                    catch(Exception plex)
                    {
                        CLS_Global_Class.LogError(plex.Message, plex);
                    }
                }

                foreach (MimeEntity item in message.Attachments)
                {
                    var fileName = item.ContentDisposition?.FileName ?? item.ContentType.Name;

                    try
                    {
                        if (fileName == null && item.ContentType.MediaType == "message")
                        {
                            fileName = ((MessagePart)item).Message.Subject.Substring(0, 10) + ".eml";
                        }
                    }
                    catch(Exception e)
                    {
                        CLS_Global_Class.LogError(e.Message, e);
                    }
                    
                    var stream = new MemoryStream();
                    if (item is MessagePart)
                    {
                        var rfc822 = (item as MessagePart);
                        rfc822.Message.WriteTo(stream);
                    }
                    else
                    {
                        var part = (MimePart)item;
                        part.Content.DecodeTo(stream);
                    }

                    var objAttachment = new AddAttachment()
                    {
                        ModuleId = tblCnfEmailMgr.ModuleId,
                        AttachedById = int_AttachedById,
                        AttachedByName = str_AttachedBy,
                        AttachedOn = DateTime.UtcNow,
                        FileName = fileName,
                        DisplayName = fileName,
                        BinaryData = stream.ToArray(),
                    };
                    coll_Attachments.Add(objAttachment);
                }

                #endregion

                int? recordId = null;

                #region Find Record id From Subject

                var str_Subject = message.Subject.ToUpper();
                string expr = "";
                if (tblCnfEmailMgr.ModuleId == (int)Enum_ModuleTypes.Request)
                    expr = @"([A-Z]{1})\-([0-9]{6})\-([0-9]{4})";
                else
                    expr = @"([A-Z]{2})\-([0-9]{6})\-([0-9]{4})";
                MatchCollection mc = Regex.Matches(str_Subject, expr);

                if (mc.Count() == 0)
                {
                    expr = @"([A-Z]{1})\-([0-9]{6})\-([0-9]{4})";
                    mc = Regex.Matches(str_Subject, expr);
                }
                Enum_ModuleTypes moduleId = 0;

                foreach (var match in mc)
                {
                    if (match.ToString().StartsWith("IN-"))
                        moduleId = Enum_ModuleTypes.Incident;
                    else if(match.ToString().StartsWith("R-"))
                        moduleId = Enum_ModuleTypes.Request;
                    else if (match.ToString().StartsWith("PR-"))
                        moduleId = Enum_ModuleTypes.Problem;
                    else if (match.ToString().StartsWith("AP-"))
                        moduleId = Enum_ModuleTypes.Approval;
                    else if (match.ToString().StartsWith("KB-"))
                        moduleId = Enum_ModuleTypes.Kb;
                    else if (match.ToString().StartsWith("T-"))
                        moduleId = Enum_ModuleTypes.Task;
                    else if (match.ToString().StartsWith("INT-"))
                        moduleId = Enum_ModuleTypes.Interaction;

                    tblCnfEmailMgr.ModuleId = (int)moduleId;

                    recordId = GlobalClass.Get_RecordId_From_IdNumber(moduleId, match.ToString(), db_context);
                    if (recordId > 0)
                    {
                        #region Reopen Closed/Resolve Tickets

                        var objStatusBE = GlobalClass.Get_RecordStatusBE_From_RecordId(moduleId, recordId, db_context);
                        if (objStatusBE != null)
                        {
                            if (objStatusBE.Name == "CLOSED")//To Created new tickets
                                recordId = null;
                            else if (objStatusBE.Name == "RESOLVED" || objStatusBE.Name == "FULFILLED" || objStatusBE.Name == "REJECTED") //To update status in progress
                            {
                                if (moduleId == Enum_ModuleTypes.Incident)
                                {
                                    var obj_TicketBE = db_context.TblTrnIncident.FirstOrDefault(a => a.IncidentId == recordId);
                                    db_context.Entry(obj_TicketBE).State = EntityState.Detached;
                                    if (obj_TicketBE != null)
                                    {
                                        var int_ProgressStatusId = GlobalClass.Get_EntityAttrId_From_Data(obj_TicketBE.OrgId, tblCnfEmailMgr.ModuleId, "COMMON_INCIDENT_STATUS", "PROGRESSING", db_context);
                                        if (int_ProgressStatusId > 0)
                                        {
                                            obj_TicketBE.StatusId = int_ProgressStatusId;
                                            obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_context);
                                            obj_TicketBE.IsFromEmailMgr = true;
                                            var result = await CLS_v4API.Put_ApiRequest(string.Format("WebIncident/UpdateIncident_MailManager/{0}", recordId), obj_TicketBE);
                                        }
                                    }
                                }
                                else if (moduleId == Enum_ModuleTypes.Request)
                                {
                                    var obj_TicketBE = db_context.TblTrnServiceRequest.FirstOrDefault(a => a.ServiceRequestId == recordId);
                                    db_context.Entry(obj_TicketBE).State = EntityState.Detached;
                                    if (obj_TicketBE != null)
                                    {
                                        var int_ProgressStatusId = GlobalClass.Get_EntityAttrId_From_Data(obj_TicketBE.OrgId, tblCnfEmailMgr.ModuleId, "COMMON_REQ_STATUS", "PROGRESSING", db_context);
                                        if (int_ProgressStatusId > 0)
                                        {
                                            obj_TicketBE.StatusId = int_ProgressStatusId;
                                            obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_context);
                                            obj_TicketBE.IsFromEmailMgr = true;
                                            var result = await CLS_v4API.Put_ApiRequest(string.Format("WebRequest/UpdateRequest_MailManager/{0}", recordId), obj_TicketBE);
                                        }
                                    }
                                }
                                else if (moduleId == Enum_ModuleTypes.Change)
                                {
                                    var obj_TicketBE = db_context.TblTrnChange.FirstOrDefault(a => a.ChangeId == recordId);
                                    db_context.Entry(obj_TicketBE).State = EntityState.Detached;
                                    if (obj_TicketBE != null)
                                    {
                                        var int_ProgressStatusId = GlobalClass.Get_EntityAttrId_From_Data(obj_TicketBE.OrgId, tblCnfEmailMgr.ModuleId, "COMMON_CHANGE_STATUS", "PROGRESSING", db_context);
                                        if (int_ProgressStatusId > 0)
                                        {
                                            obj_TicketBE.StatusId = int_ProgressStatusId;
                                            obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_context);
                                            obj_TicketBE.IsFromEmailMgr = true;
                                            var result = await CLS_v4API.Put_ApiRequest(string.Format("WebChange/UpdateChange_MailManager/{0}", recordId), obj_TicketBE);
                                        }
                                    }

                                }
                                else if (moduleId == Enum_ModuleTypes.Problem)
                                {
                                    var obj_TicketBE = db_context.TblTrnProblem.FirstOrDefault(a => a.ProblemId == recordId);
                                    db_context.Entry(obj_TicketBE).State = EntityState.Detached;
                                    if (obj_TicketBE != null)
                                    {
                                        var int_ProgressStatusId = GlobalClass.Get_EntityAttrId_From_Data(obj_TicketBE.OrgId, tblCnfEmailMgr.ModuleId, "COMMON_PROB_STATUS", "PROGRESSING", db_context);
                                        if (int_ProgressStatusId > 0)
                                        {
                                            obj_TicketBE.StatusId = int_ProgressStatusId;
                                            obj_TicketBE.ModifiedById = GlobalClass.Get_UserId_System_Admin(db_context);
                                            obj_TicketBE.IsFromEmailMgr = true;
                                            var result = await CLS_v4API.Put_ApiRequest(string.Format("WebProblem/UpdateProblem_MailManager/{0}", recordId), obj_TicketBE);
                                        }
                                    }
                                }
                            }
                        }
                        break;

                        #endregion
                    }
                }

                #endregion

                #region Email Header body 

                string str_emailHeader = "";// "<style>p{margin-top:0;margin-bottom: 0rem;}</style>";
                str_emailHeader += string.Format("<div><b>From:</b> {0}</div>", Get_MailBoxAddressCSV(message.From.Mailboxes));
                str_emailHeader += string.Format("<div><b>To:</b> {0}</div>", Get_MailBoxAddressCSV(message.To.Mailboxes));
                //added by ankur for Interaction Module, need to save Toemail id for Email Receipient column
                string email_receipient = Get_MailBoxAddressCSV(message.To.Mailboxes);

                if (message.Cc.Count > 0)
                    str_emailHeader += string.Format("<div><b>Cc:</b> {0}</div>", Get_MailBoxAddressCSV(message.Cc.Mailboxes));

                var str_SentDate = "";
                try
                {
                    str_SentDate = CLS_Global_Class.Get_DateText_By_TimeZone(message.Date.UtcDateTime.ToString("yyyy-MM-dd HH:mm"), userId, db_context);
                }
                catch
                {
                    str_SentDate = message.Date.ToString("MM/dd/yyyy hh:mm tt");
                }
                str_emailHeader += string.Format("<div><b>Sent:</b> {0}</div>", str_SentDate);
                str_emailHeader += string.Format("<div><b>Subject:</b> {0}</div>", message.Subject);
                str_emailHeader += string.Format("<div><b>Description</b> </div>");

                #endregion

                if (recordId > 0) // Notes Log entry
                {
                    //var adata = message.BodyParts.ToArray();

                    #region Get latest mailtail

                    var coll_String_Split = CLS_Global_Class.EmailSpliterTag.Split(" , ");
                    foreach (var item in coll_String_Split)
                    {
                        if (bodyHtml.Contains(item))
                        {
                            bodyHtml = bodyHtml.Split(item)[0];
                            break;
                        }
                    }

                    #endregion

                    bodyHtml = str_emailHeader + bodyHtml;

                    var int_NotesAddedById = (userId == tblCnfEmailMgr.DefaultUserId ? GlobalClass.Get_UserId_System_Admin(db_context) : userId);
                    if (moduleId == Enum_ModuleTypes.Approval)
                    {
                        var tblTrnApproval = db_context.TblTrnApproval.Where(w => w.ApprovalId == recordId).FirstOrDefault();
                        int? statusId = tblTrnApproval.StatusId;
                        if (tblTrnApproval != null)
                        {
                            if ((db_context.TblMstUserQueueMap.Count(a => a.QueueId == tblTrnApproval.ApprQueueId && a.UserId == userId) > 0) || userId == tblTrnApproval.ApproverId)
                            {
                                if ((bool)tblTrnApproval.IsActive)
                                {
                                    var statObj = await db_context.TblMstEntityAttr.FindAsync(tblTrnApproval.StatusId);
                                    if (statObj.Name.ToUpper() == "OPEN")
                                    {
                                        if (bodyHtml.ToLower().Contains("approve") || bodyHtml.ToLower().Contains("approved"))
                                        {
                                            statusId = (from enta in db_context.TblMstEntityAttr
                                                        join modmap in db_context.TblMstEntityModuleMap on enta.EntityId equals modmap.EntityId
                                                        join ent in db_context.TblMstEntity on enta.EntityId equals ent.EntityId
                                                        where enta.OrgId == tblCnfEmailMgr.OrgId && modmap.ModuleId == (int)moduleId && ent.Name.ToUpper().Equals("APPROVAL_STATUS")
                                                        && enta.Name == "APPROVED"
                                                        select enta.EntityAttrId).FirstOrDefault();
                                        }
                                        else if (bodyHtml.ToLower().Contains("reject") || bodyHtml.ToLower().Contains("rejected"))
                                        {
                                            statusId = (from enta in db_context.TblMstEntityAttr
                                                        join modmap in db_context.TblMstEntityModuleMap on enta.EntityId equals modmap.EntityId
                                                        join ent in db_context.TblMstEntity on enta.EntityId equals ent.EntityId
                                                        where enta.OrgId == tblCnfEmailMgr.OrgId && modmap.ModuleId == (int)moduleId && ent.Name.ToUpper().Equals("APPROVAL_STATUS")
                                                        && enta.Name == "REJECTED"
                                                        select enta.EntityAttrId).FirstOrDefault();
                                        }
                                        tblTrnApproval.ModifiedById = userId;
                                        tblTrnApproval.ApprComment = bodyHtml;
                                        tblTrnApproval.AuthorizedById = userId;
                                        tblTrnApproval.StatusId = statusId;

                                        //tblTrnApproval.ModuleId == 2 // Request Module Id
                                        //tblTrnApproval.RecordId = Request Id

                                        await CLS_v4API.Put_ApiRequest(string.Format("TblTrnApprovals/UpdateApproval/{0}", recordId), tblTrnApproval);
                                        CLS_Global_Class.LogInformation(String.Format("Email Manager :: Approval updated, Record Id: {0}", recordId));

                                        //Auto Update Request status after approve approval --Himalay
                                        if (tblTrnApproval.ModuleId == 2 && (bodyHtml.ToLower().Contains("approve") || bodyHtml.ToLower().Contains("approved")))
                                        {
                                            var tblTrnReq= db_context.TblTrnServiceRequest.Where(a=>a.ServiceRequestId==tblTrnApproval.RecordId ).FirstOrDefault();
                                            tblTrnReq.StatusId = GlobalClass.Get_EntityAttrId_From_Data(tblTrnReq.OrgId, tblTrnApproval.ModuleId, "COMMON_REQ_STATUS","APPROVED", db_context);
                                           
                                            await CLS_v4API.Put_ApiRequest(string.Format("WebRequest/UpdateRequest/{0}", tblTrnReq.ServiceRequestId), tblTrnReq);
                                            CLS_Global_Class.LogInformation(String.Format("Email Manager :: Request updated, Record Id: {0}", recordId));

                                        }else if (tblTrnApproval.ModuleId == 2 && (bodyHtml.ToLower().Contains("reject") || bodyHtml.ToLower().Contains("rejected")))
                                        {
                                            var tblTrnReq = db_context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == tblTrnApproval.RecordId).FirstOrDefault();
                                            tblTrnReq.StatusId = GlobalClass.Get_EntityAttrId_From_Data(tblTrnReq.OrgId, tblTrnApproval.ModuleId, "COMMON_REQ_STATUS", "REJECTED", db_context);

                                            await CLS_v4API.Put_ApiRequest(string.Format("WebRequest/UpdateRequest/{0}", tblTrnReq.ServiceRequestId), tblTrnReq);
                                            CLS_Global_Class.LogInformation(String.Format("Email Manager :: Request updated, Record Id: {0}", recordId));

                                        }
                                    }
                                    else
                                    {
                                        CLS_Global_Class.LogInformation(String.Format("Email Manager :: Approval already closed, Record Id: {0}", tblTrnApproval.IdNumber));
                                    }

                                }
                                else
                                {
                                    CLS_Global_Class.LogInformation(String.Format("Email Manager :: Approval is not active, Record Id: {0}", tblTrnApproval.IdNumber));
                                }                                
                            }
                            else
                            {
                                CLS_Global_Class.LogInformation(String.Format("Email Manager :: User do not have access to approval group, Record Id: {0}", tblTrnApproval.IdNumber));
                            }


                        }
                    }
                    else
                    {
                    var result = await Ticket_Add_Notes_Entry(message, bodyHtml, int_NotesAddedById, recordId, tblCnfEmailMgr, db_context, moduleId);
                    if (result == true)
                    {
                        CLS_Global_Class.LogInformation(String.Format("Email Manager :: Ticket Notes log added with Module Id: {0}, Record Id: {1}", tblCnfEmailMgr.ModuleId, recordId));
                    }
                }
                }
                else // New Ticket Entry
                {
                    tblCnfEmailMgr.ModuleId = originalModuleId;

                    bodyHtml = str_emailHeader + bodyHtml;

                    #region Generate Tickets

                    if (tblCnfEmailMgr.ModuleId == (int)Enum_ModuleTypes.Incident)
                    {
                        recordId = await Generate_Ticket_Incident(message, bodyHtml, userId, tblCnfEmailMgr, db_context);
                    }
                    else if (tblCnfEmailMgr.ModuleId == (int)Enum_ModuleTypes.Request)
                    {
                        recordId = await Generate_Ticket_Request(message, bodyHtml, userId, tblCnfEmailMgr, db_context);
                    }
                    else if (tblCnfEmailMgr.ModuleId == (int)Enum_ModuleTypes.Change)
                    {
                        recordId = await Generate_Ticket_Change(message, bodyHtml, userId, tblCnfEmailMgr, db_context);
                    }
                    else if (tblCnfEmailMgr.ModuleId == (int)Enum_ModuleTypes.Problem)
                    {
                        recordId = await Generate_Ticket_Problem(message, bodyHtml, userId, tblCnfEmailMgr, db_context);
                    }
                    else if (tblCnfEmailMgr.ModuleId == (int)Enum_ModuleTypes.Task)
                    {
                        recordId = await Generate_Ticket_Task(message, bodyHtml, userId, tblCnfEmailMgr, db_context);
                    }
                    else if (tblCnfEmailMgr.ModuleId == (int)Enum_ModuleTypes.Interaction)
                    {
                        recordId = await Generate_Ticket_Interaction(message, bodyHtml, userId, tblCnfEmailMgr, email_receipient, db_context);
                    }
                    #endregion
                }

                #region Upload attachment process
                if ((int)moduleId > 0)
                {

                }
                else
                {
                    //moduleId = (Enum_ModuleTypes)tblCnfEmailMgr.ModuleId;
                    moduleId = (Enum_ModuleTypes)originalModuleId;
                }
                var idNumber = CLS_Global_Class.Get_IdNumber_From_RecordId((Enum_ModuleTypes)moduleId, recordId, db_context);
                foreach (var item in coll_Attachments)
                {
                    item.RecordIdArr = new string[] { idNumber };
                    item.ModuleId = (int)moduleId;
                    var cntrAttachment = new WebGenAddAttachmentController(db_context, CLS_Global_Class.DistributedCache);
                    await cntrAttachment.GenInsertAttachmentRec(item);
                }

                #endregion
            }
            tblCnfEmailMgr.ModuleId = originalModuleId;
        }
        //private static async Task<bool> InstallApprovedSoftwareUsingIntune()
        //{

        //}
        private static async Task<int> Generate_Ticket_Incident(MimeKit.MimeMessage message, string email_bodyHTML, int? userId, TblCnfEmailMgr tblCnfEmailMgr, aditaas_v5Context db_context)
        {
            var objUserContactBE = db_context.TblMstUser.Where(a => a.UserId == userId).Select(a => new
            {
                a.ContactNo,
                a.SiteId,
            }).FirstOrDefault();
            var objIncidentBE = new TblTrnIncident()
            {
                OrgId = tblCnfEmailMgr.OrgId,
                UserId = userId,
                ContactNo = objUserContactBE.ContactNo,
                LocationId = objUserContactBE.SiteId,
                CurrAssignQueueId = tblCnfEmailMgr.DefaultQueueId,
                FirstAssignQueueId = tblCnfEmailMgr.DefaultQueueId,
                ShortDesc = message.Subject,
                AdditionalComments = email_bodyHTML,
                PriorityId = tblCnfEmailMgr.DefaultPriorityId,
                CategoryId = tblCnfEmailMgr.DefaultCategoryId,
                SubCategoryId = tblCnfEmailMgr.DefaultSubCategoryId,
                ItemId = tblCnfEmailMgr.DefaultItemId,
                CreatedOn = DateTime.UtcNow,
                IsFromEmailMgr = true,
            };

            if (objIncidentBE.PriorityId == null)
                objIncidentBE.PriorityId = GlobalClass.Get_EntityAttrId_From_Data(objIncidentBE.OrgId, (int)Enum_ModuleTypes.Incident, "COMMON_PRIORITY", GlobalClass.GetConfigItem(db_context, "P4_EQ_PRIORITY_VAL", objIncidentBE.OrgId).Value, db_context);
            var objPriorityMatrixBE = db_context.TblCnfPriorityMatrix.FirstOrDefault(a => a.ModuleId == tblCnfEmailMgr.ModuleId && a.OrgId == tblCnfEmailMgr.OrgId && a.PriorityId == objIncidentBE.PriorityId);
            if (objPriorityMatrixBE != null)
            {

                objIncidentBE.SeverityEntId = objPriorityMatrixBE.SeverityId;
                objIncidentBE.SeverityEntId = objPriorityMatrixBE.ImpactId;
            }
            //var ImpactText = Get_ImpactText_By_Priority(objIncidentBE.PriorityId, db_context);
            objIncidentBE.SeverityEntId = GlobalClass.Get_EntityAttrId_From_Data(objIncidentBE.OrgId, (int)Enum_ModuleTypes.Incident, "COMMON_INCIDENT_SEVERITY", GlobalClass.GetConfigItem(db_context, "INC_EMAILMGR_URGENCY", objIncidentBE.OrgId).Value, db_context);
            objIncidentBE.CommonImpactEntId = GlobalClass.Get_EntityAttrId_From_Data(objIncidentBE.OrgId, (int)Enum_ModuleTypes.Incident, "COMMON_IMPACT", GlobalClass.GetConfigItem(db_context, "INC_EMAILMGR_IMPACT", objIncidentBE.OrgId).Value, db_context);
            objIncidentBE.ChannelEntId = GlobalClass.Get_EntityAttrId_From_Data(objIncidentBE.OrgId, (int)Enum_ModuleTypes.Incident, "COMMON_INCIDENT_CHANNEL", GlobalClass.GetConfigItem(db_context, "INC_EMAILMGR_CHANNEL", objIncidentBE.OrgId).Value, db_context);
            objIncidentBE.StatusId = GlobalClass.Get_EntityAttrId_From_Data(objIncidentBE.OrgId, (int)Enum_ModuleTypes.Incident, "COMMON_INCIDENT_STATUS", GlobalClass.GetConfigItem(db_context, "INC_EMAILMGR_STATUS", objIncidentBE.OrgId).Value, db_context);
            objIncidentBE.CreatedById = GlobalClass.Get_UserId_System_Admin(db_context);
            Set_Extract_Field_Value_From_Body(message, email_bodyHTML, tblCnfEmailMgr, Enum_ModuleTypes.Incident, objIncidentBE, db_context);

            var result = await CLS_v4API.Post_ApiRequest("WebIncident/CreateIncident", objIncidentBE);
            var objResultBE = JsonConvert.DeserializeObject<TblTrnIncident>(result);
            CLS_Global_Class.LogInformation(String.Format("Email Manager :: Ticket created with ID: {0}", objResultBE.IdNumber));
            return objResultBE.IncidentId;
        }

        private static async Task<int> Generate_Ticket_Request(MimeKit.MimeMessage message, string email_bodyHTML, int? userId, TblCnfEmailMgr tblCnfEmailMgr, aditaas_v5Context db_context)
        {
            var objUserContactBE = db_context.TblMstUser.Where(a => a.UserId == userId).Select(a => new
            {
                a.ContactNo,
                a.SiteId,
            }).FirstOrDefault();
            var objReqestBE = new TblTrnServiceRequest()
            {
                OrgId = tblCnfEmailMgr.OrgId,
                UserId = userId,
                ContactNo = objUserContactBE.ContactNo,
                LocationId = objUserContactBE.SiteId,
                CurrAssignQueueId = tblCnfEmailMgr.DefaultQueueId,
                FirstAssignQueueId = tblCnfEmailMgr.DefaultQueueId,
                ShortDescription = message.Subject,
                AdditionalComments = email_bodyHTML,
                PriorityId = tblCnfEmailMgr.DefaultPriorityId,
                CategoryId = tblCnfEmailMgr.DefaultCategoryId,
                SubCategoryId = tblCnfEmailMgr.DefaultSubCategoryId,
                ItemId = tblCnfEmailMgr.DefaultItemId,
                CreatedOn = DateTime.UtcNow,
                IsFromEmailMgr = true,
            };

            if (objReqestBE.PriorityId == null)
                objReqestBE.PriorityId = GlobalClass.Get_EntityAttrId_From_Data(objReqestBE.OrgId, (int)Enum_ModuleTypes.Request, "COMMON_PRIORITY", GlobalClass.GetConfigItem(db_context, "P4_EQ_PRIORITY_VAL", objReqestBE.OrgId).Value, db_context);
            //var ImpactText = Get_ImpactText_By_Priority(objReqestBE.PriorityId, db_context);
            objReqestBE.SeverityEntId = GlobalClass.Get_EntityAttrId_From_Data(objReqestBE.OrgId, (int)Enum_ModuleTypes.Request, "COMMON_INCIDENT_SEVERITY", GlobalClass.GetConfigItem(db_context, "REQ_EMAILMGR_URGENCY", objReqestBE.OrgId).Value, db_context);
            objReqestBE.CommonImpactEntId = GlobalClass.Get_EntityAttrId_From_Data(objReqestBE.OrgId, (int)Enum_ModuleTypes.Request, "COMMON_IMPACT", GlobalClass.GetConfigItem(db_context, "REQ_EMAILMGR_IMPACT", objReqestBE.OrgId).Value, db_context);
            objReqestBE.ChannelEntId = GlobalClass.Get_EntityAttrId_From_Data(objReqestBE.OrgId, (int)Enum_ModuleTypes.Request, "COMMON_INCIDENT_CHANNEL", GlobalClass.GetConfigItem(db_context, "REQ_EMAILMGR_CHANNEL", objReqestBE.OrgId).Value, db_context);
            objReqestBE.StatusId = GlobalClass.Get_EntityAttrId_From_Data(objReqestBE.OrgId, (int)Enum_ModuleTypes.Request, "COMMON_REQ_STATUS", GlobalClass.GetConfigItem(db_context, "REQ_EMAILMGR_STATUS", objReqestBE.OrgId).Value, db_context);
            objReqestBE.CreatedById = GlobalClass.Get_UserId_System_Admin(db_context);
            Set_Extract_Field_Value_From_Body(message, email_bodyHTML, tblCnfEmailMgr, Enum_ModuleTypes.Request, objReqestBE, db_context);

            var result = await CLS_v4API.Post_ApiRequest("WebRequest/CreateRequest", objReqestBE);
            var objResultBE = JsonConvert.DeserializeObject<TblTrnIncident>(result);
            CLS_Global_Class.LogInformation(String.Format("Email Manager :: Ticket created with ID: {0}", objResultBE.IdNumber));
            return objResultBE.IncidentId;
        }

        private static async Task<int> Generate_Ticket_Change(MimeKit.MimeMessage message, string email_bodyHTML, int? userId, TblCnfEmailMgr tblCnfEmailMgr, aditaas_v5Context db_context)
        {
            var objUserContactBE = db_context.TblMstUser.Where(a => a.UserId == userId).Select(a => new
            {
                a.ContactNo,
                a.SiteId,
            }).FirstOrDefault();
            var objChangeBE = new TblTrnChange()
            {
                OrgId = tblCnfEmailMgr.OrgId,
                UserId = userId,
                LocationId = objUserContactBE.SiteId,
                CurrAssignQueueId = tblCnfEmailMgr.DefaultQueueId,
                FirstAssignQueueId = tblCnfEmailMgr.DefaultQueueId,
                ShortDesc = message.Subject,
                ChangeDescription = email_bodyHTML,
                PriorityId = tblCnfEmailMgr.DefaultPriorityId,
                CategoryId = tblCnfEmailMgr.DefaultCategoryId,
                SubCategoryId = tblCnfEmailMgr.DefaultSubCategoryId,
                ItemId = tblCnfEmailMgr.DefaultItemId,
                CreatedOn = DateTime.UtcNow,
                IsFromEmailMgr = true,
            };

            if (objChangeBE.PriorityId == null)
                objChangeBE.PriorityId = GlobalClass.Get_EntityAttrId_From_Data(objChangeBE.OrgId, (int)Enum_ModuleTypes.Change, "COMMON_PRIORITY", GlobalClass.GetConfigItem(db_context, "P4_EQ_PRIORITY_VAL", objChangeBE.OrgId).Value, db_context);
            //var ImpactText = Get_ImpactText_By_Priority(objChangeBE.PriorityId, db_context);
            objChangeBE.RiskEntId = GlobalClass.Get_EntityAttrId_From_Data(objChangeBE.OrgId, (int)Enum_ModuleTypes.Change, "COMMON_CHANGE_RISK", GlobalClass.GetConfigItem(db_context, "CHG_EMAILMGR_RISK", objChangeBE.OrgId).Value, db_context);
            objChangeBE.CommonImpactEntId = GlobalClass.Get_EntityAttrId_From_Data(objChangeBE.OrgId, (int)Enum_ModuleTypes.Change, "CHANGE_IMPACTED", GlobalClass.GetConfigItem(db_context, "CHG_EMAILMGR_IMPACTED", objChangeBE.OrgId).Value, db_context);
            objChangeBE.StatusId = GlobalClass.Get_EntityAttrId_From_Data(objChangeBE.OrgId, (int)Enum_ModuleTypes.Change, "COMMON_CHANGE_STATUS", GlobalClass.GetConfigItem(db_context, "CHG_EMAILMGR_STATUS", objChangeBE.OrgId).Value, db_context);
            objChangeBE.CreatedById = GlobalClass.Get_UserId_System_Admin(db_context);
            Set_Extract_Field_Value_From_Body(message, email_bodyHTML, tblCnfEmailMgr, Enum_ModuleTypes.Change, objChangeBE, db_context);
            var result = await CLS_v4API.Post_ApiRequest("WebRequest/CreateRequest", objChangeBE);
            var objResultBE = JsonConvert.DeserializeObject<TblTrnChange>(result);
            CLS_Global_Class.LogInformation(String.Format("Email Manager :: Ticket created with ID: {0}", objResultBE.IdNumber));
            return objResultBE.ChangeId;
        }

        private static async Task<int> Generate_Ticket_Problem(MimeKit.MimeMessage message, string email_bodyHTML, int? userId, TblCnfEmailMgr tblCnfEmailMgr, aditaas_v5Context db_context)
        {
            var objUserContactBE = db_context.TblMstUser.Where(a => a.UserId == userId).Select(a => new
            {
                a.ContactNo,
                a.SiteId,
            }).FirstOrDefault();
            var objProblemBE = new TblTrnProblem()
            {
                OrgId = tblCnfEmailMgr.OrgId,
                UserId = userId,
                ContactNo = objUserContactBE.ContactNo,
                LocationId = objUserContactBE.SiteId,
                CurrAssignQueueId = tblCnfEmailMgr.DefaultQueueId,
                FirstAssignQueueId = tblCnfEmailMgr.DefaultQueueId,
                ShortDesc = message.Subject,
                ProblemDescription = email_bodyHTML,
                PriorityId = tblCnfEmailMgr.DefaultPriorityId,
                CategoryId = tblCnfEmailMgr.DefaultCategoryId,
                SubCategoryId = tblCnfEmailMgr.DefaultSubCategoryId,
                ItemId = tblCnfEmailMgr.DefaultItemId,
                CreatedOn = DateTime.UtcNow,
                IsFromEmailMgr = true,
            };
            if (objProblemBE.PriorityId == null)
                objProblemBE.PriorityId = GlobalClass.Get_EntityAttrId_From_Data(objProblemBE.OrgId, (int)Enum_ModuleTypes.Problem, "COMMON_PRIORITY", GlobalClass.GetConfigItem(db_context, "P4_EQ_PRIORITY_VAL", objProblemBE.OrgId).Value, db_context);
            //var ImpactText = Get_ImpactText_By_Priority(objProblemBE.PriorityId, db_context);
            objProblemBE.SeverityEntId = GlobalClass.Get_EntityAttrId_From_Data(objProblemBE.OrgId, (int)Enum_ModuleTypes.Problem, "COMMON_INCIDENT_SEVERITY", GlobalClass.GetConfigItem(db_context, "PRB_EMAILMGR_URGENCY", objProblemBE.OrgId).Value, db_context);
            objProblemBE.CommonImpactEntId = GlobalClass.Get_EntityAttrId_From_Data(objProblemBE.OrgId, (int)Enum_ModuleTypes.Problem, "COMMON_IMPACT", GlobalClass.GetConfigItem(db_context, "PRB_EMAILMGR_IMPACT", objProblemBE.OrgId).Value, db_context);
            objProblemBE.ChannelEntId = GlobalClass.Get_EntityAttrId_From_Data(objProblemBE.OrgId, (int)Enum_ModuleTypes.Problem, "COMMON_PROBLEM_CHANNEL", GlobalClass.GetConfigItem(db_context, "PRB_EMAILMGR_CHANNEL", objProblemBE.OrgId).Value, db_context);
            objProblemBE.StatusId = GlobalClass.Get_EntityAttrId_From_Data(objProblemBE.OrgId, (int)Enum_ModuleTypes.Problem, "COMMON_PROB_STATUS", GlobalClass.GetConfigItem(db_context, "PRB_EMAILMGR_STATUS", objProblemBE.OrgId).Value, db_context);
            objProblemBE.CreatedById = GlobalClass.Get_UserId_System_Admin(db_context);
            Set_Extract_Field_Value_From_Body(message, email_bodyHTML, tblCnfEmailMgr, Enum_ModuleTypes.Problem, objProblemBE, db_context);

            var result = await CLS_v4API.Post_ApiRequest("WebRequest/CreateRequest", objProblemBE);
            var objResultBE = JsonConvert.DeserializeObject<TblTrnProblem>(result);
            CLS_Global_Class.LogInformation(String.Format("Email Manager :: Ticket created with ID: {0}", objResultBE.IdNumber));
            return objResultBE.ProblemId;
        }

        private static async Task<int> Generate_Ticket_Task(MimeKit.MimeMessage message, string email_bodyHTML, int? userId, TblCnfEmailMgr tblCnfEmailMgr, aditaas_v5Context db_context)
        {
            var objTaskBE = new TblTrnTask()
            {
                OrgId = tblCnfEmailMgr.OrgId,
                UserId = userId,
                QueueId = tblCnfEmailMgr.DefaultQueueId,
                Description = message.Subject,
                TaskTitle = message.Subject,
                Comments = message.TextBody,
                CommentsHtml = email_bodyHTML,
                CreatedOn = DateTime.UtcNow,
                IsFromEmailMgr = true,
            };
            objTaskBE.StatusId = GlobalClass.Get_EntityAttrId_From_Data(objTaskBE.OrgId, (int)Enum_ModuleTypes.Task, "COMMON_TASK_STATUS", "OPEN", db_context);
            objTaskBE.CreatedById = GlobalClass.Get_UserId_System_Admin(db_context);
            Set_Extract_Field_Value_From_Body(message, email_bodyHTML, tblCnfEmailMgr, Enum_ModuleTypes.Task, objTaskBE, db_context);
            var result = await CLS_v4API.Post_ApiRequest("WebRequest/CreateRequest", objTaskBE);
            var objResultBE = JsonConvert.DeserializeObject<TblTrnTask>(result);
            CLS_Global_Class.LogInformation(String.Format("Email Manager :: Ticket created with ID: {0}", objResultBE.IdNumber));
            return objResultBE.TaskId;
        }

        private static async Task<int> Generate_Ticket_Interaction(MimeKit.MimeMessage message, string email_bodyHTML, int? userId, TblCnfEmailMgr tblCnfEmailMgr, string email_receipient, aditaas_v5Context db_context)
        {
            var objUserContactBE = db_context.TblMstUser.Where(a => a.UserId == userId).Select(a => new
            {
                a.ContactNo,
                a.SiteId,
            }).FirstOrDefault();
            var objInteractionBE = new TblTrnInteraction()
            {
                OrgId = tblCnfEmailMgr.OrgId,
                UserId = userId,
                LocationId = objUserContactBE.SiteId,
                CategoryId = tblCnfEmailMgr.DefaultCategoryId,
                SubCategoryId = tblCnfEmailMgr.DefaultSubCategoryId,
                ItemId = tblCnfEmailMgr.DefaultItemId,
                PriorityId = tblCnfEmailMgr.DefaultPriorityId,
                SeverityEntId = null,
                ChannelEntId = null,
                CurrAssignQueueId = tblCnfEmailMgr.DefaultQueueId,
                CreatedOn = DateTime.UtcNow,
                EmailSubject = message.Subject,
                EmailBody = email_bodyHTML,
                CreatedById = userId,
                EmailReceipient = email_receipient
            };

            objInteractionBE.CreatedById = GlobalClass.Get_UserId_System_Admin(db_context);
            objInteractionBE.StatusId = GlobalClass.Get_EntityAttrId_From_Data(objInteractionBE.OrgId, (int)Enum_ModuleTypes.Interaction, "COMMON_INTERACTION_STATUS", GlobalClass.GetConfigItem(db_context, "INC_EMAILMGR_STATUS", objInteractionBE.OrgId).Value, db_context);
            Set_Extract_Field_Value_From_Body(message, email_bodyHTML, tblCnfEmailMgr, Enum_ModuleTypes.Interaction, objInteractionBE, db_context);
            var result = await CLS_v4API.Post_ApiRequest("WebInteraction/CreateInteraction", objInteractionBE);
            var objResultBE = JsonConvert.DeserializeObject<TblTrnInteraction>(result);
            CLS_Global_Class.LogInformation(String.Format("Email Manager :: Ticket created with ID: {0}", objResultBE.IdNumber));

            try
            {
                var tblCnfEmailTemplate = (from emailTemp in db_context.TblCnfEmailTemplate
                                           where emailTemp.TemplateType == "Interaction Created"
                                           select emailTemp).FirstOrDefault();
                
                var emailIdList = (from qmap in db_context.TblMstUserQueueMap
                                   join usr in db_context.TblMstUser on qmap.UserId equals usr.UserId
                                   join orgMap in db_context.TblMstUserOrgMap on usr.UserId equals orgMap.UserId
                                   where qmap.QueueId == objResultBE.CurrAssignQueueId
                                   && orgMap.OrgId == (int)objResultBE.OrgId
                                   && (!String.IsNullOrEmpty(usr.EmailId))
                                   && usr.IsActive == true
                                   select usr.EmailId).ToList();

                string strSubject = tblCnfEmailTemplate.Subject.Replace("#ID#", objResultBE.IdNumber);
                string strBody = tblCnfEmailTemplate.Body.Replace("#ID#", objResultBE.IdNumber);
                strBody = strBody.Replace("#view ticket#", "<a target='_blank' rel='noopener noreferrer' href='" + CLS_Global_Class.applicationUrl + "interaction-pending/" + objResultBE.InteractionId + "'>View Ticket</a>");
                strBody = strBody.Replace("#Subject#", objResultBE.EmailSubject);
                strBody = strBody.Replace("#Message#", objResultBE.EmailBody);

                await CLS_EmailSender.SendEmailAsync((int)objResultBE.OrgId, string.Join(",", emailIdList), null, strSubject, strBody, db_context);
            }
            catch(Exception ex)
            {
                CLS_Global_Class.LogInformation(ex.Message);
            }            

            return objResultBE.InteractionId;
        }

        #region Other Method

        private static string PopulateInlineImages(MimeMessage newMessage, string bodyHtml)
        {
            if (bodyHtml != null)
            {
                try
                {
                    foreach (MimePart att in newMessage.BodyParts)
                    {
                        if (att.ContentId != null && att.Content != null && att.ContentType.MediaType == "image" && (bodyHtml.IndexOf("cid:" + att.ContentId) > -1))
                        {
                            byte[] b;
                            using (var mem = new MemoryStream())
                            {
                                att.Content.DecodeTo(mem);
                                b = mem.ToArray();
                            }

                            var base64 = System.Convert.ToBase64String(b);

                            #region Resize Image 

                            Size? outNewSize = null;
                            base64 = ResizeImage(base64, 1000, 1000, out outNewSize);

                            if (outNewSize != null)
                            {
                                setImg_Tag_Size(ref bodyHtml, att.ContentId, outNewSize);
                            }

                            #endregion

                            string imageBase64 = "data:" + att.ContentType.MimeType + ";base64," + base64;
                            bodyHtml = bodyHtml.Replace("cid:" + att.ContentId, imageBase64);
                        }
                    }
                }
                catch { }
            }
            return bodyHtml;
        }

        private static void GetAttachmentsFromPlainTextMail(MimeMessage newMessage, List<AddAttachment> coll_Attachments, TblCnfEmailMgr tblCnfEmailMgr, int? int_AttachedById, string str_AttachedBy)
        {
            try
            {
                foreach (MimeEntity att in newMessage.BodyParts)
                {
                    if (att.GetType() != typeof(MimeKit.TextPart) && att.IsAttachment == false)
                    {
                        var fileName = att.ContentDisposition?.FileName ?? att.ContentType.Name;

                        try
                        {
                            if (fileName == null && att.ContentType.MediaType == "message")
                            {
                                fileName = ((MessagePart)att).Message.Subject.Substring(0, 10) + ".eml";
                            }
                        }
                        catch (Exception e)
                        {
                            CLS_Global_Class.LogError(e.Message, e);
                        }

                        var stream = new MemoryStream();
                        if (att is MessagePart)
                        {
                            var rfc822 = (att as MessagePart);
                            rfc822.Message.WriteTo(stream);
                        }
                        else
                        {
                            var part = (MimePart)att;
                            part.Content.DecodeTo(stream);
                        }

                        var objAttachment = new AddAttachment()
                        {
                            ModuleId = tblCnfEmailMgr.ModuleId,
                            AttachedById = int_AttachedById,
                            AttachedByName = str_AttachedBy,
                            AttachedOn = DateTime.UtcNow,
                            FileName = fileName,
                            DisplayName = fileName,
                            BinaryData = stream.ToArray(),
                        };
                        coll_Attachments.Add(objAttachment);
                    }
                }
            }
            catch { }
        }

        private static void setImg_Tag_Size(ref string bodyHtml, string cid, Size? size)
        {
            var expr = @"(<img([^>]+)>)";
            MatchCollection mc = Regex.Matches(bodyHtml, expr);
            foreach (var item in mc.Where(a => a != null && size != null && a.ToString().Contains(cid)))
            {
                var str_Img_Tags = item.ToString();
                str_Img_Tags = str_Img_Tags.Replace(" height=\"", " \"").Replace(" width=\"", " \"");
                str_Img_Tags = str_Img_Tags.Replace(" height='", " '").Replace(" width='", " '");
                //var tagHeight = string.Format("height=\"{0}\"", size.Value.Height);
                //var tagWidth = string.Format("width=\"{0}\"", size.Value.Width);
                //str_Img_Tags = string.Format("{0} {1} {2} style=\"max-width:100%;object-fit: contain;\">", str_Img_Tags.Substring(0, str_Img_Tags.Length - 1), tagHeight, tagWidth);
                str_Img_Tags = string.Format("<figure class=\"image\">{0} </figure >", str_Img_Tags);
                bodyHtml = bodyHtml.Replace(item.ToString(), str_Img_Tags);
            }
        }

        //private static string Get_ImpactText_By_Priority(int? int_PriorityId, aditaas_v5Context db_context)
        //{
        //    string str_Result = "LOW";
        //    var str_Priority = db_context.TblMstEntityAttr.Where(a => a.EntityAttrId == int_PriorityId).Select(a => a.Name).FirstOrDefault();
        //    if (str_Priority == "P1")
        //        str_Result = "HIGH";
        //    else if (str_Priority == "P2" || str_Priority == "P3")
        //        str_Result = "MEDIUM";
        //    else if (str_Priority == "P4")
        //        str_Result = "LOW";
        //    return str_Result;
        //}

        private static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }


        private static Size Get_Max_Size_Ratio(int width, int height, int maxWidth, int maxHeight)
        {
            double resizeWidth = width;
            double resizeHeight = height;
            double aspect = resizeWidth / resizeHeight;
            if (resizeWidth > maxWidth)
            {
                resizeWidth = maxWidth;
                resizeHeight = resizeWidth / aspect;
            }
            if (resizeHeight > maxHeight)
            {
                aspect = resizeWidth / resizeHeight;
                resizeHeight = maxHeight;
                resizeWidth = resizeHeight * aspect;
            }
            var size = new Size((int)resizeWidth, (int)resizeHeight);
            return size;
        }


        private static string ResizeImage(string base64, int maxWidth, int maxHeight, out Size? outNewSize)
        {
            outNewSize = null;
            Image img = Base64ToImage(base64);
            var size = Get_Max_Size_Ratio(img.Width, img.Height, 1000, 1000);
            double resizeWidth = size.Width;
            double resizeHeight = size.Height;
            if (resizeWidth == img.Width && resizeHeight == img.Height)
            {
                return base64;
            }
            else
            {
                outNewSize = size;
                var bmp = new Bitmap(img);
                Bitmap bmpResult = new Bitmap((int)resizeWidth, (int)resizeHeight);
                using (Graphics g = Graphics.FromImage(bmpResult))
                {
                    g.DrawImage(bmp, 0, 0, (int)resizeWidth, (int)resizeHeight);
                }
                var stream = new MemoryStream();
                bmpResult.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = stream.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        #endregion

        private static async Task<bool> Ticket_Add_Notes_Entry(MimeKit.MimeMessage message, string email_bodyHTML, int? userId, int? recordId, TblCnfEmailMgr tblCnfEmailMgr, aditaas_v5Context db_context,Enum_ModuleTypes objModule)
        {
            var idNumber = CLS_Global_Class.Get_IdNumber_From_RecordId(objModule, recordId, db_context);
            var objNotesBE = new GenAddNotesLog()
            {
                CreatedById = userId,
                DescriptionHtml = email_bodyHTML,
                Description = email_bodyHTML,
                ModuleId = tblCnfEmailMgr.ModuleId,
                RecordIdArr = new string[] { idNumber },
                NoteType = "Add Notes",
                IsEmailRequestor = false,
                IsEmailSupportGroup = false,
                IsEmailTechnician = false,
                IsInternalNotes = false,
                IsFromEmailMgr = true,
                CreatedOn = DateTime.UtcNow,
            };
            var result = await CLS_v4API.Post_ApiRequest("WebGenAddNotesLog/GenAddNotes", objNotesBE);
            var objResultBE = JsonConvert.DeserializeObject<GenAddNotesLog>(result);
            return objResultBE.RecordId == 1;
        }

        private static string Get_MailBoxAddressCSV(IEnumerable<MailboxAddress> coll_MailBoxs)
        {
            string str_CSV = "";
            foreach (var item in coll_MailBoxs)
            {
                if (str_CSV != "") str_CSV += ", ";
                if (item.Name == null || item.Name == "" || item.Name == item.Address)
                    str_CSV += item.Address;
                else
                    str_CSV += string.Format("{0} \"{1}\"", item.Name, item.Address);
            }
            return str_CSV;
        }

        private static void Set_Extract_Field_Value_From_Body(MimeKit.MimeMessage message, string email_bodyHTML, TblCnfEmailMgr tblCnfEmailMgr, Enum_ModuleTypes module, object objTicketBE, aditaas_v5Context db_context)
        {
            if (tblCnfEmailMgr.IsExtractField == true)
            {
                var email_Subject = message.Subject;
                Type objType = null;
                foreach (var item in tblCnfEmailMgr.TblCnfEmailMgrExtractField.OrderBy(a => a.Uid))
                {
                    var objBusFieldBE = db_context.TblCnfBusField.FirstOrDefault(a => a.BusFieldId == item.FormFieldId && a.ModuleId == (int)module);
                    var match = Regex.Match(email_bodyHTML, @"" + item.StartWith + "(.+?)" + item.EndWith + "").Groups[1].Value.Trim();
                    if (string.IsNullOrEmpty(match) == true)
                        match = Regex.Match(email_Subject, @"" + item.StartWith + "(.+?)" + item.EndWith + "").Groups[1].Value.Trim();
                    match = Regex.Replace(match, "<.*?>", String.Empty);
                    object value = null;
                    if (string.IsNullOrEmpty(match) == false && objBusFieldBE != null)
                    {
                        if (objBusFieldBE.FieldType == "User" || objBusFieldBE.FieldType == "AllOrgUser" || objBusFieldBE.FieldType == "Agent")
                        {
                            value = (from user in db_context.TblMstUser
                                     join userOrg in db_context.TblMstUserOrgMap on user.UserId equals userOrg.UserId
                                     where userOrg.OrgId == tblCnfEmailMgr.OrgId && (user.Name == match || user.FirstName + " " + user.LastName == match)
                                     select user.UserId).FirstOrDefault();
                        }
                        else if (objBusFieldBE.FieldType == "User Group")
                        {
                            value = (from queue in db_context.TblMstQueue
                                     join queueOrg in db_context.TblMstOrgQueueMap on queue.QueueId equals queueOrg.QueueId
                                     where queueOrg.OrgId == tblCnfEmailMgr.OrgId && queue.Name == match
                                     select queue.QueueId).FirstOrDefault();
                        }
                        else if (objBusFieldBE.FieldType == "Site")
                        {
                            value = db_context.TblMstSite.Where(a => a.Name == match && a.OrgId == tblCnfEmailMgr.OrgId).Max(a => a.SiteId);
                        }
                        else if (objBusFieldBE.FieldType == "Entity")
                        {
                            var query = (from entity in db_context.TblMstEntity
                                         join entityMod in db_context.TblMstEntityModuleMap on entity.EntityId equals entityMod.EntityId
                                         join entityAttr in db_context.TblMstEntityAttr on new { EntityId = (int?)entity.EntityId, tblCnfEmailMgr.OrgId, Name = match.ToLower() } equals new { entityAttr.EntityId, entityAttr.OrgId, Name = entityAttr.Name.ToLower() } into jentityAttr
                                         from entityAttr in jentityAttr.DefaultIfEmpty()
                                         where entityMod.ModuleId == tblCnfEmailMgr.ModuleId && entity.Name == objBusFieldBE.EntityName
                                         select new
                                         {
                                             EntityId = entity.EntityId,
                                             EntityAttrId = (entityAttr != null ? entityAttr.EntityAttrId : 0),
                                             ParentEntityAttrId = entityAttr.ParentEntityAttrId ?? 0,
                                             MainParentId = entityAttr.MainParentId ?? 0,
                                         }).ToList();
                            if (objBusFieldBE.DbFieldName == "category_id")
                            {
                                #region Get or Add Category

                                if (query.Count(a => a.EntityAttrId > 0) > 0)
                                {
                                    value = query.Max(a => a.EntityAttrId);
                                }
                                else if (query.Count(a => a.EntityId > 0) > 0)
                                {
                                    //Add Category Entry
                                    var objNewAttrBE = Add_NewEntityAttr(match, query.Max(a => a.EntityId), tblCnfEmailMgr.OrgId, null, null, db_context);
                                    value = objNewAttrBE.EntityAttrId;
                                }

                                #endregion
                            }
                            else if (objBusFieldBE.DbFieldName == "sub_category_id")
                            {
                                #region Get or Add Sub Category 

                                var categoryId = GlobalClass.GetPropertyValue(objTicketBE, "CategoryId", out objType);
                                if (categoryId != null && String.IsNullOrEmpty(categoryId.ToString()) == false)
                                {
                                    var result = query.Where(a => a.ParentEntityAttrId == int.Parse(categoryId.ToString()));
                                    if (result.Count(a => a.EntityAttrId > 0) > 0)
                                    {
                                        value = query.Max(a => a.EntityAttrId);
                                    }
                                    else if (query.Count(a => a.EntityId > 0) > 0)
                                    {
                                        //Add Sub-Category Entry
                                        var objNewAttrBE = Add_NewEntityAttr(match, query.Max(a => a.EntityId), tblCnfEmailMgr.OrgId, int.Parse(categoryId.ToString()), int.Parse(categoryId.ToString()), db_context);
                                        value = objNewAttrBE.EntityAttrId;
                                    }
                                }

                                #endregion
                            }
                            else if (objBusFieldBE.DbFieldName == "item_id")
                            {
                                #region Get or Add Item

                                var subCategoryId = GlobalClass.GetPropertyValue(objTicketBE, "SubCategoryId", out objType);
                                var categoryId = GlobalClass.GetPropertyValue(objTicketBE, "CategoryId", out objType);
                                if (categoryId != null && String.IsNullOrEmpty(categoryId.ToString()) == false && subCategoryId != null && String.IsNullOrEmpty(subCategoryId.ToString()) == false)
                                {
                                    var result = query.Where(a => a.ParentEntityAttrId == int.Parse(subCategoryId.ToString()));
                                    if (result.Count(a => a.EntityAttrId > 0) > 0)
                                    {
                                        value = query.Max(a => a.EntityAttrId);
                                    }
                                    else if (query.Count(a => a.EntityId > 0) > 0)
                                    {
                                        //Add Sub-Category Entry
                                        var objNewAttrBE = Add_NewEntityAttr(match, query.Max(a => a.EntityId), tblCnfEmailMgr.OrgId, int.Parse(subCategoryId.ToString()), int.Parse(categoryId.ToString()), db_context);
                                        value = objNewAttrBE.EntityAttrId;
                                    }
                                }

                                #endregion
                            }
                            else
                            {
                                value = query.Max(a => a.EntityAttrId);
                            }
                        }
                        else if (objBusFieldBE.FieldType == "Org")
                        {
                            value = db_context.TblMstOrg.Where(a => a.Name == match).Max(a => a.OrgId);
                        }
                        else if (objBusFieldBE.FieldType == "CI")
                        {
                            object userId = null;
                            try
                            {
                                userId = GlobalClass.GetPropertyValue(objTicketBE, "UserId", out objType);
                            }
                            catch (Exception)
                            { }
                            if (userId != null)
                                value = (from ci in db_context.TblCmdbTrnCi
                                         where ci.UserId == int.Parse(userId.ToString()) && ci.CiName == match
                                         select ci.CiId).FirstOrDefault();
                        }
                        else
                        {
                            value = match;
                        }
                        if (value != null && String.IsNullOrEmpty(value.ToString()) == false)
                        {
                            var str_Prop_Name = CLS_Global_Class.Get_PropName_From_BusFieldId(objBusFieldBE.BusFieldId, db_context);
                            GlobalClass.SetObjectProperty(str_Prop_Name, value, objTicketBE);
                        }

                    }
                }
            }

        }

        private static TblMstEntityAttr Add_NewEntityAttr(string name, int entityId, int? orgId, int? parentEntityAttrId, int? parentMainAttrId, aditaas_v5Context db_context)
        {
            var objNewAttr = new TblMstEntityAttr()
            {
                EntityId = entityId,
                ParentEntityAttrId = parentEntityAttrId,
                MainParentId = parentMainAttrId,
                Name = name,
                IsActive = true,
                OrgId = orgId
            };
            db_context.TblMstEntityAttr.Add(objNewAttr);
            db_context.SaveChanges();
            if (parentEntityAttrId == null)
            {
                db_context.TblMstDeptCategoryMap.Add(new TblMstDeptCategoryMap()
                {
                    DeptId = 1,
                    EntityAttrId = objNewAttr.EntityAttrId,
                });
                db_context.SaveChanges();
            }
            return objNewAttr;
        }

        private class CLS_Email_Details_BE
        {
            public string emailid { get; set; }
            public string subject { get; set; }
            public string body { get; set; }
        }
    }


}
