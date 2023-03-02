using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QMCommunication.Migrations
{
    public partial class CreateTable_PalabelCasecodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PalabelCasecodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssemblyLineCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AssemblyLineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Casecnt = table.Column<int>(type: "int", nullable: false),
                    Consignor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConsignorDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConsignorTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CusCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeliveryBatchNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DisplayType = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenerateStyle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KanbanCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KanbanLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KanbanLineno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KanbanStatus = table.Column<int>(type: "int", nullable: false),
                    KanbanType = table.Column<int>(type: "int", nullable: false),
                    KanbanUse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MtlCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MtlName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlanArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanQty = table.Column<int>(type: "int", nullable: false),
                    Plant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProgressBatchNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReceiveQty = table.Column<int>(type: "int", nullable: false),
                    RecoilQty = table.Column<int>(type: "int", nullable: false),
                    ReqDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SLoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WWhCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SZoneCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SZoneName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SZoneNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SendQty = table.Column<int>(type: "int", nullable: false),
                    SupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TWhCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TZoneCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TZoneName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TZoneNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TargetLocCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TargetWhCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalabelCasecodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PalabelCasecodes_OwnerName_OwnerCode",
                table: "PalabelCasecodes",
                columns: new[] { "OwnerName", "OwnerCode" });

            migrationBuilder.CreateIndex(
                name: "IX_PalabelCasecodes_Plant",
                table: "PalabelCasecodes",
                column: "Plant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalabelCasecodes");
        }
    }
}
