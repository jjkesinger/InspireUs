using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspireUs.Congress.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Congress",
                columns: table => new
                {
                    Nth = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Congress", x => x.Nth);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistrictRepresented = table.Column<int>(type: "int", nullable: true),
                    StateRepresented = table.Column<int>(type: "int", nullable: false),
                    Party = table.Column<int>(type: "int", nullable: false),
                    MemberType = table.Column<int>(type: "int", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressState = table.Column<int>(type: "int", nullable: true),
                    AddressZipCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Legislation",
                columns: table => new
                {
                    BillNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CongressNth = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SponserMemberId = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legislation", x => x.BillNumber);
                    table.ForeignKey(
                        name: "FK_Legislation_Congress_CongressNth",
                        column: x => x.CongressNth,
                        principalTable: "Congress",
                        principalColumn: "Nth",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Legislation_Member_SponserMemberId",
                        column: x => x.SponserMemberId,
                        principalTable: "Member",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceTime",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberType = table.Column<int>(type: "int", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTime", x => new { x.MemberId, x.Id });
                    table.ForeignKey(
                        name: "FK_ServiceTime_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Congress",
                column: "Nth",
                values: new object[]
                {
                    "100th",
                    "101st",
                    "102nd",
                    "103rd",
                    "104th",
                    "105th",
                    "106th",
                    "107th",
                    "108th",
                    "109th",
                    "10th",
                    "110th",
                    "111th",
                    "112th",
                    "113th",
                    "114th",
                    "115th",
                    "116th",
                    "117th",
                    "118th",
                    "11th",
                    "12th",
                    "13th",
                    "14th",
                    "15th",
                    "16th",
                    "17th",
                    "18th",
                    "19th",
                    "1st",
                    "20th",
                    "21st",
                    "22nd",
                    "23rd",
                    "24th",
                    "25th",
                    "26th",
                    "27th",
                    "28th",
                    "29th",
                    "2nd",
                    "30th",
                    "31st",
                    "32nd",
                    "33rd",
                    "34th",
                    "35th",
                    "36th",
                    "37th",
                    "38th",
                    "39th",
                    "3rd",
                    "40th",
                    "41st",
                    "42nd",
                    "43rd",
                    "44th",
                    "45th",
                    "46th",
                    "47th",
                    "48th",
                    "49th",
                    "4th",
                    "50th",
                    "51st",
                    "52nd",
                    "53rd",
                    "54th",
                    "55th",
                    "56th",
                    "57th",
                    "58th",
                    "59th",
                    "5th",
                    "60th",
                    "61st",
                    "62nd",
                    "63rd",
                    "64th",
                    "65th",
                    "66th",
                    "67th",
                    "68th",
                    "69th",
                    "6th",
                    "70th",
                    "71st",
                    "72nd",
                    "73rd",
                    "74th",
                    "75th",
                    "76th",
                    "77th",
                    "78th",
                    "79th",
                    "7th",
                    "80th",
                    "81st",
                    "82nd",
                    "83rd",
                    "84th",
                    "85th",
                    "86th",
                    "87th",
                    "88th",
                    "89th",
                    "8th",
                    "90th",
                    "91st",
                    "92nd",
                    "93rd",
                    "94th",
                    "95th",
                    "96th",
                    "97th",
                    "98th",
                    "99th",
                    "9th"
                });

            migrationBuilder.CreateIndex(
                name: "IX_Legislation_CongressNth",
                table: "Legislation",
                column: "CongressNth");

            migrationBuilder.CreateIndex(
                name: "IX_Legislation_SponserMemberId",
                table: "Legislation",
                column: "SponserMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Legislation");

            migrationBuilder.DropTable(
                name: "ServiceTime");

            migrationBuilder.DropTable(
                name: "Congress");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
