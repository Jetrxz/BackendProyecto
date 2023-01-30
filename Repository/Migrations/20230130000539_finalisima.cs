using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class finalisima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Empleado_EmpleadoId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_producto_Insumos_Insumos_InumosInsumoId",
                table: "producto_Insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_producto_Insumos_Productos_ProductosProductoId",
                table: "producto_Insumos");

            migrationBuilder.DropIndex(
                name: "IX_producto_Insumos_InumosInsumoId",
                table: "producto_Insumos");

            migrationBuilder.DropIndex(
                name: "IX_producto_Insumos_ProductosProductoId",
                table: "producto_Insumos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_EmpleadoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "InumosInsumoId",
                table: "producto_Insumos");

            migrationBuilder.DropColumn(
                name: "ProductosProductoId",
                table: "producto_Insumos");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Pedidos");

            migrationBuilder.CreateIndex(
                name: "IX_producto_Insumos_InsumoId",
                table: "producto_Insumos",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_producto_Insumos_ProductoId",
                table: "producto_Insumos",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_producto_Insumos_Insumos_InsumoId",
                table: "producto_Insumos",
                column: "InsumoId",
                principalTable: "Insumos",
                principalColumn: "InsumoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_producto_Insumos_Productos_ProductoId",
                table: "producto_Insumos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_producto_Insumos_Insumos_InsumoId",
                table: "producto_Insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_producto_Insumos_Productos_ProductoId",
                table: "producto_Insumos");

            migrationBuilder.DropIndex(
                name: "IX_producto_Insumos_InsumoId",
                table: "producto_Insumos");

            migrationBuilder.DropIndex(
                name: "IX_producto_Insumos_ProductoId",
                table: "producto_Insumos");

            migrationBuilder.AddColumn<int>(
                name: "InumosInsumoId",
                table: "producto_Insumos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductosProductoId",
                table: "producto_Insumos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_producto_Insumos_InumosInsumoId",
                table: "producto_Insumos",
                column: "InumosInsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_producto_Insumos_ProductosProductoId",
                table: "producto_Insumos",
                column: "ProductosProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EmpleadoId",
                table: "Pedidos",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Empleado_EmpleadoId",
                table: "Pedidos",
                column: "EmpleadoId",
                principalTable: "Empleado",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_producto_Insumos_Insumos_InumosInsumoId",
                table: "producto_Insumos",
                column: "InumosInsumoId",
                principalTable: "Insumos",
                principalColumn: "InsumoId");

            migrationBuilder.AddForeignKey(
                name: "FK_producto_Insumos_Productos_ProductosProductoId",
                table: "producto_Insumos",
                column: "ProductosProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId");
        }
    }
}
