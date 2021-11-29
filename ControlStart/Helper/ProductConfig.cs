using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HalconDotNet;
using ToolKit.HalconTool.Model;

namespace ControlStart.Helper
{
    [Serializable]
    public class ProductConfig
    {
        //产品图片
        public HObject ProductImage;
        //创建时间
        public DateTime CreateTime;
        //产品名称
        public string ProductName = "";
        public ModelParameter ABCam_Left_Model = new ModelParameter();
        public ModelParameter ABCam_Right_Model = new ModelParameter();
        public ModelParameter CDCam_Left_Model = new ModelParameter();
        public ModelParameter CDCam_Right_Model = new ModelParameter();
        public ModelParameter DownCam_Left_Model = new ModelParameter();
        public ModelParameter DownCam_Right_Model = new ModelParameter();
        //银浆位置
        public HObject ABCam_Left_SilverPaste_Location;
        //银浆范围
        public HObject ABCam_Left_SilverPaste_Scope;
        //屏幕上的银浆范围
        public HObject ABCam_Left_SilverPaste_ScreenScope;

        //银浆位置
        public HObject ABCam_Right_SilverPaste_Location;
        //银浆范围
        public HObject ABCam_Right_SilverPaste_Scope;
        //屏幕上的银浆范围
        public HObject ABCam_Right_SilverPaste_ScreenScope;



        //银浆位置
        public HObject CDCam_Left_SilverPaste_Location;
        //银浆范围
        public HObject CDCam_Left_SilverPaste_Scope;
        //屏幕上的银浆范围
        public HObject CDCam_Left_SilverPaste_ScreenScope;

        //银浆位置
        public HObject CDCam_Right_SilverPaste_Location;
        //银浆范围
        public HObject CDCam_Right_SilverPaste_Scope;
        //屏幕上的银浆范围
        public HObject CDCam_Right_SilverPaste_ScreenScope;



        //银浆位置
        public HObject DownCam_Left_SilverPaste_Location;
        //银浆范围
        public HObject DownCam_Left_SilverPaste_Scope;
        //屏幕上的银浆范围
        public HObject DownCam_Left_SilverPaste_ScreenScope;

        //银浆位置
        public HObject DownCam_Right_SilverPaste_Location;
        //银浆范围
        public HObject DownCam_Right_SilverPaste_Scope;
        //屏幕上的银浆范围
        public HObject DownCam_Right_SilverPaste_ScreenScope;

        public bool Check_SilverPaste = false;


    }
}
