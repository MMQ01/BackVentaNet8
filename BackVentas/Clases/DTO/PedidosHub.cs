using Microsoft.AspNetCore.SignalR;

namespace BackVentasADO.Models.Clases.DTO
{
    public class PedidosHub : Hub
    {
        public async Task SendAllOrders(PedidoDTO pedido)
        {
            await Clients.All.SendAsync("ReceiveAllOrders", pedido);
        }
    }
}