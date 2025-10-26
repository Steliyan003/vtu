using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricVehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CleanAlternativeFuelVehicle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricRange = table.Column<int>(type: "int", nullable: false),
                    BaseMSRP = table.Column<int>(type: "int", nullable: false),
                    LegislativeDistrict = table.Column<int>(type: "int", nullable: false),
                    DOLVehicleID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricUtility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CensusTract = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    PostalCodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricVehicle_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricVehicle_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricVehicle_PostalCode_PostalCodeId",
                        column: x => x.PostalCodeId,
                        principalTable: "PostalCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricVehicle_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectricVehicle_CityId",
                table: "ElectricVehicle",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricVehicle_CountryId",
                table: "ElectricVehicle",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricVehicle_PostalCodeId",
                table: "ElectricVehicle",
                column: "PostalCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricVehicle_StateId",
                table: "ElectricVehicle",
                column: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricVehicle");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "PostalCode");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
