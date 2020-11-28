using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPI.Model
{
    public class Usuario
    {
        public int Id { get; set; } = 0;
        public string Nome { get; set; } = "João";
        public string Email { get; set; } = "joao@gmail.com";
    }
}
