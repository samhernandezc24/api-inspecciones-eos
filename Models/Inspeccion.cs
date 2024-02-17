using System.ComponentModel.DataAnnotations;
using Workcube.Generic;

namespace API.Inspecciones.Models
{
    public class Inspeccion : UserCreated
    {
        [Key]
        public string IdInspeccion {  get; set; }
        public string Folio { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Correo { get; set; }    
        
        public virtual List<InspeccionCategoria> InspeccionesCategorias { get; set; }
        public virtual List<InspeccionCategoriaItem> InspeccionesCategoriasItems { get; set; }
    }
}
