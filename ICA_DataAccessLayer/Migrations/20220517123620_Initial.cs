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
                    MachineID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPR = table.Column<long>(type: "INTEGER", nullable: false),
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
                    table.PrimaryKey("PK_InfusionPlans", x => x.MachineID);
                });

            migrationBuilder.CreateTable(
                name: "TimeFlows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    DtoInfusionPlanMachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    Time = table.Column<double>(type: "REAL", nullable: false),
                    Flow = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFlows", x => new { x.Id, x.DtoInfusionPlanMachineId });
                    table.ForeignKey(
                        name: "FK_TimeFlows_InfusionPlans_DtoInfusionPlanMachineId",
                        column: x => x.DtoInfusionPlanMachineId,
                        principalTable: "InfusionPlans",
                        principalColumn: "MachineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeFlows_DtoInfusionPlanMachineId",
                table: "TimeFlows",
                column: "DtoInfusionPlanMachineId");
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
