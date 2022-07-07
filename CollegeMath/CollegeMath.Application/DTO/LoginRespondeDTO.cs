using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.DTO
{
    public class LoginResponseDTO
    {
        public string AccessToken { get; set; }

        public string Id { get; set; }

        public double ExpiresIn { get; set; }
    }
}
