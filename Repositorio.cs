using Microsoft.VisualBasic;

namespace PedidosYa
{
    class Repositorio
    {
        private Cadeteria? cadeteria;
        private List<Cadete> listaCadetes = new();
        private Pedido? pedido;
        private Cadete? cadeteSeleccionado;

        internal Cadeteria? Cadeteria { get => cadeteria;}
        internal Pedido? Pedido { get => pedido;}
        internal Cadete? CadeteSeleccionado { get => cadeteSeleccionado;}

        public Repositorio(string archivoCadeteria, string archivoCadetes) {
            CrearCadeteria(archivoCadeteria);
            CrearCadetes(archivoCadetes);
        }

        
        private void CrearCadeteria  (string archivoCadeteria) {
            if (string.IsNullOrWhiteSpace(archivoCadeteria)) return;
            using var sr = new StreamReader(archivoCadeteria);
            var contenido = sr.ReadToEnd();
            var datos = contenido.Split(',');
            cadeteria = new Cadeteria(datos[0], datos[1]);

        }
        private void CrearCadetes  (string archivoCadetes) {
           
            if (string.IsNullOrWhiteSpace(archivoCadetes)) return;
            using var sr = new StreamReader(archivoCadetes);
            string? linea;
    
            while ((linea = sr.ReadLine()) != null)
            {
                var datos = linea.Split(',');
                var cadete = new Cadete(datos[0], datos[1], datos[2]);
                cadeteria?.AgregarCadete(cadete);
            }
        }

        // public Pedido UltimoPedido() {
        //     return listaPedidos.Last(p => p.EstadosPedido == EstadosPedidos.Pendiente);
        // }

        public void GuardarPedido(Pedido pedido) {
            this.pedido = pedido;
        }

        public void GuardarCadete(Cadete? cadete) {
            cadeteSeleccionado = cadete;
        }

    }
}