using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace APIMensajeSingalR.SignalR
{
    public class TestHub : Hub
    {

        /*
         Diccionarios con los que se controla los identificadores conectados
         un dispositivo al conectarse al hub de signalR se le da un identificador (string)
         y nosotros le asignamos un identificador (int) al dispositivo al que le llegara el mensaje 
        */
        
        private static Dictionary<int, string> deviceConnections;
        private static Dictionary<string, int> connectionDevices;

        public TestHub()
        {
            deviceConnections = deviceConnections ?? new Dictionary<int, string>();
            connectionDevices = connectionDevices ?? new Dictionary<string, int>();
        }

        //Este metodo se activa cuando un dispositovo nuevo se a conectado,
        //en este caso no se usara mas que solo para depurar
        public override Task OnConnectedAsync()
        {
            Debug.WriteLine("Servidor SignalR conectado");
            return base.OnConnectedAsync();
        }
    }
}
