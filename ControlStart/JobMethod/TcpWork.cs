using ControlStart.Config;
using ControlStart.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ControlStart.JobMethod
{
    public class TcpWork
    {
        internal static string ABCamOrder = "";
        internal static string CDCamOrder = "";
        internal static string DownCamOrder = "";
        internal static string 上料CamOrder = "";


        #region ABCam TCP
        internal static void TCPSocketServer_SocketReceiveMessage1(Socket client, string clientSocketIp, string message)
        {
            Global.Instance.TCPLog.WriteRunLog("ABCam TCP Sever," + clientSocketIp + "," + message);
            string[] orderset = message.Split('$');
            for (int i = 0; i < orderset.Length - 1; i++)
            {
                if (orderset[i].StartsWith("#") && orderset[i].EndsWith("$"))
                {
                    ABCamOrder = orderset[i];
                    Cameras.Instance["ABCam"].Soft_Trigger();
                    Global.Instance.RunningLog.WriteRunLog("ABCam执行拍照指令");
                    while (ABCamOrder != "") { }
                }
                else
                {
                    Global.Instance.TCPLog.WriteErrorLog("收到不合法指令:" + orderset[i]);
                }
            }
        }

        internal static void TCPSocketServer_ClientsConnect1(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("ABCam TCP Sever," + clients.LocalEndPoint + "进入");
        }

        internal static void TCPSocketServer_ClientsLoss1(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("ABCam TCP Sever," + clients.LocalEndPoint + "掉线");
        }
        #endregion


        #region CDCam TCP
        internal static void TCPSocketServer_SocketReceiveMessage2(Socket client, string clientSocketIp, string message)
        {
            Global.Instance.TCPLog.WriteRunLog("CDCam TCP Sever," + clientSocketIp + "," + message);

        }

        internal static void TCPSocketServer_ClientsConnect2(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("CDCam TCP Sever," + clients.LocalEndPoint + "进入");
        }

        internal static void TCPSocketServer_ClientsLoss2(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("CDCam TCP Sever," + clients.LocalEndPoint + "掉线");

        }
        #endregion


        #region DownCam TCP

        internal static void TCPSocketServer_SocketReceiveMessage3(Socket client, string clientSocketIp, string message)
        {
            Global.Instance.TCPLog.WriteRunLog("Down TCP Sever," + clientSocketIp + "," + message);

        }

        internal static void TCPSocketServer_ClientsConnect3(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("Down TCP Sever," + clients.LocalEndPoint + "进入");
        }

        internal static void TCPSocketServer_ClientsLoss3(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("Down TCP Sever," + clients.LocalEndPoint + "掉线");

        }
        #endregion


        #region 上料相机 TCP
        internal static void TCPSocketServer_SocketReceiveMessage4(Socket client, string clientSocketIp, string message)
        {
            Global.Instance.TCPLog.WriteRunLog("上料相机 TCP Sever," + clientSocketIp + "," + message);

        }

        internal static void TCPSocketServer_ClientsConnect4(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("上料相机 TCP Sever," + clients.LocalEndPoint + "进入");
        }

        internal static void TCPSocketServer_ClientsLoss4(Socket clients)
        {
            Global.Instance.TCPLog.WriteRunLog("上料相机 TCP Sever," + clients.LocalEndPoint + "掉线");

        }
        #endregion

    }
}
