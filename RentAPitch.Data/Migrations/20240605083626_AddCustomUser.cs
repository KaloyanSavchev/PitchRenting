using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PitchRentingSystem.Web.Data.Migrations
{
    public partial class AddCustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c47dd013-e096-45fd-a290-dd647d937476", "AQAAAAEAACcQAAAAEIWtHlRzjHbzY/Vs8IgdTHdO2eH/F4/4w3S1Pw012mLh0pOrOvEnbYEY/i+Rnm/Ebg==", "31acd41b-4d74-4792-b4b3-ce6dd22ebffa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4c14ff1-453a-4c4a-9a5d-b0abbcbb7230", "AQAAAAEAACcQAAAAEI2ZtBZ+o66+vYcdkVv4R0XMptRqEighs8ZlU3VBhK5CqgUaijz+qhGjHYV0q7wzYQ==", "9e519e08-61dd-4b6d-9182-0448bac08a12" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f78fc0ef-c762-42d5-8955-92d32d77ff6b", "AQAAAAEAACcQAAAAEGgh630idr/tnR8EElaZFH/sODcvLNTNQmtDKfwTKhx0ScsxHkksXMLp6OkiGBOgBA==", "9f1e1c2f-e069-486a-be3f-e66caa63324e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a26abaab-a9f4-4ba9-ba6c-a7a8f44717b8", "AQAAAAEAACcQAAAAEKIUcHQtPhqQe9qakpLkA6QwA9KY60k4/aqX7mN/6vLXBXFheKafy9mfmx9U9ox0Ow==", "3e4edbba-a2c1-4793-ad61-3b8f0ad6b5ff" });
        }
    }
}
