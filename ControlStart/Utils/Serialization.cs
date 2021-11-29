using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ControlStart.Utils
{
    /// <summary>
    /// 序列化
    /// </summary>
    public class Serialization
    {

        /// <summary>
        /// 序列化保存对象
        /// </summary>
        /// <param name="obj">要保存的对象</param>
        /// <param name="path">要保存的路径</param>
        public static void Save2(object obj, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            try
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                bFormat.Serialize(stream, obj);
                stream.Close();
            }
            catch (Exception)
            {
                stream.Close();
            }

        }

        /// <summary>
        /// 序列化保存对象
        /// </summary>
        /// <param name="obj">要保存的对象</param>
        /// <param name="name">要保存的文件名(默认路径)</param>
        public static void Save(object obj, string name)
        {
            if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Config"))
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Vision_Config");
            FileStream stream = new FileStream(System.Windows.Forms.Application.StartupPath + "\\Vision_Config\\" + name + ".bin", FileMode.Create);
            try
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                bFormat.Serialize(stream, obj);
                stream.Close();
            }
            catch (Exception)
            {
                stream.Close();
            }

        }


        /// <summary>
        /// 读取序列化保存的对象
        /// </summary>
        /// <param name="name">(默认路径)要读取的文件名</param>
        /// <returns></returns>
        public static object Read(string name)
        {
            if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Config"))
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Vision_Config");
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Config\\" + name + ".bin"))
            {
                FileStream stream = new FileStream(System.Windows.Forms.Application.StartupPath + "\\Vision_Config\\" + name + ".bin", FileMode.Open);
                try
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    object obj = bFormat.Deserialize(stream);
                    stream.Close();
                    return obj;
                }
                catch (Exception)
                {
                    stream.Close();
                }

            }
            return null;
        }




        /// <summary>
        /// 读取序列化保存的对象
        /// </summary>
        /// <param name="path">要读取的文件路径</param>
        /// <returns></returns>
        public static object Read2(string path)
        {
            if (File.Exists(path))
            {
                FileStream stream = new FileStream(path, FileMode.Open);
                try
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    object obj = bFormat.Deserialize(stream);
                    stream.Close();
                    return obj;
                }
                catch (Exception)
                {
                    stream.Close();
                }
            }
            return null;
        }


    }
}
