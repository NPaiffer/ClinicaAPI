using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    CnpjClinica = table.Column<string>(name: "Cnpj_Clinica", type: "NVARCHAR2(450)", nullable: false),
                    NomeClinica = table.Column<string>(name: "Nome_Clinica", type: "NVARCHAR2(2000)", nullable: false),
                    IdUsuario = table.Column<int>(name: "Id_Usuario", type: "NUMBER(10)", nullable: true),
                    IdEndereco = table.Column<int>(name: "Id_Endereco", type: "NUMBER(10)", nullable: true),
                    IdTelefone = table.Column<int>(name: "Id_Telefone", type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.CnpjClinica);
                });

            migrationBuilder.CreateTable(
                name: "Dentistas",
                columns: table => new
                {
                    CpfDentista = table.Column<int>(name: "Cpf_Dentista", type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeDentista = table.Column<string>(name: "Nome_Dentista", type: "NVARCHAR2(2000)", nullable: true),
                    CroDentista = table.Column<string>(name: "Cro_Dentista", type: "NVARCHAR2(2000)", nullable: true),
                    Especialidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EmailDentista = table.Column<string>(name: "Email_Dentista", type: "NVARCHAR2(2000)", nullable: true),
                    DataContratacao = table.Column<DateTime>(name: "Data_Contratacao", type: "TIMESTAMP(7)", nullable: false),
                    CnpjClinica = table.Column<int>(name: "Cnpj_Clinica", type: "NUMBER(10)", nullable: true),
                    IdEndereco = table.Column<int>(name: "Id_Endereco", type: "NUMBER(10)", nullable: true),
                    IdTelefone = table.Column<int>(name: "Id_Telefone", type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentistas", x => x.CpfDentista);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(name: "Id_Endereco", type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RuaEndereco = table.Column<string>(name: "Rua_Endereco", type: "NVARCHAR2(2000)", nullable: true),
                    NumeroEndereco = table.Column<int>(name: "Numero_Endereco", type: "NUMBER(10)", nullable: false),
                    ComplementoEndereco = table.Column<string>(name: "Complemento_Endereco", type: "NVARCHAR2(2000)", nullable: true),
                    BairroEndereco = table.Column<string>(name: "Bairro_Endereco", type: "NVARCHAR2(2000)", nullable: true),
                    CidadeEndereco = table.Column<string>(name: "Cidade_Endereco", type: "NVARCHAR2(2000)", nullable: true),
                    EstadoEndereco = table.Column<string>(name: "Estado_Endereco", type: "NVARCHAR2(2000)", nullable: true),
                    Cep = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    CpfPaciente = table.Column<int>(name: "Cpf_Paciente", type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomePaciente = table.Column<string>(name: "Nome_Paciente", type: "NVARCHAR2(2000)", nullable: true),
                    DataNascimento = table.Column<DateTime>(name: "Data_Nascimento", type: "TIMESTAMP(7)", nullable: false),
                    GeneroPaciente = table.Column<string>(name: "Genero_Paciente", type: "NVARCHAR2(2000)", nullable: true),
                    CnpjClinica = table.Column<int>(name: "Cnpj_Clinica", type: "NUMBER(10)", nullable: true),
                    IdEndereco = table.Column<int>(name: "Id_Endereco", type: "NUMBER(10)", nullable: true),
                    IdTelefone = table.Column<int>(name: "Id_Telefone", type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.CpfPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    IdTelefone = table.Column<int>(name: "Id_Telefone", type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NumeroTelefone = table.Column<string>(name: "Numero_Telefone", type: "NVARCHAR2(2000)", nullable: true),
                    TipoTelefone = table.Column<string>(name: "Tipo_Telefone", type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.IdTelefone);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(name: "Id_Usuario", type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmailUsuario = table.Column<string>(name: "Email_Usuario", type: "NVARCHAR2(2000)", nullable: true),
                    SenhaUsuario = table.Column<string>(name: "Senha_Usuario", type: "NVARCHAR2(2000)", nullable: true),
                    StatusUsuario = table.Column<string>(name: "Status_Usuario", type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    IdAtendimento = table.Column<int>(name: "Id_Atendimento", type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoProcedimento = table.Column<string>(name: "Tipo_Procedimento", type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DescricaoAtendimento = table.Column<string>(name: "Descricao_Atendimento", type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    DataAtendimento = table.Column<DateTime>(name: "Data_Atendimento", type: "TIMESTAMP(7)", nullable: false),
                    CustoEstimado = table.Column<decimal>(name: "Custo_Estimado", type: "decimal(10,2)", nullable: false),
                    CpfPaciente = table.Column<int>(name: "Cpf_Paciente", type: "NUMBER(10)", nullable: true),
                    CpfDentista = table.Column<int>(name: "Cpf_Dentista", type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.IdAtendimento);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Dentistas_Cpf_Dentista",
                        column: x => x.CpfDentista,
                        principalTable: "Dentistas",
                        principalColumn: "Cpf_Dentista");
                    table.ForeignKey(
                        name: "FK_Atendimentos_Pacientes_Cpf_Paciente",
                        column: x => x.CpfPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Cpf_Paciente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_Cpf_Dentista",
                table: "Atendimentos",
                column: "Cpf_Dentista");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_Cpf_Paciente",
                table: "Atendimentos",
                column: "Cpf_Paciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Clinicas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Dentistas");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
