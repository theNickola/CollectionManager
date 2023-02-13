using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class customizedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NameDigitField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameDigitField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameDigitField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameStringField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameStringField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameStringField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameMarkdownField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameMarkdownField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameMarkdownField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameDateField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameDateField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameDateField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameBoolField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameBoolField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameBoolField3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateComment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IthemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IthemLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IthemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IthemLikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ithems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    DigitField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkdownField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkdownField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkdownField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoolField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoolField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoolField3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ithems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IthemTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IthemId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IthemTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "IthemLikes");

            migrationBuilder.DropTable(
                name: "Ithems");

            migrationBuilder.DropTable(
                name: "IthemTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
