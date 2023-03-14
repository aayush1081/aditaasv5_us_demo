using aditaas_v5.Classes.Notification;
using aditaas_v5.Controllers;
using aditaas_v5.Models;
using aditaas_v5.BusinessLogic;
using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using HtmlAgilityPack;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TimeZoneConverter;
using Task = System.Threading.Tasks.Task;
using V5WinService.BusinessLogic;
using System.Diagnostics;

namespace aditaas_v5.Classes
{
    public static class GlobalClass
    {

        #region Declaration

        //public static EmailSettings emailSettings { get; set; }
        public static string KendoChartExportApi { get; set; }

        public static Dictionary<string, string> tZTimeDict = new Dictionary<string, string>()
        {
            { "GMT", "UTC" },
            { "Europe/Amsterdam", "W. Europe Standard Time" },
            { "Egypt", "Jordan Standard Time" },
            { "Africa/Addis_Ababa", "E. Africa Standard Time" },
            { "Asia/Karachi", "Pakistan Standard Time" },
            { "Asia/Calcutta", "India Standard Time" },
            { "Asia/Jakarta", "SE Asia Standard Time" },
            { "Asia/Chongqing", "China Standard Time" },
            { "Japan", "Tokyo Standard Time" },
            { "Australia/Darwin", "AUS Central Standard Time" },
            { "Australia/Brisbane", "E. Australia Standard Time" },
            { "Australia/Adelaide", "Cen. Australia Standard Time" },
            { "Australia/ACT", "Magadan Standard Time" },
            { "Antarctica/McMurdo", "New Zealand Standard Time" },
            { "America/St_Johns", "Newfoundland Standard Time" },
            { "America/La_Paz", "SA Western Standard Time" },
            { "America/Atikokan", "SA Pacific Standard Time" },
            { "America/Bahia_Banderas", "Central Standard Time" },
            { "America/Boise", "Mountain Standard Time" },
            { "US/Pacific", "Pacific Standard Time" },
            { "US/Alaska", "Alaskan Standard Time" },
            { "US/Hawaii", "Hawaiian Standard Time" },
            { "Pacific/Midway", "UTC-11" }

        };

        public static void WriteEventLogError(Exception ee)
        {
            if (!EventLog.SourceExists("AdiTaasV5"))
            {
                EventLog.CreateEventSource("AdiTaasV5", "AditaasLog");
            }
            if (ee != null)
            {
                EventLog eventLog = new EventLog();
                // Setting the source
                eventLog.Source = "AdiTaasV5";
                // Write an entry to the event log.
                eventLog.WriteEntry(ee.Message, EventLogEntryType.Error, 1002);
                if (ee.InnerException!=null)
                    eventLog.WriteEntry(ee.InnerException.ToString(), EventLogEntryType.Error, 1002);
            }
        }

        public static void WriteEventLog(string message)
        {
            try
            {
                if (!EventLog.SourceExists("AdiTaasV5"))
                {
                    EventLog.CreateEventSource("AdiTaasV5", "AditaasLog");
                }

                EventLog eventLog = new EventLog();
                // Setting the source
                eventLog.Source = "AdiTaasV5";
                // Write an entry to the event log.
                eventLog.WriteEntry(message, EventLogEntryType.FailureAudit);
            }catch(Exception ee)
            {
                var data = ee;
            }
        }
        public static void LogWrite(string logMessage)
        {
            var m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            m_exePath=m_exePath+"\\AdiTaaSLog";
            if(!Directory.Exists(m_exePath))
                Directory.CreateDirectory(m_exePath);
            
            var fileName = m_exePath+"\\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!File.Exists(fileName))
            {
                var myFile = File.Create(fileName);
                myFile.Close();
            }
            try
            {
                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.Write("\r\nLog Entry : ");
                    w.WriteLine("  {1}:{0}", logMessage,DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"));
                    w.WriteLine("-------------------------------");
                }
            }
            catch (Exception ex)
            {
            }
        }
       
        #region commented old timezones
        //public static Dictionary<string, string> tZTimeDict = new Dictionary<string, string>()
        //{
        //    { "Africa/Bangui", "W. Central Africa Standard Time" },
        //    { "Africa/Cairo", "Egypt Standard Time" },
        //    { "Africa/Casablanca", "Morocco Standard Time" },
        //    { "Africa/Harare", "South Africa Standard Time" },
        //    { "Africa/Johannesburg", "South Africa Standard Time" },
        //    { "Africa/Lagos", "W. Central Africa Standard Time" },
        //    { "Africa/Monrovia", "Greenwich Standard Time" },
        //    { "Africa/Nairobi", "E. Africa Standard Time" },
        //    { "Africa/Windhoek", "Namibia Standard Time" },
        //    { "America/Anchorage", "Alaskan Standard Time" },
        //    { "America/Argentina/San_Juan", "Argentina Standard Time" },
        //    { "America/Asuncion", "Paraguay Standard Time" },
        //    { "America/Bahia", "Bahia Standard Time" },
        //    { "America/Bogota", "SA Pacific Standard Time" },
        //    { "America/Buenos_Aires", "Argentina Standard Time" },
        //    { "America/Caracas", "Venezuela Standard Time" },
        //    { "America/Cayenne", "SA Eastern Standard Time" },
        //    { "America/Chicago", "Central Standard Time" },
        //    { "America/Chihuahua", "Mountain Standard Time (Mexico)" },
        //    { "America/Cuiaba", "Central Brazilian Standard Time" },
        //    { "America/Denver", "Mountain Standard Time" },
        //    { "America/Fortaleza", "SA Eastern Standard Time" },
        //    { "America/Godthab", "Greenland Standard Time" },
        //    { "America/Guatemala", "Central America Standard Time" },
        //    { "America/Anguilla", "Atlantic Standard Time" },
        //    { "America/Indianapolis", "US Eastern Standard Time" },
        //    { "America/Indiana/Indianapolis", "US Eastern Standard Time" },
        //    { "America/La_Paz", "SA Western Standard Time" },
        //    { "America/Los_Angeles", "Pacific Standard Time" },
        //    { "America/Mexico_City", "Mexico Standard Time" },
        //    { "America/Montevideo", "Montevideo Standard Time" },
        //    { "America/New_York", "Eastern Standard Time" },
        //    { "America/Noronha", "UTC-02" },
        //    { "America/Phoenix", "US Mountain Standard Time" },
        //    { "America/Regina", "Canada Central Standard Time" },
        //    { "America/Santa_Isabel", "Pacific Standard Time (Mexico)" },
        //    { "America/Santiago", "Pacific SA Standard Time" },
        //    { "America/Sao_Paulo", "E. South America Standard Time" },
        //    { "America/St_Johns", "Newfoundland Standard Time" },
        //    { "America/Tijuana", "Pacific Standard Time" },
        //    { "Antarctica/McMurdo", "New Zealand Standard Time" },
        //    { "Atlantic/South_Georgia", "UTC-02" },
        //    { "Asia/Almaty", "Central Asia Standard Time" },
        //    { "Asia/Amman", "Jordan Standard Time" },
        //    { "Asia/Baghdad", "Arabic Standard Time" },
        //    { "Asia/Baku", "Azerbaijan Standard Time" },
        //    { "Asia/Bangkok", "SE Asia Standard Time" },
        //    { "Asia/Beirut", "Middle East Standard Time" },
        //    { "Asia/Calcutta", "India Standard Time" },
        //    { "Asia/Colombo", "Sri Lanka Standard Time" },
        //    { "Asia/Damascus", "Syria Standard Time" },
        //    { "Asia/Dhaka", "Bangladesh Standard Time" },
        //    { "Asia/Dubai", "Arabian Standard Time" },
        //    { "Asia/Irkutsk", "North Asia East Standard Time" },
        //    { "Asia/Jerusalem", "Israel Standard Time" },
        //    { "Asia/Kabul", "Afghanistan Standard Time" },
        //    { "Asia/Kamchatka", "Kamchatka Standard Time" },
        //    { "Asia/Karachi", "Pakistan Standard Time" },
        //    { "Asia/Katmandu", "Nepal Standard Time" },
        //    { "Asia/Kolkata", "India Standard Time" },
        //    { "Asia/Krasnoyarsk", "North Asia Standard Time" },
        //    { "Asia/Kuala_Lumpur", "Singapore Standard Time" },
        //    { "Asia/Kuwait", "Arab Standard Time" },
        //    { "Asia/Magadan", "Magadan Standard Time" },
        //    { "Asia/Muscat", "Arabian Standard Time" },
        //    { "Asia/Novosibirsk", "N. Central Asia Standard Time" },
        //    { "Asia/Oral", "West Asia Standard Time" },
        //    { "Asia/Rangoon", "Myanmar Standard Time" },
        //    { "Asia/Riyadh", "Arab Standard Time" },
        //    { "Asia/Seoul", "Korea Standard Time" },
        //    { "Asia/Shanghai", "China Standard Time" },
        //    { "Asia/Singapore", "Singapore Standard Time" },
        //    { "Asia/Taipei", "Taipei Standard Time" },
        //    { "Asia/Tashkent", "West Asia Standard Time" },
        //    { "Asia/Tbilisi", "Georgian Standard Time" },
        //    { "Asia/Tehran", "Iran Standard Time" },
        //    { "Asia/Tokyo", "Tokyo Standard Time" },
        //    { "Asia/Ulaanbaatar", "Ulaanbaatar Standard Time" },
        //    { "Asia/Vladivostok", "Vladivostok Standard Time" },
        //    { "Asia/Yakutsk", "Yakutsk Standard Time" },
        //    { "Asia/Yekaterinburg", "Ekaterinburg Standard Time" },
        //    { "Asia/Yerevan", "Armenian Standard Time" },
        //    { "Atlantic/Azores", "Azores Standard Time" },
        //    { "Atlantic/Cape_Verde", "Cape Verde Standard Time" },
        //    { "Atlantic/Reykjavik", "Greenwich Standard Time" },
        //    { "Australia/Adelaide", "Cen. Australia Standard Time" },
        //    { "Australia/Brisbane", "E. Australia Standard Time" },
        //    { "Australia/Darwin", "AUS Central Standard Time" },
        //    { "Australia/Hobart", "Tasmania Standard Time" },
        //    { "Australia/Perth", "W. Australia Standard Time" },
        //    { "Australia/Sydney", "AUS Eastern Standard Time" },
        //    { "Etc/GMT", "UTC" },
        //    { "Etc/GMT+11", "UTC-11" },
        //    { "Etc/GMT+12", "Dateline Standard Time" },
        //    { "Etc/GMT+2", "UTC-02" },
        //    { "Etc/GMT-12", "UTC+12" },
        //    { "Europe/Amsterdam", "W. Europe Standard Time" },
        //    { "Europe/Athens", "GTB Standard Time" },
        //    { "Europe/Belgrade", "Central Europe Standard Time" },
        //    { "Europe/Berlin", "W. Europe Standard Time" },
        //    { "Europe/Brussels", "Romance Standard Time" },
        //    { "Europe/Budapest", "Central Europe Standard Time" },
        //    { "Europe/Dublin", "GMT Standard Time" },
        //    { "Europe/Helsinki", "FLE Standard Time" },
        //    { "Europe/Istanbul", "GTB Standard Time" },
        //    { "Europe/Kiev", "FLE Standard Time" },
        //    { "Europe/London", "GMT Standard Time" },
        //    { "Europe/Minsk", "E. Europe Standard Time" },
        //    { "Europe/Moscow", "Russian Standard Time" },
        //    { "Europe/Paris", "Romance Standard Time" },
        //    { "Europe/Sarajevo", "Central European Standard Time" },
        //    { "Europe/Warsaw", "Central European Standard Time" },
        //    { "Indian/Mauritius", "Mauritius Standard Time" },
        //    { "Pacific/Apia", "Samoa Standard Time" },
        //    { "Pacific/Auckland", "New Zealand Standard Time" },
        //    { "Pacific/Fiji", "Fiji Standard Time" },
        //    { "Pacific/Guadalcanal", "Central Pacific Standard Time" },
        //    { "Pacific/Guam", "West Pacific Standard Time" },
        //    { "Pacific/Honolulu", "Hawaiian Standard Time" },
        //    { "Pacific/Pago_Pago", "UTC-11" },
        //    { "Pacific/Port_Moresby", "West Pacific Standard Time" },
        //    { "Pacific/Tongatapu", "Tonga Standard Time" },
        //    { "America/Atikokan", "SA Pacific Standard Time" }
        //};
        #endregion

