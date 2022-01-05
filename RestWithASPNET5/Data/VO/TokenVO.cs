﻿namespace RestWithASPNET5.Data.VO
{
    public class TokenVO
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AcessToken { get; set; }
        public string RefreshToken { get; set; }

        public TokenVO(bool authenticated, string created, string expiration, string acessToken, string refreshToken)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AcessToken = acessToken;
            RefreshToken = refreshToken;
        }
    }
}
