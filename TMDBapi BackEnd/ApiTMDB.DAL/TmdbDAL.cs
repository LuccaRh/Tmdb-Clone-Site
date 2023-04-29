using ApiTMDB.DAL.Utilitários;
using ApiTMDB.MOD;
using Dapper;

namespace ApiTMDB.DAL
{
    public class TmdbDAL
    {
        public bool Cadastrar(Usuário usuario)
        {
            using var connection = new BdConnection().AbrirConexao();
            string query = "INSERT INTO Tmdb.dbo.Tmdb (Username, Senha, Email) VALUES (@userName, @senha, @email);";
            connection.Execute(query, usuario);
            return true;
        }

        public Usuário Logar(Usuário usuario)
        {
            using var connection = new BdConnection().AbrirConexao();
            string query = "SELECT * FROM Tmdb.dbo.Tmdb WHERE Username = @userName AND Senha = @senha;";
            return connection.QueryFirstOrDefault<Usuário>(query, usuario);
        }
    }
}