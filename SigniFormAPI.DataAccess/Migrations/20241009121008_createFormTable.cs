using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigniFormAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createFormTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitiatedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelevantDirector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SigneePosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SigneeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DedlineDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VarPayer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VatIncluded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTerm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidityPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelevantDirectorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LegalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractSummaries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractSummaries");
        }
    }
}
