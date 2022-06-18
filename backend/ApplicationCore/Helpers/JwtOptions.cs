﻿namespace ApplicationCore.Helpers
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Key { get; set; }
        public double LifeTime { get; set; }
    }
}
