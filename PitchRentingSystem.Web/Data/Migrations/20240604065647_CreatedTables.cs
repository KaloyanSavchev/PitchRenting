using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PitchRentingSystem.Web.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pitches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerRent = table.Column<decimal>(type: "decimal(12,3)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pitches_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pitches_AspNetUsers_RenterId",
                        column: x => x.RenterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pitches_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "f78fc0ef-c762-42d5-8955-92d32d77ff6b", "guest@mail.com", false, false, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAEGgh630idr/tnR8EElaZFH/sODcvLNTNQmtDKfwTKhx0ScsxHkksXMLp6OkiGBOgBA==", null, false, "9f1e1c2f-e069-486a-be3f-e66caa63324e", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "a26abaab-a9f4-4ba9-ba6c-a7a8f44717b8", "agent@mail.com", false, false, null, "AGENT@MAIL.COM", "AGENT@MAIL.COM", "AQAAAAEAACcQAAAAEKIUcHQtPhqQe9qakpLkA6QwA9KY60k4/aqX7mN/6vLXBXFheKafy9mfmx9U9ox0Ow==", null, false, "3e4edbba-a2c1-4793-ad61-3b8f0ad6b5ff", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "NewBuilded" },
                    { 2, "Modern" },
                    { 3, "Olimpic" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("44a41a1c-943b-47e2-80e6-47463b6f139b"), "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Pitches",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerRent", "RenterId", "Title" },
                values: new object[] { 1, "Camp Nou Football Stadium", new Guid("44a41a1c-943b-47e2-80e6-47463b6f139b"), 1, "The stadium's maximum height is 48 metres, and it covers a surface area of 55,000 square metres (250 metres long and 220 metres wide). In accordance with UEFA stipulations, the playing area has been downsized to 105 metres x 68 metres. With a capacity of 99,354, it is now the biggest stadium in Europe.", "https://www.fcbarcelona.com/photo-resources/2020/02/24/3f1215ed-07e8-47ef-b2c7-8a519f65b9cd/mini_UP3_20200105_FCB_VIS_View_1a_Empty.jpg?width=1200&height=750", 2200.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Camp Nou" });

            migrationBuilder.InsertData(
                table: "Pitches",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerRent", "RenterId", "Title" },
                values: new object[] { 2, "R. Prof. Eurico Rabelo - Maracanã, Rio de Janeiro", new Guid("44a41a1c-943b-47e2-80e6-47463b6f139b"), 3, "Maracanã Stadium was built in 1950 to commemorate the country's hosting of the 1950 soccer games. Nine of Brazil's leading architects designed the stadium to impress on a global scale, with intentions to create the world's largest soccer stadium.", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0d/e0/b7/00/maracana-stadion.jpg?w=1200&h=-1&s=1", 2000.00m, null, "Maracanã Stadium" });

            migrationBuilder.InsertData(
                table: "Pitches",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerRent", "RenterId", "Title" },
                values: new object[] { 3, "Av. de Concha Espina, 1, Chamartín", new Guid("44a41a1c-943b-47e2-80e6-47463b6f139b"), 2, "The Santiago Bernabeu (named after the legendary Madrid manager, who presided over the club from 1943 to 1978) was inaugurated in 1947 and can hold over 80,000 spectators. The stadium is also equipped with more than 240 VIP boxes. The actual entrance to Tour Bernabéu is located on Avenida de Concha Espina, at Gate 28.", "https://estaticos.esmadrid.com/cdn/farfuture/wwgUeNPLBq8Z-HJOYcUUx_8t1mXAr0eYBgMKLjFy1p4/mtime:1710755365/sites/default/files/styles/content_type_full/public/recursosturisticos/infoturistica/bernabeu.jpg?itok=KvMJw4Dh", 2100.00m, null, "Santiago Bernabéu Stadium" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitches_AgentId",
                table: "Pitches",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitches_CategoryId",
                table: "Pitches",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitches_RenterId",
                table: "Pitches",
                column: "RenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pitches");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
