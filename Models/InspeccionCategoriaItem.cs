using System.ComponentModel.DataAnnotations;
using Workcube.Generic;

namespace API.Inspecciones.Models
{
    public class InspeccionCategoriaItem : UserCreated
    {
        [Key]
        public string IdInspeccionCategoriaItem {  get; set; }
        public string Name {  get; set; }
        public string Descripcion { get; set; }

        // INSPECCION
        public string IdInspeccion { get; set; }
        public virtual Inspeccion InspeccionUnidad { get; set; }
        public string InspeccionFolio { get; set; }

        // INSPECCION CATEGORIA
        public string IdInspeccionCategoria { get; set; }
        public virtual InspeccionCategoria InspeccionCategoria { get; set; }
        public string InspeccionCategoriaName { get; set; }
        
        // FORMULARIO TIPO
        public string IdFormularioTipo { get; set; }
        public virtual FormularioTipo FormularioTipo { get; set; }
        public string FormularioTipoName {  get; set; }

        public string FormularioValor {  get; set; }        

        public string Value {  get; set; }
        public string ValueAnterior {  get; set; }
    }
}
