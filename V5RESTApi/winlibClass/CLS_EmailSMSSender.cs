using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
//using MimeKit;
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
using static V5WinService.Classes.CLS_EmailSender;
using MimeKit;

namespace V5WinService.Classes
{

    public static class CLS_EmailSMSSender
    {

        public static async Task<string> SendSMSViaEmailAsync(int? orgId, string emailTo, string subject, string htmlBody, aditaas_v5Context db_context)
        {
            var str_From_EmailId = "";
            try
            {
                var obj_MailSetting = CLS_Global_Class.Get_EmailSetting_By_Org(orgId, db_context);
                if (string.IsNullOrEmpty(emailTo) == true)
                    return str_From_EmailId;
                str_From_EmailId = obj_MailSetting.SenderMail;

                #region Send Mail From SMTP

                //var SmtpServer1 = new System.Net.Mail.SmtpClient(mailServer);
                var mailMessage = new MimeMessage();
                //mailMessage.From = new System.Net.Mail.MailAddress(senderMail, senderName);
                mailMessage.To.AddRange(emailTo.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim() + CLS_Global_Class.emailSMSSettings.SMSProvideCode)));
                //foreach (var item in emailTo.Split(",").Distinct())
                //    mailMessage.To.Add(item + CLS_Global_Class.emailSMSSettings.SMSProvideCode);
                mailMessage.Subject = subject;
                var builder = new BodyBuilder();
                CLS_Global_Class.Set_MailBody(builder, htmlBody);
                builder.HtmlBody = null;
                builder.TextBody = htmlBody;
                mailMessage.Body = builder.ToMessageBody();
                //mailMessage.IsBodyHtml = true;
                CLS_EmailSender.QueueInput(new CLS_Email_Queue_BE()
                {
                    mailMessage = mailMessage,
                    obj_MailSetting = obj_MailSetting,
                });
               

                #endregion

                CLS_Global_Class.LogInformation("Email SMS notification enqueue to " + emailTo);

                return str_From_EmailId;
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("******* Email SMS sending error   *******", ex);
                throw new InvalidOperationException(ex.Message);
            }
        }

    }
}
