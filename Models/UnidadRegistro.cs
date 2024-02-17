using System.ComponentModel.DataAnnotations;
using Workcube.Generic;

namespace API.Inspecciones.Models
{
    public class UnidadRegistro : UserCreated
    {
        [Key]
        public string IdUnidadRegistro {  get; set; }
        public string NumeroEconomico { get; set; }

        public string IdRequerimiento { get; set; }
        public string RequerimientoFolio { get; set; }

        public DateTime Fecha { get; set; }
        public string FechaNatural => this.Fecha.ToString("dd.MM.yyyy");
    }
}
