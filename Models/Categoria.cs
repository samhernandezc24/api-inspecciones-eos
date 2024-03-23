using System.ComponentModel.DataAnnotations;
using Workcube.Generic;

namespace API.Inspecciones.Models
{
    public class Categoria : UserCreated
    {
        [Key]
        public string IdCategoria { get; set; }
        public string Name { get; set; }

        public string IdInspeccionTipo { get; set; }   
        public virtual InspeccionTipo InspeccionTipo { get; set; }
        public string InspeccionTipoFolio { get; set; }
        public string InspeccionTipoName { get; set; }

        public int Orden { get; set; }

        public virtual List<CategoriaItem> CategoriasItems { get; set; }
    }
}
