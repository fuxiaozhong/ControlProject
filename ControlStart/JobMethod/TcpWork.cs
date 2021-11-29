using ControlStart.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ControlStart.JobMethod
{
    public class TcpWork
    {
        #region CAM1 TCP
        internal static void TCPSocketServer_SocketReceiveMessage1(Socket client, string clientSocketIp, string message)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam1 TCP Sever," + clientSocketIp + "," + message);

        }

        internal static void TCPSocketServer_ClientsConnect1(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam1 TCP Sever," + clients.LocalEndPoint + "进入");
        }

        internal static void TCPSocketServer_ClientsLoss1(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam1 TCP Sever," + clients.LocalEndPoint + "掉线");
        }
        #endregion


        #region CAM2 TCP
        internal static void TCPSocketServer_SocketReceiveMessage2(Socket client, string clientSocketIp, string message)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam2 TCP Sever," + clientSocketIp + "," + message);

        }

        internal static void TCPSocketServer_ClientsConnect2(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam2 TCP Sever," + clients.LocalEndPoint + "进入");
        }

        internal static void TCPSocketServer_ClientsLoss2(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam2 TCP Sever," + clients.LocalEndPoint + "掉线");

        }
        #endregion


        #region CAM3 TCP

        internal static void TCPSocketServer_SocketReceiveMessage3(Socket client, string clientSocketIp, string message)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam3 TCP Sever," + clientSocketIp + "," + message);

        }

        internal static void TCPSocketServer_ClientsConnect3(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam3 TCP Sever," + clients.LocalEndPoint + "进入");
        }

        internal static void TCPSocketServer_ClientsLoss3(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam3 TCP Sever," + clients.LocalEndPoint + "掉线");

        }
        #endregion


        #region CAM4 TCP
        internal static void TCPSocketServer_SocketReceiveMessage4(Socket client, string clientSocketIp, string message)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam4 TCP Sever," + clientSocketIp + "," + message);

        }

        internal static void TCPSocketServer_ClientsConnect4(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam4 TCP Sever," + clients.LocalEndPoint + "进入");
        }

        internal static void TCPSocketServer_ClientsLoss4(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("Cam4 TCP Sever," + clients.LocalEndPoint + "掉线");

        }
        #endregion

    }
}
