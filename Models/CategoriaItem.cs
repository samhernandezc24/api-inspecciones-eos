using System.ComponentModel.DataAnnotations;
using Workcube.Generic;

namespace API.Inspecciones.Models
{
    public class CategoriaItem : UserCreated
    {
        [Key]
        public string IdCategoriaItem {  get; set; }

        // INSPECCION TIPO
        public string IdInspeccionTipo { get; set; }
        public virtual InspeccionTipo InspeccionTipo { get; set; }
        public string InspeccionTipoName { get; set; }

        // CATEGORIA
        public string IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
        public string CategoriaName { get; set; }

        public string Name { get; set; }
        public int Orden { get; set; }

        // FORMULARIO TIPO
        public string IdFormularioTipo {  get; set; }
        public virtual FormularioTipo FormularioTipo { get; set; }
        public string FormularioTipoName {  get; set; }        

        public string FormularioValor { get; set; }        
    }
}
