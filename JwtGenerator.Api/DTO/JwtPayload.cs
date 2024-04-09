namespace JwtGenerator.Api.DTO
{
    public class JwtPayload
    {
        public string Sub { get; set; }
        public string Aud { get; set; }
        public string Iss { get; set; }
        public string Exp { get; set; }
        public string Iat { get; set; }
        public string Jti { get; set; }
    }

}
