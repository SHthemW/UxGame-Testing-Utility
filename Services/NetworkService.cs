using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UxGame_Testing_Utility.Services
{  
    internal sealed class NetworkService
    {
        private const int PORT_ID = 35251;
        private const string IP = "127.0.0.1";

        internal static void SendCommand(string command, out string outmsg)
        {
            // 创建套接字
            Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 连接到服务器
            IPEndPoint endPoint = new(IPAddress.Parse(IP), PORT_ID);
            socket.Connect(endPoint);

            // 发送数据
            byte[] buffer = Encoding.UTF8.GetBytes(command);
            socket.Send(buffer);

            // 接收数据
            buffer = new byte[1024];
            int received = socket.Receive(buffer);
            string receivedMsg = Encoding.UTF8.GetString(buffer, 0, received);
            outmsg = receivedMsg;

            // 关闭套接字
            socket.Close();
        }
    }

    internal readonly struct ClientCmd
    {
        internal const string CONV_EXCEL_TO_JSON = "ConvertExcelToJson";
        internal const string CONV_JSON_TO_BIN = "ConvertJsonToBin";
    }

}
