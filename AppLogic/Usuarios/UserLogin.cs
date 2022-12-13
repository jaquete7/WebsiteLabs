using DataAccess.CRUD;
using DTO;
using DTO.Usuarios;
using System.Collections.Generic;

namespace AppLogic
{
    public class UserLogin
    {
        public List<Dictionary<string, object>> Login(Usuario usuario)
        {
            UsuarioCrudFactory crud = new UsuarioCrudFactory();
            
            return crud.Validar(usuario); 
        }
    }
}
