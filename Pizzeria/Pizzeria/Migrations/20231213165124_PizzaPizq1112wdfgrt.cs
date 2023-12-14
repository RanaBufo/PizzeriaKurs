using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzeria.Migrations
{
    /// <inheritdoc />
    public partial class PizzaPizq1112wdfgrt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fillings",
                columns: table => new
                {
                    IdFilling = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameFilling = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fillings", x => x.IdFilling);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    IDPizza = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PizzaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PizzaPrice = table.Column<double>(type: "float", nullable: false),
                    PizzaImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDSauce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.IDPizza);
                });

            migrationBuilder.CreateTable(
                name: "Sauces",
                columns: table => new
                {
                    IDSauce = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameSauce = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sauces", x => x.IDSauce);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IDUser);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    IDWorker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerPost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.IDWorker);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fillings");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Sauces");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
