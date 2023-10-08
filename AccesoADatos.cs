namespace PedidosYa
{
    abstract class AccesoADatos
    {
        protected Cadeteria? cadeteria;
        public Cadeteria? Cadeteria { get => cadeteria;}
        
        public AccesoADatos(string archivosCadeteria, string archivosCadetes) {
            CrearCadeteria(archivosCadeteria);
            CrearCadetes(archivosCadetes);
        }
        
        protected abstract void CrearCadeteria  (string archivoCadeteria);
        protected abstract void CrearCadetes  (string archivoCadetes);
    }
}