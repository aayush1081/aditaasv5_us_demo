using aditaas_v5.Classes.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using aditaas_v5.Classes;
using aditaas_v5.Models;
using V5RESTApi.Controllers;
using V5WinService.Classes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;

namespace V5WinService.BusinessLogic
{
    public static class CLS_Report_Scheduler_Engine
    {

        public static async Task Set_Scheduler_Event(SignalR_MessageBE objNotifyBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                #region Cancel Pending Job

                foreach (var item in db_Context.TblScheduleEvent.Where(a => a.AdditionalRefId == objNotifyBE.additionalRefId
                                                                    && a.EventType == (int)Enum_EventTypes.RptScheduler
                                                                    && a.Status == (int)Enum_Schedule_Event_Status.Pending))
                    item.Status = (int)Enum_Schedule_Event_Status.Cancel;
                await db_Context.SaveChangesAsync();

                #endregion

                if (objNotifyBE.actionType == (int)Enum_ActionTypes.TicketCreate || objNotifyBE.actionType == (int)Enum_ActionTypes.TicketUpdate)
                {
                    var obj_RptSchBE = db_Context.TblRptReportScheduler.FirstOrDefault(a => a.ReportSchedulerId == objNotifyBE.additionalRefId);
                    Add_ScheduleEvent_Entry(obj_RptSchBE, db_Context);
                }
                else if (objNotifyBE.actionType == (int)Enum_ActionTypes.TicketDelete)
                {
                }
            }
        }

