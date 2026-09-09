using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;


namespace BuscarAPI_V2.Domain.Models
{    public class Perfil
    {      
        public int Id { get; set; }
        public string DescricaoPerfil { get; set; }
    }
}
