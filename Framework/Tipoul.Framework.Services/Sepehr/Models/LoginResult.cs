﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.Sepehr.Models
{
    public class LoginResult
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string JwtToken { get; set; }
    }
}
