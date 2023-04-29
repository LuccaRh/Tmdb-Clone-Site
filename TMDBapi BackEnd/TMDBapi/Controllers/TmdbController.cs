using ApiTMDB.BLL;
using ApiTMDB.MOD;
using ApiToken;
using Microsoft.AspNetCore.Mvc;

namespace TMDBapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TmdbController : ControllerBase
    {
        private readonly TmdbBLL _TmdbBLL;
        private readonly TokenBuilder _TokenBuilder;
        public TmdbController()
        {
            _TmdbBLL= new TmdbBLL();
            _TokenBuilder = new TokenBuilder();
        }
        [HttpPost("Cadastro")]
        public IActionResult Cadastrar([FromBody] Usuário usuario)
        {
            try
            {
                return Ok(_TmdbBLL.Cadastrar(usuario));
            }
            catch (Exception ex)
            
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public IActionResult Logar([FromBody] Usuário usuario)
        {
            try
            {
                bool auth = false;
                auth = _TmdbBLL.Logar(usuario);
                if (auth)
                {
                    var token = _TokenBuilder.GenerateToken(usuario);
                    usuario.token = token;
                    string nome = "TmdbAuthCookie";
                    HttpContext.Response.Cookies.Append(nome, token, new CookieOptions
                    {
                        HttpOnly = false,
                        SameSite = SameSiteMode.None,
                        Secure = true
                    });
                } 
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