        static IServiceProvider services = null;
        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                services = value;
            }
        }


        public static IDictionary<int?, IEnumerable<CLS_TblMstWorkHrDay>> hashSet_SiteWorkHr = new Dictionary<int?, IEnumerable<CLS_TblMstWorkHrDay>>();
        public static IDictionary<int?, IEnumerable<CLS_TblMstWorkHrDay>> hashSet_WorkHrDay = new Dictionary<int?, IEnumerable<CLS_TblMstWorkHrDay>>();

        public static IDictionary<int?, TimeZoneInfo> hashSet_WorkHrTimeZone = new Dictionary<int?, TimeZoneInfo>();
        public static IDictionary<int?, string> hashSet_UserTZName = new Dictionary<int?, string>();
        public static IDictionary<int?, string> hashSet_UserTimeZone = new Dictionary<int?, string>();

        #endregion

        #region Global Collection Method

        static object objLockHolidayList = new object();
        static object objLockWorkHrList = new object();
        static object objLockSiteTimeZone = new object();
        static object objLockUserTimeZone = new object();

        public static IEnumerable<CLS_TblMstWorkHrDay> Get_SiteWorkHr_List(int? siteId, int? orgId, aditaas_v5Context _context)
        {
            IEnumerable<CLS_TblMstWorkHrDay> coll_WorkHr = null;
            if (siteId == null) siteId = 0;
            if (GlobalClass.hashSet_SiteWorkHr.ContainsKey(siteId))
                coll_WorkHr = GlobalClass.hashSet_SiteWorkHr[siteId];
            else
            {
                lock (objLockWorkHrList)
                {
                    if (GlobalClass.hashSet_SiteWorkHr.ContainsKey(siteId))
                        coll_WorkHr = GlobalClass.hashSet_SiteWorkHr[siteId];
                    else
                    {
                        var workHrId = TblTrnTicketSlaController.Get_Mst_Work_Hour_Id(orgId, siteId, null, _context);
                        coll_WorkHr = (from workHr in _context.TblMstWorkHr
                                       join workHrDay in _context.TblMstWkWorkHr on workHr.WorkHrId equals workHrDay.WorkHrId into jworkHrDay
                                       from workHrDay in jworkHrDay.DefaultIfEmpty()
                                       where workHr.WorkHrId == workHrId
                                       select new CLS_TblMstWorkHrDay
                                       {
                                           WorkHrId = workHr.WorkHrId,
                                           Is24hr = workHr.Is24hr,
                                           WeekDay = workHrDay.WeekDay,
                                           StartTime = workHrDay.StartTime,
                                           EndTime = workHrDay.EndTime,
                                       }).ToList();
                        GlobalClass.hashSet_SiteWorkHr.Add(siteId, coll_WorkHr);
                    }
                }

            }
            return coll_WorkHr;
        }

        public static IEnumerable<CLS_TblMstWorkHrDay> Get_WorkHrDay_List(int? workHrId, aditaas_v5Context _context)
        {
            IEnumerable<CLS_TblMstWorkHrDay> coll_WorkHr = null;
            if (workHrId == null) workHrId = 0;
            if (GlobalClass.hashSet_WorkHrDay.ContainsKey(workHrId))
                coll_WorkHr = GlobalClass.hashSet_WorkHrDay[workHrId];
            else
            {
                lock (objLockWorkHrList)
                {
                    if (GlobalClass.hashSet_WorkHrDay.ContainsKey(workHrId))
                        coll_WorkHr = GlobalClass.hashSet_WorkHrDay[workHrId];
                    else
                    {
                        coll_WorkHr = (from workHr in _context.TblMstWorkHr
                                       join workHrDay in _context.TblMstWkWorkHr on workHr.WorkHrId equals workHrDay.WorkHrId into jworkHrDay
                                       from workHrDay in jworkHrDay.DefaultIfEmpty()
                                       where workHr.WorkHrId == workHrId
                                       select new CLS_TblMstWorkHrDay
                                       {
                                           WorkHrId = workHr.WorkHrId,
                                           Is24hr = workHr.Is24hr,
                                           WeekDay = workHrDay.WeekDay,
                                           StartTime = workHrDay.StartTime,
                                           EndTime = workHrDay.EndTime,
                                       }).ToList();
                        GlobalClass.hashSet_WorkHrDay.Add(workHrId, coll_WorkHr);
                    }
                }

            }
            return coll_WorkHr;
        }

        //public static TimeZoneInfo Get_TimeZone_By_SiteId(int? siteId, aditaas_v5Context _context)
        //{
        //    if (siteId == null) siteId = 0;
        //    if (hashSet_SiteTimeZone.ContainsKey(siteId) == true)
        //        return hashSet_SiteTimeZone[siteId];
        //    else
        //    {
        //        lock (objLockSiteTimeZone)
        //        {
        //            if (GlobalClass.hashSet_SiteTimeZone.ContainsKey(siteId))
        //                return GlobalClass.hashSet_SiteTimeZone[siteId];
        //            else
        //            {
        //                var tzName = (from site in _context.TblMstSite
        //                              join workHr in _context.TblMstWorkHr on site.WorkHrId equals workHr.WorkHrId
        //                              where site.SiteId == siteId
        //                              select workHr.TimeZone).FirstOrDefault();
        //                if (tzName != null && tzName.Contains("-"))
        //                    tzName = tzName.Split('-')[1];
        //                if (tzName == null || tZTimeDict.TryGetValue(tzName, out tzName) == false)
        //                    tzName = "Pacific Standard Time";
        //                var tzInfo = TimeZoneInfo.FindSystemTimeZoneById(tzName);
        //                hashSet_SiteTimeZone.Add(siteId, tzInfo);
        //                return tzInfo;
        //            }
        //        }
        //    }
        //}

        public static TimeZoneInfo Get_TimeZone_By_WorkHrId(int? siteId, int? workHrId, aditaas_v5Context _context)
        {
            if (workHrId == null) workHrId = 0;
            if (hashSet_WorkHrTimeZone.ContainsKey(workHrId) == true)
                return hashSet_WorkHrTimeZone[workHrId];
            else
            {
                lock (objLockSiteTimeZone)
                {
                    if (GlobalClass.hashSet_WorkHrTimeZone.ContainsKey(workHrId))
                        return GlobalClass.hashSet_WorkHrTimeZone[workHrId];
                    else
                    {
                        var tzName = (from workHr in _context.TblMstWorkHr
                                      where workHr.WorkHrId == workHrId
                                      select workHr.TimeZone).FirstOrDefault();
                        if (tzName != null && tzName.Contains("-"))
                            tzName = tzName.Split('-')[1];
                        if (tzName == null || tZTimeDict.TryGetValue(tzName, out tzName) == false)
                            tzName = "Pacific Standard Time";
                        //var tzInfo = TimeZoneInfo.FindSystemTimeZoneById(tzName);
                        var tzInfo = TZConvert.GetTimeZoneInfo(tzName);
                        hashSet_WorkHrTimeZone.Add(workHrId, tzInfo);
                        return tzInfo;
                    }
                }
            }
        }

        public static string Get_TimeZone_By_UserId(int? userId, aditaas_v5Context _context)
        {
            if (hashSet_UserTimeZone.ContainsKey(userId))
                return hashSet_UserTimeZone[userId];
            else
            {
                lock (objLockUserTimeZone)
                {
                    if (hashSet_UserTimeZone.ContainsKey(userId))
                        return hashSet_UserTimeZone[userId];
                    else
                    {
                        var tzName = Get_UserTimeZone_By_UserId(userId, _context);
                        if (tZTimeDict.TryGetValue(tzName, out tzName) == false)
                            tzName = "Pacific Standard Time";

                        //var tzInfo = TZConvert.GetTimeZoneInfo(tzName);
                        hashSet_UserTimeZone.Add(userId, tzName);
                        return tzName;
                    }
                }
            }
        }
        public static TimeZoneInfo GetTimeZoneByName(string tzName)
        {
            if (tZTimeDict.TryGetValue(tzName, out tzName) == false)
                tzName = "Pacific Standard Time";
            //var tzInfo = TimeZoneInfo.FindSystemTimeZoneById(tzName);
            var tzInfo = TZConvert.GetTimeZoneInfo(tzName);
            return tzInfo;
        }

        public static string Get_UserTimeZone_By_UserId(int? userId, aditaas_v5Context _context)
        {
            if (hashSet_UserTZName.ContainsKey(userId))
                return hashSet_UserTZName[userId];
            else
            {
                lock (objLockUserTimeZone)
                {
                    if (hashSet_UserTZName.ContainsKey(userId))
                        return hashSet_UserTZName[userId];
                    else
                    {
                        var result = _context.TblMstUserProfile.Where(a => a.UserId == userId).Select(a => a.TimeZone).FirstOrDefault();
                        if (result != null && result.Contains("-"))
                            result = result.Split('-')[1];
                        if (result == null || result == "")
                            result = "America/Los_Angeles";
                        hashSet_UserTZName.Add(userId, result);
                        return result;
                    }
                }
            }

        }

        public static TimeZoneInfo Get_TimeZone_By_UserId_WinService(int? userId, aditaas_v5Context _context)
        {
            var tzName = Get_UserTimeZone_By_UserId_WinService(userId, _context);
            if (tZTimeDict.TryGetValue(tzName, out tzName) == false)
                tzName = "Pacific Standard Time";
            //var tzInfo = TimeZoneInfo.FindSystemTimeZoneById(tzName);
            var tzInfo = TZConvert.GetTimeZoneInfo(tzName);
            return tzInfo;
        }
        public static TimeZoneInfo GetTimeZoneByOrgIdWinService(int orgId, aditaas_v5Context _context)
        {
            var tzName = _context.TblMstWorkHr.Where(x => x.OrgId == orgId).Select(a => a.TimeZone).FirstOrDefault();

            if (tzName != null && tzName.Contains("-"))
                tzName = tzName.Split('-')[1];
            if (tzName == null || tzName == "")
                tzName = "America/Los_Angeles";

            if (tZTimeDict.TryGetValue(tzName, out tzName) == false)
                tzName = "Pacific Standard Time";

            var tzInfo = TZConvert.GetTimeZoneInfo(tzName);
            return tzInfo;
        }
        public static string Get_UserTimeZone_By_UserId_WinService(int? userId, aditaas_v5Context _context)
        {
            var result = _context.TblMstUserProfile.Where(a => a.UserId == userId).Select(a => a.TimeZone).FirstOrDefault();
            if (result != null && result.Contains("-"))
                result = result.Split('-')[1];
            if (result == null || result == "")
                result = "America/Los_Angeles";
            return result;
        }

        public static string Get_UserDateTime_Format(int? userId, aditaas_v5Context _context)
        {
            var result = _context.TblMstUserProfile.Where(a => a.UserId == userId).Select(a => a.DateFormat + ' ' + a.TimeFormat).FirstOrDefault();
            if (result == null || result.Trim() == "")
                result = "MM/dd/yyyy HH:mm tt";
            return result;
        }


        #endregion

        #region Notification Method

        static RedisList<SignalR_UserBE> coll_SignalR_Connections = new RedisList<SignalR_UserBE>("SignalRConnectionsIndiaDemo");
        public static List<string> antiforgtoekn = new List<string>();

        static IHubContext<NotificationHub> _currContext_SignalR = null;
        static IHubContext<NotificationHub> currContext_SignalR
        {
            get
            {
                if (services == null) return null;

                if (_currContext_SignalR == null)
                    _currContext_SignalR = services.GetService(typeof(IHubContext<NotificationHub>)) as IHubContext<NotificationHub>;

                return _currContext_SignalR;
            }
        }

        public static void SignalR_AddConnection(int userId, string userType, string connectionId)
        {
            if (coll_SignalR_Connections == null)
            {
                coll_SignalR_Connections = new RedisList<SignalR_UserBE>("SignalRConnectionsIndiaDemo");
                GlobalClass.SignalR_PushNotification_All(new SignalR_NotificationBE()
                {
                    TopicName = "resendUserInfo",
                    MessageBE = new SignalR_MessageBE() { }
                }).Wait();
            }
            //int ncount = 0;
            //try
            //{
            //    var nullconns = coll_SignalR_Connections.Where(ar => ar == null).ToList();
            //    ncount = nullconns.Count();

            //    if (ncount > 0)
            //        coll_SignalR_Connections.RemoveAt(0);
            //}
            //catch(Exception ex1)
            //{
            //    Console.WriteLine(ex1.Message + " " + ex1.StackTrace);
            //}           

            if (coll_SignalR_Connections.FirstOrDefault(ar => ar != null && ar.userId == userId && ar.connectionId == connectionId) == null)
            {
                coll_SignalR_Connections.Add(new SignalR_UserBE()
                {
                    userId = userId,
                    userType = userType,
                    connectionId = connectionId,
                });
            }
        }

        public static void SignalR_RemoveConnection(string connectionId)
        {
            var objBE = coll_SignalR_Connections.FirstOrDefault(ar => ar.connectionId == connectionId);
            if (objBE != null)
                coll_SignalR_Connections.Remove(objBE);
        }

        public static async Task<string> SignalR_PushNotification_Single(IEnumerable<int?> coll_UserId, SignalR_NotificationBE notification)
        {
            string retMessage = string.Empty;
            var connectionIds = coll_SignalR_Connections.Where(ar => coll_UserId.Any(aa => aa == ar.userId)).Select(ar => ar.connectionId).ToList();
            try
            {
                if (currContext_SignalR != null)
                    await currContext_SignalR.Clients.Clients(connectionIds).SendAsync(notification.TopicName, notification.MessageBE);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }

        public static async Task<string> SignalR_PushNotification_All(SignalR_NotificationBE notification)
        {
            if (currContext_SignalR != null)
                await currContext_SignalR.Clients.All.SendAsync(notification.TopicName, notification.MessageBE);
            return "";
        }

        public static async Task<string> SignalR_Ticket_Notification(aditaas_v5Context _context
                                                                , Enum_ModuleTypes? moduleType, Enum_ActionTypes actionType
                                                                , object objTicket
                                                                , Enum_EventTypes eventType = Enum_EventTypes.TicketBusRule
                                                                , int? additionalRefId = null
                                                                , bool? isGridCountUpdate = false
                                                                , string masterType = null)
        {
            string retMessage = string.Empty;
            if (eventType == Enum_EventTypes.TicketReminder)
            {
                var tblTrnReminder = objTicket as TblCnfFollowUp;
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnReminder.RecordId, tblTrnReminder.FollowUpId);
            }
            else if (eventType == Enum_EventTypes.RptScheduler)
            {
                var tblRptReportScheduler = objTicket as TblRptReportScheduler;
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, null, tblRptReportScheduler.ReportSchedulerId);
            }
            else if (eventType == Enum_EventTypes.TicketSchedule)
            {
                var tblCnfTicketSch = objTicket as TblCnfTicketSch;
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblCnfTicketSch.RecordId, tblCnfTicketSch.TicketSchId);

                #region Grid Count Update

                if (tblCnfTicketSch.ModuleId == (int)Enum_ModuleTypes.Incident)
                {
                    var obj_TicketBE = _context.TblTrnIncident.FirstOrDefault(a => a.IncidentId == tblCnfTicketSch.RecordId);
                    await GlobalClass.SignalR_Ticket_Notification(_context, (Enum_ModuleTypes)tblCnfTicketSch.ModuleId, Enum_ActionTypes.TicketCreate, obj_TicketBE, Enum_EventTypes.TicketBusRule, null, true); //For grid update
                }
                else if (tblCnfTicketSch.ModuleId == (int)Enum_ModuleTypes.Request)
                {
                    var obj_TicketBE = _context.TblTrnServiceRequest.FirstOrDefault(a => a.ServiceRequestId == tblCnfTicketSch.RecordId);
                    await GlobalClass.SignalR_Ticket_Notification(_context, (Enum_ModuleTypes)tblCnfTicketSch.ModuleId, Enum_ActionTypes.TicketCreate, obj_TicketBE, Enum_EventTypes.TicketBusRule, null, true); //For grid update
                }
                else if (tblCnfTicketSch.ModuleId == (int)Enum_ModuleTypes.Change)
                {
                    var obj_TicketBE = _context.TblTrnChange.FirstOrDefault(a => a.ChangeId == tblCnfTicketSch.RecordId);
                    await GlobalClass.SignalR_Ticket_Notification(_context, (Enum_ModuleTypes)tblCnfTicketSch.ModuleId, Enum_ActionTypes.TicketCreate, obj_TicketBE, Enum_EventTypes.TicketBusRule, null, true); //For grid update
                }
                else if (tblCnfTicketSch.ModuleId == (int)Enum_ModuleTypes.Problem)
                {
                    var obj_TicketBE = _context.TblTrnProblem.FirstOrDefault(a => a.ProblemId == tblCnfTicketSch.RecordId);
                    await GlobalClass.SignalR_Ticket_Notification(_context, (Enum_ModuleTypes)tblCnfTicketSch.ModuleId, Enum_ActionTypes.TicketCreate, obj_TicketBE, Enum_EventTypes.TicketBusRule, null, true); //For grid update
                }
                else if (tblCnfTicketSch.ModuleId == (int)Enum_ModuleTypes.Kb)
                {
                    var obj_TicketBE = _context.TblTrnKb.FirstOrDefault(a => a.KbId == tblCnfTicketSch.RecordId);
                    await GlobalClass.SignalR_Ticket_Notification(_context, (Enum_ModuleTypes)tblCnfTicketSch.ModuleId, Enum_ActionTypes.TicketCreate, obj_TicketBE, Enum_EventTypes.TicketBusRule, null, true); //For grid update
                }
                else if (tblCnfTicketSch.ModuleId == (int)Enum_ModuleTypes.Task)
                {
                    var obj_TicketBE = _context.TblTrnTask.FirstOrDefault(a => a.TaskId == tblCnfTicketSch.RecordId);
                    await GlobalClass.SignalR_Ticket_Notification(_context, (Enum_ModuleTypes)tblCnfTicketSch.ModuleId, Enum_ActionTypes.TicketCreate, obj_TicketBE, Enum_EventTypes.TicketBusRule, null, true); //For grid update
                }

                #endregion

            }
            else if (eventType == Enum_EventTypes.News_Bulletin)
            {
                var tblCnfTicketSch = objTicket as TblMstBulletin;
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, null, tblCnfTicketSch.BulletinId);
            }
            else if (eventType == Enum_EventTypes.Master_Updation)
            {
                #region On Ticket Location changes

                int? recordId = null;
                if (moduleType == Enum_ModuleTypes.Incident)
                    recordId = (objTicket as TblTrnIncident).IncidentId;
                else if (moduleType == Enum_ModuleTypes.Request)
                    recordId = (objTicket as TblTrnServiceRequest).ServiceRequestId;
                else if (moduleType == Enum_ModuleTypes.Change)
                    recordId = (objTicket as TblTrnChange).ChangeId;
                else if (moduleType == Enum_ModuleTypes.Problem)
                    recordId = (objTicket as TblTrnProblem).ProblemId;
                else if (moduleType == Enum_ModuleTypes.Kb)
                    recordId = (objTicket as TblTrnKb).KbId;
                else if (moduleType == Enum_ModuleTypes.Task)
                    recordId = (objTicket as TblTrnTask).TaskId;
                else if (moduleType == Enum_ModuleTypes.Assets)
                    recordId = (objTicket as TblCmdbTrnCi).CiId;
                #endregion

                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, recordId, additionalRefId, masterType);
            }
            else if (eventType == Enum_EventTypes.SLA_Manager)
            {
                var tblCnfTicketSch = objTicket as TblTrnTicketSla;
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblCnfTicketSch.RecordId, tblCnfTicketSch.TicketSlaId);
            }
            else if (actionType == Enum_ActionTypes.TicketAddNotes
                || actionType == Enum_ActionTypes.TicketAddNotes_Self
                || actionType == Enum_ActionTypes.TicketAddNotes_MailManager
                || actionType == Enum_ActionTypes.TicketAddAttachment_Self)
            {
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, (objTicket as int?), additionalRefId);
            }
            else if (actionType == Enum_ActionTypes.TicketOnSurveySubmission)
            {
                var tblTrnSurvey = objTicket as TblTrnTicketSurvey;
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnSurvey.RecordId, additionalRefId);
            }
            else if (moduleType == Enum_ModuleTypes.Incident)
            {
                var tblTrnIncident = objTicket as TblTrnIncident;
                if (isGridCountUpdate == true)
                    await GlobalClass.Notify_WebUser_GridCountUpdate(_context, "inc", new int?[] { tblTrnIncident.CreatedById, tblTrnIncident.UserId, tblTrnIncident.ModifiedById, tblTrnIncident.AssignToId }, new int?[] { tblTrnIncident.CurrAssignQueueId });
                if (tblTrnIncident != null && tblTrnIncident.IsDraft != true)
                    _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnIncident.IncidentId);
            }
            else if (moduleType == Enum_ModuleTypes.Request)
            {
                var tblTrnServiceRequest = objTicket as TblTrnServiceRequest;
                if (isGridCountUpdate == true)
                    await GlobalClass.Notify_WebUser_GridCountUpdate(_context, "req", new int?[] { tblTrnServiceRequest.CreatedById, tblTrnServiceRequest.ModifiedById, tblTrnServiceRequest.UserId, tblTrnServiceRequest.AssignToId }, new int?[] { tblTrnServiceRequest.CurrAssignQueueId });
                if (tblTrnServiceRequest != null && tblTrnServiceRequest.IsDraft != true)
                    _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnServiceRequest.ServiceRequestId);
            }
            else if (moduleType == Enum_ModuleTypes.Change)
            {
                var tblTrnChange = objTicket as TblTrnChange;
                if (isGridCountUpdate == true)
                    await GlobalClass.Notify_WebUser_GridCountUpdate(_context, "change", new int?[] { tblTrnChange.CreatedById, tblTrnChange.ModifiedById, tblTrnChange.UserId, tblTrnChange.AssignToId }, null);
                if (tblTrnChange != null && tblTrnChange.IsDraft != true)
                    _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnChange.ChangeId);
            }
            else if (moduleType == Enum_ModuleTypes.Problem)
            {
                var tblTrnProblem = objTicket as TblTrnProblem;
                if (isGridCountUpdate == true)
                    await GlobalClass.Notify_WebUser_GridCountUpdate(_context, "prob", new int?[] { tblTrnProblem.CreatedById, tblTrnProblem.ModifiedById, tblTrnProblem.UserId, tblTrnProblem.AssignToId }, new int?[] { tblTrnProblem.CurrAssignQueueId });
                if (tblTrnProblem != null && tblTrnProblem.IsDraft != true)
                    _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnProblem.ProblemId);
            }
            else if (moduleType == Enum_ModuleTypes.Kb)
            {
                var tblTrnKb = objTicket as TblTrnKb;
                if (isGridCountUpdate == true)
                    await GlobalClass.Notify_WebUser_GridCountUpdate(_context, "kb", new int?[] { tblTrnKb.CreatedById, tblTrnKb.ModifiedById, tblTrnKb.AssignToId }, null);
                if (tblTrnKb != null && tblTrnKb.IsDraft != true)
                    _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnKb.KbId);
            }
            else if (moduleType == Enum_ModuleTypes.Task)
            {
                var tblTrnTask = objTicket as TblTrnTask;
                if (isGridCountUpdate == true)
                    await GlobalClass.Notify_WebUser_GridCountUpdate(_context, "task", new int?[] { tblTrnTask.CreatedById, tblTrnTask.UserId, tblTrnTask.AssignToId, tblTrnTask.ModifiedById, tblTrnTask.ClosedById }, null);
                if (tblTrnTask != null && tblTrnTask.IsDraft != true)
                    _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnTask.TaskId);
            }
            else if (moduleType == Enum_ModuleTypes.Approval)
            {
                var tblTrnApproval = objTicket as TblTrnApproval;
                if (isGridCountUpdate == true)
                    await GlobalClass.Notify_WebUser_GridCountUpdate(_context, "approval", new int?[] { tblTrnApproval.CreatedById, tblTrnApproval.RequesterId, tblTrnApproval.ModifiedById, tblTrnApproval.ApproverId }, null);
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, (Enum_ModuleTypes)tblTrnApproval.ModuleId, tblTrnApproval.RecordId, tblTrnApproval.ApprovalId);
            }
            else if (moduleType == Enum_ModuleTypes.Assets)
            {
                var tblTrnCi = objTicket as TblCmdbTrnCi;
                if (isGridCountUpdate == true)
                    await GlobalClass.Notify_WebUser_GridCountUpdate(_context, "cmdb", new int?[] { tblTrnCi.CreatedById, tblTrnCi.AssignToId }, new int?[] { tblTrnCi.AssignQueueId });
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnCi.CiId, null);
            }
            else if (moduleType == Enum_ModuleTypes.FieldService)
            {
                var tblTrnCi = objTicket as TblTrnFieldService;
                if (isGridCountUpdate == true)
                    await GlobalClass.Notify_WebUser_GridCountUpdate(_context, "fieldService", new int?[] { tblTrnCi.CreatedById, tblTrnCi.AssignToId }, new int?[] { });
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnCi.FieldServiceId, null);
            }
            else if (moduleType == Enum_ModuleTypes.Interaction)
            {
                var tblTrnCi = objTicket as TblTrnInteraction;
                if (isGridCountUpdate == true)
                    await GlobalClass.Notify_WebUser_GridCountUpdate(_context, "interaction", new int?[] { tblTrnCi.CreatedById, tblTrnCi.AssignToId }, new int?[] { tblTrnCi.CurrAssignQueueId });
                _ = GlobalClass.Notify_WinService_TicketAction(eventType, actionType, moduleType, tblTrnCi.InteractionId, null);
            }
            return retMessage;
        }

        private static async Task<string> Notify_WebUser_GridCountUpdate(aditaas_v5Context currContext_db, string moduleName, int?[] coll_UserId, int?[] coll_UserGroupId)
        {
            try
            {
                coll_UserId = coll_UserId.Where(a => a != null).ToArray();
                //var notification = new SignalR_NotificationBE()
                //{
                //    TopicName = "gridCountUpdate",
                //    MessageBE = new SignalR_MessageBE()
                //    {
                //        type = moduleName
                //    }
                //};

                //string retMessage = string.Empty;
                //retMessage = await SignalR_PushNotification_Single(new int?[] { -1001 }, notification);
                //return retMessage;




                if (coll_UserGroupId != null && coll_UserGroupId.Length > 0)
                {
                    var Coll = coll_UserId.ToList();
                    var Coll_SuppGrp = Get_UserIds_By_GroupId(currContext_db, coll_UserGroupId, null).ToList();
                    Coll.AddRange(Coll_SuppGrp);
                    coll_UserId = Coll.ToArray();
                    //foreach (var item_userId in Get_UserIds_By_GroupId(currContext_db, coll_UserGroupId))
                    //    coll_UserId.Append(item_userId);
                }



                var notification = new SignalR_NotificationBE()
                {
                    TopicName = "gridCountUpdate",
                    MessageBE = new SignalR_MessageBE()
                    {
                        type = moduleName,
                        userIds = coll_UserId,
                    }
                };
                //if (coll_UserGroupId != null && coll_UserGroupId.Length > 0)
                //    foreach (var item_userId in Get_UserIds_By_GroupId(currContext_db, coll_UserGroupId))
                //        coll_UserId.Append(item_userId);

                //if (coll_UserGroupId != null && coll_UserGroupId.Length > 0)
                //{
                //    var Coll = coll_UserId.ToList();
                //    var Coll_SuppGrp = Get_UserIds_By_GroupId(currContext_db, coll_UserGroupId).ToList();
                //    Coll.AddRange(Coll_SuppGrp);
                //    coll_UserId = Coll.ToArray();
                //    //foreach (var item_userId in Get_UserIds_By_GroupId(currContext_db, coll_UserGroupId))
                //    //    coll_UserId.Append(item_userId);
                //}
                string retMessage = string.Empty;
                retMessage = await SignalR_PushNotification_Single(new int?[] { -1001 }, notification);
                //retMessage = await SignalR_PushNotification_Single(coll_UserId, notification);
                return retMessage;
            }
            catch (Exception)
            {
                //throw ex;
                return null;
            }
        }

        public static int?[] Get_UserIds_By_GroupId(aditaas_v5Context currContext_db, int?[] coll_UserGroupId, int? orgId)
        {
            var coll_UserId = new List<int?>();
            if (coll_UserGroupId != null && coll_UserGroupId.Count() > 0)
            {
                if (orgId != null)
                {
                    foreach (var item in coll_UserGroupId)
                    {
                        foreach (var item_userId in (from uQueue in currContext_db.TblMstUserQueueMap
                                                     join user in currContext_db.TblMstUser on uQueue.UserId equals user.UserId
                                                     join useOrgMap in currContext_db.TblMstUserOrgMap on uQueue.UserId equals useOrgMap.UserId
                                                     where uQueue.QueueId == item && user.UserType != "SELF" && useOrgMap.OrgId == orgId
                                                     && user.IsActive == true
                                                     select uQueue.UserId))
                            coll_UserId.Add(item_userId);
                    }
                }
                else
                {
                    foreach (var item in coll_UserGroupId)
                    {
                        foreach (var item_userId in (from uQueue in currContext_db.TblMstUserQueueMap
                                                     join user in currContext_db.TblMstUser on uQueue.UserId equals user.UserId
                                                     where uQueue.QueueId == item && user.UserType != "SELF"
                                                     && user.IsActive == true
                                                     select uQueue.UserId))
                            coll_UserId.Add(item_userId);
                    }
                }
            }
            return coll_UserId.ToArray();
        }

        public static string Get_UserMstFieldValue_By_UserId(aditaas_v5Context currContext_db, int? userId, string fieldName)
        {
            var str_Result = "";
            var str_Select_SQL = string.Format("select {0} from {1} where {2} = {3} AND {0} IS NOT NULL ", fieldName, "tbl_mst_user", "user_id", userId);
            var dt_Data = GlobalClass.Get_dt_From_SQL(str_Select_SQL, currContext_db);
            if (dt_Data.Rows.Count > 0)
                str_Result = dt_Data.Rows[0][0].ToString();
            return str_Result;
        }

        private static async Task<string> Notify_WinService_TicketAction(Enum_EventTypes eventType
                                                                        , Enum_ActionTypes actionType
                                                                        , Enum_ModuleTypes? moduleType
                                                                        , int? ticketId
                                                                        , int? additionalRefId = null
                                                                        , string type = null)
        {
            try
            {
                var notification = new SignalR_NotificationBE()
                {
                    TopicName = "onNotifyTicketAction",
                    MessageBE = new SignalR_MessageBE()
                    {
                        moduleId = (int?)moduleType,
                        ticketId = ticketId,
                        additionalRefId = additionalRefId,
                        actionType = (int)actionType,
                        eventType = (int)eventType,
                        type = type,
                    }
                };

                if (eventType == Enum_EventTypes.TicketBusRule && actionType == Enum_ActionTypes.TicketCreate)
                {
                    await CLS_Ticket_Bus_Rule_Engine.Set_Scheduler_EventAsync(notification.MessageBE, true);
                    //ExecuteBusinessRule(notification.MessageBE, db_Context);
                    //var objNotifyBE = notification.MessageBE;
                    //var int_OrgId = Get_TicketOrgId_From_Id((Enum_ModuleTypes)objNotifyBE.moduleId, objNotifyBE.ticketId, db_Context);
                    //var int_ModuleId = objNotifyBE.moduleId;

                    //var coll_BusRule = db_Context.TblCnfBusRule.Where(a => a.ModuleId == int_ModuleId && a.OrgId == int_OrgId && a.IsActive == true
                    //                                               && a.IsSyncOncreate.GetValueOrDefault(false) == true).ToList();

                    //foreach (var item_BusRule in coll_BusRule)
                    //{
                    //    CLS_Ticket_Bus_Rule_Engine.Set_Scheduler_EventAsync(objNotifyBE);
                    //}
                }

                string retMessage = string.Empty;
                retMessage = await SignalR_PushNotification_Single(new int?[] { -1001 }, notification);
                return retMessage;
            }
            catch (Exception)
            {
                //throw ex;
                return null;
            }
        }




        #endregion

        #region Dynamic Dashboard and ReportTools common method

        public static string Set_System_Field_Value_To_SQL_Query(string str_Query, int? userId, aditaas_v5Context _context, bool isDashboard)
        {
            var tzName = Get_TimeZone_By_UserId(userId, _context);
            var userTZ = TZConvert.GetTimeZoneInfo(tzName);
            var tzTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, userTZ);
            var UTCToday = DateTime.Parse(tzTime.Date.ToString("yyyy-MM-dd"));//.ToUniversalTime();
            var UTCNow = tzTime;//.ToUniversalTime();
            var startOfMonth = new DateTime(UTCToday.Year, UTCToday.Month, 1);

            var startOfPrevMonth = new DateTime(UTCToday.AddMonths(-1).Year, UTCToday.AddMonths(-1).Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            var endOfPrevMonth = startOfPrevMonth.AddMonths(1).AddDays(-1);
            var startOfYear = new DateTime(UTCToday.Year, 1, 1);
            var endOfYear = new DateTime(UTCToday.Year, 12, 31);

            str_Query = str_Query.Replace("{{today}}", UTCToday.ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{now}}", UTCNow.ToString("yyyy-MM-dd HH:mm"));
            str_Query = str_Query.Replace("{{tomorrow}}", UTCToday.AddDays(1).ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{yesterday}}", UTCToday.AddDays(-1).ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{today+7days}}", UTCToday.AddDays(7).ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{today-7days}}", UTCToday.AddDays(-7).ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{today+30days}}", UTCToday.AddDays(30).ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{today-30days}}", UTCToday.AddDays(-30).ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{start month}}", startOfMonth.ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{end month}}", endOfMonth.ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{start prev month}}", startOfPrevMonth.ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{end prev month}}", endOfPrevMonth.ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{start year}}", startOfYear.ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{end year}}", endOfYear.ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{now-12hours}}", UTCNow.AddHours(-12).ToString("yyyy-MM-dd"));
            str_Query = str_Query.Replace("{{now+12hours}}", UTCNow.AddHours(12).ToString("yyyy-MM-dd"));

            while (str_Query.Contains("[[nOperandDate]]"))
            {
                str_Query = Replace_nOperandDate(str_Query, isDashboard, _context, UTCNow, UTCToday, false);
            }
            while (str_Query.Contains("[[nOperandDated]]"))
            {
                str_Query = Replace_nOperandDate(str_Query, isDashboard, _context, UTCNow, UTCToday, true);
            }

            if (userId > 0)
                str_Query = str_Query.Replace("{{userId}}", userId.ToString());

            return str_Query;
        }
        private static string Replace_nOperandDate(string str_Query, bool isDashboard, aditaas_v5Context _context, DateTime UTCNow, DateTime UTCToday, bool isDashboardCommonFilter)
        {
            var startIndex = str_Query.IndexOf("[[nOperandDate" + (isDashboardCommonFilter ? "d" : "") + "]]");
            var endIndex = str_Query.IndexOf("'", startIndex + 1);
            var operandText = str_Query.Substring(startIndex, endIndex - startIndex);
            var operandValue = "";
            var nOperandValue = "";
            var strArr = operandText.Split("-");
            var filterId = int.Parse(strArr[2]);
            if (isDashboard == true)
            {
                if (isDashboardCommonFilter)
                {
                    var objFiltrBE = _context.TblDboardDashboardFilter.FirstOrDefault(a => a.Uid == filterId);
                    if (strArr[1] == "1")
                    {
                        operandValue = objFiltrBE.Operand1;
                        nOperandValue = objFiltrBE.SubOperand1;
                    }
                    else if (strArr[1] == "2")
                    {
                        operandValue = objFiltrBE.Operand2;
                        nOperandValue = objFiltrBE.SubOperand2;
                    }
                }
                else
                {
                    var objFiltrBE = _context.TblDboardDashboardPanelFilter.FirstOrDefault(a => a.Uid == filterId);
                    if (strArr[1] == "1")
                    {
                        operandValue = objFiltrBE.Operand1;
                        nOperandValue = objFiltrBE.SubOperand1;
                    }
                    else if (strArr[1] == "2")
                    {
                        operandValue = objFiltrBE.Operand2;
                        nOperandValue = objFiltrBE.SubOperand2;
                    }
                }
            }
            else
            {
                var objFiltrBE = _context.TblRptReportFilter.FirstOrDefault(a => a.Uid == filterId);
                if (strArr[1] == "1")
                {
                    operandValue = objFiltrBE.Operand1;
                    nOperandValue = objFiltrBE.SubOperand1;
                }
                else if (strArr[1] == "2")
                {
                    operandValue = objFiltrBE.Operand2;
                    nOperandValue = objFiltrBE.SubOperand2;
                }
            }

            if (operandValue == "{{now+{n}minutes}}")
                operandValue = UTCNow.AddMinutes(double.Parse(nOperandValue)).ToString("yyyy-MM-dd HH:mm");
            else if (operandValue == "{{now+{n}hours}}")
                operandValue = UTCNow.AddHours(double.Parse(nOperandValue)).ToString("yyyy-MM-dd HH:mm");
            else if (operandValue == "{{today+{n}days}}")
                operandValue = UTCToday.AddDays(double.Parse(nOperandValue)).ToString("yyyy-MM-dd HH:mm");
            else if (operandValue == "{{today+{n}months}}")
                operandValue = UTCToday.AddMonths(int.Parse(nOperandValue)).ToString("yyyy-MM-dd HH:mm");
            str_Query = str_Query.Replace(operandText, operandValue);

            return str_Query;
        }

        public static string Get_SQL_DateColumn_By_Format(TblMstDbViewColumn obj_db_Col_BE, string str_Format_Text, bool isFilter = false)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
            var IsPostgreSQL = configuration.GetSection("AppSettings").GetValue<bool>("IsPostgreSQL");
            if (IsPostgreSQL)
            {
                return Get_SQL_DateColumn_By_Format_Postgres(obj_db_Col_BE, str_Format_Text, isFilter);
            }

            string str_Col_Name = "\"" + obj_db_Col_BE.DbColumnName + "\"";
            str_Col_Name = "cast((" + str_Col_Name + " AT TIME ZONE 'UTC' AT TIME ZONE '{{UserTimeZone}}') as date)";
            if (isFilter == false)
            {
                str_Col_Name = "\"" + obj_db_Col_BE.DbColumnName + "\"";
                str_Col_Name = "(" + str_Col_Name + " AT TIME ZONE 'UTC' AT TIME ZONE '{{UserTimeZone}}')";
                if (str_Format_Text == null || str_Format_Text == "")
                {
                    if (obj_db_Col_BE.DataType == "date")
                        str_Format_Text = "MM-dd-yyyy";
                    else if (obj_db_Col_BE.DataType == "datetime")
                        str_Format_Text = "MM-dd-yyyy hh:mm tt";
                }
                if (str_Format_Text != null && (obj_db_Col_BE.DataType == "date" || obj_db_Col_BE.DataType == "datetime"))
                {
                    if (str_Format_Text.Contains("h") || str_Format_Text.Contains("HH")) // NOSONAR
                    {
                        //str_Col_Name = str_Col_Name;  // NOSONAR
                    }  // NOSONAR
                    else if (str_Format_Text.Contains("d") == true)
                        str_Col_Name = "CONVERT(date, " + str_Col_Name + ")";
                    else if (str_Format_Text.Contains("M") == true)
                        str_Col_Name = "CONVERT(DATETIME, CONVERT(VARCHAR(7)," + str_Col_Name + ", 120) + '-01')";
                    else if (str_Format_Text == "yyyy" || str_Format_Text == "yy")
                        str_Col_Name = "CONVERT(DATETIME, CONVERT(VARCHAR(4)," + str_Col_Name + ", 120) + '-01-01')";
                }
            }
            return str_Col_Name;
        }

        private static string Get_SQL_DateColumn_By_Format_Postgres(TblMstDbViewColumn obj_db_Col_BE, string str_Format_Text, bool isFilter = false)
        {
            string str_Col_Name = "\"" + obj_db_Col_BE.DbColumnName + "\"";
            str_Col_Name = "((" + str_Col_Name + " AT TIME ZONE 'UTC') AT TIME ZONE '{{UserTimeZone}}')";
            if (isFilter == false)
            {
                if (str_Format_Text == null || str_Format_Text == "")
                {
                    if (obj_db_Col_BE.DataType == "date")
                        str_Format_Text = "MM-dd-yyyy";
                    else if (obj_db_Col_BE.DataType == "datetime")
                        str_Format_Text = "MM-dd-yyyy hh:mm tt";
                }
                if (str_Format_Text != null && (obj_db_Col_BE.DataType == "date" || obj_db_Col_BE.DataType == "datetime"))
                {
                    if (str_Format_Text.Contains("d") == true)
                        str_Col_Name = "date(" + str_Col_Name + ")";
                    else if (str_Format_Text.Contains("M") == true)
                        str_Col_Name = "date_trunc('MONTH'," + str_Col_Name + ")";
                    else if (str_Format_Text == "yyyy" || str_Format_Text == "yy")
                        str_Col_Name = "date_trunc('Year'," + str_Col_Name + ")";
                }
            }
            return str_Col_Name;
        }


        public static string Get_SQL_DateValue_By_Format(TblMstDbViewColumn obj_db_Col_BE, string str_Format_Text, string str_Value)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
            var IsPostgreSQL = configuration.GetSection("AppSettings").GetValue<bool>("IsPostgreSQL");
            if (IsPostgreSQL)
            {
                return Get_SQL_DateValue_By_Format_Postgres(obj_db_Col_BE, str_Format_Text, str_Value);
            }
            string str_Col_Name = "'" + str_Value + "'";
            if (str_Format_Text == null || str_Format_Text == "")
            {
                if (obj_db_Col_BE.DataType == "date")
                    str_Format_Text = "MM-dd-yyyy";
                else if (obj_db_Col_BE.DataType == "datetime")
                    str_Format_Text = "MM-dd-yyyy hh:mm tt";
            }
            if (obj_db_Col_BE.DataType == "date" || obj_db_Col_BE.DataType == "datetime")
            {
                if (str_Format_Text == "MM-dd-yyyy")
                    str_Col_Name = "CONVERT(date, " + str_Col_Name + ")";
                else if (str_Format_Text == "MM-yyyy" || str_Format_Text == "MMM-yyyy")
                    str_Col_Name = "CONVERT(DATETIME, CONVERT(VARCHAR(7)," + str_Col_Name + ", 120) + '-01')";
                else if (str_Format_Text == "yyyy")
                    str_Col_Name = "CONVERT(DATETIME, CONVERT(VARCHAR(4)," + str_Col_Name + ", 120) + '-01-01')";

            }
            return str_Col_Name;
        }

        private static string Get_SQL_DateValue_By_Format_Postgres(TblMstDbViewColumn obj_db_Col_BE, string str_Format_Text, string str_Value)
        {
            string str_Col_Name = "'" + str_Value + "'";
            if (str_Format_Text == null || str_Format_Text == "")
            {
                if (obj_db_Col_BE.DataType == "date")
                    str_Format_Text = "MM-dd-yyyy";
                else if (obj_db_Col_BE.DataType == "datetime")
                    str_Format_Text = "MM-dd-yyyy hh:mm tt";
            }
            if (obj_db_Col_BE.DataType == "date" || obj_db_Col_BE.DataType == "datetime")
            {
                if (str_Format_Text == "MM-dd-yyyy")
                    str_Col_Name = "date(" + str_Col_Name + ")";
                else if (str_Format_Text == "MM-yyyy" || str_Format_Text == "MMM-yyyy")
                    str_Col_Name = "date_trunc('MONTH'," + str_Col_Name + ")";
                else if (str_Format_Text == "yyyy")
                    str_Col_Name = "date_trunc('Year'," + str_Col_Name + ")";
            }
            return str_Col_Name;
        }

        public static DataTable Get_dt_From_SQL(string str_Query, aditaas_v5Context _context, params DbParameter[] ParamList)
        {
            var dt = new DataTable();
            _context.Database.OpenConnection();
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = str_Query;
                cmd.CommandType = CommandType.Text;
                if (ParamList != null)
                {
                    foreach (var param in ParamList)
                    {
                        var parameter = cmd.CreateParameter();
                        parameter.ParameterName = param.ParameterName;
                        parameter.Value = param.Value;
                        cmd.Parameters.Add(parameter);
                    }
                }

                cmd.CommandTimeout = 240;
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            _context.Database.CloseConnection();
            return dt;
        }

        public static void Get_Execute_SQL(string str_Query, aditaas_v5Context _context)
        {
            var dt = new DataTable();
            _context.Database.OpenConnection();
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = str_Query;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            _context.Database.CloseConnection();
        }

        public static string Get_Org_Filter_Condition(TblMstDbView objViewBE, int? userId = null, bool isReport = false)
        {
            var str_Filter_Condition = "";
            if (objViewBE.OrgDbColName != null && objViewBE.OrgDbColName != "")
            {
                var str_Org_Query = "select omap.org_id from tbl_mst_user_org_map omap"
                                    + " where omap.user_id = {{userId}}";
                if (userId > 0)
                    str_Org_Query = str_Org_Query.Replace("{{userId}}", userId.ToString());
                str_Filter_Condition += string.Format(" AND \"{0}\" IN ({1})", objViewBE.OrgDbColName, str_Org_Query);
            }
            if (objViewBE.QueueDbColName != null && objViewBE.QueueDbColName != "" && !isReport)
            {
                var str_Queue_Query = "select qmap.queue_id from tbl_mst_user_queue_map qmap"
                                    + " where qmap.user_id = {{userId}}";
                if (userId > 0)
                    str_Queue_Query = str_Queue_Query.Replace("{{userId}}", userId.ToString());
                str_Filter_Condition += string.Format(" AND \"{0}\" IN ({1})", objViewBE.QueueDbColName, str_Queue_Query);
            }
            return str_Filter_Condition;
        }

        #endregion

        #region Send Email 
        public static async Task SendEmailAsync(int? orgId, string emailTo, string emailCc, string subject, string htmlBody, aditaas_v5Context db_context, List<string> coll_Attachment = null)
        {
            try
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();

                var obj_MailSettingBE = db_context.TblCnfMailOutgoing.FirstOrDefault(a => a.OrgId == orgId && a.IsActive == true);
                if (obj_MailSettingBE == null)
                    return;

                string mailServer = "";
                int mailPort = 0;
                bool isEnableSsl = false;
                string senderName = "";
                string senderMail = "";
                string userName = "";
                string password = "";
                bool requiresAuth = false;

                mailServer = obj_MailSettingBE.MailServer;
                mailPort = (int)obj_MailSettingBE.Port;
                isEnableSsl = (obj_MailSettingBE.IsSslEnable == true);
                senderName = obj_MailSettingBE.SenderName;
                senderMail = obj_MailSettingBE.SenderEmail;
                userName = obj_MailSettingBE.Username;
                password = obj_MailSettingBE.Password;
                requiresAuth = obj_MailSettingBE.RequiresAuth.GetValueOrDefault(false);

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(senderName, senderMail));
                mimeMessage.To.AddRange(emailTo.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim())));
                if (emailCc != null && emailCc != "")
                    mimeMessage.Cc.AddRange(emailCc.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim())));
                mimeMessage.Subject = subject;
                var builder = new BodyBuilder();
                Set_MailBody(builder, htmlBody);

                if (coll_Attachment != null)
                {
                    foreach (var item in coll_Attachment)
                    {
                        // if (File.Exists(item))
                        //   builder.Attachments.Add(item);
                        string rptMailFormat = configuration.GetSection("CommonSettings").GetValue<string>("RptMailFormat");

                        htmlBody = rptMailFormat.Replace("#mailBody#", htmlBody);

                        string attachmentUrl = configuration.GetConnectionString("apiUrl");

                        int pos = item.LastIndexOf("/") + 1;
                        string filename = item.Substring(pos, item.Length - pos);

                        var url = attachmentUrl + "/WebGenAddAttachment/DownloadRptFile?filename=" + filename;
                        var attachmentLink = "<a target = \"_blank\" rel =\"noopener noreferrer\" href =\"" + url + "\">Click here</a>";

                        htmlBody = htmlBody.Replace("#downloadText#", attachmentLink);
                        Set_MailBody(builder, htmlBody);
                    }
                }
                else
                {
                    Set_MailBody(builder, htmlBody);
                }
                mimeMessage.Body = builder.ToMessageBody();

                if (!obj_MailSettingBE.IsExchangeApi.GetValueOrDefault(false))
                {
                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                        //client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        client.ServerCertificateValidationCallback = MySslCertificateValidationCallback;

                        if (isEnableSsl == true)
                        {
                            client.CheckCertificateRevocation = false;
                            client.Connect(mailServer, mailPort, MailKit.Security.SecureSocketOptions.Auto);
                        }
                        else
                            client.Connect(mailServer, mailPort, isEnableSsl);

                        // Note: only needed if the SMTP server requires authentication
                        if (requiresAuth)
                            await client.AuthenticateAsync(senderMail, password);

                        await client.SendAsync(mimeMessage);
                        await client.DisconnectAsync(true);

                        Console.WriteLine("Email notification sent to " + emailTo);
                    }
                }
                else
                {
                    SendMailViaApiMime(obj_MailSettingBE, mimeMessage);
                }
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                Console.Error.WriteLine("Error " + ex.Message + " " + ex.StackTrace);
                throw new InvalidOperationException(ex.Message);
            }
        }

        public static void SendMailViaApiMime(TblCnfMailOutgoing tblCnfMailOutgoing, MimeMessage mailMessage)
        {
            var _exchangeService = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            _exchangeService.Credentials = new WebCredentials(tblCnfMailOutgoing.Username, tblCnfMailOutgoing.Password);
            _exchangeService.Url = new Uri(tblCnfMailOutgoing.ExchangeUrl);

            EmailMessage message = new EmailMessage(_exchangeService);
            message.Subject = mailMessage.Subject;
            var messageBody = (mailMessage.HtmlBody == null ? mailMessage.TextBody : mailMessage.HtmlBody);
            MessageBody msgBody = new MessageBody(BodyType.HTML, messageBody);
            message.Sender = tblCnfMailOutgoing.SenderEmail;
            message.Body = msgBody;

            foreach (MailboxAddress torecmail in mailMessage.To)
            {
                message.ToRecipients.Add(torecmail.Address);
            }
            if (mailMessage.Cc != null)
            {
                foreach (MailboxAddress ccrecmail in mailMessage.Cc)
                {
                    message.CcRecipients.Add(ccrecmail.Address);
                }
            }
            message.Send().Wait();
        }
        public static void Set_MailBody(MailMessage mail, string bodyHtml)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(bodyHtml);
            var cid_Counter = 0;
            if (doc.DocumentNode.SelectNodes("//img") != null)
            {
                foreach (HtmlNode imgNode in doc.DocumentNode.SelectNodes("//img"))
                {
                    var str_data = imgNode.GetAttributeValue("src", null);
                    if (str_data != null && str_data != "")
                    {
                        var contentId = MimeUtils.GenerateMessageId();
                        var imageParts = str_data.Split(',');
                        if (imageParts.Length > 1)
                        {
                            var bytes = Convert.FromBase64String(imageParts[1]);
                            var objAttachment = new System.Net.Mail.Attachment(new MemoryStream(bytes), contentId + ".jpg");
                            objAttachment.ContentId = contentId;
                            mail.Attachments.Add(objAttachment);
                            var newNode = HtmlNode.CreateNode(string.Format(@"<img src='cid:{0}'/>", contentId));
                            imgNode.ParentNode.ReplaceChild(newNode, imgNode);
                            cid_Counter++;
                        }
                    }
                }
            }
            mail.Body = doc.DocumentNode.OuterHtml;
        }

        public static void Set_MailBody(BodyBuilder builder, string bodyHtml)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(bodyHtml);
            var cid_Counter = 0;
            if (doc.DocumentNode.SelectNodes("//img") != null)
            {
                foreach (HtmlNode imgNode in doc.DocumentNode.SelectNodes("//img"))
                {
                    var str_data = imgNode.GetAttributeValue("src", null);
                    if (str_data != null && str_data != "")
                    {
                        var contentId = MimeUtils.GenerateMessageId();
                        var imageParts = str_data.Split(',');
                        if (imageParts.Length > 1)
                        {
                            var bytes = Convert.FromBase64String(imageParts[1]);

                            var image = (MimePart)builder.LinkedResources.Add(contentId + ".jpg", bytes);
                            image.ContentId = contentId;
                            image.IsAttachment = false;
                            var newNode = HtmlNode.CreateNode(string.Format(@"<img src='cid:{0}'/>", contentId));
                            imgNode.ParentNode.ReplaceChild(newNode, imgNode);
                            cid_Counter++;
                        }
                    }
                }
            }
            builder.HtmlBody = doc.DocumentNode.OuterHtml;
        }


        #endregion

        public static string Get_ReportFileName(string name, string FileType)
        {
            var str_FileName = name.Replace("/", "_").Replace(@"\", "_") + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            if (FileType.ToUpper() == "EXCEL")
                str_FileName += ".xlsx";
            else if (FileType.ToUpper() == "PDF")
                str_FileName += ".pdf";
            else if (FileType.ToUpper() == "IMG")
                str_FileName += ".jpg";
            //Directory.CreateDirectory(Path.GetDirectoryName(str_FileName));
            return str_FileName;
        }
        public static string GetExportReportFileName(string name, string FileType)
        {
            var str_FileName = "";
            str_FileName += name.Replace("/", "_").Replace(@"\", "_") + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            if (FileType.ToUpper() == "EXCEL")
                str_FileName += ".xlsx";
            else if (FileType.ToUpper() == "PDF")
                str_FileName += ".pdf";
            else if (FileType.ToUpper() == "IMG")
                str_FileName += ".jpg";

            return str_FileName;
        }
        public static int? Get_TicketOrgId_From_Id(Enum_ModuleTypes moduleType, int? recordId, aditaas_v5Context db_Context)
        {
            int? int_OrgId = null;

            if (moduleType == Enum_ModuleTypes.Incident)
                int_OrgId = db_Context.TblTrnIncident.Where(a => a.IncidentId == recordId).Select(a => a.OrgId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                int_OrgId = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == recordId).Select(a => a.OrgId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                int_OrgId = db_Context.TblTrnProblem.Where(a => a.ProblemId == recordId).Select(a => a.OrgId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                int_OrgId = db_Context.TblTrnChange.Where(a => a.ChangeId == recordId).Select(a => a.OrgId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Kb)
                int_OrgId = db_Context.TblTrnKb.Where(a => a.KbId == recordId).Select(a => a.OrgId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                int_OrgId = db_Context.TblTrnTask.Where(a => a.TaskId == recordId).Select(a => a.OrgId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Assets)
                int_OrgId = db_Context.TblCmdbTrnCi.Where(a => a.CiId == recordId).Select(a => a.OrgId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.FieldService)
                int_OrgId = db_Context.TblTrnFieldService.Where(a => a.FieldServiceId == recordId).Select(a => a.OrgId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Approval)
            {
                var objApproval_BE = db_Context.TblTrnApproval.Where(a => a.ApproverId == recordId).Select(a => new { a.ModuleId, a.RecordId }).FirstOrDefault();
                if (objApproval_BE != null)
                {
                    int_OrgId = Get_TicketOrgId_From_Id((Enum_ModuleTypes)objApproval_BE.ModuleId, objApproval_BE.RecordId, db_Context);
                }
            }
            return int_OrgId;
        }

        public static int? Get_TicketSiteId_From_Id(Enum_ModuleTypes moduleType, int? ticketId, aditaas_v5Context db_Context)
        {
            int? int_SiteId = null;
            if (moduleType == Enum_ModuleTypes.Incident)
                int_SiteId = db_Context.TblTrnIncident.Where(a => a.IncidentId == ticketId).Select(a => a.LocationId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                int_SiteId = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == ticketId).Select(a => a.LocationId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                int_SiteId = db_Context.TblTrnProblem.Where(a => a.ProblemId == ticketId).Select(a => a.LocationId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                int_SiteId = db_Context.TblTrnChange.Where(a => a.ChangeId == ticketId).Select(a => a.LocationId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Assets)
                int_SiteId = db_Context.TblCmdbTrnCi.Where(a => a.CiId == ticketId).Select(a => a.LocationId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Approval)
            {
                var obj_AppBE = db_Context.TblTrnApproval.FirstOrDefault(a => a.ApprovalId == ticketId);
                if (obj_AppBE != null)
                    int_SiteId = Get_TicketSiteId_From_Id((Enum_ModuleTypes)obj_AppBE.ModuleId, obj_AppBE.RecordId, db_Context);
            }
            return int_SiteId;
        }

        public static string Get_IdNumber_From_RecordId(Enum_ModuleTypes moduleType, int? ticketId, aditaas_v5Context db_Context)
        {
            string str_IdNumber = null;
            if (moduleType == Enum_ModuleTypes.Incident)
                str_IdNumber = db_Context.TblTrnIncident.Where(a => a.IncidentId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                str_IdNumber = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                str_IdNumber = db_Context.TblTrnProblem.Where(a => a.ProblemId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                str_IdNumber = db_Context.TblTrnChange.Where(a => a.ChangeId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Kb)
                str_IdNumber = db_Context.TblTrnKb.Where(a => a.KbId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                str_IdNumber = db_Context.TblTrnTask.Where(a => a.TaskId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Assets)
                str_IdNumber = db_Context.TblCmdbTrnCi.Where(a => a.CiId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Approval)
                str_IdNumber = db_Context.TblTrnApproval.Where(a => a.ApproverId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.FieldService)
                str_IdNumber = db_Context.TblTrnFieldService.Where(a => a.FieldServiceId == ticketId).Select(a => a.IdNumber).FirstOrDefault();
            return str_IdNumber;
        }

        public static DateTime? Get_CreatedOn_From_RecordId(Enum_ModuleTypes moduleType, int? ticketId, aditaas_v5Context db_Context)
        {
            DateTime? dt_CreatedOn = null;
            if (moduleType == Enum_ModuleTypes.Incident)
                dt_CreatedOn = db_Context.TblTrnIncident.Where(a => a.IncidentId == ticketId).Select(a => a.CreatedOn).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                dt_CreatedOn = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == ticketId).Select(a => a.CreatedOn).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                dt_CreatedOn = db_Context.TblTrnProblem.Where(a => a.ProblemId == ticketId).Select(a => a.CreatedOn).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                dt_CreatedOn = db_Context.TblTrnChange.Where(a => a.ChangeId == ticketId).Select(a => a.CreatedOn).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                dt_CreatedOn = db_Context.TblTrnTask.Where(a => a.TaskId == ticketId).Select(a => a.CreatedOn).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.FieldService)
                dt_CreatedOn = db_Context.TblTrnFieldService.Where(a => a.FieldServiceId == ticketId).Select(a => a.CreatedOn).FirstOrDefault();
            return dt_CreatedOn;
        }

        public static int? Get_CreatedById_From_RecordId(Enum_ModuleTypes moduleType, int? ticketId, aditaas_v5Context db_Context)
        {
            int? int_CreatedById = null;
            if (moduleType == Enum_ModuleTypes.Incident)
                int_CreatedById = db_Context.TblTrnIncident.Where(a => a.IncidentId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                int_CreatedById = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                int_CreatedById = db_Context.TblTrnProblem.Where(a => a.ProblemId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                int_CreatedById = db_Context.TblTrnChange.Where(a => a.ChangeId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                int_CreatedById = db_Context.TblTrnTask.Where(a => a.TaskId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.FieldService)
                int_CreatedById = db_Context.TblTrnFieldService.Where(a => a.FieldServiceId == ticketId).Select(a => a.CreatedById).FirstOrDefault();
            return int_CreatedById;
        }


        public static DateTime? Get_ResolvedOn_From_RecordId(Enum_ModuleTypes moduleType, int? ticketId, aditaas_v5Context db_Context)
        {
            DateTime? dt_ResolvedOn = null;
            if (moduleType == Enum_ModuleTypes.Incident)
                dt_ResolvedOn = db_Context.TblTrnIncident.Where(a => a.IncidentId == ticketId).Select(a => a.ResolvedOn).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                dt_ResolvedOn = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == ticketId).Select(a => a.FulfillmentDate).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                dt_ResolvedOn = db_Context.TblTrnProblem.Where(a => a.ProblemId == ticketId).Select(a => a.CloseDate).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                dt_ResolvedOn = db_Context.TblTrnChange.Where(a => a.ChangeId == ticketId).Select(a => a.CloseDate).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                dt_ResolvedOn = db_Context.TblTrnTask.Where(a => a.TaskId == ticketId).Select(a => a.ClosedOn).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.FieldService)
                dt_ResolvedOn = db_Context.TblTrnFieldService.Where(a => a.FieldServiceId == ticketId).Select(a => a.ClosedOn).FirstOrDefault();
            return dt_ResolvedOn;
        }

        public static int? Get_ResolvedById_From_RecordId(Enum_ModuleTypes moduleType, int? ticketId, aditaas_v5Context db_Context)
        {
            int? int_ResolvedById = null;
            if (moduleType == Enum_ModuleTypes.Incident)
                int_ResolvedById = db_Context.TblTrnIncident.Where(a => a.IncidentId == ticketId).Select(a => a.ResolvedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                int_ResolvedById = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == ticketId).Select(a => a.FulfilledById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                int_ResolvedById = db_Context.TblTrnProblem.Where(a => a.ProblemId == ticketId).Select(a => a.ClosedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                int_ResolvedById = db_Context.TblTrnChange.Where(a => a.ChangeId == ticketId).Select(a => a.ClosedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                int_ResolvedById = db_Context.TblTrnTask.Where(a => a.TaskId == ticketId).Select(a => a.ClosedById).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.FieldService)
                int_ResolvedById = db_Context.TblTrnFieldService.Where(a => a.FieldServiceId == ticketId).Select(a => a.ClosedById).FirstOrDefault();
            return int_ResolvedById;
        }

        public static string Get_UserName_From_UserId(int? userId, aditaas_v5Context db_Context)
        {
            return db_Context.TblMstUser.Where(a => a.UserId == userId)
                                                    .Select(a => a.FirstName + " " + a.LastName)
                                                    .FirstOrDefault();
        }

        public static int? Get_RecordId_From_IdNumber(Enum_ModuleTypes moduleType, string idNumber, aditaas_v5Context db_Context)
        {
            int? recordId = null;
            if (moduleType == Enum_ModuleTypes.Incident)
                recordId = db_Context.TblTrnIncident.Where(a => a.IdNumber == idNumber).Select(a => a.IncidentId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                recordId = db_Context.TblTrnServiceRequest.Where(a => a.IdNumber == idNumber).Select(a => a.ServiceRequestId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                recordId = db_Context.TblTrnProblem.Where(a => a.IdNumber == idNumber).Select(a => a.ProblemId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                recordId = db_Context.TblTrnChange.Where(a => a.IdNumber == idNumber).Select(a => a.ChangeId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Kb)
                recordId = db_Context.TblTrnKb.Where(a => a.IdNumber == idNumber).Select(a => a.KbId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                recordId = db_Context.TblTrnTask.Where(a => a.IdNumber == idNumber).Select(a => a.TaskId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Assets)
                recordId = db_Context.TblCmdbTrnCi.Where(a => a.IdNumber == idNumber).Select(a => a.CiId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.FieldService)
                recordId = db_Context.TblTrnFieldService.Where(a => a.IdNumber == idNumber).Select(a => a.FieldServiceId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Approval)
                recordId = db_Context.TblTrnApproval.Where(a => a.IdNumber == idNumber).Select(a => a.ApprovalId).FirstOrDefault();

            return recordId;
        }

        public static TblMstEntityAttr Get_RecordStatusBE_From_RecordId(Enum_ModuleTypes moduleType, int? recordId, aditaas_v5Context db_Context)
        {
            int? statusId = null;
            if (moduleType == Enum_ModuleTypes.Incident)
                statusId = db_Context.TblTrnIncident.Where(a => a.IncidentId == recordId).Select(a => a.StatusId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Request)
                statusId = db_Context.TblTrnServiceRequest.Where(a => a.ServiceRequestId == recordId).Select(a => a.StatusId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Problem)
                statusId = db_Context.TblTrnProblem.Where(a => a.ProblemId == recordId).Select(a => a.StatusId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Change)
                statusId = db_Context.TblTrnChange.Where(a => a.ChangeId == recordId).Select(a => a.StatusId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Kb)
                statusId = db_Context.TblTrnKb.Where(a => a.KbId == recordId).Select(a => a.StatusId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Task)
                statusId = db_Context.TblTrnTask.Where(a => a.TaskId == recordId).Select(a => a.StatusId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.Assets)
                statusId = db_Context.TblCmdbTrnCi.Where(a => a.CiId == recordId).Select(a => a.StatusId).FirstOrDefault();
            else if (moduleType == Enum_ModuleTypes.FieldService)
                statusId = db_Context.TblTrnFieldService.Where(a => a.FieldServiceId == recordId).Select(a => a.StatusId).FirstOrDefault();
            var objStatusBE = db_Context.TblMstEntityAttr.Where(a => a.EntityAttrId == statusId).FirstOrDefault();
            return objStatusBE;
        }

        public static Enum_ModuleTypes Get_NotesModuleType(int? moduleId)
        {
            if (moduleId == (int)Enum_ModuleTypes.Incident)
                return Enum_ModuleTypes.Incident_Notes;
            else if (moduleId == (int)Enum_ModuleTypes.Request)
                return Enum_ModuleTypes.Request_Notes;
            else if (moduleId == (int)Enum_ModuleTypes.Problem)
                return Enum_ModuleTypes.Problem_Notes;
            else if (moduleId == (int)Enum_ModuleTypes.Change)
                return Enum_ModuleTypes.Change_Notes;
            else if (moduleId == (int)Enum_ModuleTypes.Task)
                return Enum_ModuleTypes.Task_Notes;
            else if (moduleId == (int)Enum_ModuleTypes.Kb)
                return Enum_ModuleTypes.Kb_Notes;
            else if (moduleId == (int)Enum_ModuleTypes.Assets)
                return Enum_ModuleTypes.Assets_Notes;
            else if (moduleId == (int)Enum_ModuleTypes.FieldService)
                return Enum_ModuleTypes.FieldService_Notes;
            else
                return Enum_ModuleTypes.None;
        }


        private static int? Get_ModuleId_From_IdNumber(string idNumber)
        {
            if (idNumber != null && idNumber.StartsWith("IN-"))
                return (int)Enum_ModuleTypes.Incident;
            else if (idNumber != null && idNumber.StartsWith("R-"))
                return (int)Enum_ModuleTypes.Request;
            else
                return null;
        }

        public static int? Get_EntityAttrId_From_Data(int? orgId, int? moduleId, string entityName, string entityAttrName, aditaas_v5Context db_context)
        {
            var result = (from enta in db_context.TblMstEntityAttr
                          join modmap in db_context.TblMstEntityModuleMap on enta.EntityId equals modmap.EntityId
                          join ent in db_context.TblMstEntity on enta.EntityId equals ent.EntityId
                          where enta.OrgId == orgId && modmap.ModuleId == moduleId && ent.Name.ToUpper().Equals(entityName)
                          && enta.Name == entityAttrName
                          select enta.EntityAttrId).FirstOrDefault();
            return result;
        }

        public static string Get_EntityAttrName_From_Id(int? entityAttrId, aditaas_v5Context db_context)
        {
            var result = (from enta in db_context.TblMstEntityAttr
                          where enta.EntityAttrId == entityAttrId
                          select enta.Name).FirstOrDefault();
            return result;
        }

        #region SLA Method



        #endregion


        public static void SetObjectProperty(string propertyName, object value, object obj)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            // make sure object has the property we are after
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(obj, value, null);
            }
        }
        public static object GetPropertyValue(object source, string propertyName, out Type propertyType)
        {
            PropertyInfo property = source.GetType().GetProperty(propertyName);
            if (property == null)
            {
                propertyType = typeof(Object);
                return null;
            }
            propertyType = property.PropertyType;
            return property.GetValue(source, null);
        }
        public static MemoryStream Get_AppLogo_Path()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
            var logoPath = configuration.GetSection("AppSettings").GetValue<string>("LogoPath");

            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(logoPath);
            MemoryStream ms = new MemoryStream(bytes);

            return ms;
        }

        #region send mail template

        public static Dictionary<string, string> Get_Ticket_Field_Info(TblScheduleEvent objSchEventBE, string subjectText, string bodyText, aditaas_v5Context db_Context)
        {
            var coll_Field_Data = new Dictionary<string, string>();
            int? int_moduleId1 = null;

            if (objSchEventBE.EventType == (int)Enum_EventTypes.TicketApproval)
                int_moduleId1 = (int)Enum_ModuleTypes.Approval;
            if (objSchEventBE.ActionType == (int)Enum_ActionTypes.TicketAddNotes)
            {
                int_moduleId1 = (int)Get_NotesModuleType(objSchEventBE.ModuleId);
            }
            var str_BusField_Names = "";

            foreach (var item in db_Context.TblCnfBusField.Where(a => a.ModuleId == objSchEventBE.ModuleId || a.ModuleId == int_moduleId1))
            {
                if (subjectText != null && subjectText.Contains("#" + item.Name + "#"))
                    str_BusField_Names += "," + item.Name;
                if (bodyText != null && bodyText.Contains("#" + item.Name + "#"))
                    str_BusField_Names += "," + item.Name;
            }

            foreach (var item in str_BusField_Names.Split(',').Distinct().Where(a => a != ""))
            {
                var obj_FieldBE = db_Context.TblCnfBusField.FirstOrDefault(a => (a.ModuleId == objSchEventBE.ModuleId || a.ModuleId == int_moduleId1)
                                                                            && a.Name == item);
                if (obj_FieldBE != null)
                {
                    var str_FieldData = Get_Bus_Field_Data(objSchEventBE, obj_FieldBE.BusFieldId, db_Context);
                    if (str_FieldData != null && str_FieldData != "")
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
                else
                    coll_Field_Data.Add(item, "N/A");
            }

            if (bodyText != null && bodyText.Contains("#view ticket#"))
            {
                coll_Field_Data.Add("view ticket", "<a  target='_blank' rel='noopener noreferrer' href='" + Get_ViewTicket_URL(objSchEventBE, db_Context) + "'>View Ticket</a>");
            }

            return coll_Field_Data;
        }

        private static string Get_ViewTicket_URL(TblScheduleEvent objSchEventBE, aditaas_v5Context db_Context)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
            string str_URL = configuration.GetSection("AppSettings").GetValue<string>("ProductLink");

            if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Incident)
                str_URL += "edit-incident/" + objSchEventBE.RecordId;
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Request)
                str_URL += "edit-request/" + objSchEventBE.RecordId;
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Change)
                str_URL += "edit-change/" + objSchEventBE.RecordId;
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Problem)
                str_URL += "edit-problem/" + objSchEventBE.RecordId;
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Task)
                str_URL += "edit-task/" + objSchEventBE.RecordId;
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Assets)
                str_URL += "edit-ci/" + objSchEventBE.RecordId;
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Kb)
                str_URL += "edit-kb/" + objSchEventBE.RecordId;
            else if (objSchEventBE.ModuleId == (int)Enum_ModuleTypes.Approval)
            {
                var OrgId = GlobalClass.Get_TicketOrgId_From_Id((Enum_ModuleTypes)objSchEventBE.ModuleId, objSchEventBE.RecordId, db_Context);
                var TicketIdNumber = GlobalClass.Get_IdNumber_From_RecordId((Enum_ModuleTypes)objSchEventBE.ModuleId, objSchEventBE.RecordId, db_Context);
                str_URL += "edit-approval/" + objSchEventBE.RecordId + "/" + OrgId + "/" + TicketIdNumber;
            }
            return str_URL;
        }

        private static string Get_Bus_Field_Data(TblScheduleEvent objSchEventBE, int? busFieldId, aditaas_v5Context db_Context)
        {
            string str_Result = null;
            var obj_FieldBE = db_Context.TblCnfBusField.FirstOrDefault(a => a.BusFieldId == busFieldId);
            var moduleId = obj_FieldBE.ModuleId;
            int? ticketId = null;
            if (obj_FieldBE != null)
            {
                if (moduleId == (int)Enum_ModuleTypes.Incident || moduleId == (int)Enum_ModuleTypes.Request
                    || moduleId == (int)Enum_ModuleTypes.Problem || moduleId == (int)Enum_ModuleTypes.Change
                    || moduleId == (int)Enum_ModuleTypes.Task || moduleId == (int)Enum_ModuleTypes.Kb
                    || moduleId == (int)Enum_ModuleTypes.Assets)
                {
                    ticketId = objSchEventBE.RecordId;
                }
                else
                {
                    ticketId = objSchEventBE.AdditionalRefId;
                    if (objSchEventBE.ActionType == (int)Enum_ActionTypes.TicketAddNotes)
                    {
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
                        else if (moduleId == (int)Enum_ModuleTypes.Kb)
                            moduleId = (int)Enum_ModuleTypes.Kb_Notes;
                        else if (moduleId == (int)Enum_ModuleTypes.FieldService)
                            moduleId = (int)Enum_ModuleTypes.FieldService_Notes;
                    }
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
            }
            return str_Result;
        }

        public static string Get_BodyText_With_FieldData(Dictionary<string, string> coll_Field_Data, string str_Body, int? userId, aditaas_v5Context db_Context)
        {
            foreach (var item in coll_Field_Data)
            {
                var str_Value = item.Value;
                if (str_Value != null && str_Value.StartsWith("#Date(") && userId != null)
                    str_Value = GlobalClass.Get_DateText_By_TimeZone(str_Value, userId, db_Context);
                str_Body = str_Body.Replace("#" + item.Key + "#", str_Value);
            }
            return str_Body;
        }
        public static string Get_DateText_By_TimeZone(DateTime? dt_Value, int? userId, aditaas_v5Context _context)
        {
            if (dt_Value != null)
            {
                return Get_DateText_By_TimeZone(dt_Value.Value.ToString("yyyy-MM-dd HH:mm"), userId, _context);
            }
            else
                return "";
        }
        public static string Get_DateText_By_TimeZone(string dateText, int? userId, aditaas_v5Context _context)
        {
            var tzone = GlobalClass.Get_TimeZone_By_UserId_WinService(userId, _context);
            dateText = dateText.Replace("#Date(", "").Replace(")#", "");
            var dt_UTC_Date = DateTime.ParseExact(dateText, "yyyy-MM-dd HH:mm", null);
            var tzTime = TimeZoneInfo.ConvertTimeFromUtc(dt_UTC_Date, tzone);
            var dateTimeFormat = GlobalClass.Get_UserDateTime_Format(userId, _context);
            return tzTime.ToString(dateTimeFormat);
        }

        #endregion

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

        public static List<int?> Get_User_Ids_By_Group_Id(int? userGroupId, aditaas_v5Context db_Context)
        {
            return db_Context.TblMstUserQueueMap.Where(a => a.QueueId == userGroupId)
                                                .Select(a => a.UserId)
                                                .ToList();
        }

        public static List<string> Get_UserEmail_By_UserId(IEnumerable<int?> coll_UserId, aditaas_v5Context db_Context)
        {
            var coll_Email = (from user in db_Context.TblMstUser
                              join id in coll_UserId on user.UserId equals id
                              where user.EmailId != null && user.IsActive == true
                              select user.EmailId.ToLower()).Distinct().ToList();
            return coll_Email;
        }

        public static string Get_UserEmail_By_UserId(int? int_UserId, aditaas_v5Context db_Context)
        {
            var str_Email = (from user in db_Context.TblMstUser
                             where user.UserId == int_UserId && user.EmailId != null
                             select user.EmailId.ToLower()).FirstOrDefault();
            return str_Email;
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

        static int? UserId_System_Admin = null;
        public static int? Get_UserId_System_Admin(aditaas_v5Context _context)
        {
            var adiConfigItem = GetConfigItem(_context, "SystemAdminName", 0);
            var sysAdminNam = "SYSTEM.ADMIN";
            if (adiConfigItem != null)
            {
                sysAdminNam = adiConfigItem.Value;
            }
            UserId_System_Admin = _context.TblMstUser.Where(a => a.Name != null && a.Name.ToUpper() == sysAdminNam.ToUpper()).Select(A => A.UserId).FirstOrDefault();
            return UserId_System_Admin;
        }

        public static TblCnfConfigItem GetConfigItem(aditaas_v5Context _context, string configName, int? orgId)
        {
            return _context.TblCnfConfigItem.Where(w => w.Name.ToLower() == configName.ToLower() && w.OrgId == orgId).FirstOrDefault();
        }

        public static string Get_String_From_Obj(Object obj_Num)
        {
            if (obj_Num == null)
                return "";
            else
                return obj_Num.ToString().Trim();
        }
        public static int Get_Int_From_Obj(Object obj_Num)
        {
            int int_value = 0;
            int v = 0;
            if (obj_Num == null)
                return 0;
            else
            {
                string str_Data = obj_Num.ToString().Trim().Split('.')[0].Replace(",", "");
                bool ter = Int32.TryParse(str_Data, out int_value);

                return int_value;
            }
        }
        public static string Get_Str_CSV_From_Str_Coll(IEnumerable<string> Coll, char separator = ',')
        {
            string str_CSV = "";
            foreach (var item in Coll.Distinct())
            {
                if (str_CSV != "") str_CSV += separator;
                str_CSV += Get_String_From_Obj(item);
            }
            return str_CSV;
        }
        public static Double Get_Double_From_Date_Num(object Num)
        {
            try
            {
                if (Num == null)
                    return 0;
                else
                    return (double)Num;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static DateTime? Get_Date_From_Obj(Object obj_dt)
        {
            DateTime dt = DateTime.Now;
            if (DateTime.TryParse(Get_String_From_Obj(obj_dt), out dt) == true)
                return dt;
            else
                return null;
        }
        public static DateTime? Get_Date_From_Obj_DateTime(Object obj_dt)
        {
            try
            {
                DateTime dt = DateTime.ParseExact(Get_String_From_Obj(obj_dt), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture); ;
                return dt;
            }
            catch (Exception ee)
            {
                return null;
            }
        }
        public static List<int> Get_Coll_From_Str_CSV(string str_CSV, string str_Seperator = ",")
        {
            List<int> Coll_Int = null;
            int res = 0;
            Coll_Int = Get_String_From_Obj(str_CSV).Split(str_Seperator[0]).Where(ar => int.TryParse(ar, out res) == true).Select(ar => Convert.ToInt32(ar)).ToList<int>();
            return Coll_Int;
        }

        public static TblMstEntityAttr GetCTIFromText(int? orgId, int? moduleId, string entityName, string entityAttrName, int parentEntAttrId, aditaas_v5Context db_context)
        {
            if (parentEntAttrId == 0)
            {
                var result = (from enta in db_context.TblMstEntityAttr
                              join modmap in db_context.TblMstEntityModuleMap on enta.EntityId equals modmap.EntityId
                              join ent in db_context.TblMstEntity on enta.EntityId equals ent.EntityId
                              where enta.OrgId == orgId && modmap.ModuleId == moduleId && ent.Name.ToUpper().Equals(entityName)
                              && enta.Name == entityAttrName && (enta.ParentEntityAttrId == 0 || enta.ParentEntityAttrId == null)
                              select enta).FirstOrDefault();

                return result;
            }
            else
            {
                var result = (from enta in db_context.TblMstEntityAttr
                              join modmap in db_context.TblMstEntityModuleMap on enta.EntityId equals modmap.EntityId
                              join ent in db_context.TblMstEntity on enta.EntityId equals ent.EntityId
                              where enta.OrgId == orgId && modmap.ModuleId == moduleId && ent.Name.ToUpper().Equals(entityName)
                              && enta.Name == entityAttrName && enta.ParentEntityAttrId == parentEntAttrId
                              select enta).FirstOrDefault();

                return result;
            }
        }

        public static bool MySslCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // If there are no errors, then everything went smoothly.
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            if (sslPolicyErrors.ToString() == "RemoteCertificateNameMismatch, RemoteCertificateChainErrors")
                return true;

            // Note: MailKit will always pass the host name string as the `sender` argument.
            var host = (string)sender;

            if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) != 0)
            {
                // This means that the remote certificate is unavailable. Notify the user and return false.
                Console.WriteLine("The SSL certificate was not available for {0}", host);
                return false;
            }

            if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) != 0)
            {
                // This means that the server's SSL certificate did not match the host name that we are trying to connect to.
                var certificate2 = certificate as X509Certificate2;
                var cn = certificate2 != null ? certificate2.GetNameInfo(X509NameType.SimpleName, false) : certificate.Subject;

                Console.WriteLine("The Common Name for the SSL certificate did not match {0}. Instead, it was {1}.", host, cn);
                return false;
            }

            // The only other errors left are chain errors.
            Console.WriteLine("The SSL certificate for the server could not be validated for the following reasons:");

            // The first element's certificate will be the server's SSL certificate (and will match the `certificate` argument)
            // while the last element in the chain will typically either be the Root Certificate Authority's certificate -or- it
            // will be a non-authoritative self-signed certificate that the server admin created. 
            foreach (var element in chain.ChainElements)
            {
                // Each element in the chain will have its own status list. If the status list is empty, it means that the
                // certificate itself did not contain any errors.
                if (element.ChainElementStatus.Length == 0)
                    continue;

                Console.WriteLine("\u2022 {0}", element.Certificate.Subject);
                foreach (var error in element.ChainElementStatus)
                {
                    // `error.StatusInformation` contains a human-readable error string while `error.Status` is the corresponding enum value.
                    Console.WriteLine("\t\u2022 {0}", error.StatusInformation);
                }
            }

            return false;
        }

        private static DbContextOptionsBuilder<aditaas_v5Context> dbOptionsBuilder = null;
        public static aditaas_v5Context GetV5DbContext()
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

        private static DbContextOptionsBuilder<aditaas_v5Context> dbROOptionsBuilder = null;
        public static aditaas_v5Context GetV5ReadOnlyDbContext()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
            var IsPostgreSQL = configuration.GetSection("AppSettings").GetValue<bool>("IsPostgreSQL");
            if (IsPostgreSQL)
            {
                return GetV5ReadOnlyDbContextPostgres(configuration);
            }
            if (dbROOptionsBuilder == null)
            {
                dbROOptionsBuilder = new DbContextOptionsBuilder<aditaas_v5Context>();
                dbROOptionsBuilder.UseSqlServer(configuration.GetConnectionString("ReadOnlyConnection"), sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null).CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                    sqlOptions.CommandTimeout(600);
                });
            }
            var context = new aditaas_v5Context(dbROOptionsBuilder.Options);
            return context;
        }

        private static aditaas_v5Context GetV5ReadOnlyDbContextPostgres(IConfigurationRoot configuration)
        {
            if (dbROOptionsBuilder == null)
            {
                dbROOptionsBuilder = new DbContextOptionsBuilder<aditaas_v5Context>();
                dbROOptionsBuilder.UseNpgsql(configuration.GetConnectionString("ReadOnlyConnection"), npgsqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null).CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                    sqlOptions.CommandTimeout(600);
                });
            }

            var context = new aditaas_v5Context(dbROOptionsBuilder.Options);
            return context;
        }

        public static void SendMailViaApi(SmtpClient SmtpServer, MailMessage mail, bool requiresAuth, string SenderUser, string SenderPwd, string ExchangeUrl)
        {
            var _exchangeService = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            _exchangeService.Credentials = new WebCredentials(SenderUser, SenderPwd);
            _exchangeService.Url = new Uri(ExchangeUrl);

            EmailMessage message = new EmailMessage(_exchangeService);
            message.Subject = mail.Subject;
            var messageBody = mail.Body;
            MessageBody msgBody = new MessageBody(BodyType.HTML, messageBody);
            message.Sender = mail.From.Address;
            message.Body = msgBody;

            foreach (MailAddress torecmail in mail.To)
            {
                message.ToRecipients.Add(torecmail.Address);
            }
            if (mail.CC != null)
            {
                foreach (MailAddress ccrecmail in mail.CC)
                {
                    message.CcRecipients.Add(ccrecmail.Address);
                }
            }
            message.Send().Wait();
        }
        //binu used function start
        public static async Task SendEmailAsync1(int? emailFrom, string emailTo, string emailCc, string subject, string htmlBody, aditaas_v5Context db_context, List<string> coll_Attachment = null)
        {
            try
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();

                var obj_MailSettingBE = db_context.TblCnfMailOutgoing.FirstOrDefault(a => a.IsActive == true && a.Uid == emailFrom);
                if (obj_MailSettingBE == null)
                    return;

                string mailServer = "";
                int mailPort = 0;
                bool isEnableSsl = false;
                string senderName = "";
                string senderMail = "";
                string userName = "";
                string password = "";
                bool requiresAuth = false;

                mailServer = obj_MailSettingBE.MailServer;
                mailPort = (int)obj_MailSettingBE.Port;
                isEnableSsl = (obj_MailSettingBE.IsSslEnable == true);
                senderName = obj_MailSettingBE.SenderName;
                senderMail = obj_MailSettingBE.SenderEmail;
                userName = obj_MailSettingBE.Username;
                password = obj_MailSettingBE.Password;
                requiresAuth = obj_MailSettingBE.RequiresAuth.GetValueOrDefault(false);

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(senderName, senderMail));
                mimeMessage.To.AddRange(emailTo.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim())));
                if (emailCc != null && emailCc != "")
                    mimeMessage.Cc.AddRange(emailCc.Split(",").Distinct().Select(a => new MailboxAddress(string.Empty, a.Trim())));
                mimeMessage.Subject = subject;
                var builder = new BodyBuilder();
                Set_MailBody(builder, htmlBody);

                if (coll_Attachment != null)
                {
                    foreach (var item in coll_Attachment)
                    {
                        // if (File.Exists(item))
                        //   builder.Attachments.Add(item);
                        string rptMailFormat = configuration.GetSection("CommonSettings").GetValue<string>("RptMailFormat");

                        htmlBody = rptMailFormat.Replace("#mailBody#", htmlBody);

                        string attachmentUrl = configuration.GetConnectionString("apiUrl");

                        int pos = item.LastIndexOf("/") + 1;
                        string filename = item.Substring(pos, item.Length - pos);

                        var url = attachmentUrl + "/WebGenAddAttachment/DownloadRptFile?filename=" + filename;
                        var attachmentLink = "<a target = \"_blank\" rel =\"noopener noreferrer\" href =\"" + url + "\">Click here</a>";

                        htmlBody = htmlBody.Replace("#downloadText#", attachmentLink);
                        Set_MailBody(builder, htmlBody);
                    }
                }
                else
                {
                    Set_MailBody(builder, htmlBody);
                }
                mimeMessage.Body = builder.ToMessageBody();

                if (!obj_MailSettingBE.IsExchangeApi.GetValueOrDefault(false))
                {
                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                        //client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        client.ServerCertificateValidationCallback = MySslCertificateValidationCallback;

                        if (isEnableSsl == true)
                        {
                            client.CheckCertificateRevocation = false;
                            client.Connect(mailServer, mailPort, MailKit.Security.SecureSocketOptions.Auto);
                        }
                        else
                            client.Connect(mailServer, mailPort, isEnableSsl);

                        // Note: only needed if the SMTP server requires authentication
                        if (requiresAuth)
                            await client.AuthenticateAsync(senderMail, password);

                        await client.SendAsync(mimeMessage);
                        await client.DisconnectAsync(true);

                        Console.WriteLine("Email notification sent to " + emailTo);
                    }
                }
                else
                {
                    SendMailViaApiMime(obj_MailSettingBE, mimeMessage);
                }
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                Console.Error.WriteLine("Error " + ex.Message + " " + ex.StackTrace);
                throw new InvalidOperationException(ex.Message);
            }
        }
        //binu used function end


    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TblCnfSlaCond, TblCnfBusRuleCond>().ReverseMap();
            CreateMap<TblDboardDashboardFilter, TblDboardDashboardPanelFilter>().ReverseMap();
        }
    }

    public class EmailSettings
    {
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public bool RequiresAuth { get; set; }
        public string SMSProvideCode { get; set; }
        public bool? IsExchangeApi { get; set; }
        public string ExchangeUrl { get; set; }

    }


    public class CLS_TblMstWorkHrDay
    {

        public int? WorkHrId { get; set; }
        public bool? Is24hr { get; set; }
        public string WeekDay { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }


}
