using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace aditaas_v5.Models
{
    public partial class aditaas_v5Context
    {
        //https://stackoverflow.com/questions/46212704/how-do-i-write-ef-functions-extension-method/46214081#46214081
        //[DbFunction("CHARINDEX")]
        //public static int? CharIndex(string toSearch, string target) => throw new Exception();

        //partial void OnModelCreatingPartial(
        //    ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .HasDbFunction(typeof(MyDbContext).GetMethod(nameof(CharIndex)))
        //        .HasTranslation(
        //            args =>
        //                SqlFunctionExpression.Create("CHARINDEX", args, typeof(int?), null));
        //}
        public void DetachAllEntities()
        {
            var changedEntriesCopy = ChangeTracker.Entries().ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        public override int SaveChanges()
        {
            var retval = base.SaveChanges();

            ChangeTracker.Clear();

            return retval;
        }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int retval = await base.SaveChangesAsync(cancellationToken);

            ChangeTracker.Clear();

            return retval;
        }

        public int CustSaveChanges()
        {
            var retval = base.SaveChanges();
            return retval;
        }
        public async Task<int> CustSaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int retval = await base.SaveChangesAsync(cancellationToken);

            return retval;
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewMyfavMyapprovals>(entity =>
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
                entity.Property(e => e.ApprCreatedByFullName).HasColumnName("apprCreatedByFullName");
                entity.Property(e => e.ApprApproverFullName).HasColumnName("apprApproverFullName");
                entity.Property(e => e.ApprRequesterFullName).HasColumnName("apprRequesterFullName");
                entity.Property(e => e.ApprAuthorizedByFullName).HasColumnName("apprAuthorizedByFullName");
            });
        }
    }
}
