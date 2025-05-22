using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CRMCallCenter.Migrations
{
    /// <inheritdoc />
    public partial class DodanieModeliPodstawowych : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Uzytkownicy",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HasloHash",
                table: "Uzytkownicy",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PrzelozonyId",
                table: "Uzytkownicy",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolaId",
                table: "Uzytkownicy",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZespolId",
                table: "Uzytkownicy",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nazwa = table.Column<string>(type: "text", nullable: false),
                    Opis = table.Column<string>(type: "text", nullable: true),
                    Cena = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nazwa = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zespoly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nazwa = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zespoly", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Imie = table.Column<string>(type: "text", nullable: false),
                    Nazwisko = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true),
                    ZepolId = table.Column<int>(type: "integer", nullable: false),
                    ZespolId = table.Column<int>(type: "integer", nullable: false),
                    PrzypisanyUzytkownikId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klienci_Uzytkownicy_PrzypisanyUzytkownikId",
                        column: x => x.PrzypisanyUzytkownikId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Klienci_Zespoly_ZespolId",
                        column: x => x.ZespolId,
                        principalTable: "Zespoly",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolaczeniaTelefoniczne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KlientId = table.Column<int>(type: "integer", nullable: false),
                    UzytkownikId = table.Column<int>(type: "integer", nullable: false),
                    CzasTrwaniaSekundy = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CzyNagrane = table.Column<bool>(type: "boolean", nullable: false),
                    UrlNagrania = table.Column<string>(type: "text", nullable: true),
                    Notatka = table.Column<string>(type: "text", nullable: true),
                    DataUtworzenia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolaczeniaTelefoniczne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolaczeniaTelefoniczne_Klienci_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolaczeniaTelefoniczne_Uzytkownicy_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tansakcje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KlientId = table.Column<int>(type: "integer", nullable: false),
                    ProduktId = table.Column<int>(type: "integer", nullable: false),
                    UtworzonaPrzezId = table.Column<int>(type: "integer", nullable: false),
                    Etap = table.Column<int>(type: "integer", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataPodpisania = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CzyZdalna = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tansakcje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tansakcje_Klienci_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tansakcje_Produkty_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tansakcje_Uzytkownicy_UtworzonaPrzezId",
                        column: x => x.UtworzonaPrzezId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_PrzelozonyId",
                table: "Uzytkownicy",
                column: "PrzelozonyId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_RolaId",
                table: "Uzytkownicy",
                column: "RolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_ZespolId",
                table: "Uzytkownicy",
                column: "ZespolId");

            migrationBuilder.CreateIndex(
                name: "IX_Klienci_PrzypisanyUzytkownikId",
                table: "Klienci",
                column: "PrzypisanyUzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Klienci_ZespolId",
                table: "Klienci",
                column: "ZespolId");

            migrationBuilder.CreateIndex(
                name: "IX_PolaczeniaTelefoniczne_KlientId",
                table: "PolaczeniaTelefoniczne",
                column: "KlientId");

            migrationBuilder.CreateIndex(
                name: "IX_PolaczeniaTelefoniczne_UzytkownikId",
                table: "PolaczeniaTelefoniczne",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Tansakcje_KlientId",
                table: "Tansakcje",
                column: "KlientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tansakcje_ProduktId",
                table: "Tansakcje",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Tansakcje_UtworzonaPrzezId",
                table: "Tansakcje",
                column: "UtworzonaPrzezId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Role_RolaId",
                table: "Uzytkownicy",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Uzytkownicy_PrzelozonyId",
                table: "Uzytkownicy",
                column: "PrzelozonyId",
                principalTable: "Uzytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Zespoly_ZespolId",
                table: "Uzytkownicy",
                column: "ZespolId",
                principalTable: "Zespoly",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Role_RolaId",
                table: "Uzytkownicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Uzytkownicy_PrzelozonyId",
                table: "Uzytkownicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Zespoly_ZespolId",
                table: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "PolaczeniaTelefoniczne");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Tansakcje");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Produkty");

            migrationBuilder.DropTable(
                name: "Zespoly");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkownicy_PrzelozonyId",
                table: "Uzytkownicy");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkownicy_RolaId",
                table: "Uzytkownicy");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkownicy_ZespolId",
                table: "Uzytkownicy");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Uzytkownicy");

            migrationBuilder.DropColumn(
                name: "HasloHash",
                table: "Uzytkownicy");

            migrationBuilder.DropColumn(
                name: "PrzelozonyId",
                table: "Uzytkownicy");

            migrationBuilder.DropColumn(
                name: "RolaId",
                table: "Uzytkownicy");

            migrationBuilder.DropColumn(
                name: "ZespolId",
                table: "Uzytkownicy");
        }
    }
}
