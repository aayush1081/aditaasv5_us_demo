using aditaas_v5.Classes;
using aditaas_v5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using V5WinService.Classes;

namespace V5WinService.BusinessLogic
{
    public static class CLS_Archive_Data_Engine
    {
        public static void Start_ArchiveData(Object stateInfo)
        {
            using (var db_Context = CLS_Global_Class.Get_db_Context())
            {

                var listOfArch = db_Context.TblCnfDataArchive.Where(a => a.IsActive == true).ToList();
                foreach (var archConfig in listOfArch)
                {
                    try
                    {
                        var tblTrnArchiveLog = new TblTrnArchiveLog();
                        tblTrnArchiveLog.ArchiveId = archConfig.ArchiveId;
                        tblTrnArchiveLog.StartedOn = DateTime.UtcNow;
                        tblTrnArchiveLog.Message = "";
                        var DeptIdsColl = GlobalClass.Get_Coll_From_Str_CSV(archConfig.DepartmentIds, ",");
                        var LocationIdsColl = GlobalClass.Get_Coll_From_Str_CSV(archConfig.LocationIds, ",");
                        #region Incident Module
                        if (archConfig.ModuleId == (int)Enum_ModuleTypes.Incident)
                        {
                            List<int> incList = null;
                            if (archConfig.Status == "RESOLVED_OR_FULFILLED")
                            {
                                if (archConfig.DateOption == "RESOLVED_DATE")
                                {
                                    incList = (from tkt in db_Context.TblTrnIncident
                                               join sts in db_Context.TblMstEntityAttr on tkt.StatusId equals sts.EntityAttrId into stsj
                                               join tblUserDept in db_Context.TblMstUserDeptMap on tkt.UserId equals tblUserDept.UserId into jtblUserDept
                                               from tblUserDept in jtblUserDept.DefaultIfEmpty()
                                               from sts in stsj.DefaultIfEmpty()
                                               where sts.Name.ToUpper() == "RESOLVED" && tkt.OrgId == archConfig.OrgId
                                               && tkt.ResolvedOn <= DateTime.Now.AddMonths(-archConfig.BeforeTimeDuration.GetValueOrDefault(365))
                                               && tkt.IsArchRestore != true
                                               && (DeptIdsColl.Count == 0 || DeptIdsColl.Any(a => a == tblUserDept.DepartmentId))
                                               && (LocationIdsColl.Count == 0 || LocationIdsColl.Any(a => a == tkt.LocationId.GetValueOrDefault(0)))
                                               select tkt.IncidentId).Distinct().ToList(); 
                                }
                                else if (archConfig.DateOption == "CREATED_DATE")
                                {
                                    incList = (from tkt in db_Context.TblTrnIncident
                                               join sts in db_Context.TblMstEntityAttr on tkt.StatusId equals sts.EntityAttrId into stsj
                                               from sts in stsj.DefaultIfEmpty()
                                               join tblUserDept in db_Context.TblMstUserDeptMap on tkt.UserId equals tblUserDept.UserId into jtblUserDept
                                               from tblUserDept in jtblUserDept.DefaultIfEmpty()
                                               where sts.Name.ToUpper() == "RESOLVED" && tkt.OrgId == archConfig.OrgId
                                               && tkt.CreatedOn <= DateTime.Now.AddMonths(-archConfig.BeforeTimeDuration.GetValueOrDefault(365))
                                               && tkt.IsArchRestore != true
                                               && (DeptIdsColl.Count == 0 || DeptIdsColl.Any(a => a == tblUserDept.DepartmentId))
                                               && (LocationIdsColl.Count == 0 || LocationIdsColl.Any(a => a == tkt.LocationId.GetValueOrDefault(0)))
                                               select tkt.IncidentId).Distinct().ToList();
                                }
                            }
                            else if (archConfig.Status == "CLOSED_ONLY")
                            {
                                if (archConfig.DateOption == "CREATED_DATE")
                                {
                                    incList = (from tkt in db_Context.TblTrnIncident
                                               join sts in db_Context.TblMstEntityAttr on tkt.StatusId equals sts.EntityAttrId into stsj
                                               from sts in stsj.DefaultIfEmpty()
                                               join tblUserDept in db_Context.TblMstUserDeptMap on tkt.UserId equals tblUserDept.UserId into jtblUserDept
                                               from tblUserDept in jtblUserDept.DefaultIfEmpty()
                                               where sts.Name.ToUpper() == "CLOSED" && tkt.OrgId == archConfig.OrgId
                                               && tkt.CreatedOn <= DateTime.Now.AddMonths(-archConfig.BeforeTimeDuration.GetValueOrDefault(365))
                                               && tkt.IsArchRestore != true
                                               && (DeptIdsColl.Count == 0 || DeptIdsColl.Any(a => a == tblUserDept.DepartmentId))
                                               && (LocationIdsColl.Count == 0 || LocationIdsColl.Any(a => a == tkt.LocationId.GetValueOrDefault(0)))
                                               select tkt.IncidentId).Distinct().ToList();
                                }
                                else if (archConfig.DateOption == "CLOSED_DATE")
                                {
                                    incList = (from tkt in db_Context.TblTrnIncident
                                               join sts in db_Context.TblMstEntityAttr on tkt.StatusId equals sts.EntityAttrId into stsj
                                               from sts in stsj.DefaultIfEmpty()
                                               join tblUserDept in db_Context.TblMstUserDeptMap on tkt.UserId equals tblUserDept.UserId into jtblUserDept
                                               from tblUserDept in jtblUserDept.DefaultIfEmpty()
                                               where sts.Name.ToUpper() == "CLOSED" && tkt.OrgId == archConfig.OrgId
                                               && (DeptIdsColl.Count == 0 || DeptIdsColl.Any(a => a == tblUserDept.DepartmentId))
                                               && (LocationIdsColl.Count == 0 || LocationIdsColl.Any(a => a == tkt.LocationId.GetValueOrDefault(0)))
                                               && tkt.ClosedOn <= DateTime.Now.AddMonths(-archConfig.BeforeTimeDuration.GetValueOrDefault(365))
                                               && tkt.IsArchRestore != true
                                               select tkt.IncidentId).Distinct().ToList();
                                }
                            }
                            else if (archConfig.Status == "ANY")
                            {
                                if (archConfig.DateOption == "CREATED_DATE")
                                {
                                    incList = (from tkt in db_Context.TblTrnIncident
                                               join tblUserDept in db_Context.TblMstUserDeptMap on tkt.UserId equals tblUserDept.UserId into jtblUserDept
                                               from tblUserDept in jtblUserDept.DefaultIfEmpty()
                                               where tkt.OrgId == archConfig.OrgId
                                               && tkt.CreatedOn <= DateTime.Now.AddMonths(-archConfig.BeforeTimeDuration.GetValueOrDefault(365))
                                               && tkt.IsArchRestore != true
                                               && (DeptIdsColl.Count == 0 || DeptIdsColl.Any(a => a == tblUserDept.DepartmentId))
                                               && (LocationIdsColl.Count == 0 || LocationIdsColl.Any(a => a == tkt.LocationId.GetValueOrDefault(0)))
                                               select tkt.IncidentId).Distinct().ToList();
                                }
                            }

                            if (incList != null)
                            {
                                tblTrnArchiveLog.Message = tblTrnArchiveLog.Message + string.Format("#Date({0})#", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")) + " :-    Archiving process for incident records is started" + Environment.NewLine;
                                var count = 0;
                                foreach (var ticket in incList)
                                {
                                    if (db_Context.ArchTrnIncident.Where(a => a.IncidentId == ticket).Any())
                                    {
                                        continue;
                                    }
                                    #region archive tasks
                                    var arch_tasks = db_Context.TblTrnTask.Where(a => a.ModuleId == (int)Enum_ModuleTypes.Incident && a.RecordId == ticket).ToList();
                                    var taskarr = arch_tasks.Select(a => a.TaskId).ToArray();

                                    var taskactivities = db_Context.TblTrnTaskActivityLog.Where(a => taskarr.Contains((int)a.RecordId)).ToList();

                                    var taskattachment = db_Context.TblTrnTaskAttachment.Where(a => taskarr.Contains((int)a.RecordId)).ToList();

                                    var tasknotes = db_Context.TblTrnTaskNotesLog.Where(a => taskarr.Contains((int)a.RecordId)).ToList();

                                    var taskreminders = db_Context.TblCnfFollowUp.Where(a => taskarr.Contains((int)a.RecordId) && a.ModuleId == (int)Enum_ModuleTypes.Task).ToList();
                                    #endregion

                                    #region archive approvals
                                    var arch_approvals = db_Context.TblTrnApproval.Where(a => a.ModuleId == (int)Enum_ModuleTypes.Incident && a.RecordId == ticket).ToList();
                                    var apprArr = arch_approvals.Select(a => a.ApprovalId).ToArray();

                                    var apprattachment = db_Context.TblTrnApprAttachment.Where(a => apprArr.Contains((int)a.RecordId)).ToList();
                                    #endregion

                                    #region archive incident
                                    var incnotes = db_Context.TblTrnIncNotesLog.Where(a => a.RecordId == ticket).ToList();

                                    var incattachment = db_Context.TblTrnIncAttachment.Where(a => a.RecordId == ticket).ToList();

                                    var incactivities = db_Context.TblTrnIncActivityLog.Where(a => a.RecordId == ticket).ToList();

                                    var increminders = db_Context.TblCnfFollowUp.Where(a => a.ModuleId == (int)Enum_ModuleTypes.Incident && a.RecordId == ticket).ToList();

                                    var incRec = db_Context.TblTrnIncident.Where(a => a.IncidentId == ticket).FirstOrDefault();

                                    var incticketlinks = db_Context.TblTrnTicketLink.Where(a => a.SourceModuleId == (int)Enum_ModuleTypes.Incident && a.SourceRecordId == ticket).ToList();
                                    #endregion

                                    #region Move tickets in archive DB

                                    //Copy ticket start
                                    db_Context.Entry(incRec).State = EntityState.Detached;

                                    var archTrnIncident = MiscUtil.Reflection.PropertyCopy<ArchTrnIncident>.CopyFrom(incRec);
                                    archTrnIncident.ArchiveOn = DateTime.UtcNow;
                                    db_Context.ArchTrnIncident.Add(archTrnIncident);
                                    db_Context.SaveChanges();

                                    foreach (var item in incnotes)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incnote = MiscUtil.Reflection.PropertyCopy<ArchTrnIncNotesLog>.CopyFrom(item);
                                        db_Context.ArchTrnIncNotesLog.Add(new_incnote);
                                    }
                                    if (incnotes.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in incattachment)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incattachment = MiscUtil.Reflection.PropertyCopy<ArchTrnIncAttachment>.CopyFrom(item);
                                        db_Context.ArchTrnIncAttachment.Add(new_incattachment);
                                        db_Context.SaveChanges();
                                    }
                                    if (incattachment.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in incactivities)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incactivities = MiscUtil.Reflection.PropertyCopy<ArchTrnIncActivityLog>.CopyFrom(item);
                                        db_Context.ArchTrnIncActivityLog.Add(new_incactivities);
                                        db_Context.SaveChanges();
                                    }
                                    if (incactivities.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in increminders)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_increminders = MiscUtil.Reflection.PropertyCopy<ArchCnfFollowUp>.CopyFrom(item);
                                        db_Context.ArchCnfFollowUp.Add(new_increminders);
                                        db_Context.SaveChanges();
                                    }
                                    if (increminders.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in incticketlinks)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incrlinks = MiscUtil.Reflection.PropertyCopy<ArchTrnTicketLink>.CopyFrom(item);
                                        db_Context.ArchTrnTicketLink.Add(new_incrlinks);
                                        db_Context.SaveChanges();
                                    }
                                    if (incticketlinks.Count > 0)
                                        db_Context.SaveChanges();

                                    //Approval start
                                    foreach (var item in arch_approvals)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_appr = MiscUtil.Reflection.PropertyCopy<ArchTrnApproval>.CopyFrom(item);
                                        db_Context.ArchTrnApproval.Add(new_appr);
                                        db_Context.SaveChanges();
                                    }
                                    if (arch_approvals.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in apprattachment)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_attach = MiscUtil.Reflection.PropertyCopy<ArchTrnIncAttachment>.CopyFrom(item);
                                        db_Context.ArchTrnIncAttachment.Add(new_attach);
                                        db_Context.SaveChanges();
                                    }
                                    if (apprattachment.Count > 0)
                                        db_Context.SaveChanges();

                                    //Approval end

                                    //Task start
                                    foreach (var item in arch_tasks)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incnote = MiscUtil.Reflection.PropertyCopy<ArchTrnTask>.CopyFrom(item);
                                        db_Context.ArchTrnTask.Add(new_incnote);
                                    }
                                    if (arch_tasks.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in taskactivities)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_act = MiscUtil.Reflection.PropertyCopy<ArchTrnTaskActivityLog>.CopyFrom(item);
                                        db_Context.ArchTrnTaskActivityLog.Add(new_act);
                                    }
                                    if (taskactivities.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in taskattachment)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incattachment = MiscUtil.Reflection.PropertyCopy<ArchTrnTaskAttachment>.CopyFrom(item);
                                        db_Context.ArchTrnTaskAttachment.Add(new_incattachment);
                                        db_Context.SaveChanges();
                                    }
                                    if (taskattachment.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in tasknotes)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_note = MiscUtil.Reflection.PropertyCopy<ArchTrnTaskNotesLog>.CopyFrom(item);
                                        db_Context.ArchTrnTaskNotesLog.Add(new_note);
                                        db_Context.SaveChanges();
                                    }
                                    if (tasknotes.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in taskreminders)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_increminders = MiscUtil.Reflection.PropertyCopy<ArchCnfFollowUp>.CopyFrom(item);
                                        db_Context.ArchCnfFollowUp.Add(new_increminders);
                                        db_Context.SaveChanges();
                                    }
                                    if (taskreminders.Count > 0)
                                        db_Context.SaveChanges();
                                    //Task end

                                    //Copy ticket end

                                    //Delete from source start
                                    db_Context.TblTrnIncident.Remove(incRec);
                                    db_Context.TblTrnIncNotesLog.RemoveRange(incnotes);
                                    db_Context.TblTrnIncAttachment.RemoveRange(incattachment);
                                    db_Context.TblTrnIncActivityLog.RemoveRange(incactivities);
                                    db_Context.TblCnfFollowUp.RemoveRange(increminders);
                                    db_Context.TblTrnTicketLink.RemoveRange(incticketlinks);
                                    db_Context.SaveChanges();


                                    db_Context.TblTrnTask.RemoveRange(arch_tasks);
                                    db_Context.TblTrnTaskNotesLog.RemoveRange(tasknotes);
                                    db_Context.TblTrnTaskAttachment.RemoveRange(taskattachment);
                                    db_Context.TblTrnTaskActivityLog.RemoveRange(taskactivities);
                                    db_Context.TblCnfFollowUp.RemoveRange(taskreminders);
                                    db_Context.SaveChanges();

                                    db_Context.TblTrnApproval.RemoveRange(arch_approvals);
                                    db_Context.TblTrnApprAttachment.RemoveRange(apprattachment);
                                    db_Context.SaveChanges();

                                    //Delete from source end
                                    #endregion

                                    count++;
                                }

                                tblTrnArchiveLog.Message = tblTrnArchiveLog.Message + string.Format("#Date({0})#", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")) + " :-    " + count + " incident records archived, archiving process has been completed for '" + archConfig.ArchiveName + "'" + Environment.NewLine;
                            }
                        }
                        #endregion

                        #region Problem Module
                        if (archConfig.ModuleId == (int)Enum_ModuleTypes.Problem)
                        {
                            IQueryable<int> incList = null;
                            if (archConfig.Status == "CLOSED_ONLY")
                            {
                                if (archConfig.DateOption == "CREATED_DATE")
                                {
                                    incList = (from tkt in db_Context.TblTrnProblem
                                               join sts in db_Context.TblMstEntityAttr on tkt.StatusId equals sts.EntityAttrId into stsj
                                               from sts in stsj.DefaultIfEmpty()
                                               join tblUserDept in db_Context.TblMstUserDeptMap on tkt.UserId equals tblUserDept.UserId into jtblUserDept
                                               from tblUserDept in jtblUserDept.DefaultIfEmpty()
                                               where sts.Name.ToUpper() == "CLOSED" && tkt.OrgId == archConfig.OrgId
                                               && tkt.CreatedOn <= DateTime.Now.AddMonths(-archConfig.BeforeTimeDuration.GetValueOrDefault(365))
                                               && tkt.IsArchRestore != true
                                               && (DeptIdsColl.Count == 0 || DeptIdsColl.Any(a => a == tblUserDept.DepartmentId))
                                               && (LocationIdsColl.Count == 0 || LocationIdsColl.Any(a => a == tkt.LocationId.GetValueOrDefault(0)))
                                               select tkt.ProblemId).Distinct();
                                }
                                else if (archConfig.DateOption == "CLOSED_DATE")
                                {
                                    incList = (from tkt in db_Context.TblTrnProblem
                                               join sts in db_Context.TblMstEntityAttr on tkt.StatusId equals sts.EntityAttrId into stsj
                                               from sts in stsj.DefaultIfEmpty()
                                               join tblUserDept in db_Context.TblMstUserDeptMap on tkt.UserId equals tblUserDept.UserId into jtblUserDept
                                               from tblUserDept in jtblUserDept.DefaultIfEmpty()
                                               where sts.Name.ToUpper() == "CLOSED" && tkt.OrgId == archConfig.OrgId
                                               && tkt.CloseDate <= DateTime.Now.AddMonths(-archConfig.BeforeTimeDuration.GetValueOrDefault(365))
                                               && tkt.IsArchRestore != true
                                               && (DeptIdsColl.Count == 0 || DeptIdsColl.Any(a => a == tblUserDept.DepartmentId))
                                               && (LocationIdsColl.Count == 0 || LocationIdsColl.Any(a => a == tkt.LocationId.GetValueOrDefault(0)))
                                               select tkt.ProblemId).Distinct();
                                }
                            }
                            else if (archConfig.Status == "ANY")
                            {
                                if (archConfig.DateOption == "CREATED_DATE")
                                {
                                    incList = (from tkt in db_Context.TblTrnProblem
                                               join tblUserDept in db_Context.TblMstUserDeptMap on tkt.UserId equals tblUserDept.UserId into jtblUserDept
                                               from tblUserDept in jtblUserDept.DefaultIfEmpty()
                                               where tkt.OrgId == archConfig.OrgId
                                               && tkt.CreatedOn <= DateTime.Now.AddMonths(-archConfig.BeforeTimeDuration.GetValueOrDefault(365))
                                               && tkt.IsArchRestore != true
                                               && (DeptIdsColl.Count == 0 || DeptIdsColl.Any(a => a == tblUserDept.DepartmentId))
                                               && (LocationIdsColl.Count == 0 || LocationIdsColl.Any(a => a == tkt.LocationId.GetValueOrDefault(0)))
                                               select tkt.ProblemId).Distinct();
                                }
                            }

                            if (incList != null)
                            {
                                tblTrnArchiveLog.Message = tblTrnArchiveLog.Message + string.Format("#Date({0})#", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")) + " :-    Archiving process for problem is started" + Environment.NewLine;
                                var count = 0;
                                foreach (var ticket in incList)
                                {
                                    if (db_Context.ArchTrnProblem.Where(a => a.ProblemId == ticket).Any())
                                    {
                                        continue;
                                    }

                                    #region archive tasks
                                    var arch_tasks = db_Context.TblTrnTask.Where(a => a.ModuleId == (int)Enum_ModuleTypes.Problem && a.RecordId == ticket).ToList();
                                    var taskarr = arch_tasks.Select(a => a.TaskId).ToArray();

                                    var taskactivities = db_Context.TblTrnTaskActivityLog.Where(a => taskarr.Contains((int)a.RecordId)).ToList();

                                    var taskattachment = db_Context.TblTrnTaskAttachment.Where(a => taskarr.Contains((int)a.RecordId)).ToList();

                                    var tasknotes = db_Context.TblTrnTaskNotesLog.Where(a => taskarr.Contains((int)a.RecordId)).ToList();

                                    var taskreminders = db_Context.TblCnfFollowUp.Where(a => taskarr.Contains((int)a.RecordId) && a.ModuleId == (int)Enum_ModuleTypes.Task).ToList();
                                    #endregion

                                    #region archive approvals
                                    var arch_approvals = db_Context.TblTrnApproval.Where(a => a.ModuleId == (int)Enum_ModuleTypes.Problem && a.RecordId == ticket).ToList();
                                    var apprArr = arch_approvals.Select(a => a.ApprovalId).ToArray();

                                    var apprattachment = db_Context.TblTrnApprAttachment.Where(a => apprArr.Contains((int)a.RecordId)).ToList();
                                    #endregion

                                    #region archive problem
                                    var incnotes = db_Context.TblTrnPrNotesLog.Where(a => a.RecordId == ticket).ToList();

                                    var incattachment = db_Context.TblTrnPrAttachment.Where(a => a.RecordId == ticket).ToList();

                                    var incactivities = db_Context.TblTrnPrActivityLog.Where(a => a.RecordId == ticket).ToList();

                                    var increminders = db_Context.TblCnfFollowUp.Where(a => a.ModuleId == (int)Enum_ModuleTypes.Problem && a.RecordId == ticket).ToList();

                                    var incticketlinks = db_Context.TblTrnTicketLink.Where(a => a.SourceModuleId == (int)Enum_ModuleTypes.Problem && a.SourceRecordId == ticket).ToList();

                                    var incRec = db_Context.TblTrnProblem.Where(a => a.ProblemId == ticket).FirstOrDefault();
                                    #endregion

                                    #region Move tickets in archive DB

                                    //Copy ticket start
                                    db_Context.Entry(incRec).State = EntityState.Detached;

                                    var tblTrnIncident = MiscUtil.Reflection.PropertyCopy<ArchTrnProblem>.CopyFrom(incRec);
                                    tblTrnIncident.ArchiveOn = DateTime.UtcNow;

                                    db_Context.ArchTrnProblem.Add(tblTrnIncident);
                                    db_Context.SaveChanges();

                                    foreach (var item in incnotes)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incnote = MiscUtil.Reflection.PropertyCopy<ArchTrnPrNotesLog>.CopyFrom(item);
                                        db_Context.ArchTrnPrNotesLog.Add(new_incnote);
                                    }
                                    if (incnotes.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in incattachment)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incattachment = MiscUtil.Reflection.PropertyCopy<ArchTrnPrAttachment>.CopyFrom(item);
                                        db_Context.ArchTrnPrAttachment.Add(new_incattachment);
                                        db_Context.SaveChanges();
                                    }
                                    if (incattachment.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in incactivities)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incactivities = MiscUtil.Reflection.PropertyCopy<ArchTrnPrActivityLog>.CopyFrom(item);
                                        db_Context.ArchTrnPrActivityLog.Add(new_incactivities);
                                        db_Context.SaveChanges();
                                    }
                                    if (incactivities.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in increminders)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_increminders = MiscUtil.Reflection.PropertyCopy<ArchCnfFollowUp>.CopyFrom(item);
                                        db_Context.ArchCnfFollowUp.Add(new_increminders);
                                        db_Context.SaveChanges();
                                    }
                                    if (increminders.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in incticketlinks)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incticketlinks = MiscUtil.Reflection.PropertyCopy<ArchTrnTicketLink>.CopyFrom(item);
                                        db_Context.ArchTrnTicketLink.Add(new_incticketlinks);
                                        db_Context.SaveChanges();
                                    }
                                    if (incticketlinks.Count > 0)
                                        db_Context.SaveChanges();

                                    //Approval start
                                    foreach (var item in arch_approvals)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_appr = MiscUtil.Reflection.PropertyCopy<ArchTrnApproval>.CopyFrom(item);
                                        db_Context.ArchTrnApproval.Add(new_appr);
                                        db_Context.SaveChanges();
                                    }
                                    if (arch_approvals.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in apprattachment)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_attach = MiscUtil.Reflection.PropertyCopy<ArchTrnIncAttachment>.CopyFrom(item);
                                        db_Context.ArchTrnIncAttachment.Add(new_attach);
                                        db_Context.SaveChanges();
                                    }
                                    if (apprattachment.Count > 0)
                                        db_Context.SaveChanges();

                                    //Approval end

                                    //Task start
                                    foreach (var item in arch_tasks)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incnote = MiscUtil.Reflection.PropertyCopy<ArchTrnTask>.CopyFrom(item);
                                        new_incnote.ArchiveOn = DateTime.UtcNow;
                                        db_Context.ArchTrnTask.Add(new_incnote);
                                    }
                                    if (arch_tasks.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in taskactivities)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_act = MiscUtil.Reflection.PropertyCopy<ArchTrnTaskActivityLog>.CopyFrom(item);
                                        db_Context.ArchTrnTaskActivityLog.Add(new_act);
                                    }
                                    if (taskactivities.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in taskattachment)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_incattachment = MiscUtil.Reflection.PropertyCopy<ArchTrnTaskAttachment>.CopyFrom(item);
                                        db_Context.ArchTrnTaskAttachment.Add(new_incattachment);
                                        db_Context.SaveChanges();
                                    }
                                    if (taskattachment.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in tasknotes)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_note = MiscUtil.Reflection.PropertyCopy<ArchTrnTaskNotesLog>.CopyFrom(item);
                                        db_Context.ArchTrnTaskNotesLog.Add(new_note);
                                        db_Context.SaveChanges();
                                    }
                                    if (tasknotes.Count > 0)
                                        db_Context.SaveChanges();

                                    foreach (var item in taskreminders)
                                    {
                                        db_Context.Entry(item).State = EntityState.Detached;
                                        var new_increminders = MiscUtil.Reflection.PropertyCopy<ArchCnfFollowUp>.CopyFrom(item);
                                        db_Context.ArchCnfFollowUp.Add(new_increminders);
                                        db_Context.SaveChanges();
                                    }
                                    if (taskreminders.Count > 0)
                                        db_Context.SaveChanges();
                                    //Task end

                                    //Copy ticket end

                                    //Delete from source start
                                    db_Context.TblTrnProblem.Remove(incRec);
                                    db_Context.TblTrnPrNotesLog.RemoveRange(incnotes);
                                    db_Context.TblTrnPrAttachment.RemoveRange(incattachment);
                                    db_Context.TblTrnPrActivityLog.RemoveRange(incactivities);
                                    db_Context.TblCnfFollowUp.RemoveRange(increminders);
                                    db_Context.TblTrnTicketLink.RemoveRange(incticketlinks);
                                    db_Context.SaveChanges();


                                    db_Context.TblTrnTask.RemoveRange(arch_tasks);
                                    db_Context.TblTrnTaskNotesLog.RemoveRange(tasknotes);
                                    db_Context.TblTrnTaskAttachment.RemoveRange(taskattachment);
                                    db_Context.TblTrnTaskActivityLog.RemoveRange(taskactivities);
                                    db_Context.TblCnfFollowUp.RemoveRange(taskreminders);
                                    db_Context.SaveChanges();

                                    db_Context.TblTrnApproval.RemoveRange(arch_approvals);
                                    db_Context.TblTrnApprAttachment.RemoveRange(apprattachment);
                                    db_Context.SaveChanges();

                                    //Delete from source end
                                    #endregion

                                    count++;
                                }
                                tblTrnArchiveLog.Message = tblTrnArchiveLog.Message + string.Format("#Date({0})#", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")) + " :-    " + count + " problem records archived, archiving process has been completed for '" +  archConfig.ArchiveName + "'" + Environment.NewLine;
                            }
                        }
                        #endregion

                        if (string.IsNullOrEmpty(tblTrnArchiveLog.Message)) tblTrnArchiveLog.Message = tblTrnArchiveLog.Message + string.Format("#Date({0})#", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")) + " :-    " + "No records found for archiving" + Environment.NewLine;

                        tblTrnArchiveLog.EndedOn = DateTime.UtcNow;
                        db_Context.TblTrnArchiveLog.Add(tblTrnArchiveLog);
                        db_Context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        CLS_Global_Class.LogError("Archive databse creation error", ex);
                    }
                    
                }
                //lastArchRec.LastExecutedOn = DateTime.Now;
                //db_Context.TblTrnArchiveLog.Update(lastArchRec);

            }
        }
    }
}
