namespace JwtGenerator.Api.DTO
{
    public class JwksPair
    {
        List<JwksPublic> JwksPublic { get; set; }
        JwksPrivate JwksPrivate { get; set; }
    }

}
