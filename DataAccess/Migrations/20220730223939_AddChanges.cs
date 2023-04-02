using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataAccess.Migrations
{
    public partial class AddChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepositAmount",
                schema: "public",
                table: "CashIns");

            migrationBuilder.RenameColumn(
                name: "DepositPhoneNumberNetworkName",
                schema: "public",
                table: "CashIns",
                newName: "PayerNote");

            migrationBuilder.RenameColumn(
                name: "DepositPhoneNumber",
                schema: "public",
                table: "CashIns",
                newName: "PayeeNote");

            migrationBuilder.RenameColumn(
                name: "CustomerPhoneNumber",
                schema: "public",
                table: "CashIns",
                newName: "PartyIdType");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                schema: "public",
                table: "CashIns",
                newName: "ExternalId");

            migrationBuilder.RenameColumn(
                name: "BranchMerchantNumberNetworkName",
                schema: "public",
                table: "CashIns",
                newName: "DepositorContactNo");

            migrationBuilder.RenameColumn(
                name: "BranchMerchantNumber",
                schema: "public",
                table: "CashIns",
                newName: "BranchAccountNumber");

            migrationBuilder.AlterColumn<decimal>(
                name: "SendingCost",
                schema: "public",
                table: "CashIns",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDateTime",
                schema: "public",
                table: "CashIns",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                schema: "public",
                table: "CashIns",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNetworkName",
                schema: "public",
                table: "CashIns",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                schema: "public",
                table: "CashIns",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "public",
                table: "CashIns",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BranchAccountNetworkName",
                schema: "public",
                table: "CashIns",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                schema: "public",
                table: "CashIns");

            migrationBuilder.DropColumn(
                name: "AccountNetworkName",
                schema: "public",
                table: "CashIns");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                schema: "public",
                table: "CashIns");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "public",
                table: "CashIns");

            migrationBuilder.DropColumn(
                name: "BranchAccountNetworkName",
                schema: "public",
                table: "CashIns");

            migrationBuilder.RenameColumn(
                name: "PayerNote",
                schema: "public",
                table: "CashIns",
                newName: "DepositPhoneNumberNetworkName");

            migrationBuilder.RenameColumn(
                name: "PayeeNote",
                schema: "public",
                table: "CashIns",
                newName: "DepositPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PartyIdType",
                schema: "public",
                table: "CashIns",
                newName: "CustomerPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ExternalId",
                schema: "public",
                table: "CashIns",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "DepositorContactNo",
                schema: "public",
                table: "CashIns",
                newName: "BranchMerchantNumberNetworkName");

            migrationBuilder.RenameColumn(
                name: "BranchAccountNumber",
                schema: "public",
                table: "CashIns",
                newName: "BranchMerchantNumber");

            migrationBuilder.AlterColumn<double>(
                name: "SendingCost",
                schema: "public",
                table: "CashIns",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDateTime",
                schema: "public",
                table: "CashIns",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DepositAmount",
                schema: "public",
                table: "CashIns",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}