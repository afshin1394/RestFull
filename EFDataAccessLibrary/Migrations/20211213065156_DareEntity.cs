using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccessLibrary.Migrations
{
    public partial class DareEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DareStr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dares", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dares",
                columns: new[] { "Id", "CategoryID", "CategoryName", "DareStr" },
                values: new object[,]
                {
                    { 1, 3, "فیزیکی", "به مدت پنج دقیقه پاهای شرکت کننده سمت چپ خود را ماساژ بده" },
                    { 2, 1, "چالش", "یک قاشق کره بخور" },
                    { 3, 2, "سرگرمی", "اولین کلمه ای که به ذهنت می رسد را فریاد بزن" },
                    { 4, 1, "چالش", "یک قطعه یخ در شلوار خود قرار بده و صبر کن تا آب شود" },
                    { 5, 1, "چالش", "ده بار دور خودت بگرد، بعد از آن سعی کن در خط مستقیم راه بروی" },
                    { 6, 0, "شخصیتی", "آیا خودت را متعصب یا نژادپرست می دانید؟" },
                    { 7, 1, "چالش", "با آهنگ انتخابی گروه برقص" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dares");
        }
    }
}
