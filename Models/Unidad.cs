using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        // UNIDADES TIPOS
        public string IdUnidadTipo { get; set; }
        public string UnidadTipoName { get; set; }        

        // BASE
        public string IdBase {  get; set; }
        public string BaseName { get; set; }

        // MARCA DE LA UNIDAD
        public string IdUnidadMarca { get; set; }
        public string UnidadMarcaName { get; set; }
       
        public string NumeroSerie { get; set; }
        public string AnioEquipo { get; set; }
        public string Modelo { get; set; }

        public string Capacidad { get; set; }
        public int Odometro { get; set; }
        public int Horometro { get; set; }
    }
}
