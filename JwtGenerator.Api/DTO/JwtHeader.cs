namespace JwtGenerator.Api.DTO
{
    public class JwtHeader
    {
        public string Alg { get; set; }
        public string Typ { get; set; }
        public string Kid { get; set; }
    }


}
