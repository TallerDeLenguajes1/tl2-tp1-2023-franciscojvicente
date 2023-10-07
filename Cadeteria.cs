using System.IO.Pipes;

namespace PedidosYa {
    class Cadeteria
    {
        private string? nombre;
        private string telefono;
        private List<Cadete> listadoCadetes = new();

        public string? Nombre { get => nombre; }
        public string Telefono { get => telefono;  }
        public List<Cadete> ListadoCadetes { get => listadoCadetes;}

        public Cadeteria(string nombre, string telefono) {
            this.nombre = nombre;
            this.telefono = telefono;
        }

        public void AgregarCadete(Cadete cadete) {
            listadoCadetes.Add(cadete);
        }

        public decimal CantidadEnviosPromedio() {
            var suma = ListadoCadetes.Sum(c => c.PedidosEntregados());
            return listadoCadetes.Any() ? 
            suma/(decimal)listadoCadetes.Count : 
            0;
        }
    //      AsignarPedido();
    //      AgregarCadete();
    //      EliminarCadete();
    }
}