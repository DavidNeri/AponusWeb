﻿namespace Aponus_Web_API.Modelos
{
    public class Usuarios
    {
        public string Usuario { get; set; } = "";
        public string Contraseña { get; set; } = "";
        public string Correo { get; set; } = "";
        public int IdPerfil { get; set; }

        public virtual ICollection<Entidades> IdUsuarioRegistroNavigation { get; set; } = new HashSet<Entidades>();
        public virtual ICollection<Compras> Compras { get; set; } = new HashSet<Compras>();
        public virtual ICollection<Ventas> Ventas { get; set; } = new HashSet<Ventas>();
        public virtual PerfilesUsuarios Perfil { get; set; } = new();
    }
}