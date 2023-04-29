namespace ApiTMDB.MOD
{
    public class Usuário
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string senha { get; set; }
        public string? email { get; set; }
        public string? Role { get; set; } //adm ou usuario
        public string? token { get; set; }
    }
}