using Microsoft.EntityFrameworkCore.Migrations;

namespace ICA_DataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfusionPlans",
                columns: table => new
                {
                    CPR = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedicineName = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    MachineID = table.Column<int>(type: "INTEGER", nullable: false),
                    Fulltime = table.Column<int>(type: "INTEGER", nullable: false),
                    Factor = table.Column<double>(type: "REAL", nullable: false),
                    MaxDoseage = table.Column<double>(type: "REAL", nullable: false),
                    IntervalTime = table.Column<int>(type: "INTEGER", nullable: false),
                    Concentration = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfusionPlans", x => x.CPR);
                });

            migrationBuilder.CreateTable(
                name: "TimeFlowLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    DtoInfusionPlanCpr = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFlowLists", x => new { x.Id, x.DtoInfusionPlanCpr });
                    table.ForeignKey(
                        name: "FK_TimeFlowLists_InfusionPlans_DtoInfusionPlanCpr",
                        column: x => x.DtoInfusionPlanCpr,
                        principalTable: "InfusionPlans",
                        principalColumn: "CPR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeFlowListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    DtoTimeFlowListId = table.Column<int>(type: "INTEGER", nullable: false),
                    DtoTimeFlowListDtoInfusionPlanCpr = table.Column<long>(type: "INTEGER", nullable: false),
                    TimeFlowListItemType = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFlowListItems", x => new { x.Id, x.DtoTimeFlowListId, x.DtoTimeFlowListDtoInfusionPlanCpr });
                    table.ForeignKey(
                        name: "FK_TimeFlowListItems_TimeFlowLists_DtoTimeFlowListId_DtoTimeFlowListDtoInfusionPlanCpr",
                        columns: x => new { x.DtoTimeFlowListId, x.DtoTimeFlowListDtoInfusionPlanCpr },
                        principalTable: "TimeFlowLists",
                        principalColumns: new[] { "Id", "DtoInfusionPlanCpr" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeFlowListItems_DtoTimeFlowListId_DtoTimeFlowListDtoInfusionPlanCpr",
                table: "TimeFlowListItems",
                columns: new[] { "DtoTimeFlowListId", "DtoTimeFlowListDtoInfusionPlanCpr" });

            migrationBuilder.CreateIndex(
                name: "IX_TimeFlowLists_DtoInfusionPlanCpr",
                table: "TimeFlowLists",
                column: "DtoInfusionPlanCpr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeFlowListItems");

            migrationBuilder.DropTable(
                name: "TimeFlowLists");

            migrationBuilder.DropTable(
                name: "InfusionPlans");
        }
    }
}
