using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Concesionario.Seguridad
{
    public class IdentityPersonalizado : IIdentity
    {
        public int id { get; set; }
        public string username { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string imagen { get; set; }
        public string Rol { get; set; }
        public string email { get; set; }

        public IIdentity Identity { get; private set; }

        public IdentityPersonalizado(IIdentity identity)
        {
            this.Identity = identity;
            var u = Membership.GetUser(identity.Name) as UsuarioMembership;
            nombre = u.nombre;
            apellidos = u.apellidos;
            username = u.username;
            id = u.id;
            email = u.email;
            imagen = u.imagen;
            Rol = u.Rol;
        }



        public string Name
        {
            get { return username; }
        }

        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; } 
        }

        public bool IsAuthenticated
        {
            get { return Identity.IsAuthenticated; } 
        }
    }
}