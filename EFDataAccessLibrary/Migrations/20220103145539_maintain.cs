using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccessLibrary.Migrations
{
    public partial class maintain : Migration
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
                    DareGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DareStr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionStr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dares",
                columns: new[] { "Id", "CategoryID", "CategoryName", "DareGuid", "DareStr" },
                values: new object[,]
                {
                    { 1, 3, "فیزیکی", new Guid("f403b75d-10bf-4887-9a7b-0855306dfbf4"), "به مدت پنج دقیقه پاهای شرکت کننده سمت چپ خود را ماساژ بده" },
                    { 2, 1, "چالش", new Guid("ff727078-a8b4-452c-b585-31d4bfcddf11"), "یک قاشق کره بخور" },
                    { 3, 2, "سرگرمی", new Guid("90f22fb9-d1f0-46cf-b76d-97cdfd009503"), "اولین کلمه ای که به ذهنت می رسد را فریاد بزن" },
                    { 4, 1, "چالش", new Guid("a3131982-0134-42ab-8f08-ef0eff5f8e66"), "یک قطعه یخ در شلوار خود قرار بده و صبر کن تا آب شود" },
                    { 5, 1, "چالش", new Guid("e3798dd7-6b48-4899-af79-9ee9821fc804"), "ده بار دور خودت بگرد، بعد از آن سعی کن در خط مستقیم راه بروی" },
                    { 7, 1, "چالش", new Guid("d39bf606-c2e9-4e5a-a71a-09eee9b8c2ac"), "با آهنگ انتخابی گروه برقص" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CategoryID", "CategoryName", "QuestionGuid", "QuestionStr" },
                values: new object[,]
                {
                    { 1, 0, "شخصیتی", new Guid("bfa00297-0e9f-43e5-b394-0a05d9bb033d"), "وقتی صحبت از دوستی می شود کدام ویژگی برای تو بیشترین ارزش را دارد؟ و اینکه آیا به راحتی دوست می شوی؟" },
                    { 2, 1, "چالش", new Guid("93fa7aff-3a52-4ce5-9a0e-257f31f41cbd"), "آیا تا به حال از کسی سو استفاده کرده ای؟" },
                    { 3, 2, "سرگرمی", new Guid("a624b12f-121e-4c52-a753-35ff0dc6e235"), " اگر یک حیوان بودی چه بودی؟" },
                    { 4, 0, "شخصیتی", new Guid("8aee77c4-46c5-4c6f-affa-9135eb6f7585"), "آیا خود را شخص قابل اعتمادی می دانید؟ آیا دوستان تان شما را قابل اعتماد می دانند؟" },
                    { 5, 0, "شخصیتی", new Guid("b97dfffd-657b-43c8-906f-633d0cbac5b6"), "آیا خرافاتی هستی؟" },
                    { 6, 0, "شخصیتی", new Guid("6479d53d-39af-47b8-94ba-e4992f379c09"), "آیا خودت را متعصب یا نژادپرست می دانید؟" },
                    { 7, 1, "چالش", new Guid("08fa2b30-eb75-4d31-986e-3126c01ee77b"), "بدترین رازت را بگو؟" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dares");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
