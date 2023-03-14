using aditaas_v5.Classes;
using aditaas_v5.Classes.Notification;
using aditaas_v5.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using V5WinService.BusinessLogic;
using System.Threading;

namespace V5WinService.Classes
{
    public static class CLS_SignalR_Connection
    {
        static List<HubConnection> connection;

        public static async Task Start_ConnectionAsync()
        {
            try
            {
                if (connection == null)
                    connection = new List<HubConnection>();

                foreach (var hubConnectionUrl in CLS_Global_Class.hubConnectionUrls)
                {
                    var apiToken = await CLS_v4API.GetApiTokenForHub(hubConnectionUrl.Replace("/notificationHub/", "/api/", StringComparison.InvariantCultureIgnoreCase));

                    var sconnection = new HubConnectionBuilder()
                      .WithUrl(hubConnectionUrl, options =>
                      {
                          options.AccessTokenProvider = () => Task.FromResult(apiToken);
                      })
                      .WithAutomaticReconnect()
                      .Build();

                    connection.Add(sconnection);

                    sconnection.Reconnected += Connection_Reconnected;
                    sconnection.Reconnecting += Connection_Reconnecting;
                    sconnection.Closed += Connection_Closed;
                    sconnection.On<SignalR_MessageBE>("onNotifyTicketAction", (objBE) =>
                    {
                        OnNotify_TicketAction(objBE);
                    });
                    sconnection.On<SignalR_MessageBE>("resendUserInfo", (objBE) =>
                    {
                        SendUserInfoAsync(sconnection).Wait();
                    });
                    sconnection.On<SignalR_MessageBE>("gridCountUpdate", (objBE) =>
                    {
                        foreach (var item in connection)
                        {
                            item.InvokeAsync("sendWebNotificationGridCount", objBE);
                        }
                        //SendUserInfoAsync(sconnection).Wait();
                    });

                    await sconnection.StartAsync();
                    CLS_Global_Class.LogInformation("SignalR Connection Id  : " + sconnection.ConnectionId);
                    await SendUserInfoAsync(sconnection);
                }
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("******* Signal connection error *******", ex);
                await Retry_ConnectionAsync();
                //throw ex;
            }
        }

        private static async Task Connection_Reconnecting(Exception arg)
        {
            CLS_Global_Class.LogInformation("SignalR connection reconnecting..");
        }

        private static async Task Connection_Reconnected(string connectionId)
        {
            CLS_Global_Class.LogInformation("SignalR connection Id  : " + connectionId);
            foreach (var item in connection.Where(a => a.ConnectionId == connectionId))
            {
                await SendUserInfoAsync(item);
            }

        }

        private static async Task Connection_Closed(Exception arg)
        {
            CLS_Global_Class.LogInformation("SignalR connection closed..");
            await Retry_ConnectionAsync();
        }

        private static async Task Retry_ConnectionAsync()
        {
            await Task.Delay(10 * 1000);
            CLS_Global_Class.LogInformation("SignalR connection retry..");
            await Start_ConnectionAsync();
        }

