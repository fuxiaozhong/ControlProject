using ControlStart.ControlForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStart.Config
{
    public class GlobalMethod
    {

        public static Control control;

        public static object GetGlobalSystemValue(string name)
        {
            return ((Form_Tool)control).GetSystemValue(name);
        }

        public static object GetGlobalUserValue(string name)
        {
            return ((Form_Tool)control).GetUserValue(name);
        }



    }
}
