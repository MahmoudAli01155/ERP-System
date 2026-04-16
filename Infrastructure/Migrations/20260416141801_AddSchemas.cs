using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSchemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hr");

            migrationBuilder.EnsureSchema(
                name: "commerce");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "commerce");

            migrationBuilder.RenameTable(
                name: "Payrolls",
                newName: "Payrolls",
                newSchema: "hr");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payments",
                newSchema: "commerce");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "commerce");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItem",
                newSchema: "commerce");

            migrationBuilder.RenameTable(
                name: "Leaves",
                newName: "Leaves",
                newSchema: "hr");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employees",
                newSchema: "hr");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Departments",
                newSchema: "hr");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "commerce");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Carts",
                newSchema: "commerce");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "CartItem",
                newSchema: "commerce");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendances",
                newSchema: "hr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Products",
                schema: "commerce",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Payrolls",
                schema: "hr",
                newName: "Payrolls");

            migrationBuilder.RenameTable(
                name: "Payments",
                schema: "commerce",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "commerce",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                schema: "commerce",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "Leaves",
                schema: "hr",
                newName: "Leaves");

            migrationBuilder.RenameTable(
                name: "Employees",
                schema: "hr",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Departments",
                schema: "hr",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "commerce",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Carts",
                schema: "commerce",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "CartItem",
                schema: "commerce",
                newName: "CartItem");

            migrationBuilder.RenameTable(
                name: "Attendances",
                schema: "hr",
                newName: "Attendances");
        }
    }
}
