using System.ComponentModel.DataAnnotations;
using Workcube.Generic;

namespace API.Inspecciones.Models
{
    // Unidades Temporales
    public class Unidad : UserCreated
    {
        [Key]
        public string IdUnidad {  get; set; }
        public string NumeroEconomico { get; set; }
        public string Descripcion { get; set; }

        public string IdUnidadTipo { get; set; }
        public string UnidadTipoName { get; set; }        
    }
}
