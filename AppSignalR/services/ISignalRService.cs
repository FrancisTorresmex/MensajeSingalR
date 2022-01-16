using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSignalR.services
{
    public interface ISignalRService
    {
        //Eventos
        event EventHandler<MessageItem> MessageItemReceived; //Salta cuando se recibe un mensaje
        event EventHandler Connecting; //Salta cuando se intenta conectar un dispositivo a SignalR
        event EventHandler Connected; //Salta cuando ya se conecto el dispositvo

        //Metodos
        void StartWithReconnectionAsync(); //Concectarme al servidor APIMensajeSignalR (llamar al metodo Init del api)
        Task SendMessageToAll(MessageItem item); //Enviar mensaje a todos
        Task SendMessageToDevice(MessageItem item); //Enviar mensaje a un dispositivo
        Task StopAsync(); //Desconexión
    }
}
