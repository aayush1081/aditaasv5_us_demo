using aditaas_v5.Classes;
using aditaas_v5.Controllers;
using aditaas_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using V5WinService.Classes;

namespace V5WinService.BusinessLogic
{
    public static class CLS_SLA_Calculation_Engine
    {

        public static void Process_Calculate_TicketSLA()
        {
            try
            {
                CLS_Global_Class.LogInformation("SLA calcuation process start");
                using (var db_Context = CLS_Global_Class.Get_db_Context())
                {
                    var coll_SLAColor = db_Context.TblMstSlaColor.ToList();
                    //var obj_last_CalcDate_BE = db_Context.TblMstEntity.FirstOrDefault(a => a.Name == "SLA Calculation Time" && a.Description != "");
                    var dt_CurrentTime = DateTime.UtcNow;
                    //DateTime? dt_LastCalcTime = null;
                    //if (obj_last_CalcDate_BE == null)
                    //{
                    //    obj_last_CalcDate_BE = new TblMstEntity()
                    //    {
                    //        Name = "SLA Calculation Time",
                    //        Description = dt_CurrentTime.ToString(),
                    //        IsActive = true,
                    //        Level = 0
                    //    };
                    //    db_Context.TblMstEntity.Add(obj_last_CalcDate_BE);
                    //}
                    //else
                    //{
                    //    dt_LastCalcTime = DateTime.Parse(obj_last_CalcDate_BE.Description);
                    //    obj_last_CalcDate_BE.Description = dt_CurrentTime.ToString();
                    //}
                    TblTrnTicketSlaController.ht_Site_CalcTime.Clear();
                    var query = db_Context.TblTrnTicketSla.Where(a => a.ResolveSlaStatus == "Progress" && a.OrgId > 0 && a.WorkHrId > 0).Select(a=>a.TicketSlaId).ToList();
                    //var query = db_Context.TblTrnTicketSla.Where(a => a.RecordId == 592648);
                    var delaycounter = 0;
                    foreach (var item_TicketSlaId in query)
                    {
                        var item_SLABE = db_Context.TblTrnTicketSla.FirstOrDefault(a => a.TicketSlaId == item_TicketSlaId && a.ResolveSlaStatus == "Progress");
                        if (item_SLABE == null)
                            continue;
                        var dbl_Total_Min = TblTrnTicketSlaController.Get_Ticket_Total_Spent_Time_With_Update(item_SLABE, dt_CurrentTime, db_Context);
                        if (item_SLABE.ResolveSlaPercentage == null || item_SLABE.ResolveSlaPercentage < 100) //SLA detail update if not breach
                        {
                            if (dbl_Total_Min == null) dbl_Total_Min = 0;
                            if (item_SLABE.ResponseSlaStatus == "Progress" && item_SLABE.ResponseTargetMin > 0)
                            {
                                item_SLABE.ResponseActualMin = (int?)Math.Round((decimal)dbl_Total_Min, 0);
                                item_SLABE.ResponseSlaPercentage = item_SLABE.ResponseActualMin * 100 / item_SLABE.ResponseTargetMin;
                            }
                            item_SLABE.ResolveActualMin = (int?)Math.Round((decimal)dbl_Total_Min, 0);
                            if (item_SLABE.ResolveTargetMin > 0)
                            {
                                item_SLABE.ResolveSlaPercentage = item_SLABE.ResolveActualMin * 100 / item_SLABE.ResolveTargetMin;
                                if (item_SLABE.ResolveSlaPercentage > 0)
                                {
                                    var percentage = item_SLABE.ResolveSlaPercentage;
                                    if (percentage > 100)
                                        percentage = 100;
                                    item_SLABE.ResolveSlaColor = coll_SLAColor.Where(a => a.OrgId == item_SLABE.OrgId && percentage >= a.PercentageFrom && percentage <= a.PercentageTo).Max(a => a.ColorCode);
                                }
                            }
                        }
                        db_Context.SaveChanges();
                        if (delaycounter == 10)
                        {
                            System.Threading.Thread.Sleep(10);
                            delaycounter = 0;
                        }
                        delaycounter++;
                    }                    
                    coll_SLAColor = null;
                    CLS_Global_Class.LogInformation("SLA calcuation process end");
                    db_Context.Dispose();
                }
            }
            catch (Exception ex)
            {
                CLS_Global_Class.LogError("***************Error SLA Calcuation************");
                CLS_Global_Class.LogError(ex.Message);
                CLS_Global_Class.LogError("**************************************");
            }
        }
    }
}
