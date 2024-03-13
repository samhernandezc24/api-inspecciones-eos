using System.ComponentModel.DataAnnotations;
using Workcube.Generic;

namespace API.Inspecciones.Models
{
    public class InspeccionFichero : UserCreated
    {
        [Key]
        public string IdInspeccionFichero {  get; set; }

        // INSPECCION
        public string IdInspeccion {  get; set; }
        public virtual Inspeccion Inspeccion { get; set; }
        public string InspeccionFolio { get; set; }

        public string Path { get; set; }
        public int Orden {  get; set; }      
    }
}
