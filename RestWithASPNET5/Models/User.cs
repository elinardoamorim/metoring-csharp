using RestWithASPNET5.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Models
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Column("login")]
        public string Login { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
