using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhyomAssignment.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NWC_Default_Slice_Values",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NWC_Default_Slice_Values_Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NWC_Default_Slice_Values_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NWC_Default_Slice_Values_Condtion = table.Column<int>(type: "int", nullable: false),
                    NWC_Default_Slice_Values_Water_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NWC_Default_Slice_Values_Sanitation_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NWC_Default_Slice_Values_Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Default_Slice_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NWC_Rreal_Estate_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NWC_Rreal_Estate_Types_Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NWC_Rreal_Estate_Types_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NWC_Rreal_Estate_Types_Reasons = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Rreal_Estate_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NWC_Subscriber_Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NWC_Subscriber_File_Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NWC_Subscriber_File_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NWC_Subscriber_File_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NWC_Subscriber_File_Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NWC_Subscriber_File_Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NWC_Subscriber_File_Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Subscriber_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NWC_Subscription_Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NWC_Subscription_File_Unit_No = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    NWC_Subscription_File_Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    NWC_Subscription_File_Last_Reading_Meter = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    NWC_Subscription_File_Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NWC_Subscription_File_Subscriber_Code = table.Column<int>(type: "int", nullable: false),
                    NWC_Subscription_File_Rreal_Estate_Types_Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Subscription_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NWC_Subscription_Files_NWC_Rreal_Estate_Types_NWC_Subscription_File_Rreal_Estate_Types_Code",
                        column: x => x.NWC_Subscription_File_Rreal_Estate_Types_Code,
                        principalTable: "NWC_Rreal_Estate_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NWC_Subscription_Files_NWC_Subscriber_Files_NWC_Subscription_File_Subscriber_Code",
                        column: x => x.NWC_Subscription_File_Subscriber_Code,
                        principalTable: "NWC_Subscriber_Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NWC_Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NWC_Invoices_No = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NWC_Invoices_Year = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NWC_Invoices_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NWC_Invoices_From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NWC_Invoices_To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NWC_Invoices_Previous_Consumption_Amount = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    NWC_Invoices_Current_Consumption_Amount = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    NWC_Invoices_Amount_Consumption = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    NWC_Invoices_Service_Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NWC_Invoices_Tax_Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NWC_Invoices_Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    NWC_Invoices_Wastewater_Consumption_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NWC_Invoices_Total_Invoice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NWC_Invoices_Tax_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NWC_Invoices_Total_Bill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NWC_Invoices_Total_Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NWC_Invoices_Rreal_Estate_Types_No = table.Column<int>(type: "int", nullable: false),
                    NWC_Invoices_Subscription_No = table.Column<int>(type: "int", nullable: false),
                    NWC_Invoices_Subscriber_No = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NWC_Invoices_NWC_Rreal_Estate_Types_NWC_Invoices_Rreal_Estate_Types_No",
                        column: x => x.NWC_Invoices_Rreal_Estate_Types_No,
                        principalTable: "NWC_Rreal_Estate_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NWC_Invoices_NWC_Subscriber_Files_NWC_Invoices_Subscriber_No",
                        column: x => x.NWC_Invoices_Subscriber_No,
                        principalTable: "NWC_Subscriber_Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NWC_Invoices_NWC_Subscription_Files_NWC_Invoices_Subscription_No",
                        column: x => x.NWC_Invoices_Subscription_No,
                        principalTable: "NWC_Subscription_Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Invoices_NWC_Invoices_Rreal_Estate_Types_No",
                table: "NWC_Invoices",
                column: "NWC_Invoices_Rreal_Estate_Types_No");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Invoices_NWC_Invoices_Subscriber_No",
                table: "NWC_Invoices",
                column: "NWC_Invoices_Subscriber_No");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Invoices_NWC_Invoices_Subscription_No",
                table: "NWC_Invoices",
                column: "NWC_Invoices_Subscription_No");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Subscription_Files_NWC_Subscription_File_Rreal_Estate_Types_Code",
                table: "NWC_Subscription_Files",
                column: "NWC_Subscription_File_Rreal_Estate_Types_Code");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Subscription_Files_NWC_Subscription_File_Subscriber_Code",
                table: "NWC_Subscription_Files",
                column: "NWC_Subscription_File_Subscriber_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NWC_Default_Slice_Values");

            migrationBuilder.DropTable(
                name: "NWC_Invoices");

            migrationBuilder.DropTable(
                name: "NWC_Subscription_Files");

            migrationBuilder.DropTable(
                name: "NWC_Rreal_Estate_Types");

            migrationBuilder.DropTable(
                name: "NWC_Subscriber_Files");
        }
    }
}
