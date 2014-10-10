using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class UsuariosNego
    {
        UsuariosRepo usuarioRepo = new UsuariosRepo();

        public IEnumerable<SSO_User> listaUsuarios()
        {
            return usuarioRepo.listaUsuarios();
        }
    }
}
