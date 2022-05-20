using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MaximoFarm.Register.Api.Migrations
{
    public partial class RefatoringEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAD_ESTOQUE",
                columns: table => new
                {
                    CD_ESTOQUE = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_CAD_ESTOQUE = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_ESTOQUE = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAD_ESTOQUE", x => x.CD_ESTOQUE);
                });

            migrationBuilder.CreateTable(
                name: "CARGOS",
                columns: table => new
                {
                    CD_CARGO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_CARGO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_CARGO = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARGO", x => x.CD_CARGO);
                });

            migrationBuilder.CreateTable(
                name: "CDEBITO",
                columns: table => new
                {
                    CD_CDEBITO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_CDEBITO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_CDEBITO = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    ATIVO = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDEBITO", x => x.CD_CDEBITO);
                });

            migrationBuilder.CreateTable(
                name: "CENTRO_CUSTO",
                columns: table => new
                {
                    CD_CCUSTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_CCUSTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_CCUSTO = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    ATIVO = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCUSTO", x => x.CD_CCUSTO);
                });

            migrationBuilder.CreateTable(
                name: "CENTRO_RECEITA",
                columns: table => new
                {
                    CD_CRECEITA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_CRECEITA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_CRECEITA = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    ATIVO = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CENTRO_RECEITA", x => x.CD_CRECEITA);
                });

            migrationBuilder.CreateTable(
                name: "CICLO",
                columns: table => new
                {
                    CD_CICLO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_CICLO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_CICLO = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CICLO", x => x.CD_CICLO);
                });

            migrationBuilder.CreateTable(
                name: "CLASS_MANU",
                columns: table => new
                {
                    CD_CLASS_MANU = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_CLASS_MANU = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_CLASS_MANU = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLASS_MANU", x => x.CD_CLASS_MANU);
                });

            migrationBuilder.CreateTable(
                name: "CRECEITA",
                columns: table => new
                {
                    CD_CRECEITA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_CRECEITA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_CRECEITA = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    ATIVO = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA_RECEITA", x => x.CD_CRECEITA);
                });

            migrationBuilder.CreateTable(
                name: "ESPACAMENTOS",
                columns: table => new
                {
                    CD_ESPACAMENTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_ESPACAMENTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_ESPACAMENTO = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESPACAMENTO", x => x.CD_ESPACAMENTO);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOS",
                columns: table => new
                {
                    CD_ESTADO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_ESTADO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_ESTADO = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    DA_ESTADO = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADO", x => x.CD_ESTADO);
                });

            migrationBuilder.CreateTable(
                name: "GRUPO_EQUIPTO",
                columns: table => new
                {
                    CD_GRUPO_EQUIPTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_GRUPO_EQUIPTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_GRUPO_EQUIPTO = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    ATIVO = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPO_EQUIPTO", x => x.CD_GRUPO_EQUIPTO);
                });

            migrationBuilder.CreateTable(
                name: "GRUPO_PRODUTO",
                columns: table => new
                {
                    CD_GRUPO_PROD = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_GRUPO_PROD = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_GRUPO_PROD = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    ATIVO = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPO_PROD", x => x.CD_GRUPO_PROD);
                });

            migrationBuilder.CreateTable(
                name: "MARCAS",
                columns: table => new
                {
                    CD_MARCA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_MARCA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_MARCA = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARCA", x => x.CD_MARCA);
                });

            migrationBuilder.CreateTable(
                name: "MEDIDAS",
                columns: table => new
                {
                    CD_MEDIDA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_MEDIDA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DA_MEDIDA = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DE_MEDIDA = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDIDA", x => x.CD_MEDIDA);
                });

            migrationBuilder.CreateTable(
                name: "OPERACOES",
                columns: table => new
                {
                    CD_OPERACAO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_OPERACAO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DA_OPERACAO = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DE_OPERACAO = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERACAO", x => x.CD_OPERACAO);
                });

            migrationBuilder.CreateTable(
                name: "PONTO_ABAST",
                columns: table => new
                {
                    CD_PONTO_ABAST = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_PONTO_ABAST = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_PONTO_ABAST = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PONTO_ABAST", x => x.CD_PONTO_ABAST);
                });

            migrationBuilder.CreateTable(
                name: "SAFRA",
                columns: table => new
                {
                    CD_SAFRA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_SAFRA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_SAFRA = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAFRA", x => x.CD_SAFRA);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_EQUIPTO",
                columns: table => new
                {
                    CD_TP_EQUIPTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_TP_EQUIPTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_TP_EQUIPTO = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TP_EQUIPTO", x => x.CD_TP_EQUIPTO);
                });

            migrationBuilder.CreateTable(
                name: "CIDADES",
                columns: table => new
                {
                    CD_CIDADE = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_CIDADE = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_CIDADE = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    CD_ESTADO = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIDADE", x => x.CD_CIDADE);
                    table.ForeignKey(
                        name: "FK_CIDADES__ESTADOS",
                        column: x => x.CD_ESTADO,
                        principalTable: "ESTADOS",
                        principalColumn: "CD_ESTADO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATERIAIS",
                columns: table => new
                {
                    CD_MATERIAL = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_MATERIAL = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_MATERIAL = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    CD_MEDIDA = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_GRUPO_PROD = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_ESPACAMENTO = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_MATERIAL", x => x.CD_MATERIAL);
                    table.ForeignKey(
                        name: "FK_MATERIAIS__ESPACAMENTO",
                        column: x => x.CD_ESPACAMENTO,
                        principalTable: "ESPACAMENTOS",
                        principalColumn: "CD_ESPACAMENTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATERIAIS__GRUPO_PROD",
                        column: x => x.CD_GRUPO_PROD,
                        principalTable: "GRUPO_PRODUTO",
                        principalColumn: "CD_GRUPO_PROD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATERIAIS__MEDIDAS",
                        column: x => x.CD_MEDIDA,
                        principalTable: "MEDIDAS",
                        principalColumn: "CD_MEDIDA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MODELOS",
                columns: table => new
                {
                    CD_MODELO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_MODELO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_MODELO = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CD_MARCA = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_MEDIDA = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_MODELO", x => x.CD_MODELO);
                    table.ForeignKey(
                        name: "FK_MODELOS__MARCAS",
                        column: x => x.CD_MARCA,
                        principalTable: "MARCAS",
                        principalColumn: "CD_MARCA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MODELOS__MEDIDAS",
                        column: x => x.CD_MEDIDA,
                        principalTable: "MEDIDAS",
                        principalColumn: "CD_MEDIDA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                columns: table => new
                {
                    CD_ENDERECO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RUA = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    BAIRRO = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    NUMERO = table.Column<int>(type: "INTEGER", nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    TELEFONE = table.Column<int>(type: "INTEGER", nullable: false),
                    TELEFONE_AUX = table.Column<int>(type: "INTEGER", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    LATITUDE = table.Column<decimal>(type: "numeric(5,5)", nullable: false),
                    LONGITUDE = table.Column<decimal>(type: "numeric(5,5)", nullable: false),
                    ID_CIDADE = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.CD_ENDERECO);
                    table.ForeignKey(
                        name: "FK_ENDERECO__CIDADE",
                        column: x => x.ID_CIDADE,
                        principalTable: "CIDADES",
                        principalColumn: "CD_CIDADE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FORNECEDORES",
                columns: table => new
                {
                    CD_FORNEC = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_FORNEC = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_FORNEC = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    TP_PESSOA = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    CD_ENDERECO = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_FORNEC", x => x.CD_FORNEC);
                    table.ForeignKey(
                        name: "FK_FORNECEDORES__ENDERECOS",
                        column: x => x.CD_ENDERECO,
                        principalTable: "ENDERECOS",
                        principalColumn: "CD_ENDERECO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPTOS",
                columns: table => new
                {
                    CD_EQUIPTO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ANO_FABR = table.Column<int>(type: "INTEGER", nullable: false),
                    PLACA = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    CHASSI = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    RENAVAN = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    DT_AQUISICAO = table.Column<DateTime>(type: "DATE", nullable: false),
                    ATIVO = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CD_TIPO_EQUIPTO = table.Column<int>(type: "INT", nullable: false),
                    CD_FORNEC = table.Column<int>(type: "INT", nullable: false),
                    CD_CCUSTO = table.Column<int>(type: "INT", nullable: false),
                    CD_GRUPO_EQUIPTO = table.Column<int>(type: "INT", nullable: false),
                    CD_MODELO = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPTO", x => x.CD_EQUIPTO);
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTO__CCUSTO",
                        column: x => x.CD_CCUSTO,
                        principalTable: "CENTRO_CUSTO",
                        principalColumn: "CD_CCUSTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTO__FORNECEDORES",
                        column: x => x.CD_FORNEC,
                        principalTable: "FORNECEDORES",
                        principalColumn: "CD_FORNEC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTO__GRUPO_EQUIPTO",
                        column: x => x.CD_GRUPO_EQUIPTO,
                        principalTable: "GRUPO_EQUIPTO",
                        principalColumn: "CD_GRUPO_EQUIPTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTO__MODELOS",
                        column: x => x.CD_MODELO,
                        principalTable: "MODELOS",
                        principalColumn: "CD_MODELO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTO__TIPO_EQUIPTO",
                        column: x => x.CD_TIPO_EQUIPTO,
                        principalTable: "TIPO_EQUIPTO",
                        principalColumn: "CD_TP_EQUIPTO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSUMOS",
                columns: table => new
                {
                    CD_INSUMOS = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_INSUMOS = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_INSUMOS = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    CD_FORNEC = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_MARCA = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_MEDIDA = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_GRUPO_PRODUTO = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSUMOS", x => x.CD_INSUMOS);
                    table.ForeignKey(
                        name: "FK_INSUMOS__FORNECEDORES",
                        column: x => x.CD_FORNEC,
                        principalTable: "FORNECEDORES",
                        principalColumn: "CD_FORNEC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSUMOS__INSUMOS",
                        column: x => x.CD_GRUPO_PRODUTO,
                        principalTable: "GRUPO_PRODUTO",
                        principalColumn: "CD_GRUPO_PROD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSUMOS__MARCAS",
                        column: x => x.CD_MARCA,
                        principalTable: "MARCAS",
                        principalColumn: "CD_MARCA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSUMOS__MEDIDAS",
                        column: x => x.CD_MEDIDA,
                        principalTable: "MEDIDAS",
                        principalColumn: "CD_MEDIDA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROPRIEDADE_HE",
                columns: table => new
                {
                    CD_PROPRIEDADE = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DE_PROPRIEDADE = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    QT_AREA_TOT = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    NO_INCRA = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    NO_CADPRO = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    NO_CCIR = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    CD_FORNEC = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_CIDADE = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_PROPRIEDADE", x => x.CD_PROPRIEDADE);
                    table.ForeignKey(
                        name: "FK_PROPRIEDADE__CIDADES",
                        column: x => x.CD_CIDADE,
                        principalTable: "CIDADES",
                        principalColumn: "CD_CIDADE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROPRIEDADE__FORNECEDOR",
                        column: x => x.CD_FORNEC,
                        principalTable: "FORNECEDORES",
                        principalColumn: "CD_FORNEC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VARIEDADES",
                columns: table => new
                {
                    CD_VARIEDADE = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_VARIEDADE = table.Column<int>(type: "INTEGER", nullable: false),
                    DE_VARIEDADE = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DA_VARIEDADE = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CD_MEDIDA = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_FORNEC = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_CICLO = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_ESPACAMENTO = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VARIEDADE", x => x.CD_VARIEDADE);
                    table.ForeignKey(
                        name: "FK_VARIEDADES__CICLOS",
                        column: x => x.CD_CICLO,
                        principalTable: "CICLO",
                        principalColumn: "CD_CICLO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VARIEDADES__FORNECEDORES",
                        column: x => x.CD_FORNEC,
                        principalTable: "FORNECEDORES",
                        principalColumn: "CD_FORNEC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VARIEDADES__MEDIDAS",
                        column: x => x.CD_MEDIDA,
                        principalTable: "MEDIDAS",
                        principalColumn: "CD_MEDIDA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VARIEDADES__VARIEDADES",
                        column: x => x.ID_VARIEDADE,
                        principalTable: "ESPACAMENTOS",
                        principalColumn: "CD_ESPACAMENTO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROPRIEDADE_DE",
                columns: table => new
                {
                    CD_PROPRIEDADE = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_TALHAO = table.Column<int>(type: "INTEGER", nullable: false),
                    QT_AREA_TOT = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    QT_AREA_PROD = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    QT_AREA_DANO = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    LATITUDE = table.Column<decimal>(type: "numeric(5,5)", nullable: false),
                    LONGITUDE = table.Column<decimal>(type: "numeric(5,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROPRIEDADE", x => x.CD_PROPRIEDADE);
                    table.ForeignKey(
                        name: "FK_PROPRIEDADE__PROPRIEDADE_ITEM",
                        column: x => x.CD_PROPRIEDADE,
                        principalTable: "PROPRIEDADE_HE",
                        principalColumn: "CD_PROPRIEDADE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CIDADES_CD_ESTADO",
                table: "CIDADES",
                column: "CD_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_ID_CIDADE",
                table: "ENDERECOS",
                column: "ID_CIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPTOS_CD_CCUSTO",
                table: "EQUIPTOS",
                column: "CD_CCUSTO");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPTOS_CD_FORNEC",
                table: "EQUIPTOS",
                column: "CD_FORNEC");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPTOS_CD_GRUPO_EQUIPTO",
                table: "EQUIPTOS",
                column: "CD_GRUPO_EQUIPTO");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPTOS_CD_MODELO",
                table: "EQUIPTOS",
                column: "CD_MODELO");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPTOS_CD_TIPO_EQUIPTO",
                table: "EQUIPTOS",
                column: "CD_TIPO_EQUIPTO");

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDORES_CD_ENDERECO",
                table: "FORNECEDORES",
                column: "CD_ENDERECO");

            migrationBuilder.CreateIndex(
                name: "IX_INSUMOS_CD_FORNEC",
                table: "INSUMOS",
                column: "CD_FORNEC");

            migrationBuilder.CreateIndex(
                name: "IX_INSUMOS_CD_GRUPO_PRODUTO",
                table: "INSUMOS",
                column: "CD_GRUPO_PRODUTO");

            migrationBuilder.CreateIndex(
                name: "IX_INSUMOS_CD_MARCA",
                table: "INSUMOS",
                column: "CD_MARCA");

            migrationBuilder.CreateIndex(
                name: "IX_INSUMOS_CD_MEDIDA",
                table: "INSUMOS",
                column: "CD_MEDIDA");

            migrationBuilder.CreateIndex(
                name: "IX_MATERIAIS_CD_ESPACAMENTO",
                table: "MATERIAIS",
                column: "CD_ESPACAMENTO");

            migrationBuilder.CreateIndex(
                name: "IX_MATERIAIS_CD_GRUPO_PROD",
                table: "MATERIAIS",
                column: "CD_GRUPO_PROD");

            migrationBuilder.CreateIndex(
                name: "IX_MATERIAIS_CD_MEDIDA",
                table: "MATERIAIS",
                column: "CD_MEDIDA");

            migrationBuilder.CreateIndex(
                name: "IX_MODELOS_CD_MARCA",
                table: "MODELOS",
                column: "CD_MARCA");

            migrationBuilder.CreateIndex(
                name: "IX_MODELOS_CD_MEDIDA",
                table: "MODELOS",
                column: "CD_MEDIDA");

            migrationBuilder.CreateIndex(
                name: "IX_PROPRIEDADE_HE_CD_CIDADE",
                table: "PROPRIEDADE_HE",
                column: "CD_CIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_PROPRIEDADE_HE_CD_FORNEC",
                table: "PROPRIEDADE_HE",
                column: "CD_FORNEC");

            migrationBuilder.CreateIndex(
                name: "IX_VARIEDADES_CD_CICLO",
                table: "VARIEDADES",
                column: "CD_CICLO");

            migrationBuilder.CreateIndex(
                name: "IX_VARIEDADES_CD_FORNEC",
                table: "VARIEDADES",
                column: "CD_FORNEC");

            migrationBuilder.CreateIndex(
                name: "IX_VARIEDADES_CD_MEDIDA",
                table: "VARIEDADES",
                column: "CD_MEDIDA");

            migrationBuilder.CreateIndex(
                name: "IX_VARIEDADES_ID_VARIEDADE",
                table: "VARIEDADES",
                column: "ID_VARIEDADE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAD_ESTOQUE");

            migrationBuilder.DropTable(
                name: "CARGOS");

            migrationBuilder.DropTable(
                name: "CDEBITO");

            migrationBuilder.DropTable(
                name: "CENTRO_RECEITA");

            migrationBuilder.DropTable(
                name: "CLASS_MANU");

            migrationBuilder.DropTable(
                name: "CRECEITA");

            migrationBuilder.DropTable(
                name: "EQUIPTOS");

            migrationBuilder.DropTable(
                name: "INSUMOS");

            migrationBuilder.DropTable(
                name: "MATERIAIS");

            migrationBuilder.DropTable(
                name: "OPERACOES");

            migrationBuilder.DropTable(
                name: "PONTO_ABAST");

            migrationBuilder.DropTable(
                name: "PROPRIEDADE_DE");

            migrationBuilder.DropTable(
                name: "SAFRA");

            migrationBuilder.DropTable(
                name: "VARIEDADES");

            migrationBuilder.DropTable(
                name: "CENTRO_CUSTO");

            migrationBuilder.DropTable(
                name: "GRUPO_EQUIPTO");

            migrationBuilder.DropTable(
                name: "MODELOS");

            migrationBuilder.DropTable(
                name: "TIPO_EQUIPTO");

            migrationBuilder.DropTable(
                name: "GRUPO_PRODUTO");

            migrationBuilder.DropTable(
                name: "PROPRIEDADE_HE");

            migrationBuilder.DropTable(
                name: "CICLO");

            migrationBuilder.DropTable(
                name: "ESPACAMENTOS");

            migrationBuilder.DropTable(
                name: "MARCAS");

            migrationBuilder.DropTable(
                name: "MEDIDAS");

            migrationBuilder.DropTable(
                name: "FORNECEDORES");

            migrationBuilder.DropTable(
                name: "ENDERECOS");

            migrationBuilder.DropTable(
                name: "CIDADES");

            migrationBuilder.DropTable(
                name: "ESTADOS");
        }
    }
}
