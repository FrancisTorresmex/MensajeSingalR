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
        //en este caso no se usara mas que solo para depurar (osea la conexión)
        public override Task OnConnectedAsync()
        {
            Debug.WriteLine("Servidor SignalR conectado");
            return base.OnConnectedAsync();
        }

        

        //Metodo para deconectar dispositivo (este desconceta un dispositivo)
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //Ver si el diccionario aún contiene la id que asigno signalR al dispositivo
            int? deviceId = connectionDevices.ContainsKey(Context.ConnectionId) ?
                            (int?)connectionDevices[Context.ConnectionId] : null;

            if (deviceId.HasValue) //si es lo contrario de null (true)
            {
                deviceConnections.Remove(deviceId.Value);
                connectionDevices.Remove(Context.ConnectionId);
            }

            Debug.WriteLine($"Desconcetado del server SignalR. Dispositivo: {deviceId}.");
            await base.OnDisconnectedAsync(exception);
        }


        //Nombre del metodo al que tiene que llamar la parte cliente
        [HubMethodName("Init")]
        public Task Init(DeviceInfo info) //y este es el metodo que llama HubMethodName (este asigna las Id)
        {
            //Se añade el mapeo del identificador en los diccionarios (Context.ConnectionId sirve para que SignalR le asigne un identificador y ese identificador se usa en conjunto con el id que nosotros le asignamos)
            deviceConnections.Add(info.Id, Context.ConnectionId);
            connectionDevices.Add(Context.ConnectionId, info.Id);

            return Task.CompletedTask;
        }


        //Metodo que envia mensaje a todos
        [HubMethodName("SendMessageToAll")]
        public async Task SendMessageToAll(MessageItem item)
        {
            await Clients.All.SendAsync("NuevoMensaje", item); //SendAsync requiere de parametro el nombre del metodo en "" y el objeto a enviar
        }


        //Enviar mensaje a un dispositivo
        [HubMethodName("SendMessageToDevice")]
        public async Task SendMessageToDevice (MessageItem item)
        {
            Debug.WriteLine($"El servidor de SignalR envio el mensaje {item.Message} de {item.SourceId} a {item.TargetId}");

            //Si en los diccionarios existe el identificador del dispositivo al que se quiere enviar el mensaje, se envia
            if (deviceConnections.ContainsKey(item.TargetId)) 
                await Clients.Client(deviceConnections[item.TargetId]).SendAsync("NuevoMensaje", item);
        }
    }
}
