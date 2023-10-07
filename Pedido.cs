namespace PedidosYa
{
    class Pedido
    {
        private static int autonumerico = 1;
        private int numeroPedido;
        private string? observacionPedido;
        private Cliente? cliente;
        private EstadosPedidos estadosPedido;

        
        public int NumeroPedido { get => numeroPedido;}
        public string? ObservacionPedido { get => observacionPedido;}
        public EstadosPedidos EstadosPedido { get => estadosPedido;  }

        public Pedido(string? observacion, string? nombre, string? direccion, string? telefono, string? datosReferenciaDireccion)
        {
            if(nombre == null || direccion == null || telefono == null || datosReferenciaDireccion == null ) return;
            cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
            numeroPedido = autonumerico++;
            observacionPedido = observacion;
            estadosPedido = EstadosPedidos.Pendiente;
        }

        // public (string, string? Direccion, string? DatosReferenciaDireccion) VerDireccionCliente() {
        //     return ("La direccion es {0} y sus referencias son {1}", cliente.Direccion, cliente.DatosReferenciaDireccion);
        // }
        // public (string, string? Nombre, int Telefono) VerDatosCliente() {
        //     return ("Nombre cliente: {0}\nTelefono Cliente: {1}", cliente.Nombre, cliente.Telefono);
        // }


        public void CambiarEstado()
        {
            int siguienteValor = ((int)EstadosPedido + 1) % Enum.GetValues(typeof(EstadosPedidos)).Length;
            EstadosPedidos siguienteEstado = (EstadosPedidos)siguienteValor;

            if (siguienteEstado > EstadosPedido)
            {
                estadosPedido = siguienteEstado;
            }
        }

        public void Asignado()
        {
            estadosPedido = EstadosPedidos.Asignado;
        }

        public void Rechazar()
        {
            estadosPedido = EstadosPedidos.Rechazado;
        }

        public void Entregar()
        {
            estadosPedido = EstadosPedidos.Entregado;
        }
        // solo
        public void Pendiente() {
            estadosPedido = EstadosPedidos.Pendiente;
        }
    }
}