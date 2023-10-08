﻿﻿using PedidosYa;
using System;

namespace PedidosYa
{
    internal class Program
    {
        const string ArchivoCadeteria = "cadeteria";
        const string ArchivoCadetes = "listaCadetes"; 
        static void Main(string[] args)
        {
            var archivoElegido = 0;
            
            while (archivoElegido <= 0 || archivoElegido > 2) {
                Console.WriteLine($"Qué extensión de archivo desea usar? 1. CSV 2. JSON");
                archivoElegido = int.TryParse(Console.ReadLine(), out var valor) ? valor : 0;  
            }
            AccesoADatos repositorio;
            if (archivoElegido == 1) {
                repositorio = new AccesoCSV(ArchivoCadeteria, ArchivoCadetes);
            } else {
                repositorio = new AccesoJSON(ArchivoCadeteria, ArchivoCadetes);
            }
            var respuesta = "s";
            while (respuesta != "n") {
            Console.WriteLine("a. Dar de alta un pedido");
            Console.WriteLine("b. Asignar pedido a cadete");
            Console.WriteLine("c. Cambiar estado de un pedido");
            Console.WriteLine("d. Reasignar pedido a un cadete");
            Console.WriteLine("e. Mostrar jornal por cadete");
            respuesta = Console.ReadLine();
            switch (respuesta)
            {
                case "a":
                    CargarPedido(repositorio.Cadeteria);
                    break;
                case "b":
                    AsignarPedidoCadete(repositorio.Cadeteria);
                    break;
                case "c":
                    CambiarEstado(repositorio.Cadeteria);
                    break;
                case "d":
                    ReasignarPedidoCadete(repositorio.Cadeteria);
                    break;
                case "e":
                    MostrarJornalPorCadete(repositorio.Cadeteria);
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
        private static void CambiarEstado(Cadeteria? cadeteria)
        {
            if (cadeteria == null)
            {
                Console.WriteLine($"La cadeteria no puede ser null");
                return;
            }
            var indice = 1;
            foreach (var pedido in cadeteria.ListadoPedidos)
            {
                Console.WriteLine($"{indice}-{pedido.NumeroPedido}-{pedido.ObservacionPedido}");
                indice++;
            }
            var seleccion = 0;
            var totalPedidos = cadeteria.ListadoPedidos.Count();
            while (seleccion <= 0 || seleccion > totalPedidos)
            {
                Console.WriteLine($"Seleccione un pedido para cambiar su estado");
                seleccion = int.TryParse(Console.ReadLine(), out var valor) ? valor : 0;
            }
            var pedidoSeleccionado =  cadeteria.ListadoPedidos[seleccion - 1];
            var respuesta = 0;
            while (respuesta <= 0 || respuesta > 2 )
            {
            Console.WriteLine($"A qué estado desea cambiar el pedido?");
            Console.WriteLine($"1. Rechazado");
            Console.WriteLine($"2. Entregado");
            respuesta = int.TryParse(Console.ReadLine(), out var valor) ? valor : 0;
            }
            if(respuesta == 1) pedidoSeleccionado.Rechazar();
            else pedidoSeleccionado.Entregar();
        }

        private static void CargarPedido(Cadeteria? cadeteria) {
            if(cadeteria == null) {
                Console.WriteLine($"La cadeteria no puede ser null");
                return;
            }
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
            cadeteria.AgregarPedido(observacion, nombre, direccion, telefono, datosReferenciaDireccion);
        }

        private static void AsignarPedidoCadete(Cadeteria? cadeteria) {
            if(cadeteria == null) {
                Console.WriteLine($"La cadeteria no puede ser null");
                return;
            }
            var pedido = ListarPedidosPendientes(cadeteria);
            var cadete = ListarCadetes(cadeteria.ListadoCadetes);
            cadeteria.AsignarCadeteAPedido(cadete.Id, pedido.NumeroPedido);
        }
    
        private static Pedido ListarPedidosPendientes(Cadeteria cadeteria) {
            var pedidosPendientes = cadeteria.PedidosPendientes().ToList();
            var indice = 1;
            foreach (var pedido in pedidosPendientes)
            {
                Console.WriteLine($"{indice}-{pedido.NumeroPedido}");
                indice++;
            }
            var seleccion = 0;
            var total = pedidosPendientes.Count();
            while (seleccion <= 0 || seleccion > total) {
                Console.WriteLine($"Seleccione uno de los siguientes pedidos");
                seleccion = int.TryParse(Console.ReadLine(), out var valor) ? valor : 0;
            }
            var pedidoSeleccionado =  pedidosPendientes[seleccion - 1];
            return pedidoSeleccionado;
        }
        
        private static Cadete ListarCadetes(List<Cadete> listaCadetes) {
            var indice = 1;
            foreach (var cadete in listaCadetes)
            {
                Console.WriteLine($"{indice}-{cadete.Nombre}");
                indice++;
            }
            var seleccion = 0;
            var total = listaCadetes.Count;
            while (seleccion <= 0 || seleccion > total )
            {
            Console.WriteLine($"Que cadete desea asignar al pedido?");
            seleccion = int.TryParse(Console.ReadLine(), out var valor) ? valor : 0;
            }
            var cadetePedido = listaCadetes[seleccion - 1];
            return cadetePedido;
        }
        private static void ReasignarPedidoCadete(Cadeteria? cadeteria) {
            // listar pedidos asignados
            if(cadeteria == null) {
                Console.WriteLine($"La cadeteria no puede ser null");
                return;
            }
            var pedidosAsignados = cadeteria.PedidosAsignados().ToList();
            // elegir pedido
            var indice = 1;
            foreach (var pedido in pedidosAsignados)
            {
                Console.WriteLine($"{indice}-{pedido.NumeroPedido}");
                indice++;
            }
            var seleccion = 0;
            var total = pedidosAsignados.Count();
            while (seleccion <= 0 || seleccion > total) {
                Console.WriteLine($"Seleccione uno de los siguientes pedidos");
                seleccion = int.TryParse(Console.ReadLine(), out var valor) ? valor : 0;
            }
            var pedidoSeleccionado =  pedidosAsignados[seleccion - 1];
            // listar cadetes - cadete que estaba. con un where que cadete != que cadete tenia el id
            if (pedidoSeleccionado.Cadete == null) return;
            var listaSinCadeteAsignado = cadeteria.ListadoCadetes.Where(c => c.Id != pedidoSeleccionado.Cadete.Id);
            
            // listar cadetes para elegir
            var cadeteSeleccionado = ListarCadetes(listaSinCadeteAsignado.ToList());
            cadeteria.AsignarCadeteAPedido(cadeteSeleccionado.Id, pedidoSeleccionado.NumeroPedido);
        }

        private static void MostrarJornalPorCadete(Cadeteria? cadeteria) {
            if(cadeteria == null) {
                Console.WriteLine($"La cadeteria no puede ser null");
                return;
            }
            var cadete = ListarCadetes(cadeteria.ListadoCadetes);
            var totalACobrar = cadeteria.JornalACobrar(cadete.Id);
            Console.WriteLine($"El cadete {cadete.Id}-{cadete.Nombre} debe cobrar ${totalACobrar}");
        }
    }
}
