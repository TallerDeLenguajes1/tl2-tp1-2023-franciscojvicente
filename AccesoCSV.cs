namespace PedidosYa
{
    class AccesoCSV: AccesoADatos
    {
        public AccesoCSV(string archivoCadeteria, string archivoCadetes): base($"{archivoCadeteria}.csv", $"{archivoCadetes}.csv") {
            
        }
    
        protected override void CrearCadeteria  (string archivoCadeteria) {
            if (string.IsNullOrWhiteSpace(archivoCadeteria)) return;
            using var sr = new StreamReader(archivoCadeteria);
            var contenido = sr.ReadToEnd();
            var datos = contenido.Split(',');
            cadeteria = new Cadeteria(datos[0], datos[1]);
        }

        protected override void CrearCadetes  (string archivoCadetes) {
            if (string.IsNullOrWhiteSpace(archivoCadetes)) return;
            using var sr = new StreamReader(archivoCadetes);
            string? linea;
    
            while ((linea = sr.ReadLine()) != null)
            {
                var datos = linea.Split(',');
                cadeteria?.AgregarCadete(datos[0], datos[1], datos[2]);
            }
        }
    }
}