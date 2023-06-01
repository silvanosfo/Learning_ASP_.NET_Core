using Microsoft.Data.SqlClient;
using System.Data;

namespace EquiMembros2023.Data
{
    class ConectarEColonizar
    {
        private string scRemota = "Server=62.28.39.135,62444;Database=zSilEquipas;user=EFASilvano;password=SILvanosfo;";

        public DataTable ExecutarConsulta(string SSQL)
        {

            string stringConnectionEquipasEMembros = scRemota;//CUIDADO AQUI! <------- ##
                                                              //criar uma conexão:
            SqlConnection c = new SqlConnection(stringConnectionEquipasEMembros);
            c.Open();
            //criar comando SQL para extrair os dados pretendidos:
            SqlCommand command = c.CreateCommand();
            command.CommandText = SSQL;

            //trazer os dados da tabela especificada para uma "tabela" em memória:
            SqlDataAdapter da = new SqlDataAdapter(command);
            var dt = new DataTable();
            da.Fill(dt);

            //desligar a conexão:
            c.Close();
            return dt;
        }

        public void RecolonizarTabelaDeEquipas()
        {
            string SSQL =
            "DELETE FROM Tequipas;" +
            "DBCC CHECKIDENT(Tequipas, RESEED, 0);" +
            "SET IDENTITY_INSERT Tequipas ON;" +
            "INSERT[dbo].[Tequipas]([Id], [NomeEquipa]) VALUES(1, N'Falcões do Picoto');" +
            "INSERT[dbo].[Tequipas]([Id], [NomeEquipa]) VALUES(2, N'Arsenal da Devesa');" +
            "INSERT[dbo].[Tequipas]([Id], [NomeEquipa]) VALUES(3, N'Ases de Fraião');" +
            "INSERT[dbo].[Tequipas]([Id], [NomeEquipa]) VALUES(4, N'Leões da Tecla');" +
            "INSERT[dbo].[Tequipas]([Id], [NomeEquipa]) VALUES(5, N'Maximinense');" +
            "SET IDENTITY_INSERT Tequipas OFF;"
            ;

            //executa a consulta sql anterior:
            ExecutarConsulta(SSQL);
        }

        public void RecolonizarTabelaDeMembros()
        {
            string SSQL =
            "DELETE FROM Tmembros;" +
            "DBCC CHECKIDENT(Tmembros, RESEED, 0);" +
            "SET IDENTITY_INSERT Tmembros ON;" +
            "INSERT[dbo].[Tmembros]([Id], [NomeMembro], [EquipaID]) VALUES(1, N'Carlinhos', 1);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(2, N'Afonsinho', 1);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(3, N'Abel', 2);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(4, N'Ana', 1);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(5, N'Arlindo', 4);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(6, N'Rosa', 1);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(7, N'Adriano', 4);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(8, N'António', 4);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(9, N'Alexandre', 4);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(10, N'Amélia', 4);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(11, N'Sandra', 5);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(12, N'Teresa', 4);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(13, N'Isabelinha', 5);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(14, N'Abel', 5);" +
            "INSERT[dbo].[Tmembros] ([Id], [NomeMembro], [EquipaID]) VALUES(15, N'Joana', 1);" +
            "SET IDENTITY_INSERT Tmembros OFF;"
            ;

            //executa a consulta sql anterior:
            ExecutarConsulta(SSQL);
        }
    }
}



