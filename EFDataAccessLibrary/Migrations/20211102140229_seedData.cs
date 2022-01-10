using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccessLibrary.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Category", "QuestionStr" },
                values: new object[,]
                {
                    { 1, "شخصیتی", "وقتی صحبت از دوستی می شود کدام ویژگی برای تو بیشترین ارزش را دارد؟ و اینکه آیا به راحتی دوست می شوی؟" },
                    { 2, "چالش", "آیا تا به حال از کسی سو استفاده کرده ای؟" },
                    { 3, "سرگرمی", " اگر یک حیوان بودی چه بودی؟" },
                    { 4, "شخصیتی", "آیا خود را شخص قابل اعتمادی می دانید؟ آیا دوستان تان شما را قابل اعتماد می دانند؟" },
                    { 5, "شخصیتی", "آیا خرافاتی هستی؟" },
                    { 6, "شخصیتی", "آیا خودت را متعصب یا نژادپرست می دانید؟" },
                    { 7, "چالش", "بدترین رازت را بگو؟" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
