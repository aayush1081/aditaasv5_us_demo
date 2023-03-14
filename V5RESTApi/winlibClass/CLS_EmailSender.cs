using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using aditaas_v5.Classes;
using System.Text.RegularExpressions;
using aditaas_v5.Models;
using MimeKit;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Exchange.WebServices.Data;
using System.Net.Mail;

namespace V5WinService.Classes
{

    public static class CLS_EmailSender
    {

        private static Queue<CLS_Email_Queue_BE> workQueue = new Queue<CLS_Email_Queue_BE>();
        public static Thread workerThread;
        private static EventWaitHandle waitHandle = new AutoResetEvent(true);


        public static async Task<string> SendEmailAsync(int? orgId, string emailTo, string emailCc, string subject, string htmlBody, aditaas_v5Context db_context, List<string> coll_Attachment = null)
        {
            var str_From_Email_Id = "";
            try
            {
                var obj_MailSetting = CLS_Global_Class.Get_EmailSetting_By_Org(orgId, db_context);

                if (string.IsNullOrEmpty(emailTo) == true)
                    return str_From_Email_Id;
                str_From_Email_Id = obj_MailSetting.SenderMail;

                #region Generate CSS

                string str_CSS_Class = "<style>table{ border-collapse: collapse;width: 100%;}";
                var cnt_Class = 0;
                str_CSS_Class += ".tableCkEditor{ border: 1.5px solid #cdd4e0; border-spacing:0px;padding:0 5.4px;} ";
                //str_CSS_Class += ".tableCkEditor th, .tableCkEditor td{ border: 1.5px solid #cdd4e0; border-spacing:0px;padding:0 5.4px;} ";
                var strStyleTag = "style=\"";
                while (htmlBody.Contains(strStyleTag))
                {
                    var idx_Start = htmlBody.IndexOf(strStyleTag) + strStyleTag.Length;
                    var idx_end = htmlBody.IndexOf('"', idx_Start);
                    var strStyle_Text = htmlBody.Substring(idx_Start, idx_end - idx_Start);
                    var str_Class_Name = "customClass_" + cnt_Class;
                    var str_Full_StyleTag = strStyleTag + strStyle_Text + "\"";

                    htmlBody = htmlBody.Replace(str_Full_StyleTag, string.Format("class='{0}'", str_Class_Name));
                    str_CSS_Class += string.Format(" .{0}{{ {1} }}", str_Class_Name, strStyle_Text);

                    cnt_Class++;
                }

                #region HSL Color to RGB

                strStyleTag = "hsl(";
                while (str_CSS_Class.Contains("hsl("))
                {
                    var idx_Start = str_CSS_Class.IndexOf(strStyleTag) + strStyleTag.Length;
                    var idx_end = str_CSS_Class.IndexOf(')', idx_Start);
                    var strStyle_Text = str_CSS_Class.Substring(idx_Start, idx_end - idx_Start);
                    var haxColor = CLS_ColorScale.ColorFromHSL(strStyle_Text);
                    strStyle_Text = strStyleTag + strStyle_Text + ")";
                    str_CSS_Class = str_CSS_Class.Replace(strStyle_Text, haxColor);
                }

                #endregion

                str_CSS_Class += "</style> " + Environment.NewLine;

                #endregion

                #region Send Mail From SMTP

                //var SmtpServer1 = new System.Net.Mail.SmtpClient(obj_MailSetting.MailServer);
                var mailMessage = new MimeMessage();
                mailMessage.To.AddRange(emailTo.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim())));
                if (string.IsNullOrEmpty(emailCc) == false)
                {
                    mailMessage.Cc.AddRange(emailCc.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim())));
                }
                mailMessage.Subject = subject;
                var builder = new BodyBuilder();
                //CLS_Global_Class.Set_MailBody(builder, str_CSS_Class + htmlBody);
                
                if (coll_Attachment != null)
                {
                    /*foreach (var item in coll_Attachment)
                    {
                        if (File.Exists(item))
                            builder.Attachments.Add(item);
                    }*/

                    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
                    foreach (var item in coll_Attachment)
                    {
                        string rptMailFormat = configuration.GetSection("CommonSettings").GetValue<string>("RptMailFormat");

                        htmlBody = rptMailFormat.Replace("#mailBody#", htmlBody);

                        string attachmentUrl = configuration.GetConnectionString("apiUrl");

                        int pos = item.LastIndexOf("/") + 1;
                        string filename = item.Substring(pos, item.Length - pos);

                        var url = attachmentUrl + "/WebGenAddAttachment/DownloadRptFile?filename=" + filename;
                        var attachmentLink = "<a target = \"_blank\" rel =\"noopener noreferrer\" href =\"" + url + "\">Click here</a>";

                        htmlBody = htmlBody.Replace("#downloadText#", attachmentLink);
                        CLS_Global_Class.Set_MailBody(builder, str_CSS_Class + htmlBody);
                    }
                }
                else
                {
                    CLS_Global_Class.Set_MailBody(builder, str_CSS_Class + htmlBody);
                }
                mailMessage.Body = builder.ToMessageBody();
               
                QueueInput(new CLS_Email_Queue_BE()
                {
                    mailMessage = mailMessage,
                    obj_MailSetting = obj_MailSetting,
                });
               

                #endregion

                CLS_Global_Class.LogInformation("Email notification sent enqueue to " + emailTo);
                return str_From_Email_Id;
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("******* Email sending error *******", ex);
                throw new InvalidOperationException(ex.Message);
            }
        }

        public static async Task<string> SendEmailSimpleAsync(int? orgId, string emailTo, string emailCc, string subject, string htmlBody, aditaas_v5Context db_context, List<string> coll_Attachment = null)
        {
            var str_From_Email_Id = "";
            try
            {
                var obj_MailSetting = CLS_Global_Class.Get_EmailSetting_By_Org(orgId, db_context);

                if (string.IsNullOrEmpty(emailTo) == true)
                    return str_From_Email_Id;
                str_From_Email_Id = obj_MailSetting.SenderMail;

                #region Send Mail From SMTP

                //var SmtpServer1 = new System.Net.Mail.SmtpClient(obj_MailSetting.MailServer);
                var mailMessage = new MimeMessage();
                mailMessage.To.AddRange(emailTo.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim())));
                if (string.IsNullOrEmpty(emailCc) == false)
                {
                    mailMessage.Cc.AddRange(emailCc.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim())));
                }
                mailMessage.Subject = subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = htmlBody;
                if (coll_Attachment != null)
                {
                    /*foreach (var item in coll_Attachment)
                    {
                        if (File.Exists(item))
                            builder.Attachments.Add(item);
                    }*/
                    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
                    foreach (var item in coll_Attachment)
                    {
                        string rptMailFormat = configuration.GetSection("CommonSettings").GetValue<string>("RptMailFormat");

                        htmlBody = rptMailFormat.Replace("#mailBody#", htmlBody);

                        string attachmentUrl = configuration.GetConnectionString("apiUrl");

                        int pos = item.LastIndexOf("/") + 1;
                        string filename = item.Substring(pos, item.Length - pos);

                        var url = attachmentUrl + "/WebGenAddAttachment/DownloadRptFile?filename=" + filename;
                        var attachmentLink = "<a target = \"_blank\" rel =\"noopener noreferrer\" href =\"" + url + "\">Click here</a>";

                        htmlBody = htmlBody.Replace("#downloadText#", attachmentLink);
                        CLS_Global_Class.Set_MailBody(builder, htmlBody);
                    }
                }
                else
                {
                    CLS_Global_Class.Set_MailBody(builder, htmlBody);
                }
                mailMessage.Body = builder.ToMessageBody();

                QueueInput(new CLS_Email_Queue_BE()
                {
                    mailMessage = mailMessage,
                    obj_MailSetting = obj_MailSetting,
                });


                #endregion

                CLS_Global_Class.LogInformation("Email notification sent enqueue to " + emailTo);
                return str_From_Email_Id;
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("******* Email sending error *******", ex);
                throw new InvalidOperationException(ex.Message);
            }
        }

        public static void QueueInput(CLS_Email_Queue_BE objMailBE)
        {
            if (workQueue.Contains(objMailBE))
                return;
            workQueue.Enqueue(objMailBE);
            if (workerThread == null)
            {
                workerThread = new Thread(new ThreadStart(Work_SendMail));
                workerThread.Start();
            }
            else if (workerThread.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
            {
                waitHandle.Set();
            }
        }

        private static void Work_SendMail() //NOSONAR
        {
            while (true) 
            {
                var obj_QueueBE = Get_Queue_Element();
                if (obj_QueueBE != null)
                {
                    try
                    {
                        #region MailKit Send Email

                        if (!obj_QueueBE.obj_MailSetting.IsExchangeApi.GetValueOrDefault(false))
                        {
                        using (var client = new MailKit.Net.Smtp.SmtpClient())
                        {
                            if (obj_QueueBE.mailMessage.From.Count == 0)
                                obj_QueueBE.mailMessage.From.Add(new MailboxAddress(obj_QueueBE.obj_MailSetting.SenderName, obj_QueueBE.obj_MailSetting.SenderMail));
                            //client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                            client.ServerCertificateValidationCallback = GlobalClass.MySslCertificateValidationCallback;
                            if (obj_QueueBE.obj_MailSetting.EnableSsl == true)
                            {
                                client.CheckCertificateRevocation = false;
                                client.Connect(obj_QueueBE.obj_MailSetting.MailServer, obj_QueueBE.obj_MailSetting.MailPort, MailKit.Security.SecureSocketOptions.Auto);
                            }
                            else
                                client.Connect(obj_QueueBE.obj_MailSetting.MailServer, obj_QueueBE.obj_MailSetting.MailPort, obj_QueueBE.obj_MailSetting.EnableSsl);

                            if (obj_QueueBE.obj_MailSetting.RequiresAuth)
                                client.Authenticate(obj_QueueBE.obj_MailSetting.UserName, obj_QueueBE.obj_MailSetting.Password);

                            client.Send(obj_QueueBE.mailMessage);
                            client.Disconnect(true);
                        }
                        }
                        else
                        {
                            SendMailViaApiMime(obj_QueueBE);
                        }
                        #endregion

                        CLS_Global_Class.LogInformation("Email notification sent To:-" + string.Join(",", obj_QueueBE.mailMessage.To.Select(a => a)) + ", Subject:-" + obj_QueueBE.mailMessage.Subject);
                    }
                    catch (Exception ex)
                    {
                        CLS_Global_Class.LogError("******* Email sending error ************** (Queue Count :" + workQueue.Count.ToString() + ")", ex);
                        if (ex.Message != null && ex.Message.ToLower().Contains("4.4.2 Message submission rate for this client has exceeded the configured limit".ToLower()) == true)
                        {
                            workQueue.Enqueue(obj_QueueBE);
                            Thread.Sleep(10000);
                        }
                    }
                }
                else
                {
                    // If no files left to process then wait
                    waitHandle.WaitOne();
                }
            }
        }
        public static void SendMailViaApiMime(CLS_Email_Queue_BE objEmailQueue)
        {
            var _exchangeService = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            _exchangeService.Credentials = new WebCredentials(objEmailQueue.obj_MailSetting.UserName, objEmailQueue.obj_MailSetting.Password);
            _exchangeService.Url = new Uri(objEmailQueue.obj_MailSetting.ExchangeUrl);

            EmailMessage message = new EmailMessage(_exchangeService);
            message.Subject = objEmailQueue.mailMessage.Subject;
            var messageBody = (objEmailQueue.mailMessage.HtmlBody == null ? objEmailQueue.mailMessage.TextBody : objEmailQueue.mailMessage.HtmlBody);
            MessageBody msgBody = new MessageBody(BodyType.HTML, messageBody);
            message.Sender = objEmailQueue.obj_MailSetting.SenderMail;
            message.Body = msgBody;

            foreach (MailboxAddress torecmail in objEmailQueue.mailMessage.To)
            {
                message.ToRecipients.Add(torecmail.Address);
            }
            if (objEmailQueue.mailMessage.Cc != null)
            {
                foreach (MailboxAddress ccrecmail in objEmailQueue.mailMessage.Cc)
                {
                    message.CcRecipients.Add(ccrecmail.Address);
                }
            }
            message.Send().Wait();
        }
        private static CLS_Email_Queue_BE Get_Queue_Element()
        {
            if (workQueue.Count > 0)
                return workQueue.Dequeue();
            else
                return null;
        }

        public class CLS_Email_Queue_BE
        {
            public MimeMessage mailMessage { get; set; }
            //public System.Net.Mail.MailMessage mailMessage { get; set; }
            public EmailSettings obj_MailSetting { get; set; }
        }

        //binu overload method to incorporate senderprofileid
        public static async Task<string> SendEmailBySenderProfileIdAsync(int? senderProfileId, string emailTo, string emailCc, string subject, string htmlBody, aditaas_v5Context db_context, List<string> coll_Attachment = null)
        {
            var str_From_Email_Id = "";
            try
            {
                var obj_MailSetting = CLS_Global_Class.GetEmailSettingBySenderProfileId(senderProfileId, db_context);

                if (string.IsNullOrEmpty(emailTo) == true)
                    return str_From_Email_Id;
                str_From_Email_Id = obj_MailSetting.SenderMail;
                #region Generate CSS

                string str_CSS_Class = "<style>table{ border-collapse: collapse;width: 100%;}";
                var cnt_Class = 0;
                str_CSS_Class += ".tableCkEditor{ border: 1.5px solid #cdd4e0; border-spacing:0px;padding:0 5.4px;} ";
                //str_CSS_Class += ".tableCkEditor th, .tableCkEditor td{ border: 1.5px solid #cdd4e0; border-spacing:0px;padding:0 5.4px;} ";
                var strStyleTag = "style=\"";
                while (htmlBody.Contains(strStyleTag))
                {
                    var idx_Start = htmlBody.IndexOf(strStyleTag) + strStyleTag.Length;
                    var idx_end = htmlBody.IndexOf('"', idx_Start);
                    var strStyle_Text = htmlBody.Substring(idx_Start, idx_end - idx_Start);
                    var str_Class_Name = "customClass_" + cnt_Class;
                    var str_Full_StyleTag = strStyleTag + strStyle_Text + "\"";

                    htmlBody = htmlBody.Replace(str_Full_StyleTag, string.Format("class='{0}'", str_Class_Name));
                    str_CSS_Class += string.Format(" .{0}{{ {1} }}", str_Class_Name, strStyle_Text);

                    cnt_Class++;
                }

                #region HSL Color to RGB

                strStyleTag = "hsl(";
                while (str_CSS_Class.Contains("hsl("))
                {
                    var idx_Start = str_CSS_Class.IndexOf(strStyleTag) + strStyleTag.Length;
                    var idx_end = str_CSS_Class.IndexOf(')', idx_Start);
                    var strStyle_Text = str_CSS_Class.Substring(idx_Start, idx_end - idx_Start);
                    var haxColor = CLS_ColorScale.ColorFromHSL(strStyle_Text);
                    strStyle_Text = strStyleTag + strStyle_Text + ")";
                    str_CSS_Class = str_CSS_Class.Replace(strStyle_Text, haxColor);
                }
                #endregion

                str_CSS_Class += "</style> " + Environment.NewLine;

                #endregion

                #region Send Mail From SMTP

                //var SmtpServer1 = new System.Net.Mail.SmtpClient(obj_MailSetting.MailServer);
                var mailMessage = new MimeMessage();
                mailMessage.To.AddRange(emailTo.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim())));
                if (string.IsNullOrEmpty(emailCc) == false)
                {
                    mailMessage.Cc.AddRange(emailCc.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim())));
                }
                mailMessage.Subject = subject;
                var builder = new BodyBuilder();
                //CLS_Global_Class.Set_MailBody(builder, str_CSS_Class + htmlBody);

                if (coll_Attachment != null)
                {
                    /*foreach (var item in coll_Attachment)
                    {
                        if (File.Exists(item))
                            builder.Attachments.Add(item);
                    }*/

                    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
                    foreach (var item in coll_Attachment)
                    {
                        string rptMailFormat = configuration.GetSection("CommonSettings").GetValue<string>("RptMailFormat");

                        htmlBody = rptMailFormat.Replace("#mailBody#", htmlBody);

                        string attachmentUrl = configuration.GetConnectionString("apiUrl");

                        int pos = item.LastIndexOf("/") + 1;
                        string filename = item.Substring(pos, item.Length - pos);

                        var url = attachmentUrl + "/WebGenAddAttachment/DownloadRptFile?filename=" + filename;
                        var attachmentLink = "<a target = \"_blank\" rel =\"noopener noreferrer\" href =\"" + url + "\">Click here</a>";

                        htmlBody = htmlBody.Replace("#downloadText#", attachmentLink);
                        CLS_Global_Class.Set_MailBody(builder, str_CSS_Class + htmlBody);
                    }
                }
                else
                {
                    CLS_Global_Class.Set_MailBody(builder, str_CSS_Class + htmlBody);
                }
                mailMessage.Body = builder.ToMessageBody();

                QueueInput(new CLS_Email_Queue_BE()
                {
                    mailMessage = mailMessage,
                    obj_MailSetting = obj_MailSetting,
                });


                #endregion

                CLS_Global_Class.LogInformation("Email notification sent enqueue to " + emailTo);
                return str_From_Email_Id;
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("******* Email sending error *******", ex);
                throw new InvalidOperationException(ex.Message);
            }
        }
        //binu end


        public static async Task<string> SendEmailUsingOrgOrSender(int? orgId, int? senderProfileId, string emailTo, string emailCc, string subject, string htmlBody, aditaas_v5Context db_context, List<string> coll_Attachment = null)
        {
            if(senderProfileId.GetValueOrDefault(0) == 0)
            {
                return await SendEmailAsync(orgId, emailTo, emailCc, subject, htmlBody, db_context, coll_Attachment);
            }
            else
            {
                return await SendEmailBySenderProfileIdAsync(senderProfileId, emailTo, emailCc, subject, htmlBody, db_context, coll_Attachment);
            }
        }


    }
}
