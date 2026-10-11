using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbankAPI.Application.Dto
{
    public class UserResponseDTO
    {
        public long UserID { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
    }
}
