using System.IO.Pipes;

namespace PedidosYa {
    class Cadeteria
    {
        private string? nombre;
        private string telefono;
        private List<Cadete> listadoCadetes = new();
        private List<Pedido> listadoPedidos = new();

        
        public List<Cadete> ListadoCadetes { get => listadoCadetes;}
        internal List<Pedido> ListadoPedidos { get => listadoPedidos;}
        public string? Nombre { get => nombre;  }
        public string Telefono { get => telefono; }

        public Cadeteria(){

        }
        public Cadeteria(string nombre, string telefono) {
            this.nombre = nombre;
            this.telefono = telefono;
        }


        public void AgregarCadete(Cadete cadete) {
            listadoCadetes.Add(cadete);
        }
        public void AgregarCadetes(List<Cadete>? cadetes) {
            if (cadetes == null) return;
            listadoCadetes = cadetes;
        }

        public void AgregarPedido(Pedido pedido) {
            listadoPedidos.Add(pedido);
        }

        // solo

        public int PedidosEntregados() {
            return listadoPedidos.Count(p => p.EstadosPedido == EstadosPedidos.Entregado);
        }
        public decimal JornalACobrar(int idCadete) {
            var cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            if (cadete == null) return 0;
            var totalPedidos = listadoPedidos.Count(p => p.Cadete?.Id == cadete.Id && p.EstadosPedido == EstadosPedidos.Entregado);
            return totalPedidos * 500;
        }
        public void AsignarCadeteAPedido(int idCadete, int idPedido) {
            var cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            var pedido = listadoPedidos.FirstOrDefault(p => p.NumeroPedido == idPedido);
            if (pedido == null || cadete == null) return;
            pedido.AsignarCadete(cadete);
        }

        public IEnumerable<Pedido> PedidosPendientes() {
            return listadoPedidos.Where(p => p.EstadosPedido == EstadosPedidos.Pendiente);
        }
        public IEnumerable<Pedido> PedidosAsignados() {
            return listadoPedidos.Where(p => p.EstadosPedido == EstadosPedidos.Asignado);
        }
        

        // public decimal CantidadEnviosPromedio() {
        //     var suma = ListadoCadetes.Sum(c => c.PedidosEntregados());
        //     return listadoCadetes.Any() ? 
        //     suma/(decimal)listadoCadetes.Count : 
        //     0;
        // }
    //      AsignarPedido();
    //      AgregarCadete();
    //      EliminarCadete();
    }
}