using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ahorasia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comprobante_TipoComprobante_PedidoId",
                table: "Comprobante");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_TipoComprobanteId",
                table: "Comprobante",
                column: "TipoComprobanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comprobante_TipoComprobante_TipoComprobanteId",
                table: "Comprobante",
                column: "TipoComprobanteId",
                principalTable: "TipoComprobante",
                principalColumn: "TipoComprobanteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comprobante_TipoComprobante_TipoComprobanteId",
                table: "Comprobante");

            migrationBuilder.DropIndex(
                name: "IX_Comprobante_TipoComprobanteId",
                table: "Comprobante");

            migrationBuilder.AddForeignKey(
                name: "FK_Comprobante_TipoComprobante_PedidoId",
                table: "Comprobante",
                column: "PedidoId",
                principalTable: "TipoComprobante",
                principalColumn: "TipoComprobanteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
