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

        // si tengo metodo abstracto me obliga a que en cada clase derivada yo defina ese metodo, si no lo defino no podré crear instancias de esa clase derivada
        protected abstract void CrearCadeteria  (string archivoCadeteria);

        protected abstract void CrearCadetes  (string archivoCadetes);

    }
}