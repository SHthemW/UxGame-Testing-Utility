using Org.BouncyCastle.Tsp;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UxGame_Testing_Utility.Services
{  
    internal sealed class NetworkService
    {
        private readonly Socket _socket;

        private const int PORT_ID = 35251;
        private const string IP = "127.0.0.1";

        internal NetworkService() 
        {
            // 创建套接字
            _socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        internal async Task ConnectToServer() 
        {          
            // 连接到服务器
            IPEndPoint endPoint = new(IPAddress.Parse(IP), PORT_ID);
            await _socket.ConnectAsync(endPoint);
        }
        internal async Task<string> SendCommand(string command)
        {
            byte[] dataToSend = Encoding.UTF8.GetBytes(command);
            byte[] receivedData = await SendAndReceiveAsync(_socket, dataToSend);

            return Encoding.UTF8.GetString(receivedData, 0, receivedData.Length);

            //return await Task.Run(() => 
            //{
            //    // 发送数据
            //    byte[] buffer = Encoding.UTF8.GetBytes(command);
            //    var sendArgs = new SocketAsyncEventArgs();
            //    sendArgs.SetBuffer(buffer, 0, buffer.Length);
            //    sendArgs.Completed += (s, e) =>
            //    {
            //        // 处理发送操作完成后的逻辑
            //    };

            //    bool isPending = _socket.SendAsync(sendArgs);

            //    // 接收数据
            //    buffer = new byte[1024];
            //    var rcevArgs = new SocketAsyncEventArgs();
            //    rcevArgs.SetBuffer(buffer, 0, buffer.Length);
            //    _socket.ReceiveAsync(rcevArgs);

            //    string receivedMsg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            //    return receivedMsg;
            //});             
        }

        private static Task<byte[]> SendAndReceiveAsync(Socket socket, byte[] dataToSend)
        {
            var sendArgs = new SocketAsyncEventArgs();
            sendArgs.SetBuffer(dataToSend, 0, dataToSend.Length);

            var receiveArgs = new SocketAsyncEventArgs();
            var receiveBuffer = new byte[1024];
            receiveArgs.SetBuffer(receiveBuffer, 0, receiveBuffer.Length);

            var tcs = new TaskCompletionSource<byte[]>();

            sendArgs.Completed += (s, e) =>
            {
                if (e.SocketError == SocketError.Success)
                {
                    // 发送成功，开始接收数据
                    bool isReceivePending = socket.ReceiveAsync(receiveArgs);
                    if (!isReceivePending)
                    {
                        // 如果接收操作已同步完成，立即处理接收操作完成后的逻辑
                        ProcessReceive(receiveArgs, tcs);
                    }
                }
                else
                {
                    // 发送失败，设置任务的异常
                    tcs.SetException(new SocketException((int)e.SocketError));
                }
            };

            receiveArgs.Completed += (s, e) =>
            {
                ProcessReceive(e, tcs);
            };

            bool isSendPending = socket.SendAsync(sendArgs);
            if (!isSendPending)
            {
                // 如果发送操作已同步完成，立即开始接收数据
                bool isReceivePending = socket.ReceiveAsync(receiveArgs);
                if (!isReceivePending)
                {
                    // 如果接收操作已同步完成，立即处理接收操作完成后的逻辑
                    ProcessReceive(receiveArgs, tcs);
                }
            }

            return tcs.Task;
        }
        private static void ProcessReceive(SocketAsyncEventArgs e, TaskCompletionSource<byte[]> tcs)
        {
            if (e.SocketError == SocketError.Success)
            {
                // 接收成功，设置任务的结果
                byte[] result = new byte[e.BytesTransferred];
                Array.Copy(e.Buffer!, e.Offset, result, 0, e.BytesTransferred);
                tcs.SetResult(result);
            }
            else
            {
                // 接收失败，设置任务的异常
                tcs.SetException(new SocketException((int)e.SocketError));
            }
        }

        ~NetworkService()
        {
            // 关闭套接字
            _socket.Close();
        }
    }

    internal readonly struct ClientCmd
    {
        internal const string CONV_EXCEL_TO_JSON = "ConvertExcelToJson";
        internal const string CONV_JSON_TO_BIN = "ConvertJsonToBin";
    }

}
