using System.ComponentModel.DataAnnotations;
using Workcube.Generic;

namespace API.Inspecciones.Models
{
    public class InspeccionTipo : UserCreated
    {
        [Key]
        public string IdInspeccionTipo { get; set; }

        public string Folio { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Correo { get; set; }
        public int Orden { get; set; }
        
        public virtual List<Categoria> Categorias { get; set; }
        public virtual List<CategoriaItem> CategoriasItems { get; set; }
        public virtual List<Inspeccion> Inspecciones { get; set; }
    }
}
