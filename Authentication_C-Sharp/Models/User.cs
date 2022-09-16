using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Authentication_C_Sharp.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = default!;
        [JsonPropertyName("last_name")]
        public string LastName { get; set; } =default!;
        public string Email { get; set; } = default!;
        [JsonIgnore]
        //password will be ignored when returning to the front end
        public string Password { get; set; } = default!;


    }
}
