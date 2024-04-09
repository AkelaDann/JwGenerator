namespace JwtGenerator.Api.DTO
{
    public class JwksPublic
    {
        public string kty { get; set; }
        public string e { get; set; }
        public string use { get; set; }
        public string kid { get; set; }
        public string alg { get; set; }
        public string n { get; set; }
    }

}
