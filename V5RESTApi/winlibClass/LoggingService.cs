using aditaas_v5.BusinessLogic.KendoGrid;
using aditaas_v5.BusinessLogics;
using aditaas_v5.Classes;
using aditaas_v5.Controllers;
using aditaas_v5.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using V5WinService.BusinessLogic;
using V5WinService.Classes;

namespace V5WinService
{
    public class LoggingService : BackgroundService
    {

        //private void Log(string logMessage)
        //{
        //    string _logFileLocation = string.Format(@"C:\temp\servicelog_{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
        //    Directory.CreateDirectory(Path.GetDirectoryName(_logFileLocation));
        //    File.AppendAllText(_logFileLocation, DateTime.UtcNow.ToString() + " : " + logMessage + Environment.NewLine);
        //}

        //static Timer mySLATimer = null;
        static System.Timers.Timer mySchedulerTimer = null;
        static DateTime dt_PrevDate = DateTime.Today;

        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        protected void OnStart(string[] args)
        {
            CLS_Global_Class.LogInformation("Service Started");

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
            var str_dbConnection = configuration.GetConnectionString("DefaultConnection");
            if (str_dbConnection == "FirstRunConfig")
            {
                FileSystemWatcher finf = new FileSystemWatcher(AppDomain.CurrentDomain.BaseDirectory);
                finf.EnableRaisingEvents = true;
                finf.Changed += Finf_Changed;
                //base.OnStart(args);
                return;
            }
            Service_Start_ProcessAsync().Wait();
            //base.OnStart(args);
        }

