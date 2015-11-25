using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using Concesionario.Models;
using Concesionario.Utilidades;

namespace Concesionario.Seguridad
{
    //enlaza el principal con el membership provider
    //es el intermediario entre el identity y entity framework
    public class UsuarioMembership : MembershipUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string imagen { get; set; }
        public String Rol { get; set; }


        public UsuarioMembership(Usuario u)
        {
            var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
            id = u.id;
            nombre = u.nombre;
            apellidos = u.apellidos;
            imagen = u.imagen;
            email = SeguridadUtilidades.DesCifrar(Convert.FromBase64String(u.email), clave);
            Rol = u.Rol.nombre;
            username = u.username;
        }
    }
}