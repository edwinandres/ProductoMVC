using System;

namespace MiPrimerAppMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; } 

        public string Nombre { get; set; }  

        public string Correo { get; set; }

        public string Password { get; set; }

        public DateTime FechaDeAlta { get; set; }

        public bool Activo { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}