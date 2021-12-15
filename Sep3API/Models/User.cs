using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Sep3API.Models
{
    public class User
    {
        [JsonPropertyName("password")]
        public string password { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("role")]
        public string role { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("username")]
        public string username { get; set; }

        public User(int id, string username, string password, string role, string Email)
        {
            this.password = password;
            this.Email = Email;
            this.role = role;
            this.id = id;
            this.username = username;
            
            
            
        }

        public User()
        {
            
        }

       
    }
}