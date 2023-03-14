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
    public static class CLS_News_Bulletin_Engine
    {

        public static async Task Set_Scheduler_Event(SignalR_MessageBE objNotifyBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                #region Cancel Pending Job

                foreach (var item in db_Context.TblScheduleEvent.Where(a => a.AdditionalRefId == objNotifyBE.additionalRefId
                                                                    && a.EventType == (int)Enum_EventTypes.News_Bulletin
                                                                    && a.Status == (int)Enum_Schedule_Event_Status.Pending))
                    item.Status = (int)Enum_Schedule_Event_Status.Cancel;
                await db_Context.SaveChangesAsync();

                #endregion

                if (objNotifyBE.actionType == (int)Enum_ActionTypes.TicketCreate || objNotifyBE.actionType == (int)Enum_ActionTypes.TicketUpdate)
                {
                    var obj_BulletinBE = db_Context.TblMstBulletin.FirstOrDefault(a => a.BulletinId == objNotifyBE.additionalRefId);
                    if (obj_BulletinBE != null)
                        Add_ScheduleEvent_Entry(obj_BulletinBE, db_Context);
                }
            }
        }

        public static async Task Start_Schedule_Event(TblScheduleEvent objSchEventBE)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {
                try
                {
                    var obj_BulletinBE = await db_Context.TblMstBulletin.FirstOrDefaultAsync(a => a.BulletinId == objSchEventBE.AdditionalRefId);
                    if (obj_BulletinBE != null )
                    {
                        Send_Notification_News_Remove(objSchEventBE.EventType, obj_BulletinBE, db_Context);

                        #region Send Start Date Notification

                        if (obj_BulletinBE.IsActive == true && obj_BulletinBE.EndDate != objSchEventBE.ScheduledOn)
                        {
                            var obj_MessageBE = new SignalR_MessageBE()
                            {
                                type = "News",
                                notifyType = "add",
                                eventType = objSchEventBE.EventType,
                                additionalRefId = objSchEventBE.AdditionalRefId,
                                title = "News & Bulletin",
                                messageText = obj_BulletinBE.Title,
                            };
                            if (obj_BulletinBE.UserType == "All")
                            {
                                var collUserId = db_Context.TblMstUserOrgMap.Where(a => a.OrgId == obj_BulletinBE.OrgId).Select(a => a.UserId).ToList();
                                CLS_SignalR_Connection.SendWebNotification(obj_MessageBE, db_Context, collUserId);
                            }
                            else if (obj_BulletinBE.UserType == "Agent")
                            {
                                var collUserId = (from userOrgMap in db_Context.TblMstUserOrgMap
                                                  join user in db_Context.TblMstUser on userOrgMap.UserId equals user.UserId
                                                  where user.UserType == "AGENT" && userOrgMap.OrgId == obj_BulletinBE.OrgId
                                                  select userOrgMap.UserId).ToList();
                                CLS_SignalR_Connection.SendWebNotification(obj_MessageBE, db_Context, collUserId);
                            }
                            else if (obj_BulletinBE.UserType == "Self")
                            {
                                var collUserId = (from userOrgMap in db_Context.TblMstUserOrgMap
                                                  join user in db_Context.TblMstUser on userOrgMap.UserId equals user.UserId
                                                  where user.UserType == "SELF" && userOrgMap.OrgId == obj_BulletinBE.OrgId
                                                  select userOrgMap.UserId).ToList();
                                CLS_SignalR_Connection.SendWebNotification(obj_MessageBE, db_Context, collUserId);
                            }
                        }

                        #endregion

                        CLS_Global_Class.LogInformation(string.Format("Bulletin Id: {0} {1} update to users..", obj_BulletinBE.BulletinId, obj_BulletinBE.Title));

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

        private static void Add_ScheduleEvent_Entry(TblMstBulletin obj_BulletinBE, aditaas_v5Context db_Context)
        {
            if (obj_BulletinBE != null)
            {
                var dt_StartDate = (obj_BulletinBE.StartDate == null ? DateTime.UtcNow : obj_BulletinBE.StartDate);
                var objScheduleBE = new TblScheduleEvent()
                {
                    AdditionalRefId = obj_BulletinBE.BulletinId,
                    CreatedOn = DateTime.UtcNow,
                    ScheduledOn = dt_StartDate,
                    Status = (int)Enum_Schedule_Event_Status.Pending,
                    EventType = (int)Enum_EventTypes.News_Bulletin,
                };
                db_Context.TblScheduleEvent.Add(objScheduleBE);
                if (obj_BulletinBE.IsActive == true && obj_BulletinBE.EndDate != null)
                {
                    db_Context.TblScheduleEvent.Add(new TblScheduleEvent()
                    {
                        AdditionalRefId = obj_BulletinBE.BulletinId,
                        CreatedOn = DateTime.UtcNow,
                        ScheduledOn = obj_BulletinBE.EndDate,
                        Status = (int)Enum_Schedule_Event_Status.Pending,
                        EventType = (int)Enum_EventTypes.News_Bulletin,
                    });
                }
                db_Context.SaveChanges();
            }
        }

        private static void Send_Notification_News_Remove(int? eventType, TblMstBulletin obj_BulletinBE, aditaas_v5Context db_Context)
        {
            var obj_MessageRemoveBE = new SignalR_MessageBE()
            {
                type = "News",
                notifyType = "remove",
                eventType = eventType,
                additionalRefId = obj_BulletinBE.BulletinId,
            };
            var collUserId = db_Context.TblMstUserOrgMap.Where(a => a.OrgId == obj_BulletinBE.OrgId).Select(a => a.UserId).ToList();
            CLS_SignalR_Connection.SendWebNotification(obj_MessageRemoveBE, db_Context, collUserId);
        }
    }
}
