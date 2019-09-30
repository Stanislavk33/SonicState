using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SonicState.Models.BindingModels
{
    public class LoginUser
    {
        [Required]
      [JsonProperty("email")]
        public string Email { get; set; }


        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
