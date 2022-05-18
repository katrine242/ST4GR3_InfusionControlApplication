using Microsoft.EntityFrameworkCore.Migrations;

namespace ICA_DataAccessLayer.Migrations
{
    public partial class DataBaseInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfusionPlans",
                columns: table => new
                {
                    InfusionPlanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPR = table.Column<long>(type: "INTEGER", nullable: false),
                    MachineID = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineName = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Fulltime = table.Column<int>(type: "INTEGER", nullable: false),
                    Factor = table.Column<double>(type: "REAL", nullable: false),
                    MaxDoseage = table.Column<double>(type: "REAL", nullable: false),
                    IntervalTime = table.Column<int>(type: "INTEGER", nullable: false),
                    Concentration = table.Column<double>(type: "REAL", nullable: false),
                    BatchId = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfusionPlans", x => x.InfusionPlanId);
                });

            migrationBuilder.CreateTable(
                name: "TimeFlows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<double>(type: "REAL", nullable: false),
                    Flow = table.Column<double>(type: "REAL", nullable: false),
                    DtoInfusionPlanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFlows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeFlows_InfusionPlans_DtoInfusionPlanId",
                        column: x => x.DtoInfusionPlanId,
                        principalTable: "InfusionPlans",
                        principalColumn: "InfusionPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeFlows_DtoInfusionPlanId",
                table: "TimeFlows",
                column: "DtoInfusionPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeFlows");

            migrationBuilder.DropTable(
                name: "InfusionPlans");
        }
    }
}
