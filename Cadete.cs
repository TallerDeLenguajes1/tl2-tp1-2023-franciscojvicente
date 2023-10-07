namespace PedidosYa
{
    class Cadete
    {
        private static int autonumerico = 1;
        private int id; // atributo
        private string? nombre;
        private string? direccion;
        private string? telefono;
        private List<Pedido> listadoPedidos = new();

        public int Id { get => id;} // propiedad
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telefono { get => telefono; set => telefono = value; }

        public Cadete(string nombre, string direccion, string telefono) {
            id = autonumerico++;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public void TomarPedido(Pedido pedido) {
            listadoPedidos.Add(pedido);
            pedido.Asignado();
        }
        // solo
        public void AbandonarPedido(Pedido pedido) {
            listadoPedidos.Remove(pedido);
            pedido.Pendiente();
        }

        public int PedidosEntregados() {
            return listadoPedidos.Count(p => p.EstadosPedido == EstadosPedidos.Entregado);
        }
        public decimal TotalGanado() {
            return PedidosEntregados() * 500;
        }
    }
}