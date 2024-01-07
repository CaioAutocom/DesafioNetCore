using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioNetCore.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "person",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    document = table.Column<string>(type: "text", nullable: true),
                    town = table.Column<string>(type: "text", nullable: true),
                    canbuy = table.Column<bool>(type: "boolean", nullable: false),
                    observations = table.Column<string>(type: "text", nullable: true),
                    alternativeidentifier = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    shortid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unit",
                schema: "public",
                columns: table => new
                {
                    acronym = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shortid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unit", x => x.acronym);
                });

            migrationBuilder.CreateTable(
                name: "product",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shortdescription = table.Column<string>(type: "text", nullable: true),
                    fulldescription = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    storage = table.Column<decimal>(type: "numeric", nullable: false),
                    barcode = table.Column<string>(type: "text", nullable: true),
                    cansell = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    acronym = table.Column<Guid>(type: "uuid", nullable: false),
                    Acronym = table.Column<string>(type: "text", nullable: false),
                    UnitAcronym = table.Column<string>(type: "text", nullable: true),
                    shortid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_unit_Acronym",
                        column: x => x.Acronym,
                        principalSchema: "public",
                        principalTable: "unit",
                        principalColumn: "acronym",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_unit_UnitAcronym",
                        column: x => x.UnitAcronym,
                        principalSchema: "public",
                        principalTable: "unit",
                        principalColumn: "acronym");
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_Acronym",
                schema: "public",
                table: "product",
                column: "Acronym");

            migrationBuilder.CreateIndex(
                name: "IX_product_UnitAcronym",
                schema: "public",
                table: "product",
                column: "UnitAcronym");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person",
                schema: "public");

            migrationBuilder.DropTable(
                name: "product",
                schema: "public");

            migrationBuilder.DropTable(
                name: "unit",
                schema: "public");
        }
    }
}
