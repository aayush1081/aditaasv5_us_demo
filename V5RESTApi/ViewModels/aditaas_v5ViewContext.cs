using System;
using aditaas_v5.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aditaas_v5.Models
{

    public partial class aditaas_v5Context : DbContext
    {
        public virtual DbSet<ViewMyFavMyTickets> ViewMyFavMyTickets { get; set; }
        public virtual DbSet<ViewMyFavMyWork> ViewMyFavMyWork { get; set; }
        public virtual DbSet<ViewMyFavMyGroupWork> ViewMyFavMyGroupWork { get; set; }
        public virtual DbSet<ViewMyFavOpenUnAssigned> ViewMyFavOpenUnAssigned { get; set; }
        public virtual DbSet<ViewMyFavMyApprovals> ViewMyFavMyApprovals { get; set; }
        public virtual DbSet<ViewIncReq> ViewIncReq { get; set; }
        public virtual DbSet<ViewCmdbCiList> ViewCmdbCiList { get; set; }

        public virtual DbSet<ViewVipTickets> ViewVipTickets { get; set; }

        public virtual DbSet<ViewUniversalSearchData> ViewUniversalSearchData { get; set; }
        public virtual DbSet<ViewAllTicketsChat> ViewAllTicketsChat { get; set; }
        zpublic virtual DbSet<ViewAllTickets> ViewAllTickets { get; set; }
        public virtual DbSet<ViewAllArchTickets> ViewAllArchTickets { get; set; }

        public virtual DbSet<ViewActivityLogAllModules> ViewActivityLogAllModules { get; set; }

        public virtual DbSet<ViewAllOpenTickets> ViewAllOpenTickets { get; set; }

        protected void OnModelCreatingView(ModelBuilder modelBuilder)
        {
            #region ignore from database migration, code first approach           
            //modelBuilder.Ignore<ViewMyFavMyTickets>();
            //modelBuilder.Ignore<ViewMyFavMyTickets>();
            //modelBuilder.Ignore<ViewMyFavMyWork>();
            //modelBuilder.Ignore<ViewMyFavMyGroupWork>();
            //modelBuilder.Ignore<ViewMyFavOpenUnAssigned>();
            //modelBuilder.Ignore<ViewMyFavMyApprovals>();
            //modelBuilder.Ignore<ViewIncReq>();
            //modelBuilder.Ignore<ViewCmdbCiList>();
            //modelBuilder.Ignore<ViewVipTickets>();
            //modelBuilder.Ignore<ViewUniversalSearchData>();
            //modelBuilder.Ignore<ViewAllTicketsChat>();
            //modelBuilder.Ignore<ViewAllTickets>();
            //modelBuilder.Ignore<ViewAllArchTickets>();
            //modelBuilder.Ignore<ViewActivityLogAllModules>();
            //modelBuilder.Ignore<ViewAllOpenTickets>();
            //return;
            #endregion

            #region code for view
            modelBuilder.Entity<ViewMyFavMyTickets>(entity =>
            {

                entity.HasKey(e => e.TicketId);

                entity.ToTable("view_myfav_mytickets");

                entity.Property(e => e.TicketId)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TicketIdNumber).HasColumnName("idNumber");

                entity.Property(e => e.TicketShortDesc)
                    .HasColumnName("shortDesc")
                    .HasMaxLength(400);

                entity.Property(e => e.TicketOpenedDate).HasColumnName("openedDate");

                entity.Property(e => e.TicketCategory).HasColumnName("category");

                entity.Property(e => e.TicketSubCategory).HasColumnName("subCategory");

                entity.Property(e => e.TicketItem).HasColumnName("item");

                entity.Property(e => e.TicketPriority).HasColumnName("priority");

                entity.Property(e => e.TicketStatus).HasColumnName("status");

                entity.Property(e => e.TicketAssignedTo).HasColumnName("assignedTo");
                entity.Property(e => e.TicketContactName).HasColumnName("contactName");

                entity.Property(e => e.TicketLocation).HasColumnName("location");
                entity.Property(e => e.TicketAltLocation).HasColumnName("altLocation");

                entity.Property(e => e.TicketLastModifyDate).HasColumnName("lastModifyDate");
                entity.Property(e => e.TicketTargetResolveTime).HasColumnName("targetResolveTime");

                entity.Property(e => e.TicketCreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.TicketModifiedBy).HasColumnName("modifiedBy");
                entity.Property(e => e.TicketCreatedById).HasColumnName("createdById");
                entity.Property(e => e.TicketModifiedById).HasColumnName("modifiedById");
                entity.Property(e => e.TicketAssignedToId).HasColumnName("assignedToId");
                entity.Property(e => e.TicketUserId).HasColumnName("userId");
                entity.Property(e => e.TicketQueue).HasColumnName("queue");
                entity.Property(e => e.TicketOrgId).HasColumnName("orgId");
                entity.Property(e => e.TicketOrgName).HasColumnName("orgName");
                entity.Property(e => e.TicketQueueId).HasColumnName("queueId");
                entity.Property(e => e.TicketSeverity).HasColumnName("severity");
                entity.Property(e => e.TicketChannel).HasColumnName("channel");
                entity.Property(e => e.TicketImpactedCi).HasColumnName("impactedCi");
                entity.Property(e => e.TicketIsVip).HasColumnName("is_vip");
                //entity.Property(e => e.contactUserName).HasColumnName("contactusername");
                //entity.Property(e => e.contactMobile).HasColumnName("contactmobile");
                //entity.Property(e => e.contactFirstName).HasColumnName("contactfirstname");
                //entity.Property(e => e.contactLastName).HasColumnName("contactlastname");
                //entity.Property(e => e.contactTitle).HasColumnName("contacttitle");
                //entity.Property(e => e.contactEmail).HasColumnName("contactemail");
                //entity.Property(e => e.contactIsActive).HasColumnName("contactisactive");
                entity.Property(e => e.HasChild).HasColumnName("has_child");
                entity.Property(e => e.addlComments).HasColumnName("additional_comments");
                entity.Property(e => e.slaPercentage).HasColumnName("slaPercentage");
                entity.Property(e => e.moduleId).HasColumnName("moduleid");
                entity.Property(e => e.slaColor).HasColumnName("slaColor");
                entity.Property(e => e.isParent).HasColumnName("is_parent");
            });

            modelBuilder.Entity<ViewMyFavMyWork>(entity =>
            {

                entity.HasKey(e => e.WorkId);

                entity.ToTable("view_myfav_mywork");

                entity.Property(e => e.WorkId)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.WorkIdNumber).HasColumnName("idNumber");

                entity.Property(e => e.WorkShortDesc)
                    .HasColumnName("shortDesc")
                    .HasMaxLength(400);

                entity.Property(e => e.ModuleId).HasColumnName("moduleid");
                entity.Property(e => e.WorkOpenedDate).HasColumnName("openedDate");

                entity.Property(e => e.WorkCategory).HasColumnName("category");

                entity.Property(e => e.WorkSubCategory).HasColumnName("subCategory");

                entity.Property(e => e.WorkItem).HasColumnName("item");

                entity.Property(e => e.WorkPriority).HasColumnName("priority");

                entity.Property(e => e.WorkStatus).HasColumnName("status");

                entity.Property(e => e.WorkAssignedTo).HasColumnName("assignedTo");
                entity.Property(e => e.WorkContactName).HasColumnName("contactName");

                entity.Property(e => e.WorkLocation).HasColumnName("location");
                entity.Property(e => e.WorkAltLocation).HasColumnName("altLocation");

                entity.Property(e => e.WorkLastModifyDate).HasColumnName("lastModifyDate");
                entity.Property(e => e.WorkTargetResolveTime).HasColumnName("targetResolveTime");

                entity.Property(e => e.WorkCreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.WorkModifiedBy).HasColumnName("modifiedBy");
                entity.Property(e => e.WorkCreatedById).HasColumnName("createdById");
                entity.Property(e => e.WorkModifiedById).HasColumnName("modifiedById");
                entity.Property(e => e.WorkAssignedToId).HasColumnName("assignedToId");
                entity.Property(e => e.WorkUserId).HasColumnName("userId");
                entity.Property(e => e.WorkQueue).HasColumnName("queue");
                entity.Property(e => e.WorkCurrentQueueId).HasColumnName("currentQueueId");
                entity.Property(e => e.WorkOrgId).HasColumnName("orgId");
                entity.Property(e => e.WorkOrgName).HasColumnName("orgName");
                entity.Property(e => e.WorkSeverity).HasColumnName("severity");
                entity.Property(e => e.WorkChannel).HasColumnName("channel");
                entity.Property(e => e.WorkImpactedCi).HasColumnName("impactedCi");
                entity.Property(e => e.isVip).HasColumnName("is_vip");

                entity.Property(e => e.HasChild).HasColumnName("has_child");
                entity.Property(e => e.addlComments).HasColumnName("additional_comments");
                entity.Property(e => e.isDraft).HasColumnName("is_draft");
                entity.Property(e => e.slaPercentage).HasColumnName("slaPercentage");
                entity.Property(e => e.slaColor).HasColumnName("slaColor");
                entity.Property(e => e.ParentIncidentId).HasColumnName("parentIncidentId");
                entity.Property(e => e.IsParent).HasColumnName("isParent");
            });

            modelBuilder.Entity<ViewMyFavMyGroupWork>(entity =>
            {

                entity.HasKey(e => e.GworkId);

                entity.ToTable("view_myfav_mygroupwork");

                entity.Property(e => e.GworkId)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GworkIdNumber).HasColumnName("idNumber");

                entity.Property(e => e.GworkShortDesc)
                    .HasColumnName("shortDesc")
                    .HasMaxLength(400);

                entity.Property(e => e.GworkOpenedDate).HasColumnName("openedDate");

                entity.Property(e => e.GworkCategory).HasColumnName("category");

                entity.Property(e => e.GworkSubCategory).HasColumnName("subCategory");

                entity.Property(e => e.GworkItem).HasColumnName("item");

                entity.Property(e => e.GworkPriority).HasColumnName("priority");

                entity.Property(e => e.GworkStatus).HasColumnName("status");

                entity.Property(e => e.GworkAssignedTo).HasColumnName("assignedTo");
                entity.Property(e => e.GworkContactName).HasColumnName("contactName");

                entity.Property(e => e.GworkLocation).HasColumnName("location");
                entity.Property(e => e.GworkAltLocation).HasColumnName("altLocation");

                entity.Property(e => e.GworkLastModifyDate).HasColumnName("lastModifyDate");
                entity.Property(e => e.GworkTargetResolveTime).HasColumnName("targetResolveTime");

                entity.Property(e => e.GworkCreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.GworkModifiedBy).HasColumnName("modifiedBy");
                entity.Property(e => e.GworkCreatedById).HasColumnName("createdById");
                entity.Property(e => e.GworkModifiedById).HasColumnName("modifiedById");
                entity.Property(e => e.GworkAssignedToId).HasColumnName("assignedToId");
                entity.Property(e => e.GworkUserId).HasColumnName("userId");
                entity.Property(e => e.GworkCurrentQueueId).HasColumnName("currentQueueId");
                entity.Property(e => e.GworkQueue).HasColumnName("queue");
                entity.Property(e => e.GworkOrgId).HasColumnName("orgId");
                entity.Property(e => e.GworkOrgName).HasColumnName("orgName");
                entity.Property(e => e.GworkSeverity).HasColumnName("severity");
                entity.Property(e => e.GworkChannel).HasColumnName("channel");
                entity.Property(e => e.GworkImpactedCi).HasColumnName("impactedCi");
                entity.Property(e => e.isVip).HasColumnName("is_vip");
                entity.Property(e => e.ModuleId).HasColumnName("module_id");
                entity.Property(e => e.HasChild).HasColumnName("has_child");
                entity.Property(e => e.addlComments).HasColumnName("additional_comments");
                entity.Property(e => e.slaPercentage).HasColumnName("slaPercentage");
                entity.Property(e => e.slaColor).HasColumnName("slaColor");
                entity.Property(e => e.ParentIncidentId).HasColumnName("parentIncidentId");
                entity.Property(e => e.IsParent).HasColumnName("isParent");
            });
            modelBuilder.Entity<ViewMyFavMyApprovals>(entity =>
            {
                entity.HasKey(e => e.ApprApprovalId)
                    .HasName("id");

                entity.ToTable("view_myfav_myapprovals");

                entity.Property(e => e.ApprApprovalId)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApprIdNumber)
                    .HasColumnName("idNumber")
                    .HasMaxLength(100);

                entity.Property(e => e.ApprModule).HasColumnName("module");

                entity.Property(e => e.rowNumberId).HasColumnName("rowNumberId");

                entity.Property(e => e.ApprRecord).HasColumnName("record");


                entity.Property(e => e.ApprStatus).HasColumnName("status");

                entity.Property(e => e.ApprDescription).HasColumnName("descripion");

                entity.Property(e => e.ApprComment).HasColumnName("comment");

                entity.Property(e => e.ApprQueue).HasColumnName("queue");

                entity.Property(e => e.Approver).HasColumnName("approver");

                entity.Property(e => e.ApprCreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.ApprModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ApprCreatedOn).HasColumnName("createdOn");

                entity.Property(e => e.ApprModifiedOn).HasColumnName("modifiedOn");

                entity.Property(e => e.ApprRequester).HasColumnName("requester");

                entity.Property(e => e.ApprApproverId).HasColumnName("approverId");
                entity.Property(e => e.ApprModuleId).HasColumnName("moduleId");
                entity.Property(e => e.ApprStatusId).HasColumnName("statusId");
                entity.Property(e => e.ApprCreatedbyId).HasColumnName("createdById");
                entity.Property(e => e.ApprModifiedById).HasColumnName("modifiedById");
                entity.Property(e => e.ApprRecordId).HasColumnName("recordId");
                entity.Property(e => e.ApprRequesterId).HasColumnName("requesterId");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.ApprQueueId).HasColumnName("queueId");
                entity.Property(e => e.ApprOrgId).HasColumnName("orgId");
                entity.Property(e => e.ApprOrgName).HasColumnName("orgName");
                entity.Property(e => e.isVip).HasColumnName("is_vip");
                entity.Property(e => e.contactUserName).HasColumnName("contactusername");
                entity.Property(e => e.contactMobile).HasColumnName("contactmobile");
                entity.Property(e => e.contactFirstName).HasColumnName("contactfirstname");
                entity.Property(e => e.contactLastName).HasColumnName("contactlastname");
                entity.Property(e => e.contactTitle).HasColumnName("contacttitle");
                entity.Property(e => e.contactEmail).HasColumnName("contactemail");
                entity.Property(e => e.contactIsActive).HasColumnName("contactisactive");
                entity.Property(e => e.isActive).HasColumnName("isactive");
            });

            modelBuilder.Entity<ViewMyFavOpenUnAssigned>(entity =>
            {

                entity.HasKey(e => e.Id);

                entity.ToTable("view_myfav_open_unassigned");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdNumber).HasColumnName("idNumber");

                entity.Property(e => e.ShortDesc)
                    .HasColumnName("shortDesc")
                    .HasMaxLength(400);


                entity.Property(e => e.OpenedDate).HasColumnName("openedDate");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.SubCategory).HasColumnName("subCategory");

                entity.Property(e => e.Item).HasColumnName("item");

                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.ModuleId).HasColumnName("moduleid");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.AssignedTo).HasColumnName("assignedTo");
                entity.Property(e => e.ContactName).HasColumnName("contactName");

                entity.Property(e => e.Location).HasColumnName("location");
                entity.Property(e => e.AltLocation).HasColumnName("altLocation");

                entity.Property(e => e.LastModifyDate).HasColumnName("lastModifyDate");
                entity.Property(e => e.TargetResolveTime).HasColumnName("targetResolveTime");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
                entity.Property(e => e.CreatedById).HasColumnName("createdById");
                entity.Property(e => e.ModifiedById).HasColumnName("modifiedById");
                entity.Property(e => e.AssignedToId).HasColumnName("assignedToId");
                entity.Property(e => e.UserId).HasColumnName("userId");
                entity.Property(e => e.Queue).HasColumnName("queue");
                entity.Property(e => e.OrgId).HasColumnName("orgId");
                entity.Property(e => e.OrgName).HasColumnName("orgName");
                entity.Property(e => e.Severity).HasColumnName("severity");
                entity.Property(e => e.Channel).HasColumnName("channel");
                entity.Property(e => e.ImpactedCi).HasColumnName("impactedCi");
                entity.Property(e => e.CurrentQueueId).HasColumnName("currentQueueId");
                entity.Property(e => e.isVip).HasColumnName("is_vip");
                entity.Property(e => e.HasChild).HasColumnName("has_child");
                entity.Property(e => e.addlComments).HasColumnName("additional_comments");
                entity.Property(e => e.slaPercentage).HasColumnName("slaPercentage");
                entity.Property(e => e.slaColor).HasColumnName("slaColor");
                entity.Property(e => e.ParentIncidentId).HasColumnName("parentIncidentId");
                entity.Property(e => e.IsParent).HasColumnName("isParent");
            });

            modelBuilder.Entity<ViewIncReq>(entity =>
            {
                entity.ToTable("view_inc_req");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AltLocation)
                    .HasColumnName("altLocation")
                    .HasMaxLength(255);

                entity.Property(e => e.AssignedGroupName).HasMaxLength(255);

                entity.Property(e => e.AssignedTo).HasColumnName("assignedTo");

                entity.Property(e => e.AssignedToId).HasColumnName("assignedToId");
                entity.Property(e => e.OrgId).HasColumnName("org_id");
                entity.Property(e => e.ModuleId).HasColumnName("moduleId");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(200);

                entity.Property(e => e.ContactName).HasColumnName("contactName");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedById).HasColumnName("createdById");

                entity.Property(e => e.IdNumber)
                    .HasColumnName("idNumber")
                    .HasMaxLength(100);

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasMaxLength(200);

                entity.Property(e => e.LastModifyDate).HasColumnName("lastModifyDate");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255);

                entity.Property(e => e.ModifiedById).HasColumnName("modifiedById");

                entity.Property(e => e.OpenedDate).HasColumnName("openedDate");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasMaxLength(150);

                entity.Property(e => e.ShortDesc)
                    .HasColumnName("shortDesc")
                    .HasColumnType("character varying");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(150);

                entity.Property(e => e.SubCategory)
                    .HasColumnName("subCategory")
                    .HasMaxLength(200);

                entity.Property(e => e.TargetResolveTime).HasColumnName("targetResolveTime");

                entity.Property(e => e.UserId).HasColumnName("userId");
                entity.Property(e => e.slaPercentage).HasColumnName("slapercentage");
                entity.Property(e => e.slaColor).HasColumnName("slacolor");
            });
            modelBuilder.Entity<ViewVipTickets>(entity =>
            {
                entity.HasKey(e => e.VipId)
                    .HasName("id");

                entity.ToTable("view_vipticket");

                entity.Property(e => e.VipId)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.VipIdNumber)
                    .HasColumnName("idNumber")
                    .HasMaxLength(100);


                entity.Property(e => e.ModuleId).HasColumnName("moduleid");
                entity.Property(e => e.VipStatus).HasColumnName("status");
                entity.Property(e => e.VipShortDesc).HasColumnName("shortDesc");
                entity.Property(e => e.VipCategory).HasColumnName("category");
                entity.Property(e => e.VipSubCategory).HasColumnName("subCategory");
                entity.Property(e => e.VipItem).HasColumnName("item");
                entity.Property(e => e.VipPriority).HasColumnName("priority");
                entity.Property(e => e.VipQueue).HasColumnName("queue");
                entity.Property(e => e.VipCreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.VipModifiedBy).HasColumnName("modifiedBy");
                entity.Property(e => e.VipCreatedOn).HasColumnName("createdon");
                entity.Property(e => e.VipModifiedOn).HasColumnName("modifiedOn");
                entity.Property(e => e.VipCreatedById).HasColumnName("createdById");
                entity.Property(e => e.VipModifiedById).HasColumnName("modifiedById");
                entity.Property(e => e.VipOrgId).HasColumnName("orgId");
                entity.Property(e => e.VipOrgName).HasColumnName("orgName");
                entity.Property(e => e.VipCurrentQueueId).HasColumnName("currentQueueId");
                entity.Property(e => e.VipAssignedToId).HasColumnName("assignedToId");
                entity.Property(e => e.VipOpenedDate).HasColumnName("openedDate");
                entity.Property(e => e.VipAssignedTo).HasColumnName("assignedTo");
                entity.Property(e => e.VipContactName).HasColumnName("contactName");
                entity.Property(e => e.VipLocation).HasColumnName("location");
                entity.Property(e => e.VipAltLocation).HasColumnName("altLocation");
                entity.Property(e => e.VipLastModifyDate).HasColumnName("lastModifyDate");
                entity.Property(e => e.VipTargetResolveTime).HasColumnName("targetResolveTime");
                entity.Property(e => e.Is_VIP).HasColumnName("is_vip");
                entity.Property(e => e.VipUserId).HasColumnName("userId");
                entity.Property(e => e.isDraft).HasColumnName("isDraft");
                entity.Property(e => e.HasChild).HasColumnName("has_child");
                entity.Property(e => e.addlComments).HasColumnName("additional_comments");
                entity.Property(e => e.isParent).HasColumnName("is_parent");

            });
            modelBuilder.Entity<ViewCmdbCiList>(entity =>
            {
                entity.HasKey(e => e.CiId);
                entity.ToTable("view_cmdb_ci_list");

                entity.Property(e => e.CiId)
                    .HasColumnName("ci_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.OrgId).HasColumnName("org_id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.Property(e => e.SerialNumber).HasColumnName("serial_number");
            });

            modelBuilder.Entity<ViewAllTicketsChat>(entity =>
            {
                entity.HasKey(e => e.TicketId);

                entity.ToTable("view_all_tickets_chat");

                entity.Property(e => e.TicketId)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TicketIdNumber).HasColumnName("idNumber");

                entity.Property(e => e.TicketShortDesc)
                    .HasColumnName("shortDesc")
                    .HasMaxLength(400);

                entity.Property(e => e.TicketOpenedDate).HasColumnName("openedDate");
                entity.Property(e => e.TicketCategory).HasColumnName("category");
                entity.Property(e => e.TicketSubCategory).HasColumnName("subCategory");
                entity.Property(e => e.TicketItem).HasColumnName("item");
                entity.Property(e => e.TicketPriority).HasColumnName("priority");
                entity.Property(e => e.TicketStatus).HasColumnName("status");
                entity.Property(e => e.TicketAssignedTo).HasColumnName("assignedTo");
                entity.Property(e => e.TicketContactName).HasColumnName("contactName");
                entity.Property(e => e.TicketLocation).HasColumnName("location");
                entity.Property(e => e.TicketAltLocation).HasColumnName("altLocation");
                entity.Property(e => e.TicketLastModifyDate).HasColumnName("lastModifyDate");
                entity.Property(e => e.TicketTargetResolveTime).HasColumnName("targetResolveTime");
                entity.Property(e => e.TicketCreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.TicketModifiedBy).HasColumnName("modifiedBy");
                entity.Property(e => e.TicketCreatedById).HasColumnName("createdById");
                entity.Property(e => e.TicketModifiedById).HasColumnName("modifiedById");
                entity.Property(e => e.TicketAssignedToId).HasColumnName("assignedToId");
                entity.Property(e => e.TicketUserId).HasColumnName("userId");
                entity.Property(e => e.TicketQueue).HasColumnName("queue");
                entity.Property(e => e.TicketOrgId).HasColumnName("orgId");
                entity.Property(e => e.TicketOrgName).HasColumnName("orgName");
                entity.Property(e => e.TicketQueueId).HasColumnName("currentQueueId");
                entity.Property(e => e.TicketSeverity).HasColumnName("severity");
                entity.Property(e => e.TicketChannel).HasColumnName("channel");
                entity.Property(e => e.TicketImpactedCi).HasColumnName("impactedCi");
                entity.Property(e => e.TicketIsVip).HasColumnName("is_vip");
                entity.Property(e => e.HasChild).HasColumnName("has_child");
                entity.Property(e => e.addlComments).HasColumnName("additional_comments");
                entity.Property(e => e.slaPercentage).HasColumnName("slaPercentage");
                entity.Property(e => e.slaColor).HasColumnName("slaColor");
            });




            modelBuilder.Entity<ViewAllTickets>(entity =>
            {
                entity.HasKey(e => new { e.RecordId, e.ModuleId });
                entity.ToTable("view_all_tickets");
                entity.Property(e => e.RecordId).HasColumnName("recordId");
                entity.Property(e => e.ModuleId).HasColumnName("moduleId");
                entity.Property(e => e.IdNumber).HasColumnName("idNumber");
                entity.Property(e => e.OrgId).HasColumnName("orgId");
                entity.Property(e => e.UserId).HasColumnName("userId");
                entity.Property(e => e.StatusId).HasColumnName("statusId");
                entity.Property(e => e.PriorityId).HasColumnName("priorityId");
                entity.Property(e => e.AssignToId).HasColumnName("assignToId");
                entity.Property(e => e.CurrAssignQueueId).HasColumnName("currAssignQueueId");
                entity.Property(e => e.CreatedOn).HasColumnName("createdOn");
                entity.Property(e => e.CreatedById).HasColumnName("createdById");
                entity.Property(e => e.ModifiedOn).HasColumnName("modifiedOn");
                entity.Property(e => e.ModifiedById).HasColumnName("modifiedById");
                entity.Property(e => e.ShortDesc).HasColumnName("shortDesc");
                entity.Property(e => e.AdditionalComments).HasColumnName("additionalComments");
                entity.Property(e => e.LocationId).HasColumnName("locationId");
            });

            modelBuilder.Entity<ViewAllArchTickets>(entity =>
            {
                entity.HasKey(e => new { e.RecordId, e.ModuleId });
                entity.ToTable("view_all_arch_tickets");
                entity.Property(e => e.RecordId).HasColumnName("recordId");
                entity.Property(e => e.ModuleId).HasColumnName("moduleId");
                entity.Property(e => e.IdNumber).HasColumnName("idNumber");
            });

            modelBuilder.Entity<ViewUniversalSearchData>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.ToTable("view_universal_search_data");

                entity.Property(e => e.RecordId).HasColumnName("record_id").ValueGeneratedNever();
                entity.Property(e => e.ModuleId).HasColumnName("module_id");
                entity.Property(e => e.OrgId).HasColumnName("org_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.CurrAssignQueueId).HasColumnName("curr_assign_queue_id");
                entity.Property(e => e.IdNumber).HasColumnName("id_number");
                entity.Property(e => e.ContactName).HasColumnName("contact_name");
                entity.Property(e => e.AssignTo).HasColumnName("assign_to");
                entity.Property(e => e.Queue).HasColumnName("queue");
                entity.Property(e => e.ShortDesc).HasColumnName("short_desc");
                entity.Property(e => e.StatusId).HasColumnName("status_id");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.SubCategoryId).HasColumnName("sub_category_id");
                entity.Property(e => e.ItemId).HasColumnName("item_id");
                entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                entity.Property(e => e.PriorityId).HasColumnName("priority_id");
                entity.Property(e => e.LocationId).HasColumnName("location_id");
                entity.Property(e => e.AltLocationId).HasColumnName("alt_location_id");
                entity.Property(e => e.ConfigCiId).HasColumnName("config_ci_id");
                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
                entity.Property(e => e.CreatedOn).HasColumnName("created_on");
                entity.Property(e => e.ModifiedById).HasColumnName("modified_by_id");
                entity.Property(e => e.ModifiedOn).HasColumnName("modified_on");
            });
            modelBuilder.Entity<ViewActivityLogAllModules>(entity =>
            {
                entity.HasKey(e => e.ActivityLogId);
                entity.ToTable("view_activity_log_all_modules");

                entity.Property(e => e.ActivityLogId)
                    .HasColumnName("activity_log_id")
                    .ValueGeneratedNever();
                entity.Property(e => e.LogTime).HasColumnName("log_time");
                entity.Property(e => e.LogTitle).HasColumnName("log_title");
                entity.Property(e => e.ActionType).HasColumnName("action_type");
                entity.Property(e => e.Module).HasColumnName("module");
                entity.Property(e => e.DescriptionHtml).HasColumnName("description_html");
                entity.Property(e => e.Resolved).HasColumnName("resolved");
                entity.Property(e => e.IdNumber).HasColumnName("id_number");                
            });

            modelBuilder.Entity<ViewAllOpenTickets>(entity =>
            {
                entity.HasKey(e => new { e.IdNumber });
                entity.ToTable("view_all_open_tickets");
                entity.Property(e => e.Recordid).HasColumnName("recordid");
                entity.Property(e => e.OrgId).HasColumnName("orgId");
                entity.Property(e => e.ModuleName).HasColumnName("moduleName");
                entity.Property(e => e.IdNumber).HasColumnName("idNumber");
                entity.Property(e => e.Location).HasColumnName("location");
                entity.Property(e => e.ContactName).HasColumnName("contactName");
                entity.Property(e => e.Category).HasColumnName("category");
                entity.Property(e => e.SubCategory).HasColumnName("subCategory");
                entity.Property(e => e.Item).HasColumnName("item");
                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.Queue).HasColumnName("queue");
                entity.Property(e => e.AssignedTo).HasColumnName("assignedTo");
                entity.Property(e => e.OpenedDate).HasColumnName("openedDate");
                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
                entity.Property(e => e.LastModifyDate).HasColumnName("lastModifyDate");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
                entity.Property(e => e.IsActive).HasColumnName("isActive");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.OrgName).HasColumnName("orgName");
                entity.Property(e => e.Firstassignqueuename).HasColumnName("firstassignqueuename");
                entity.Property(e => e.Prevassignqueuename).HasColumnName("prevassignqueuename");
                entity.Property(e => e.ShortDesc).HasColumnName("shortDesc");
            });

            #endregion
        }
    }
}
