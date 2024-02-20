using System.ComponentModel.DataAnnotations;

namespace API.Inspecciones.Models
{
    public class InspeccionUnidadEstatus
    {
        [Key]
        public string IdInspeccionUnidadEstatus { get; set; }
        public string Name { get; set; }
        public int Orden {  get; set; }
        public bool Deleted { get; set; }

        public virtual List<InspeccionUnidad> InspeccionesUnidades { get; set; }
    }
}
