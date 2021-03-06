﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediccion
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Procedencia { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        private Usuario(int id, string procedencia, string email, string token)
        {
            Id = id;
            Procedencia = procedencia;
            Email = email;
            Token = token;
        }

        public static Usuario Create(int id, string procedencia, string email, string token)
        {
            return new Usuario(id, procedencia, email, token);
        }
    }
}
