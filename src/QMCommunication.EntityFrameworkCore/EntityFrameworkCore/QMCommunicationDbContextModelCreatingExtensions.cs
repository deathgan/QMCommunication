using QMCommunication.QMPalabelCasecode;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace QMCommunication.EntityFrameworkCore
{
    public static class QMCommunicationDbContextModelCreatingExtensions
    {
        public static void ConfigureQMCommunication(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(QMCommunicationConsts.DbTablePrefix + "YourEntities", QMCommunicationConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});


            builder.Entity<PalabelCasecode>(b =>
            {
                b.ToTable("PalabelCasecodes", QMCommunicationConsts.DbSchema);
                b.ConfigureByConvention();


                /* Configure more properties here */

                b.Property(_ => _.AssemblyLineCode).HasMaxLength(50);
                b.Property(_ => _.AssemblyLineName).HasMaxLength(50);
                b.Property(_ => _.Consignor).HasMaxLength(50);
                b.Property(_ => _.ConsignorDescription).HasMaxLength(256);
                b.Property(_ => _.CusCode).HasMaxLength(50);
                b.Property(_ => _.DeliveryBatchNo).HasMaxLength(50);
                b.Property(_ => _.DocumentType).HasMaxLength(50);
                b.Property(_ => _.GenerateStyle).HasMaxLength(50);
                b.Property(_ => _.KanbanCode).HasMaxLength(50);
                b.Property(_ => _.KanbanLabel).HasMaxLength(50);
                b.Property(_ => _.KanbanLineno).HasMaxLength(50);
                b.Property(_ => _.KanbanUse).HasMaxLength(50);
                b.Property(_ => _.MtlCode).HasMaxLength(50);
                b.Property(_ => _.MtlName).HasMaxLength(50);
                b.Property(_ => _.OwnerCode).HasMaxLength(50);
                b.Property(_ => _.OwnerName).HasMaxLength(50);
                b.Property(_ => _.Plant).HasMaxLength(50);
                b.Property(_ => _.ProgressBatchNo).HasMaxLength(50);
                b.Property(_ => _.SLoc).HasMaxLength(50);
                b.Property(_ => _.WWhCode).HasMaxLength(50);
                b.Property(_ => _.SZoneCode).HasMaxLength(50);
                b.Property(_ => _.SZoneName).HasMaxLength(50);
                b.Property(_ => _.SZoneNo).HasMaxLength(50);
                b.Property(_ => _.SupCode).HasMaxLength(50);
                b.Property(_ => _.SupName).HasMaxLength(50);
                b.Property(_ => _.TWhCode).HasMaxLength(50);
                b.Property(_ => _.TZoneCode).HasMaxLength(50);
                b.Property(_ => _.TZoneName).HasMaxLength(50);
                b.Property(_ => _.TZoneNo).HasMaxLength(50);
                b.Property(_ => _.TargetLocCode).HasMaxLength(50);
                b.Property(_ => _.TargetWhCode).HasMaxLength(50);
                b.Property(_ => _.KanbanStatus).HasMaxLength(50);
                b.Property(_ => _.KanbanType).HasMaxLength(50);

                b.Property(_ => _.IsDeleted).HasDefaultValue(false);

                b.HasIndex(_ => _.Plant);

                b.HasIndex(_ => new { _.OwnerName, _.OwnerCode });
            });
        }
    }
}
