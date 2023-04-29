using ApiTMDB.DAL;
using ApiTMDB.MOD;
using ApiToken;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace ApiTMDB.BLL
{
    public class TmdbBLL 
    {
        private readonly TmdbDAL _TmdbDAL;
        public TmdbBLL()
        {
            _TmdbDAL = new TmdbDAL();
        }
        public Usuário Cadastrar(Usuário usuario)
        {

            if (!_TmdbDAL.Cadastrar(usuario))
            {
                throw new Exception("Erro ao cadastrar.");
            }            
            return usuario;
        }
        public bool Logar(Usuário usuario)
        {
            if (_TmdbDAL.Logar(usuario) == null)
            {
                throw new Exception("Usuário não registrado");
            }
            return true;
        }
    }
}