using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CouponClipper.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCouponClippings_Coupons_ClippedCouponCouponId",
                table: "UserCouponClippings");

            migrationBuilder.DropIndex(
                name: "IX_UserCouponClippings_ClippedCouponCouponId",
                table: "UserCouponClippings");

            migrationBuilder.DropColumn(
                name: "ClippedCouponCouponId",
                table: "UserCouponClippings");

            migrationBuilder.AlterColumn<int>(
                name: "CouponId",
                table: "UserCouponClippings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserCouponClippings_CouponId",
                table: "UserCouponClippings",
                column: "CouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCouponClippings_Coupons_CouponId",
                table: "UserCouponClippings",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "CouponId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCouponClippings_Coupons_CouponId",
                table: "UserCouponClippings");

            migrationBuilder.DropIndex(
                name: "IX_UserCouponClippings_CouponId",
                table: "UserCouponClippings");

            migrationBuilder.AlterColumn<string>(
                name: "CouponId",
                table: "UserCouponClippings",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ClippedCouponCouponId",
                table: "UserCouponClippings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCouponClippings_ClippedCouponCouponId",
                table: "UserCouponClippings",
                column: "ClippedCouponCouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCouponClippings_Coupons_ClippedCouponCouponId",
                table: "UserCouponClippings",
                column: "ClippedCouponCouponId",
                principalTable: "Coupons",
                principalColumn: "CouponId");
        }
    }
}
