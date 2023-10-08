using System.Text.Json;
using System.Text.Json.Serialization;
namespace PedidosYa
{
    class AccesoJSON: AccesoADatos
    {
        public AccesoJSON(string archivoCadeteria, string archivoCadetes): base($"{archivoCadeteria}.json", $"{archivoCadetes}.json") {
            
        }
    
        protected override void CrearCadeteria  (string archivoCadeteria) {
            if (string.IsNullOrWhiteSpace(archivoCadeteria)) return;
            using var sr = new StreamReader(archivoCadeteria);
            var contenido = sr.ReadToEnd();
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(contenido);
        }

        protected override void CrearCadetes  (string archivoCadetes) {
            if (string.IsNullOrWhiteSpace(archivoCadetes)) return;
            var listaCadetes = new List<Cadete>();
            using var sr = new StreamReader(archivoCadetes);
            listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(sr.ReadToEnd());
            foreach (var cadete in listaCadetes)
            {
                cadeteria.AgregarCadete(cadete.Nombre, cadete.Direccion, cadete.Telefono);
            }
        }
    }
}