        private static void OnNotify_TicketAction(SignalR_MessageBE objNotifyBE)
        {
            CLS_Global_Class.LogInformation(String.Format("SignalR Notification Data:{0} ", JsonConvert.SerializeObject(objNotifyBE)));
            if (objNotifyBE.eventType == (int)Enum_EventTypes.RptScheduler)
            {
                _ = CLS_Report_Scheduler_Engine.Set_Scheduler_Event(objNotifyBE);
            }
            else if (objNotifyBE.eventType == (int)Enum_EventTypes.TicketReminder)
            {
                _ = CLS_Ticket_Reminder_Engine.Set_Scheduler_Event(objNotifyBE);
            }
            else if (objNotifyBE.eventType == (int)Enum_EventTypes.TicketSchedule)
            {
                _ = CLS_Ticket_Scheduler_Engine.Set_Scheduler_Event(objNotifyBE);
            }
            else if (objNotifyBE.eventType == (int)Enum_EventTypes.News_Bulletin)
            {
                _ = CLS_News_Bulletin_Engine.Set_Scheduler_Event(objNotifyBE);
            }
            else if (objNotifyBE.eventType == (int)Enum_EventTypes.SLA_Manager)
            {
                _ = CLS_SLA_Manager_Engine.Set_Scheduler_Event(objNotifyBE);
            }            
            else if (objNotifyBE.eventType == (int)Enum_EventTypes.Master_Updation)
            {
                if (objNotifyBE.type == "Master Site WorkHours")
                {
                    GlobalClass.hashSet_SiteWorkHr.Clear();
                    GlobalClass.hashSet_WorkHrDay.Clear();
                    GlobalClass.hashSet_WorkHrTimeZone.Clear();
                }
                //else if (objNotifyBE.type == "Ticket's Site Change")
                //{
                //    CLS_Global_Class.Remove_Ticket_SiteId(objNotifyBE.moduleId, objNotifyBE.ticketId);
                //}
                else if (objNotifyBE.type == "Master Holiday")
                {
                    //GlobalClass.hashSet_SiteHoliday.Clear();
                }
                else if (objNotifyBE.type == "Master User")
                {
                    if (GlobalClass.hashSet_UserTZName.ContainsKey(objNotifyBE.additionalRefId)) GlobalClass.hashSet_UserTZName.Remove(objNotifyBE.additionalRefId);
                    if (GlobalClass.hashSet_UserTimeZone.ContainsKey(objNotifyBE.additionalRefId)) GlobalClass.hashSet_UserTimeZone.Remove(objNotifyBE.additionalRefId);
                }
                else if (objNotifyBE.type == "Master Email Manager")
                {
                    CLS_Mail_Manager_Engine.Set_Scheduler_Event();
                }
                else if (objNotifyBE.type == "LDAP Update")
                {
                    try
                    {
                        using (var db_Context = CLS_Global_Class.Get_db_Context())
                        {
                            var adServer = db_Context.TblCnfAdLdap.Where(w => w.ScheduleTime != null && w.RecurrenceHour != null && w.AdLdapId == objNotifyBE.additionalRefId.Value).FirstOrDefault();
                            if (adServer != null)
                            {
                                if (adServer.IsActive.GetValueOrDefault(false))
                                {
                                    var startTime1 = adServer.ScheduleTime;
                                    var Interval = adServer.RecurrenceHour;

                                    DateTime targetDate1 = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy") + " " + startTime1.Value.ToString("HH:mm"));
                                    TimeSpan delayTime1 = targetDate1 - DateTime.Now;

                                    if (delayTime1.CompareTo(TimeSpan.Zero) < 0)
                                        targetDate1 = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy") + " " + startTime1.Value.ToString("HH:mm"));
                                    delayTime1 = targetDate1 - DateTime.Now;

                                    if (LoggingService.dicTimerScheduled.ContainsKey(objNotifyBE.additionalRefId.Value))
                                    {
                                        LoggingService.dicTimerScheduled[objNotifyBE.additionalRefId.Value].Change(delayTime1, new TimeSpan(Interval.Value, 0, 0));
                                    }
                                    else
                                    {
                                        System.Threading.Timer stateTimerScheduled1 = new System.Threading.Timer(LoggingService.ScheduledADTask1, adServer, delayTime1, new TimeSpan(Interval.Value, 0, 0));
                                        LoggingService.dicTimerScheduled.Add(adServer.AdLdapId, stateTimerScheduled1);
                                    }
                                }
                                else
                                {
                                    if (LoggingService.dicTimerScheduled.ContainsKey(objNotifyBE.additionalRefId.Value))
                                    {
                                        var adTimer = LoggingService.dicTimerScheduled[objNotifyBE.additionalRefId.Value];
                                        LoggingService.dicTimerScheduled[objNotifyBE.additionalRefId.Value].Change(Timeout.Infinite, Timeout.Infinite);
                                        LoggingService.dicTimerScheduled.Remove(objNotifyBE.additionalRefId.Value);                                      
                                        try
                                        {
                                            adTimer.Dispose();
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CLS_Global_Class.LogInformation(ex.Message);
                    }
                }
                else if (objNotifyBE.type == "Azure AD Update")
                {
                    try
                    {
                        using (var db_Context = CLS_Global_Class.Get_db_Context())
                        {
                            var adServer = db_Context.TblCnfAzureAd.Where(w => w.ScheduleTime != null && w.RecurrenceHour != null && w.AzureAdId == objNotifyBE.additionalRefId.Value).FirstOrDefault();
                            if (adServer != null)
                            {
                                if(adServer.IsActive.GetValueOrDefault(false))
                                {
                                    var startTime1 = adServer.ScheduleTime;
                                    var Interval = adServer.RecurrenceHour;

                                    DateTime targetDate1 = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy") + " " + startTime1.Value.ToString("HH:mm"));
                                    TimeSpan delayTime1 = targetDate1 - DateTime.Now;

                                    if (delayTime1.CompareTo(TimeSpan.Zero) < 0)
                                        targetDate1 = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy") + " " + startTime1.Value.ToString("HH:mm"));
                                    delayTime1 = targetDate1 - DateTime.Now;

                                    if (LoggingService.dicAzureADTimerScheduled.ContainsKey(objNotifyBE.additionalRefId.Value))
                                    {
                                        LoggingService.dicAzureADTimerScheduled[objNotifyBE.additionalRefId.Value].Change(delayTime1, new TimeSpan(Interval.Value, 0, 0));
                                    }
                                    else
                                    {
                                        System.Threading.Timer stateTimerScheduled1 = new System.Threading.Timer(LoggingService.ScheduledADTask1, adServer, delayTime1, new TimeSpan(Interval.Value, 0, 0));
                                        LoggingService.dicAzureADTimerScheduled.Add(adServer.AzureAdId, stateTimerScheduled1);
                                    }
                                }
                                else
                                {
                                    if (LoggingService.dicAzureADTimerScheduled.ContainsKey(objNotifyBE.additionalRefId.Value))
                                    {
                                        var adTimer = LoggingService.dicAzureADTimerScheduled[objNotifyBE.additionalRefId.Value];
                                        LoggingService.dicAzureADTimerScheduled[objNotifyBE.additionalRefId.Value].Change(Timeout.Infinite, Timeout.Infinite);
                                        LoggingService.dicAzureADTimerScheduled.Remove(objNotifyBE.additionalRefId.Value);
                                        try
                                        {
                                            adTimer.Dispose();

                                        }
                                        catch { }
                                    }
                                }
                            }                            
                        }
                    }
                    catch (Exception ex)
                    {
                        CLS_Global_Class.LogInformation(ex.Message);
                    }
                }
            }
            else
            {
                if (objNotifyBE.actionType == (int)Enum_ActionTypes.TicketCreate && objNotifyBE.eventType != (int)Enum_EventTypes.TicketApproval)
                    _ = CLS_Ticket_Bus_Rule_Engine.On_TicketCreate_P1_Ticket(objNotifyBE);
                _ = CLS_Ticket_Bus_Rule_Engine.Set_Scheduler_EventAsync(objNotifyBE);
            }
        }

        private static async Task SendUserInfoAsync(HubConnection connection)
        {
            if (connection != null)
            {
                //foreach (var sconnection in connection)
                {
                    CLS_Global_Class.LogInformation("Sent SignalR connection information..");
                    await connection.InvokeAsync("setConnectionUserInfo", -1001, "WinService");
                }
            }
        }

        public static void SendWebNotification(SignalR_MessageBE messageBE, aditaas_v5Context db_Context, IEnumerable<int?> coll_UserId, int? userGrpId = null)
        {
            var Coll_UserId_New = new List<int?>();
            if (coll_UserId != null)
                Coll_UserId_New.AddRange(coll_UserId);
            if (userGrpId > 0)
                Coll_UserId_New.AddRange(GlobalClass.Get_UserIds_By_GroupId(db_Context, new int?[] { userGrpId }, null));
            foreach (var item in Coll_UserId_New.Distinct())
                SendWebNotification(messageBE, db_Context, item, false);
            CLS_Global_Class.LogInformation("SignalR notification sent to users : " + string.Join(", ", Coll_UserId_New.ToArray()));
        }

        public static void SendWebNotification(SignalR_MessageBE messageBE, aditaas_v5Context db_Context, int? userId, bool IsSingle = true)
        {
            if (messageBE.createdOn == null)
                messageBE.createdOn = DateTime.UtcNow;
            if (messageBE.type == null)
                messageBE.type = "Notification";
            if (messageBE.type == "Notification")
                messageBE.notificationUid = CLS_Global_Class.Save_TblTrnUserNotification(userId, messageBE, db_Context);
            if (connection != null)
            {
                foreach (var sconnection in connection)
                {
                    sconnection.InvokeAsync("sendWebNotification", userId, messageBE);
                }
            }
            if (IsSingle == true)
                CLS_Global_Class.LogInformation("SignalR notification sent to user : " + userId.ToString());
        }
    }
}
