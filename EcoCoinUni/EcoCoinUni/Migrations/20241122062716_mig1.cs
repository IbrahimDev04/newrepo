using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCoinUni.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_AspNetUsers_UserId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_TransportType_TransportId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_ToCardInfo_AspNetUsers_UserId",
                table: "ToCardInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Histories",
                table: "Histories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransportType",
                table: "TransportType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToCardInfo",
                table: "ToCardInfo");

            migrationBuilder.RenameTable(
                name: "Histories",
                newName: "histories");

            migrationBuilder.RenameTable(
                name: "TransportType",
                newName: "transportTypes");

            migrationBuilder.RenameTable(
                name: "ToCardInfo",
                newName: "toCards");

            migrationBuilder.RenameIndex(
                name: "IX_Histories_UserId",
                table: "histories",
                newName: "IX_histories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Histories_TransportId",
                table: "histories",
                newName: "IX_histories_TransportId");

            migrationBuilder.RenameIndex(
                name: "IX_ToCardInfo_UserId",
                table: "toCards",
                newName: "IX_toCards_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_histories",
                table: "histories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transportTypes",
                table: "transportTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_toCards",
                table: "toCards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_histories_AspNetUsers_UserId",
                table: "histories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_histories_transportTypes_TransportId",
                table: "histories",
                column: "TransportId",
                principalTable: "transportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_toCards_AspNetUsers_UserId",
                table: "toCards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_histories_AspNetUsers_UserId",
                table: "histories");

            migrationBuilder.DropForeignKey(
                name: "FK_histories_transportTypes_TransportId",
                table: "histories");

            migrationBuilder.DropForeignKey(
                name: "FK_toCards_AspNetUsers_UserId",
                table: "toCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_histories",
                table: "histories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transportTypes",
                table: "transportTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_toCards",
                table: "toCards");

            migrationBuilder.RenameTable(
                name: "histories",
                newName: "Histories");

            migrationBuilder.RenameTable(
                name: "transportTypes",
                newName: "TransportType");

            migrationBuilder.RenameTable(
                name: "toCards",
                newName: "ToCardInfo");

            migrationBuilder.RenameIndex(
                name: "IX_histories_UserId",
                table: "Histories",
                newName: "IX_Histories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_histories_TransportId",
                table: "Histories",
                newName: "IX_Histories_TransportId");

            migrationBuilder.RenameIndex(
                name: "IX_toCards_UserId",
                table: "ToCardInfo",
                newName: "IX_ToCardInfo_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Histories",
                table: "Histories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransportType",
                table: "TransportType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToCardInfo",
                table: "ToCardInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_AspNetUsers_UserId",
                table: "Histories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_TransportType_TransportId",
                table: "Histories",
                column: "TransportId",
                principalTable: "TransportType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToCardInfo_AspNetUsers_UserId",
                table: "ToCardInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
