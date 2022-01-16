namespace APIMensajeSingalR.SignalR
{
    public class MessageItem
    {
        public string Message { get; set; }
        public int SourceId { get; set; } //Id dispositivo que envia el mensaje

        public int TargetId { get; set; } //Id dispostivo al que se enviara el mensaje
    }
}
