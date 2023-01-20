using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePos.Models
{
    public class TProducto
    {
        public uint IdProd { get; set; }
        public int? IdGrupo { get; set; }
        public int? IdBod { get; set; }
        public string NomProd { get; set; } = null!;
        public string CodProd { get; set; }
        public double ValorUnitario { get; set; }
        public double PrecioVenta { get; set; }
        public string PreparaCocina { get; set; }
        public string Combo { get; set; }
        public string DefineSabor { get; set; }
        public string MonitorBarra { get; set; }
        public string DefineTermino { get; set; }
        public string DefineBebida { get; set; }
        public string DefineTono { get; set; }
        public double PrecioVenta2 { get; set; }
        public double PrecioVenta3 { get; set; }
        public DateTime? Fecha { get; set; }

        //public virtual ICollection<TCuentasProducto> TCuentasProductos { get; set; }

    }
}