        private void Finf_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (e.Name.Contains("appsettings.json"))
                {
                    System.Threading.Thread.Sleep(5000);
                    //System.Diagnostics.Process process = new System.Diagnostics.Process();
                    //process.StartInfo.FileName = "cmd";
                    //process.StartInfo.Arguments = "/c net stop \"V5WinService\" & net start \"V5WinService\"";
                    //process.Start();
                }
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("Watch file !!", ex);
            }
        }

        public void OnStartedDebug()
        {
            OnStart(null);
            //Service_Start_ProcessAsync().Wait();
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        protected void OnStop()
        {

            CLS_Global_Class.LogInformation("Service Stoppped");
            try
            {
                if (CLS_EmailSender.workerThread != null && CLS_EmailSender.workerThread.IsAlive)
                    CLS_EmailSender.workerThread.Abort();

            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("Email sending Thread Error :- " + ex);
            }
            //base.OnStop();
        }

        protected void OnPause()
        {
            CLS_Global_Class.LogInformation("Service Pausing");
            //base.OnPause();
        }

        static System.Threading.TimerCallback tcbScheduled1;
        static System.Threading.Timer stateTimerScheduled1;

        static System.Threading.TimerCallback slaTimerCallBack;
        static System.Threading.Timer slaTimerScheduled;

        //static System.Threading.TimerCallback archiveTimerCallBack;
        //static System.Threading.Timer archiveTimerScheduled;

        static System.Threading.TimerCallback exportRptTimerCallBack;
        static System.Threading.Timer exportRptTimerScheduled;


        static System.Threading.Timer azureADScheduleTimer;

        public static Dictionary<int, System.Threading.Timer> dicTimerScheduled = new Dictionary<int, System.Threading.Timer>();
        public static Dictionary<int, System.Threading.Timer> dicAzureADTimerScheduled = new Dictionary<int, System.Threading.Timer>();

        public static async Task Service_Start_ProcessAsync()
        {

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
            var appSettings = configuration.GetSection("AppSettings");

        #region Database connection start

        lblDbConnect:
            try
            {
                using (var context = CLS_Global_Class.Get_db_Context())
                {
                    CLS_Global_Class.LogInformation("Connecting database");
                    var data = await context.TblMstUser.CountAsync();
                    CLS_Global_Class.LogInformation(" : Done");
                }
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("Database Connecting  error !!", ex);
                System.Threading.Thread.Sleep(1000 * 10);
                goto lblDbConnect;
            }

        #endregion


        #region Get API Token

        lblApiToken:
            try
            {
                CLS_Global_Class.LogInformation("Connecting API Source ");
                CLS_Global_Class.apiToken = await CLS_v4API.Get_ApiToken();
                CLS_Global_Class.LogInformation("  : Done");
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("API Connecting  error..", ex);
                System.Threading.Thread.Sleep(1000 * 10);
                goto lblApiToken;
            }

        #endregion

        #region SignalR connection start

        lblSignalRConnect:
            try
            {
                await CLS_SignalR_Connection.Start_ConnectionAsync();
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("SignalR Connecting  error", ex);
                System.Threading.Thread.Sleep(1000 * 10);
                goto lblSignalRConnect;
            }

            #endregion

            #region Scheduler Timer Start

            try
            {
                mySchedulerTimer = new System.Timers.Timer();
                mySchedulerTimer.Interval = 1000 * 30;
                mySchedulerTimer.Elapsed += new ElapsedEventHandler(SchedulerTimer_Event);
                SchedulerTimer_Event(mySchedulerTimer, null);
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("Error Scheduler Timer Start", ex);
            }

            #endregion
          
            #region SLA Calculation

            int SLAFirstStartDelayMin = appSettings.GetValue<int>("SLAFirstStartDelayMin");
            slaTimerCallBack = CalculateTicketSLA;
            slaTimerScheduled = new System.Threading.Timer(slaTimerCallBack, null, new TimeSpan(0, SLAFirstStartDelayMin, 0), new TimeSpan(0, CLS_Global_Class.SLAIntervalMin, 0));

            #endregion

            #region Email Manager Start
            try
            {
                CLS_Mail_Manager_Engine.Set_Scheduler_Event();
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("Error Email Manager Start", ex);
            }
            #endregion

            #region Report Export Job

            exportRptTimerCallBack = ExportReportNSendMail;
            exportRptTimerScheduled = new System.Threading.Timer(exportRptTimerCallBack, null, new TimeSpan(0, 0, 0), new TimeSpan(0, CLS_Global_Class.ExportCheckIntervalMin, 0));
            #endregion

            #region Azure AD Sync Start
            var LDAPSyncSettings = configuration.GetSection("LDAPSync");
            var IsADSyncEnabled = LDAPSyncSettings.GetValue<bool>("IsADSyncEnabled");
            if (IsADSyncEnabled)
            {
                using (var db_Context = CLS_Global_Class.Get_db_Context())
                {
                    var adList = db_Context.TblCnfAzureAd.Where(w => w.IsActive == true && w.ScheduleTime != null && w.RecurrenceHour != null).ToList();
                    adList.ForEach(tblCnfAzureAd =>
                    {
                        var startTime1 = tblCnfAzureAd.ScheduleTime;
                        var Interval = tblCnfAzureAd.RecurrenceHour;

                        DateTime targetDate1 = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy") + " " + startTime1.Value.ToString("HH:mm"));
                        TimeSpan delayTime1 = targetDate1 - DateTime.Now;

                        if (delayTime1.CompareTo(TimeSpan.Zero) < 0)
                            targetDate1 = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy") + " " + startTime1.Value.ToString("HH:mm"));
                        delayTime1 = targetDate1 - DateTime.Now;

                        azureADScheduleTimer = new System.Threading.Timer(SyncAzureAD, tblCnfAzureAd, delayTime1, new TimeSpan(Interval.Value, 0, 0));
                        dicAzureADTimerScheduled.Add(tblCnfAzureAd.AzureAdId, azureADScheduleTimer);

                        //SyncAzureAD(tblCnfAzureAd);
                    });
                }
            }
            #endregion

            #region AD Sync Start
            //Schedule 1 Start--------------------------------------------------------
            if (IsADSyncEnabled)
            {
                using (var db_Context = CLS_Global_Class.Get_db_Context())
                {
                    var adList = db_Context.TblCnfAdLdap.Where(w => w.IsActive == true && w.ScheduleTime != null && w.RecurrenceHour != null).ToList();

                    foreach (var adServer in adList)
                    {
                        try
                        {
                            //ScheduledADTask1(adServer);
                            var startTime1 = adServer.ScheduleTime;
                            var Interval = adServer.RecurrenceHour;

                            DateTime targetDate1 = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy") + " " + startTime1.Value.ToString("HH:mm"));
                            TimeSpan delayTime1 = targetDate1 - DateTime.Now;

                            if (delayTime1.CompareTo(TimeSpan.Zero) < 0)
                                targetDate1 = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy") + " " + startTime1.Value.ToString("HH:mm"));
                            delayTime1 = targetDate1 - DateTime.Now;

                            stateTimerScheduled1 = new System.Threading.Timer(ScheduledADTask1, adServer, delayTime1, new TimeSpan(Interval.Value, 0, 0));
                            dicTimerScheduled.Add(adServer.AdLdapId, stateTimerScheduled1);
                        }
                        catch (Exception ex)
                        {
                            CLS_Global_Class.LogInformation(ex.Message);
                        }
                    }
                }
            }
            //SyncActiveDirectory();
            //Schedule 1 End --------------------------------------------------------
            #endregion

            #region Data Archive

            //int ArchiveChkIntervalMin = appSettings.GetValue<int>("ArchiveChkIntervalMin");
            //archiveTimerCallBack = CLS_Archive_Data_Engine.Start_ArchiveData;
            //archiveTimerScheduled = new System.Threading.Timer(archiveTimerCallBack, null, new TimeSpan(0, 0, 0), new TimeSpan(0, ArchiveChkIntervalMin, 0));
            #endregion

        }


        private static void ExportReportNSendMail(object state)
        {
            exportRptTimerScheduled.Change(Timeout.Infinite, Timeout.Infinite); //Stop Timer
            CLS_Report_Scheduler_Engine.ExportReportNSendMail(state);
            exportRptTimerScheduled.Change(new TimeSpan(0, CLS_Global_Class.ExportCheckIntervalMin, 0), new TimeSpan(0, CLS_Global_Class.ExportCheckIntervalMin, 0));
        }

        public static void CalculateTicketSLA(Object stateInfo)
        {
            slaTimerScheduled.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite); //Stop Timer
            CLS_SLA_Calculation_Engine.Process_Calculate_TicketSLA();

            slaTimerScheduled.Change(new TimeSpan(0, CLS_Global_Class.SLAIntervalMin, 0), new TimeSpan(0, CLS_Global_Class.SLAIntervalMin, 0));
        }
        public static void ScheduledADTask1(Object stateInfo)
        {
            var adServer = (TblCnfAdLdap)stateInfo;
            SyncActiveDirectory(adServer);
        }

        protected static void SyncAzureAD(Object stateInfo)
        {
            internalSyncAzureADAsync(stateInfo).Wait();
        }
        protected static async Task internalSyncAzureADAsync(Object stateInfo)
        {
            try
            {
                var tblCnfAzureAd = (TblCnfAzureAd)stateInfo;

                int syncCount = 0;
                CLS_Global_Class.LogInformation("Azure AD Sync started for Azure AD");
                using (var db_Context = CLS_Global_Class.Get_db_Context())
                {
                    var sytemAdminId = (int)GlobalClass.Get_UserId_System_Admin(db_Context);

                    IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                            .Create(tblCnfAzureAd.ClientId)
                            .WithTenantId(tblCnfAzureAd.TenantId)
                            .WithClientSecret(tblCnfAzureAd.ClientSecret)
                            .Build();

                    ClientCredentialProvider authenticationProvider = new ClientCredentialProvider(confidentialClientApplication);
                    GraphServiceClient graphServiceClient = new GraphServiceClient(authenticationProvider);

                    //List<User> users = new List<User>();

                    //var result = await graphServiceClient.Users.Request().Filter("accountEnabled eq true").Select("onPremisesSamAccountName,mail,userPrincipalName,givenName,displayName,businessPhones,surname,officeLocation,companyName,accountEnabled,state,city,streetAddress,postalCode,country,mobilePhone,manager").GetAsync();
                    var result = await graphServiceClient.Users.Request().Expand(u => u.Manager).Select("onPremisesSamAccountName,mail,userPrincipalName,givenName,displayName,businessPhones,surname,officeLocation,companyName,accountEnabled,state,city,streetAddress,postalCode,country,mobilePhone,manager").GetAsync();

                    //users.AddRange(result.CurrentPage);
                    do
                    {
                        foreach (var item in result.CurrentPage)
                        {
                            try
                            {
                                if(item.AccountEnabled.GetValueOrDefault(true))
                                {
                                    var isEditRec = false;
                                    TblTrnLdapStaging userRecord;
                                    string Samaccountname = "";
                                    //Samaccountname = item.UserPrincipalName;
                                    Samaccountname = item.OnPremisesSamAccountName;
                                    var mail = (item.Mail == null) ? item.UserPrincipalName : item.Mail;

                                    if (String.IsNullOrEmpty(Samaccountname)) Samaccountname = item.UserPrincipalName;

                                    userRecord = db_Context.TblTrnLdapStaging.Where(a => a.Samaccountname.ToLower() == Samaccountname.ToLower() && a.OrgId == tblCnfAzureAd.OrgId).FirstOrDefault();
                                    if (userRecord == null)
                                    {
                                        userRecord = new TblTrnLdapStaging();
                                        isEditRec = false;
                                    }
                                    else
                                        isEditRec = true;

                                    userRecord.Samaccountname = Samaccountname;

                                    //foreach (var fieldmap in fieldMapping)
                                    //{
                                    //    if (fieldmap.AdFieldName.ToLower() != adServer.LoginAttribute)
                                    //    {
                                    //        if (result1.Properties[fieldmap.AdFieldName].Count > 0)
                                    //        {
                                    //            var property = typeof(TblTrnLdapStaging).GetProperty(fieldmap.AditaasFieldName);
                                    //            property.SetValue(userRecord, result1.Properties[fieldmap.AdFieldName][0].ToString());
                                    //        }
                                    //    }
                                    //}

                                    var FirstName = (item.GivenName == null) ? item.DisplayName : item.GivenName;

                                    userRecord.Telephonenumber = item.BusinessPhones.FirstOrDefault();
                                    userRecord.Mail = mail;
                                    userRecord.FirstName = FirstName;
                                    userRecord.LastName = (item.Surname == null ? "" : item.Surname);
                                    userRecord.SiteName = item.OfficeLocation;
                                    userRecord.Company = item.CompanyName;
                                    userRecord.Useraccountcontrol = item.AccountEnabled.GetValueOrDefault(true) ? "A" : "I";
                                    userRecord.AccountStatus = (item.AccountEnabled.GetValueOrDefault(true) ? "Enabled" : "Disabled");
                                    userRecord.State = item.State;
                                    userRecord.City = item.City;
                                    userRecord.Address = item.StreetAddress;
                                    userRecord.PostalCode = item.PostalCode;
                                    userRecord.Country = item.Country;
                                    //userRecord.IpPhone = item.phon
                                    userRecord.Mobile = item.MobilePhone;
                                    userRecord.Description = "";

                                    var manager = "";
                                    if(item.Manager != null)
                                    {
                                        manager = ((User)item.Manager).OnPremisesSamAccountName;
                                        if (string.IsNullOrEmpty(manager)) Samaccountname = ((User)item.Manager).UserPrincipalName;
                                    }

                                    //if (result1.Properties["mail"].Count > 0) userRecord.Mail = result1.Properties["mail"][0].ToString();
                                    //if (result1.Properties["givenName"].Count > 0) userRecord.FirstName = result1.Properties["givenName"][0].ToString();
                                    //if (result1.Properties["sn"].Count > 0) userRecord.LastName = result1.Properties["sn"][0].ToString();
                                    //if (result1.Properties["physicalDeliveryOfficeName"].Count > 0) userRecord.SiteName = result1.Properties["physicalDeliveryOfficeName"][0].ToString();
                                    //if (result1.Properties["company"].Count > 0) userRecord.Company = result1.Properties["company"][0].ToString();
                                    //if (result1.Properties["userAccountControl"].Count > 0) userRecord.Useraccountcontrol = result1.Properties["userAccountControl"][0].ToString();
                                    //if (result1.Properties["st"].Count > 0) userRecord.State = result1.Properties["st"][0].ToString();
                                    //if (result1.Properties["l"].Count > 0) userRecord.City = result1.Properties["l"][0].ToString();
                                    //if (result1.Properties["streetAddress"].Count > 0) userRecord.Address = result1.Properties["streetAddress"][0].ToString();
                                    //if (result1.Properties["postalCode"].Count > 0) userRecord.PostalCode = result1.Properties["postalCode"][0].ToString();
                                    //if (result1.Properties["c"].Count > 0) userRecord.Country = result1.Properties["c"][0].ToString();
                                    //if (result1.Properties["ipPhone"].Count > 0) userRecord.IpPhone = result1.Properties["ipPhone"][0].ToString();
                                    //if (result1.Properties["mobile"].Count > 0) userRecord.Mobile = result1.Properties["mobile"][0].ToString();
                                    //if (result1.Properties["description"].Count > 0) userRecord.Description = result1.Properties["description"][0].ToString();

                                    userRecord.OrgId = tblCnfAzureAd.OrgId;

                                    if (isEditRec)
                                    {
                                        var isAnyChange = db_Context.TblTrnLdapStaging.Where(a => a.Mail.ToLower() == userRecord.Mail.ToLower() && a.OrgId == userRecord.OrgId &&
                                        (a.Telephonenumber != userRecord.Telephonenumber || a.FirstName != userRecord.FirstName
                                        || a.LastName != userRecord.LastName || a.SiteName != userRecord.SiteName || a.SiteName != userRecord.SiteName
                                        || a.Useraccountcontrol != userRecord.Useraccountcontrol || a.Mobile != userRecord.Mobile
                                        || a.Description != userRecord.Description || a.Samaccountname != userRecord.Samaccountname || a.ManagerUsername != a.ManagerUsername)).Any();

                                        if (isAnyChange)
                                        {
                                            userRecord.IsModified = true;
                                            db_Context.TblTrnLdapStaging.Update(userRecord);
                                            db_Context.SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        if (userRecord.Useraccountcontrol == "A")
                                        {
                                            userRecord.IsModified = true;
                                            db_Context.TblTrnLdapStaging.Add(userRecord);
                                            db_Context.SaveChanges();
                                        }
                                    }
                                }
                            }
                            catch (Exception adex)
                            {
                                CLS_Global_Class.LogInformation(adex.Message);
                            }
                        }
                        if (result.NextPageRequest != null)
                            result = await result.NextPageRequest.GetAsync();
                    } while (result.NextPageRequest != null);



                    CLS_Global_Class.LogInformation("AD Sync - Add / Update users from staging tables completed for " + tblCnfAzureAd.OrgId);

                    try
                    {
                        #region Add / Update users from staging tables
                        //var rowsAffected = db_Context.Database.ExecuteSqlCommand("update tbl_mst_user set azure_ad_id = ldap_id where isnull(ldap_id, 0) > 0 and azure_ad_id is null");
                        var stagedList = db_Context.TblTrnLdapStaging.Where(a => a.OrgId == tblCnfAzureAd.OrgId && a.IsModified == true).ToList();
                        foreach (var adRecord in stagedList)
                        {
                            try
                            {
                                var existsUserId = db_Context.TblMstUser.Where(a => a.EmailId.ToLower() == adRecord.Mail.ToLower() && (a.Provider.ToLower() == "azuread" || a.Provider.ToLower() == "activedirectory") && a.AzureAdId == tblCnfAzureAd.AzureAdId).Select(s => s.UserId).FirstOrDefault();
                                var isUserExists = (existsUserId > 0);
                                if (string.IsNullOrEmpty(adRecord.SiteName)) adRecord.SiteName = "NO SITE";
                                if (string.IsNullOrEmpty(adRecord.Country)) adRecord.Country = "NO COUNTRY";
                                if (string.IsNullOrEmpty(adRecord.State)) adRecord.State = "NO STATE";
                                if (string.IsNullOrEmpty(adRecord.City)) adRecord.City = "NO CITY";

                                var siteId = db_Context.TblMstSite.Where(a => a.Name.ToLower() == adRecord.SiteName.ToLower() && a.OrgId == tblCnfAzureAd.OrgId).Select(s => s.SiteId).FirstOrDefault();

                                if (siteId == 0)
                                {
                                    var countryId = db_Context.TblMstCountry.Where(a => a.ContName.ToLower() == adRecord.Country.ToLower()).Select(s => s.ContId).FirstOrDefault();
                                    if (countryId == 0)
                                    {
                                        var objcountry = new TblMstCountry();
                                        var newpkid = db_Context.TblMstCountry.Max(a => (int?)a.ContId);
                                        if (newpkid == null) newpkid = 0;
                                        newpkid++;

                                        objcountry.ContId = (int)newpkid;
                                        objcountry.ContName = adRecord.Country;
                                        db_Context.TblMstCountry.Add(objcountry);
                                        db_Context.SaveChanges();
                                        countryId = objcountry.ContId;
                                    }
                                    var stateId = db_Context.TblMstState.Where(a => a.StateName.ToLower() == adRecord.State.ToLower() && a.ContId == countryId).Select(s => s.StateId).FirstOrDefault();
                                    if (stateId == 0)
                                    {
                                        var objstate = new TblMstState();
                                        var newpkid = db_Context.TblMstState.Max(a => (int?)a.StateId);
                                        if (newpkid == null) newpkid = 0;
                                        newpkid++;

                                        objstate.StateId = (int)newpkid;
                                        objstate.StateName = adRecord.State;
                                        objstate.ContId = countryId;
                                        db_Context.TblMstState.Add(objstate);
                                        db_Context.SaveChanges();
                                        stateId = objstate.StateId;
                                    }
                                    var cityId = db_Context.TblMstCity.Where(a => a.CityName.ToLower() == adRecord.City.ToLower() && a.StateId == stateId && a.ContId == countryId).Select(s => s.CityId).FirstOrDefault();
                                    if (cityId == 0)
                                    {
                                        var objcity = new TblMstCity();
                                        var newpkid = db_Context.TblMstCity.Max(a => (int?)a.CityId);
                                        if (newpkid == null) newpkid = 0;
                                        newpkid++;

                                        objcity.CityId = (int)newpkid;
                                        objcity.CityName = adRecord.City;
                                        objcity.StateId = stateId;
                                        objcity.ContId = countryId;
                                        db_Context.TblMstCity.Add(objcity);
                                        db_Context.SaveChanges();
                                        cityId = objcity.CityId;
                                    }

                                    var objSite = new TblMstSite();
                                    objSite.Name = adRecord.SiteName;
                                    objSite.CreatedOn = DateTime.UtcNow;
                                    objSite.CreatedBy = sytemAdminId;
                                    objSite.IsActive = true;
                                    objSite.Name = adRecord.SiteName;
                                    objSite.OrgId = tblCnfAzureAd.OrgId;
                                    objSite.PrimaryAddr1 = (adRecord.Address == null ? "" : adRecord.Address);
                                    objSite.PrimaryCity = cityId;
                                    objSite.PrimaryCountry = countryId;
                                    objSite.PrimaryState = stateId;
                                    objSite.PrimaryZipcode = (adRecord.PostalCode == null ? "" : adRecord.PostalCode);
                                    db_Context.TblMstSite.Add(objSite);
                                    db_Context.SaveChanges();
                                    siteId = objSite.SiteId;
                                }

                                var departmentId = db_Context.TblMstDepartment.Where(a => a.Name.ToUpper() == "IT" && a.OrgId == tblCnfAzureAd.OrgId && a.IsDefault == true).Select(s => s.DepartmentId).FirstOrDefault();
                                var roleId = db_Context.TblMstRole.Where(a => a.Name.ToLower() == GlobalClass.GetConfigItem(db_Context, "SelfUserRole", tblCnfAzureAd.OrgId).Value.ToLower()).Select(s => s.RoleId).FirstOrDefault();

                                ContactDetails enduser = new ContactDetails();
                                enduser.userName = adRecord.Samaccountname;
                                enduser.contactNo = adRecord.Telephonenumber;
                                enduser.emailId = adRecord.Mail;
                                enduser.firstName = adRecord.FirstName;
                                enduser.lastName = adRecord.LastName;
                                enduser.isActive = (adRecord.Useraccountcontrol == "A");
                                enduser.mobile = adRecord.Mobile;
                                enduser.siteId = siteId;
                                enduser.azureAdId = tblCnfAzureAd.AzureAdId;
                                enduser.orgId = tblCnfAzureAd.OrgId;
                                enduser.provider = "AzureAd";

                                var isManagerUpdated = true;
                                if(!string.IsNullOrEmpty(adRecord.ManagerUsername))
                                {
                                    var managerId = db_Context.TblMstUser.Where(w => w.Name.ToLower() == adRecord.ManagerUsername).Select(s => s.UserId).FirstOrDefault();                                    
                                    if (managerId != 0)
                                        enduser.reportingTo = managerId;                                   
                                    else
                                        isManagerUpdated = false;
                                }

                                var objusercontroller = new TblMstUsersController(db_Context, null);
                                if (isUserExists)
                                {
                                    var exuser = (from curruser in db_Context.TblMstUser
                                                  join prof in db_Context.TblMstUserProfile on curruser.UserId equals prof.UserId
                                                  where curruser.UserId == existsUserId
                                                  select new
                                                  {
                                                      prof.DateFormat,
                                                      curruser.IsVip,
                                                      prof.Language,
                                                      prof.TimeFormat,
                                                      prof.TimeZone,
                                                      curruser.UserType
                                                  }).FirstOrDefault();


                                    enduser.dateFormat = exuser.DateFormat;
                                    enduser.isVip = exuser.IsVip;
                                    enduser.language = exuser.Language;
                                    enduser.timeFormat = exuser.TimeFormat;
                                    enduser.timezone = exuser.TimeZone;
                                    enduser.userType = exuser.UserType;
                                 
                                    enduser.userId = existsUserId;
                                    enduser.supGroups = db_Context.TblMstUserQueueMap.Where(q => q.UserId == existsUserId).Select(s => s.QueueId).ToArray();
                                    enduser.roles = db_Context.TblMstUserRoleMap.Where(r => r.UserId == existsUserId).Select(s => s.RoleId).ToArray();
                                    if (enduser.roles.Length == 0) enduser.roles = new int?[] { roleId };
                                    enduser.departments = db_Context.TblMstUserDeptMap.Where(d => d.UserId == existsUserId).Select(s => (int?)s.DepartmentId).ToArray();
                                    objusercontroller.pUpdateContact(sytemAdminId, enduser, true);
                                }
                                else
                                {
                                    enduser.dateFormat = "MM/dd/yyyy";
                                    enduser.isVip = false;
                                    enduser.language = "en";
                                    enduser.timeFormat = "HH:mm:ss";
                                    enduser.timezone = "US/Pacific";
                                    enduser.userType = "SELF";

                                    if (departmentId > 0)
                                        enduser.departments = new int?[] { departmentId };
                                    if (roleId > 0)
                                        enduser.roles = new int?[] { roleId };
                                    else
                                        enduser.roles = new int?[] { };

                                    objusercontroller.CreateContact(sytemAdminId, enduser);
                                }

                                if (isManagerUpdated)
                                    adRecord.IsModified = false;

                                db_Context.TblTrnLdapStaging.Update(adRecord);
                                db_Context.SaveChanges();

                                syncCount++;
                            }
                            catch (Exception stageex)
                            {
                                CLS_Global_Class.LogInformation(stageex.Message);
                            }
                        }
                        #endregion
                    }
                    catch (Exception adex)
                    {
                        CLS_Global_Class.LogInformation(adex.Message);
                    }
                    CLS_Global_Class.LogInformation("AD Sync completed for " + tblCnfAzureAd.OrgId + ", " + syncCount + " records synchronized");
                    syncCount = 0;

                }
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogInformation(ex.Message);
            }
        }
        protected static void SyncActiveDirectory(TblCnfAdLdap adServer)
        {
            int syncCount = 0;
            CLS_Global_Class.LogInformation("AD Sync started for " + adServer.AccountName);
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                var sytemAdminId = (int)GlobalClass.Get_UserId_System_Admin(db_Context);

                string rootDN;
                DirectoryEntry rootDSE;
                DirectoryEntry searchRoot;
                DirectoryEntry userEntry;
                DirectorySearcher searcher;
                IEnumerable<System.DirectoryServices.SearchResult> results;
                try
                {
                    var cr = new Crypto();
                    var adPassword = cr.DecryptStringFromBytes(Convert.FromBase64String(adServer.Password));

                    var hostName = adServer.HostName;
                    if (adServer.HostName.Contains(" "))
                    {
                        hostName = hostName.Split(" ")[0];
                    }
                    rootDSE = new DirectoryEntry(String.Format("LDAP://{0}/rootDSE", hostName), adServer.UserName, adPassword, AuthenticationTypes.Secure | AuthenticationTypes.Sealing | AuthenticationTypes.ServerBind);
                    rootDN = Convert.ToString(rootDSE.Properties["defaultNamingContext"].Value);
                    searchRoot = new DirectoryEntry(String.Format("LDAP://{0}/{1}", hostName, rootDN), adServer.UserName, adPassword, AuthenticationTypes.Secure | AuthenticationTypes.Sealing | AuthenticationTypes.ServerBind);
                    searcher = new DirectorySearcher(searchRoot);
                    searcher.Filter = "(&(objectClass=*)(sAMAccountName=*)(givenName=*))";

                    var fieldMapping = db_Context.TblCnfAdLdapFieldMap.Where(a => a.AdLdapId == adServer.AdLdapId).ToList();

                    searcher.PropertiesToLoad.Add(adServer.LoginAttribute);
                    foreach (var fieldmap in fieldMapping)
                    {
                        if (fieldmap.AdFieldName.ToLower() != adServer.LoginAttribute)
                        {
                            searcher.PropertiesToLoad.Add(fieldmap.AdFieldName);
                        }
                    }

                    searcher.SearchScope = SearchScope.Subtree;
                    searcher.CacheResults = false;
                    searcher.PageSize = 1000;

                    results = SafeFindAll(searcher);
                    #region Fetch data from AD
                    foreach (System.DirectoryServices.SearchResult result1 in results)
                    {
                        try
                        {
                            userEntry = result1.GetDirectoryEntry();
                            if (userEntry != null)
                            {
                                var isEditRec = false;
                                TblTrnLdapStaging userRecord;
                                string Samaccountname = "";
                                if (result1.Properties[adServer.LoginAttribute].Count > 0) Samaccountname = result1.Properties[adServer.LoginAttribute][0].ToString();

                                if (!String.IsNullOrEmpty(Samaccountname))
                                {
                                    userRecord = db_Context.TblTrnLdapStaging.Where(a => a.Samaccountname == Samaccountname && a.OrgId == adServer.OrgId).FirstOrDefault();
                                    if (userRecord == null)
                                    {
                                        userRecord = new TblTrnLdapStaging();
                                        isEditRec = false;
                                    }
                                    else
                                        isEditRec = true;

                                    userRecord.Samaccountname = Samaccountname;

                                    foreach (var fieldmap in fieldMapping)
                                    {
                                        if (fieldmap.AdFieldName.ToLower() != adServer.LoginAttribute)
                                        {
                                            if (result1.Properties[fieldmap.AdFieldName].Count > 0)
                                            {
                                                var property = typeof(TblTrnLdapStaging).GetProperty(fieldmap.AditaasFieldName);
                                                property.SetValue(userRecord, result1.Properties[fieldmap.AdFieldName][0].ToString());
                                            }
                                        }
                                    }

                                    //if (result1.Properties["telephoneNumber"].Count > 0) userRecord.Telephonenumber = result1.Properties["telephoneNumber"][0].ToString();
                                    //if (result1.Properties["mail"].Count > 0) userRecord.Mail = result1.Properties["mail"][0].ToString();
                                    //if (result1.Properties["givenName"].Count > 0) userRecord.FirstName = result1.Properties["givenName"][0].ToString();
                                    //if (result1.Properties["sn"].Count > 0) userRecord.LastName = result1.Properties["sn"][0].ToString();
                                    //if (result1.Properties["physicalDeliveryOfficeName"].Count > 0) userRecord.SiteName = result1.Properties["physicalDeliveryOfficeName"][0].ToString();
                                    //if (result1.Properties["company"].Count > 0) userRecord.Company = result1.Properties["company"][0].ToString();
                                    //if (result1.Properties["userAccountControl"].Count > 0) userRecord.Useraccountcontrol = result1.Properties["userAccountControl"][0].ToString();
                                    //if (result1.Properties["st"].Count > 0) userRecord.State = result1.Properties["st"][0].ToString();
                                    //if (result1.Properties["l"].Count > 0) userRecord.City = result1.Properties["l"][0].ToString();
                                    //if (result1.Properties["streetAddress"].Count > 0) userRecord.Address = result1.Properties["streetAddress"][0].ToString();
                                    //if (result1.Properties["postalCode"].Count > 0) userRecord.PostalCode = result1.Properties["postalCode"][0].ToString();
                                    //if (result1.Properties["c"].Count > 0) userRecord.Country = result1.Properties["c"][0].ToString();
                                    //if (result1.Properties["ipPhone"].Count > 0) userRecord.IpPhone = result1.Properties["ipPhone"][0].ToString();
                                    //if (result1.Properties["mobile"].Count > 0) userRecord.Mobile = result1.Properties["mobile"][0].ToString();
                                    //if (result1.Properties["description"].Count > 0) userRecord.Description = result1.Properties["description"][0].ToString();
                                    bool isDisabled = false;
                                    if (result1.Properties["userAccountControl"].Count > 0)
                                    {
                                        int userAccountControlValue = Convert.ToInt32(userEntry.Properties["userAccountControl"].Value);
                                        UserAccountControl userAccountControl = (UserAccountControl)userAccountControlValue;
                                        isDisabled = (userAccountControl & UserAccountControl.ACCOUNTDISABLE) == UserAccountControl.ACCOUNTDISABLE;

                                        userRecord.AccountStatus = (isDisabled ? "Disabled" : "Enabled");
                                        userRecord.Useraccountcontrol = (isDisabled ? "I" : "A");
                                    }
                                    userRecord.OrgId = adServer.OrgId;

                                    if (isEditRec)
                                    {
                                        var isAnyChange = db_Context.TblTrnLdapStaging.Where(a => a.Samaccountname == userRecord.Samaccountname && a.OrgId == userRecord.OrgId &&
                                        (a.Telephonenumber != userRecord.Telephonenumber || a.Mail != userRecord.Mail || a.FirstName != userRecord.FirstName
                                        || a.LastName != userRecord.LastName || a.SiteName != userRecord.SiteName || a.SiteName != userRecord.SiteName
                                        || a.Useraccountcontrol != userRecord.Useraccountcontrol || a.IpPhone != userRecord.IpPhone || a.Mobile != userRecord.Mobile
                                        || a.Description != userRecord.Description)).Any();

                                        if (isAnyChange)
                                        {
                                            userRecord.IsModified = true;
                                            db_Context.TblTrnLdapStaging.Update(userRecord);
                                            db_Context.SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        if (userRecord.Useraccountcontrol == "A")
                                        {
                                            userRecord.IsModified = true;
                                            db_Context.TblTrnLdapStaging.Add(userRecord);
                                            db_Context.SaveChanges();
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception adex)
                        {
                            CLS_Global_Class.LogInformation(adex.Message);
                        }
                    }
                    #endregion

                    CLS_Global_Class.LogInformation("AD Sync - Add / Update users from staging tables completed for " + adServer.AccountName);
                    #region Add / Update users from staging tables
                    var stagedList = db_Context.TblTrnLdapStaging.Where(a => a.OrgId == adServer.OrgId && a.IsModified == true).ToList();
                    foreach (var adRecord in stagedList)
                    {
                        try
                        {
                            var existsUserId = db_Context.TblMstUser.Where(a => a.Name.ToLower() == adRecord.Samaccountname.ToLower() && a.Provider.ToLower() == "activedirectory" && a.LdapId == adServer.AdLdapId).Select(s => s.UserId).FirstOrDefault();
                            var isUserExists = (existsUserId > 0);
                            if (string.IsNullOrEmpty(adRecord.SiteName)) adRecord.SiteName = "NO SITE";
                            if (string.IsNullOrEmpty(adRecord.Country)) adRecord.Country = "NO COUNTRY";
                            if (string.IsNullOrEmpty(adRecord.State)) adRecord.State = "NO STATE";
                            if (string.IsNullOrEmpty(adRecord.City)) adRecord.City = "NO CITY";

                            var siteId = db_Context.TblMstSite.Where(a => a.Name.ToLower() == adRecord.SiteName.ToLower() && a.OrgId == adServer.OrgId).Select(s => s.SiteId).FirstOrDefault();

                            if (siteId == 0)
                            {
                                var countryId = db_Context.TblMstCountry.Where(a => a.ContName.ToLower() == adRecord.Country.ToLower()).Select(s => s.ContId).FirstOrDefault();
                                if (countryId == 0)
                                {
                                    var objcountry = new TblMstCountry();
                                    var newpkid = db_Context.TblMstCountry.Max(a => (int?)a.ContId);
                                    if (newpkid == null) newpkid = 0;
                                    newpkid++;

                                    objcountry.ContId = (int)newpkid;
                                    objcountry.ContName = adRecord.Country;
                                    db_Context.TblMstCountry.Add(objcountry);
                                    db_Context.SaveChanges();
                                    countryId = objcountry.ContId;
                                }
                                var stateId = db_Context.TblMstState.Where(a => a.StateName.ToLower() == adRecord.State.ToLower() && a.ContId == countryId).Select(s => s.StateId).FirstOrDefault();
                                if (stateId == 0)
                                {
                                    var objstate = new TblMstState();
                                    var newpkid = db_Context.TblMstState.Max(a => (int?)a.StateId);
                                    if (newpkid == null) newpkid = 0;
                                    newpkid++;

                                    objstate.StateId = (int)newpkid;
                                    objstate.StateName = adRecord.State;
                                    objstate.ContId = countryId;
                                    db_Context.TblMstState.Add(objstate);
                                    db_Context.SaveChanges();
                                    stateId = objstate.StateId;
                                }
                                var cityId = db_Context.TblMstCity.Where(a => a.CityName.ToLower() == adRecord.City.ToLower() && a.StateId == stateId && a.ContId == countryId).Select(s => s.CityId).FirstOrDefault();
                                if (cityId == 0)
                                {
                                    var objcity = new TblMstCity();
                                    var newpkid = db_Context.TblMstCity.Max(a => (int?)a.CityId);
                                    if (newpkid == null) newpkid = 0;
                                    newpkid++;

                                    objcity.CityId = (int)newpkid;
                                    objcity.CityName = adRecord.City;
                                    objcity.StateId = stateId;
                                    objcity.ContId = countryId;
                                    db_Context.TblMstCity.Add(objcity);
                                    db_Context.SaveChanges();
                                    cityId = objcity.CityId;
                                }

                                var objSite = new TblMstSite();
                                objSite.Name = adRecord.SiteName;
                                objSite.CreatedOn = DateTime.UtcNow;
                                objSite.CreatedBy = sytemAdminId;
                                objSite.IsActive = true;
                                objSite.Name = adRecord.SiteName;
                                objSite.OrgId = adServer.OrgId;
                                objSite.PrimaryAddr1 = (adRecord.Address == null ? "" : adRecord.Address);
                                objSite.PrimaryCity = cityId;
                                objSite.PrimaryCountry = countryId;
                                objSite.PrimaryState = stateId;
                                objSite.PrimaryZipcode = (adRecord.PostalCode == null ? "" : adRecord.PostalCode);
                                db_Context.TblMstSite.Add(objSite);
                                db_Context.SaveChanges();
                                siteId = objSite.SiteId;
                            }

                            var departmentId = db_Context.TblMstDepartment.Where(a => a.Name.ToUpper() == "IT" && a.OrgId == adServer.OrgId && a.IsDefault == true).Select(s => s.DepartmentId).FirstOrDefault();
                            var roleId = db_Context.TblMstRole.Where(a => a.Name.ToLower() == GlobalClass.GetConfigItem(db_Context, "SelfUserRole", adServer.OrgId).Value.ToLower()).Select(s => s.RoleId).FirstOrDefault();

                            ContactDetails enduser = new ContactDetails();
                            enduser.userName = adRecord.Samaccountname;
                            enduser.contactNo = adRecord.Telephonenumber;
                            enduser.emailId = adRecord.Mail;
                            enduser.firstName = adRecord.FirstName;
                            enduser.lastName = adRecord.LastName;
                            enduser.isActive = (adRecord.Useraccountcontrol == "A");
                            enduser.mobile = adRecord.Mobile;
                            enduser.siteId = siteId;
                            enduser.ldapId = adServer.AdLdapId;
                            enduser.orgId = adServer.OrgId;
                            enduser.provider = "activedirectory";
                            enduser.userName = adRecord.Samaccountname;

                            var objusercontroller = new TblMstUsersController(db_Context, null);
                            if (isUserExists)
                            {
                                var exuser = (from curruser in db_Context.TblMstUser
                                              join prof in db_Context.TblMstUserProfile on curruser.UserId equals prof.UserId
                                              where curruser.UserId == existsUserId
                                              select new
                                              {
                                                  prof.DateFormat,
                                                  curruser.IsVip,
                                                  prof.Language,
                                                  prof.TimeFormat,
                                                  prof.TimeZone,
                                                  curruser.UserType
                                              }).FirstOrDefault();


                                enduser.dateFormat = exuser.DateFormat;
                                enduser.isVip = exuser.IsVip;
                                enduser.language = exuser.Language;
                                enduser.timeFormat = exuser.TimeFormat;
                                enduser.timezone = exuser.TimeZone;
                                enduser.userType = exuser.UserType;

                                enduser.userId = existsUserId;
                                enduser.supGroups = db_Context.TblMstUserQueueMap.Where(q => q.UserId == existsUserId).Select(s => s.QueueId).ToArray();
                                enduser.roles = db_Context.TblMstUserRoleMap.Where(r => r.UserId == existsUserId).Select(s => s.RoleId).ToArray();
                                enduser.departments = db_Context.TblMstUserDeptMap.Where(d => d.UserId == existsUserId).Select(s => (int?)s.DepartmentId).ToArray();
                                objusercontroller.UpdateContact(sytemAdminId, enduser);
                            }
                            else
                            {
                                enduser.dateFormat = "MM/dd/yyyy";
                                enduser.isVip = false;
                                enduser.language = "en";
                                enduser.timeFormat = "HH:mm:ss";
                                enduser.timezone = "Asia/Calcutta";
                                enduser.userType = "SELF";

                                if (departmentId > 0)
                                    enduser.departments = new int?[] { departmentId };
                                if (roleId > 0)
                                    enduser.roles = new int?[] { roleId };
                                else
                                    enduser.roles = new int?[] { };

                                objusercontroller.CreateContact(sytemAdminId, enduser);
                            }

                            adRecord.IsModified = false;
                            db_Context.TblTrnLdapStaging.Update(adRecord);
                            db_Context.SaveChanges();

                            syncCount++;
                        }
                        catch (Exception stageex)
                        {
                            CLS_Global_Class.LogInformation(stageex.Message);
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    CLS_Global_Class.LogInformation(ex.Message);
                }
            }
            CLS_Global_Class.LogInformation("AD Sync completed for " + adServer.AccountName + ", " + syncCount + " records synchronized");
        }
        public static IEnumerable<System.DirectoryServices.SearchResult> SafeFindAll(DirectorySearcher searcher)
        {
            using (SearchResultCollection results = searcher.FindAll())
            {
                foreach (System.DirectoryServices.SearchResult result in results)
                {
                    yield return result;
                }
            } // SearchResultCollection will be disposed here
        }
        public static void SchedulerTimer_Event(object source, ElapsedEventArgs e)
        {
            var objTimer = (source as System.Timers.Timer);
            try
            {
                if (dt_PrevDate != DateTime.Today)
                {
                    if (CLS_Global_Class.appIsDebug == true)
                        Console.Clear();
                    dt_PrevDate = DateTime.Today;
                }
                objTimer.Stop();
                using (var db_Context = CLS_Global_Class.Get_db_Context())
                {
                    var coll_Pending_Event = db_Context.TblScheduleEvent.Where(a => a.ScheduledOn <= DateTime.UtcNow
                                                                                 && a.Status == (int)Enum_Schedule_Event_Status.Pending && (a.IsSyncOncreate == null || a.IsSyncOncreate == false)).ToList();
                    //var coll_Pending_Event = db_Context.TblScheduleEvent.Where(a => a.ScheduleEventId == 18129).ToList();
                    foreach (var item in coll_Pending_Event)
                    {
                        try
                        {
                            item.Status = (int)Enum_Schedule_Event_Status.Processing;
                            db_Context.Entry(item).State = EntityState.Modified;
                            db_Context.SaveChanges();
                            if (item.EventType == (int)Enum_EventTypes.RptScheduler)
                                CLS_Report_Scheduler_Engine.Start_Schedule_Event(item).Wait();
                            else if (item.EventType == (int)Enum_EventTypes.TicketReminder)
                                CLS_Ticket_Reminder_Engine.Start_Schedule_Event(item).Wait();
                            else if (item.EventType == (int)Enum_EventTypes.TicketSchedule)
                                CLS_Ticket_Scheduler_Engine.Start_Schedule_Event(item).Wait();
                            else if (item.EventType == (int)Enum_EventTypes.News_Bulletin)
                                CLS_News_Bulletin_Engine.Start_Schedule_Event(item).Wait();
                            else if (item.EventType == (int)Enum_EventTypes.SLA_Manager)
                                CLS_SLA_Manager_Engine.Start_Schedule_Event(item).Wait();
                            else
                                CLS_Ticket_Bus_Rule_Engine.Start_Schedule_Event(item).Wait();
                        }
                        catch (Exception ex)
                        {
                            item.Status = (int)Enum_Schedule_Event_Status.Fail;
                            item.ErrorMessage = ex.Message;
                            db_Context.Entry(item).State = EntityState.Modified;
                            db_Context.SaveChanges();
                            CLS_Global_Class.LogError(String.Format("*****Job Execution Error*****Job ID : {0}", item.ScheduleEventId), ex);
                        }
                    }
                    db_Context.Dispose();
                }
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("Error SchedulerTimer_Event method", ex);
            }
            finally
            {
                objTimer.Interval = 1000 * 30;
                objTimer.Start();
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Service_Start_ProcessAsync();

            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //    await Task.Delay(1000, stoppingToken);
            //}
        }
    }
    [Flags()]
    public enum UserAccountControl : int
    {
        /// <summary>
        /// The logon script is executed. 
        ///</summary>
        SCRIPT = 0x00000001,

        /// <summary>
        /// The user account is disabled. 
        ///</summary>
        ACCOUNTDISABLE = 0x00000002,

        /// <summary>
        /// The home directory is required. 
        ///</summary>
        HOMEDIR_REQUIRED = 0x00000008,

        /// <summary>
        /// The account is currently locked out. 
        ///</summary>
        LOCKOUT = 0x00000010,

        /// <summary>
        /// No password is required. 
        ///</summary>
        PASSWD_NOTREQD = 0x00000020,

        /// <summary>
        /// The user cannot change the password. 
        ///</summary>
        /// <remarks>
        /// Note:  You cannot assign the permission settings of PASSWD_CANT_CHANGE by directly modifying the UserAccountControl attribute. 
        /// For more information and a code example that shows how to prevent a user from changing the password, see User Cannot Change Password.
        // </remarks>
        PASSWD_CANT_CHANGE = 0x00000040,

        /// <summary>
        /// The user can send an encrypted password. 
        ///</summary>
        ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0x00000080,

        /// <summary>
        /// This is an account for users whose primary account is in another domain. This account provides user access to this domain, but not 
        /// to any domain that trusts this domain. Also known as a local user account. 
        ///</summary>
        TEMP_DUPLICATE_ACCOUNT = 0x00000100,

        /// <summary>
        /// This is a default account type that represents a typical user. 
        ///</summary>
        NORMAL_ACCOUNT = 0x00000200,

        /// <summary>
        /// This is a permit to trust account for a system domain that trusts other domains. 
        ///</summary>
        INTERDOMAIN_TRUST_ACCOUNT = 0x00000800,

        /// <summary>
        /// This is a computer account for a computer that is a member of this domain. 
        ///</summary>
        WORKSTATION_TRUST_ACCOUNT = 0x00001000,

        /// <summary>
        /// This is a computer account for a system backup domain controller that is a member of this domain. 
        ///</summary>
        SERVER_TRUST_ACCOUNT = 0x00002000,

        /// <summary>
        /// Not used. 
        ///</summary>
        Unused1 = 0x00004000,

        /// <summary>
        /// Not used. 
        ///</summary>
        Unused2 = 0x00008000,

        /// <summary>
        /// The password for this account will never expire. 
        ///</summary>
        DONT_EXPIRE_PASSWD = 0x00010000,

        /// <summary>
        /// This is an MNS logon account. 
        ///</summary>
        MNS_LOGON_ACCOUNT = 0x00020000,

        /// <summary>
        /// The user must log on using a smart card. 
        ///</summary>
        SMARTCARD_REQUIRED = 0x00040000,

        /// <summary>
        /// The service account (user or computer account), under which a service runs, is trusted for Kerberos delegation. Any such service 
        /// can impersonate a client requesting the service. 
        ///</summary>
        TRUSTED_FOR_DELEGATION = 0x00080000,

        /// <summary>
        /// The security context of the user will not be delegated to a service even if the service account is set as trusted for Kerberos delegation. 
        ///</summary>
        NOT_DELEGATED = 0x00100000,

        /// <summary>
        /// Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys. 
        ///</summary>
        USE_DES_KEY_ONLY = 0x00200000,

        /// <summary>
        /// This account does not require Kerberos pre-authentication for logon. 
        ///</summary>
        DONT_REQUIRE_PREAUTH = 0x00400000,

        /// <summary>
        /// The user password has expired. This flag is created by the system using data from the Pwd-Last-Set attribute and the domain policy. 
        ///</summary>
        PASSWORD_EXPIRED = 0x00800000,

        /// <summary>
        /// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be strictly 
        /// controlled. This setting enables a service running under the account to assume a client identity and authenticate as that user to 
        /// other remote servers on the network.
        ///</summary>
        TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 0x01000000,

        /// <summary>
        /// 
        /// </summary>
        PARTIAL_SECRETS_ACCOUNT = 0x04000000,

        /// <summary>
        /// 
        /// </summary>
        USE_AES_KEYS = 0x08000000
    }
}
