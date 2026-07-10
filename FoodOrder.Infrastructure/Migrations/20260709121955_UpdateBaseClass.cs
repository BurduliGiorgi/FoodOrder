using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Orders",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "Orders",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Orders",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "OrderItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "OrderItems",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "OrderItems",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "OrderItems",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MenuItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "MenuItems",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "MenuItems",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "MenuItems",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Orders",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Orders",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Orders",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderItems",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "OrderItems",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "OrderItems",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "OrderItems",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MenuItems",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "MenuItems",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "MenuItems",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "MenuItems",
                newName: "CreateAt");
        }
    }
}
