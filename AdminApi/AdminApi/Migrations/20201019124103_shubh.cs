using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Migrations
{
    public partial class shubh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminCredential",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminCredential", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Id = table.Column<int>(nullable: false),
                    Book_Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    No_of_pages = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Id = table.Column<int>(nullable: false),
                    Book_Name = table.Column<string>(nullable: true),
                    Book_Author = table.Column<string>(nullable: true),
                    User_Id = table.Column<int>(nullable: false),
                    User_Name = table.Column<string>(nullable: true),
                    Phone_Number = table.Column<string>(nullable: true),
                    Issue_Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usercheck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usercheck", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminCredential");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "IssueDetail");

            migrationBuilder.DropTable(
                name: "Usercheck");
        }
    }
}
