using PedidosYa;
using System;

namespace PedidosYa // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repositorio = new Repositorio("cadeteria.csv", "listaCadetes.csv");

            var respuesta = "s";

            while (respuesta != "n")
            {

            Console.WriteLine("a. Dar de alta un pedido");
            Console.WriteLine("b. Asignar pedido a cadete");
            Console.WriteLine("c. Cambiar estado de un pedido");
            Console.WriteLine("d. Reasignar pedido a un cadete");
            Console.WriteLine("e. Mostrar informe");
            
            

            respuesta = Console.ReadLine();

            switch (respuesta)
            {
                case "a":
                    var pedido = CargarPedido();
                    repositorio.GuardarPedido(pedido);
                    break;

                case "b":
                    var cadetePedido = AsignarPedidoCadete(repositorio.Cadeteria, repositorio.Pedido);
                    repositorio.GuardarCadete(cadetePedido);
                    break;
                case "c":
                    CambiarEstado(repositorio.Pedido);
                    break;
                case "d":
                    var cadeteReasignado = ReasignarPedido(repositorio.Cadeteria, repositorio.Pedido, repositorio.CadeteSeleccionado);
                    repositorio.GuardarCadete(cadeteReasignado);
                    break;
                case "e":
                    MostrarInforme(repositorio.Cadeteria);
                    break;
                default:
                    Console.WriteLine($"Esa opcion no es valida");
                    break;
            }
            Console.WriteLine($"Desea seguir operando? s/n");
            respuesta = Console.ReadLine();
            Console.Clear();
            }
            
            
            
        }

        private static void MostrarInforme(Cadeteria? cadeteria)
        {
            if(cadeteria == null) {
                Console.WriteLine($"La cadeteria no puede ser null");
                return;
            }
            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                Console.WriteLine($"Nombre Cadete: {cadete.Nombre}");
                Console.WriteLine($"Cantidad de pedidos: {cadete.PedidosEntregados()}");
                Console.WriteLine($"Total Recaudado: {cadete.TotalGanado()}");
            }
            Console.WriteLine($"El promedio de envios por cadete es: {cadeteria.CantidadEnviosPromedio()}");
            
        }

        private static Cadete? ReasignarPedido(Cadeteria? cadeteria, Pedido? pedido, Cadete? cadeteSeleccionado)
        {
            if (pedido == null)
            {
                Console.WriteLine($"El pedido no puede ser null");
                return null;
            }
            if (cadeteSeleccionado == null) {
                Console.WriteLine($"El cadete no puede ser null");
                return null;
            }
            cadeteSeleccionado.AbandonarPedido(pedido);
            return AsignarPedidoCadete(cadeteria , pedido);
        }

        private static void CambiarEstado(Pedido? pedido)
        {
            // TODO:completar msj del pedido null
            if (pedido == null)
            {
                Console.WriteLine($"El pedido no puede ser null");
                return;
            }
            var respuesta = 0;
            while (respuesta <= 0 || respuesta > 2 )
            {
            Console.WriteLine($"A qué estado desea cambiar el pedido?");
            Console.WriteLine($"1. Rechazado");
            Console.WriteLine($"2. Entregado");
            respuesta = int.TryParse(Console.ReadLine(), out var valor) ? valor : 0;
            }
            if(respuesta == 1) pedido.Rechazar();
            else pedido.Entregar();
        }

        private static Pedido CargarPedido() {
            Console.WriteLine("Generar pedido:");
            Console.WriteLine("Ingrese observacion sobre su pedido");
            var observacion = Console.ReadLine();
            Console.WriteLine("Ingrese su nombre");
            var nombre = Console.ReadLine();
            Console.WriteLine($"Ingrese su direccion");
            var direccion = Console.ReadLine();
            Console.WriteLine($"Ingrese su telefono");
            var telefono = Console.ReadLine();
            Console.WriteLine($"Datos de referencia de su direccion");
            var datosReferenciaDireccion = Console.ReadLine();
            var pedido = new Pedido(observacion, nombre, direccion, telefono, datosReferenciaDireccion);
            return pedido;
        }
        private static Cadete? AsignarPedidoCadete(Cadeteria? cadeteria, Pedido? pedido) {
            if (pedido == null)
            {
                Console.WriteLine($"El pedido no puede ser null");
                return null;
            }
            if(cadeteria == null) {
                Console.WriteLine($"La cadeteria no puede ser null");
                return null;
            }
            var indice = 1;
            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                Console.WriteLine($"{indice}-{cadete.Nombre}");
                indice++;
            }
            var seleccion = 0;
            var total = cadeteria.ListadoCadetes.Count;
            while (seleccion <= 0 || seleccion > total )
            {
            Console.WriteLine($"Que cadete desea asignar al pedido?");
            seleccion = int.TryParse(Console.ReadLine(), out var valor) ? valor : 0;
            }
            var cadetePedido = cadeteria.ListadoCadetes[seleccion-1];
            cadetePedido.TomarPedido(pedido);
            return cadetePedido;
        }
    }
}

// delegado es una referencia a un metodo . representa un metodo, se lo puede usar para asignar o referenciar un metodo. 
// sintaxis de definición. palabra delegate, defino un tipo
// es un tipo de dato, lo que defino es la estructura de un metodo, firma o signature. la firma o signature del metodo es el tipo de retorno, nombre y parámetro
// cuando defino un delegado tengo que definie la firma de un metodo. lo mas importante es el tipo de retorno y los parametros

// delegados ya creados. action es un delegado que representa un metodo que no devuelve nada y no recibe ningun parametro

// varias declaraciones de action. action o action<> -> action<int, int>

// otra declaracion para cuando retorna Func. Func<int> => metodo que no recibe param pero devuelve entero
// Func <string, int> recibe string, devuelvo un entero. al ultimo va el tipo de retorno



















// var pedido1 = new Pedidos(EstadosPedidos.Pendiente, 111111, "No le gusta la cebolla al Sr.");

// pedido1.CambiarEstado();
// pedido1.CambiarEstado();
// pedido1.CambiarEstado();
// pedido1.CambiarEstado();
// pedido1.CambiarEstado();
// pedido1.CambiarEstado();


// System.Console.WriteLine("Fin del programa");
