using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Concesionario.Seguridad
{
    public class PrincipalPersonalizado : IPrincipal
    {
        public bool IsInRole(string role)
        {
            return MiIdentidadPersonalizado.Rol == role;
        }

        public IIdentity Identity { get; private set; }


        public IdentityPersonalizado MiIdentidadPersonalizado
        {
            get { return (IdentityPersonalizado)Identity; }
            set { Identity = value; }

        }

        public PrincipalPersonalizado(IdentityPersonalizado identity)
        {
            Identity = identity;
        }
    }
}