        public static async Task Start_Schedule_Event(TblScheduleEvent objSchEventBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                try
                {
                    var obj_RptSchBE = db_Context.TblRptReportScheduler.FirstOrDefault(a => a.ReportSchedulerId == objSchEventBE.AdditionalRefId);
                    if (obj_RptSchBE != null)
                    {
                        #region Get OrgId From Scheduler Creater Id 

                        int? orgId = db_Context.TblMstUserOrgMap.Where(a => a.UserId == obj_RptSchBE.CreatedById).Select(a => a.OrgId).FirstOrDefault();

                        #endregion

                        var obj_ReportBE = db_Context.TblRptReport.FirstOrDefault(a => a.ReportId == obj_RptSchBE.ReportId);
                        var str_FileName = GlobalClass.Get_ReportFileName(obj_ReportBE.Name, obj_RptSchBE.ReportFormat);
                        byte[] fileData = null;
                        if (obj_RptSchBE.ReportFormat.ToUpper() == "EXCEL")
                        {
                            fileData = await CLS_v4API.Get_ApiRequest_ByteArray(string.Format("TblRptReports/Get_Report_Export_Excel/{0}/{1}", obj_RptSchBE.ReportId, obj_RptSchBE.CreatedById));
                        }
                        else if (obj_RptSchBE.ReportFormat.ToUpper() == "PDF")
                        {
                            fileData = await CLS_v4API.Get_ApiRequest_ByteArray(string.Format("TblRptReports/Get_Report_Export_Pdf/{0}/{1}", obj_RptSchBE.ReportId, obj_RptSchBE.CreatedById));
                        }
                        //File.WriteAllBytes(str_FileName, fileData);
                        await uploadToBlob(str_FileName, fileData);

                        var Coll_Rpt_Data_File = new List<string>();
                        Coll_Rpt_Data_File.Add(str_FileName);

                        //below code commnted by deepak in code review
                        //await CLS_EmailSender.SendEmailAsync(orgId, obj_RptSchBE.EmailTo, obj_RptSchBE.EmailCc, obj_RptSchBE.EmailSubject, obj_RptSchBE.EmailBody, db_Context, Coll_Rpt_Data_File);

                        //Added by deepak
                        await CLS_EmailSender.SendEmailBySenderProfileIdAsync(obj_RptSchBE.SenderProfileId, obj_RptSchBE.EmailTo, obj_RptSchBE.EmailCc, obj_RptSchBE.EmailSubject, obj_RptSchBE.EmailBody, db_Context, Coll_Rpt_Data_File);

                        //binu strt
                        //below code commnted by deepak in code review
                        //if (obj_RptSchBE.ReportFormat.ToUpper() == "EXCEL")
                        //{
                        //    await CLS_EmailSender.SendEmailBySenderProfileIdAsync(obj_RptSchBE.SenderProfileId, obj_RptSchBE.EmailTo, obj_RptSchBE.EmailCc, obj_RptSchBE.EmailSubject, obj_RptSchBE.EmailBody, db_Context, Coll_Rpt_Data_File);
                        //}
                        //else if (obj_RptSchBE.ReportFormat.ToUpper() == "PDF")
                        //{
                        //    await CLS_EmailSender.SendEmailAsync(orgId, obj_RptSchBE.EmailTo, obj_RptSchBE.EmailCc, obj_RptSchBE.EmailSubject, obj_RptSchBE.EmailBody, db_Context, Coll_Rpt_Data_File);
                        //}
                        //binu end
                        var obj_MessageBE = new SignalR_MessageBE()
                        {
                            actionType = objSchEventBE.ActionType,
                            moduleId = objSchEventBE.ModuleId,
                            eventType = objSchEventBE.EventType,
                            additionalRefId = objSchEventBE.AdditionalRefId,
                            messageText = string.Format("Report: {0} email send successfully..", obj_ReportBE.Name),
                        };
                        CLS_SignalR_Connection.SendWebNotification(obj_MessageBE, db_Context, obj_RptSchBE.CreatedById);
                        obj_RptSchBE.LastExecutedOn = DateTime.UtcNow;
                        db_Context.Entry(obj_RptSchBE).Property(x => x.LastExecutedOn).IsModified = true;

                        var next_ScheduleDate = TblRptReportSchedulesController.Get_Next_Report_Schedule_Date(obj_RptSchBE);
                        if (obj_RptSchBE.NextExecutionOn != next_ScheduleDate)
                        {
                            obj_RptSchBE.NextExecutionOn = next_ScheduleDate;
                            if (next_ScheduleDate != null)
                                Add_ScheduleEvent_Entry(obj_RptSchBE, db_Context);
                        }
                        objSchEventBE.Status = (int)Enum_Schedule_Event_Status.Success;
                    }
                    else
                        objSchEventBE.Status = (int)Enum_Schedule_Event_Status.Cancel;
                    db_Context.Entry(objSchEventBE).State = EntityState.Modified;

                    
                    await db_Context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    objSchEventBE.Status = (int)Enum_Schedule_Event_Status.Fail;
                    objSchEventBE.ErrorMessage = ex.Message;
                    db_Context.Entry(objSchEventBE).State = EntityState.Modified;
                    db_Context.SaveChanges();
                    CLS_Global_Class.LogError(String.Format("*****Job Execution Error*****Job ID : {0}", objSchEventBE.ScheduleEventId), ex);
                    //throw ex;
                }
            }
        }

        private static void Add_ScheduleEvent_Entry(TblRptReportScheduler obj_BE, aditaas_v5Context db_Context)
        {
            var objScheduleBE = new TblScheduleEvent()
            {
                AdditionalRefId = obj_BE.ReportSchedulerId,
                ModuleId = (int)Enum_ModuleTypes.None,
                CreatedOn = DateTime.UtcNow,
                ScheduledOn = obj_BE.NextExecutionOn,
                Status = (int)Enum_Schedule_Event_Status.Pending,
                EventType = (int)Enum_EventTypes.RptScheduler,
            };
            db_Context.TblScheduleEvent.Add(objScheduleBE);
            db_Context.SaveChanges();
        }

        private static async Task<bool> uploadToBlob(string fileName, byte[] fileData)
        {
            try
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
                var connectionString = configuration.GetSection("Blobstorage").GetValue<string>("ConnectionString");
                var containerName = configuration.GetSection("Blobstorage").GetValue<string>("ContainerName");
                var parentFolderName = configuration.GetSection("Blobstorage").GetValue<string>("ParentFolderName");

                var containerClient = new BlobContainerClient(connectionString, containerName);
                await containerClient.CreateIfNotExistsAsync();

                BlobClient blobClient = containerClient.GetBlobClient(parentFolderName + @"\" + "Report Attachment" + @"\" + fileName);

                MemoryStream ms = new MemoryStream(fileData);
                await blobClient.UploadAsync(ms, new BlobHttpHeaders { ContentType = "application/octet-stream" });

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static async void ExportReportNSendMail(Object stateInfo)
        {
            using (var dbContext = CLS_Global_Class.Get_db_Context())
            {
                try
                {
                    var objSchedules = dbContext.TblRptScheduleExport.Where(a => a.Status == (int)Enum_Schedule_Event_Status.Pending).ToList();

                    CLS_Global_Class.apiToken = await CLS_v4API.Get_ApiToken();
                    foreach (var objSchedule in objSchedules)
                    {
                        try
                        {
                            objSchedule.Status = (int)Enum_Schedule_Event_Status.Processing;
                            dbContext.Entry(objSchedule).State = EntityState.Modified;
                            dbContext.SaveChanges();

                            int? orgId = dbContext.TblMstUserOrgMap.Where(a => a.UserId == objSchedule.CreatedById).Select(a => a.OrgId).FirstOrDefault();
                            var objReportBE = dbContext.TblRptReport.FirstOrDefault(a => a.ReportId == objSchedule.ReportId);
                            var str_FileName = GlobalClass.GetExportReportFileName(objReportBE.Name, objSchedule.ExportType);
                            byte[] fileData = null;
                            if (objSchedule.ExportType.ToUpper() == "EXCEL")
                            {
                                fileData = await CLS_v4API.Get_ApiRequest_ByteArray(string.Format("TblRptReports/Get_Report_Export_Excel/{0}/{1}", objSchedule.ReportId, objSchedule.CreatedById));
                            }
                            else if (objSchedule.ExportType.ToUpper() == "PDF")
                            {
                                fileData = await CLS_v4API.Get_ApiRequest_ByteArray(string.Format("TblRptReports/Get_Report_Export_Pdf/{0}/{1}", objSchedule.ReportId, objSchedule.CreatedById));
                            }

                            
                            var multipartFormDataContent = new MultipartFormDataContent();                            
                            var fileContent = new ByteArrayContent(fileData);
                            multipartFormDataContent.Add(fileContent, "file", str_FileName);

                            var result = await CLS_v4API.PostFileData("TblRptReportSchedules/UploadExportedFile", multipartFormDataContent);

                            var downloadLink = CLS_Global_Class.ExportBaseURL + "TblRptReportSchedules/DownloadFile/" + objSchedule.ExportId;

                            var emailTemplate = dbContext.TblCnfEmailTemplate.Where(a => a.TemplateType == "ExportReportMail").FirstOrDefault();

                            var mailBody = emailTemplate.Body.Replace("#ReportLink#", downloadLink);
                            var subject = emailTemplate.Subject.Replace("#ReportName#", objReportBE.Name);

                            await CLS_EmailSender.SendEmailBySenderProfileIdAsync(objSchedule.SenderProfileId, objSchedule.MailId, null, subject, mailBody, dbContext);
                            //await CLS_EmailSender.SendEmailSimpleAsync(orgId, objSchedule.MailId, null, subject, mailBody, dbContext);

                            objSchedule.Status = (int)Enum_Schedule_Event_Status.Success;
                            objSchedule.FileName = str_FileName;
                            objSchedule.CompletedOn = DateTime.UtcNow;
                            dbContext.Entry(objSchedule).State = EntityState.Modified;
                            dbContext.SaveChanges();

                            //File.WriteAllBytes(str_FileName, fileData);
                            //await CLS_EmailSender.SendEmailAsync(orgId, obj_RptSchBE.EmailTo, obj_RptSchBE.EmailCc, obj_RptSchBE.EmailSubject, obj_RptSchBE.EmailBody, db_Context, Coll_Rpt_Data_File);
                        }
                        catch (Exception iex)
                        {
                            objSchedule.Status = (int)Enum_Schedule_Event_Status.Fail;
                            objSchedule.ErrorMsg = iex.Message;
                            dbContext.Entry(objSchedule).State = EntityState.Modified;
                            dbContext.SaveChanges();
                            CLS_Global_Class.LogError(String.Format("*****Report export error*****Export ID : {0}", objSchedule.ExportId), iex);
                        }                        
                    }                    
                }
                catch (Exception ex)
                {                   
                    CLS_Global_Class.LogError("ExportReportNSendMail", ex);                 
                }
            }
        }
    }
}
