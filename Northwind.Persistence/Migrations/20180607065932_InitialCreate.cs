using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Northwind.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    NumberOfSeats = table.Column<int>(nullable: true),
                    Area = table.Column<int>(nullable: true),
                    //WifiAccess = table.Column<bool>(nullable: true),
                    Calendar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                });

            migrationBuilder.CreateIndex(
               name: "IX_Rooms",
               table: "Rooms",
               column: "RoomID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employees_ReportsTo",
            //    table: "Employees",
            //    column: "ReportsTo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_EmployeeTerritories_TerritoryID",
            //    table: "EmployeeTerritories",
            //    column: "TerritoryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Order Details_ProductID",
            //    table: "Order Details",
            //    column: "ProductID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_CustomerID",
            //    table: "Orders",
            //    column: "CustomerID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_EmployeeID",
            //    table: "Orders",
            //    column: "EmployeeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_ShipVia",
            //    table: "Orders",
            //    column: "ShipVia");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_CategoryID",
            //    table: "Products",
            //    column: "CategoryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_SupplierID",
            //    table: "Products",
            //    column: "SupplierID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Territories_RegionID",
            //    table: "Territories",
            //    column: "RegionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            //migrationBuilder.DropTable(
            //    name: "EmployeeTerritories");

            //migrationBuilder.DropTable(
            //    name: "Order Details");

            //migrationBuilder.DropTable(
            //    name: "Territories");

            //migrationBuilder.DropTable(
            //    name: "Orders");

            //migrationBuilder.DropTable(
            //    name: "Products");

            //migrationBuilder.DropTable(
            //    name: "Region");

            //migrationBuilder.DropTable(
            //    name: "Customers");

            //migrationBuilder.DropTable(
            //    name: "Employees");

            //migrationBuilder.DropTable(
            //    name: "Shippers");

            //migrationBuilder.DropTable(
            //    name: "Categories");

            //migrationBuilder.DropTable(
            //    name: "Suppliers");
        }
    }
}
