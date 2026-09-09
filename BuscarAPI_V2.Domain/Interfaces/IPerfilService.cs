using BuscarAPI_V2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscarAPI_V2.Domain.Interfaces
{
    public interface IPerfilService
    {
        Task<IList<Perfil>> GetPerfis();
        Task<Perfil> GetPerfilId(int perfilId);
        Task<Perfil> UpdatePerfil(Perfil perfil);
        Task<Perfil> CreatePerfil(Perfil perfil);
        Task DeletePerfil(int perfilId);
    }
}
