using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Dto
{
    public class LoginDto:ResultDto
    {
        public string token { get; set; }
        public DateTime expires { get; set; }
    }
}
