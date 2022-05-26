using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XjoyKeymapGenerator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> _jcKeyDict;
        private Dictionary<string, string> _xboxKeyDict;

        public MainWindow()
        {
            InitializeComponent();

            InitKeyAssets();
        }

        private void InitKeyAssets()
        {
            _jcKeyDict = new Dictionary<string, string>();
            _jcKeyDict["L_DPAD_LEFT"] = "(L) Left";
            _jcKeyDict["L_DPAD_DOWN"] = "(L) Down";
            _jcKeyDict["L_DPAD_UP"] = "(L) Up";
            _jcKeyDict["L_DPAD_RIGHT"] = "(L) Right";
            _jcKeyDict["L_DPAD_SL"] = "(L) SL";
            _jcKeyDict["L_DPAD_SR"] = "(L) SR";
            _jcKeyDict["L_SHOULDER"] = "(L) L";
            _jcKeyDict["L_TRIGGER"] = "(L) ZL";
            _jcKeyDict["L_CAPTURE"] = "(L) Capture";
            _jcKeyDict["L_MINUS"] = "(L) Minus";
            _jcKeyDict["L_STICK"] = "(L) Stick";

            _jcKeyDict["R_BUT_A"] = "(R) A";
            _jcKeyDict["R_BUT_B"] = "(R) B";
            _jcKeyDict["R_BUT_X"] = "(R) X";
            _jcKeyDict["R_BUT_Y"] = "(R) Y";
            _jcKeyDict["R_BUT_SL"] = "(R) SL";
            _jcKeyDict["R_BUT_SR"] = "(R) SR";
            _jcKeyDict["R_SHOULDER"] = "(R) R";
            _jcKeyDict["R_TRIGGER"] = "(R) ZR";
            _jcKeyDict["R_HOME"] = "(R) Home";
            _jcKeyDict["R_PLUS"] = "(R) Plus";
            _jcKeyDict["R_STICK"] = "(R) Stick";

            _xboxKeyDict = new Dictionary<string, string>();
            _xboxKeyDict["DISABLE"] = "DISABLE";
            _xboxKeyDict["XUSB_GAMEPAD_DPAD_LEFT"] = "Left";
            _xboxKeyDict["XUSB_GAMEPAD_DPAD_DOWN"] = "Down";
            _xboxKeyDict["XUSB_GAMEPAD_DPAD_UP"] = "Up";
            _xboxKeyDict["XUSB_GAMEPAD_DPAD_RIGHT"] = "Right";
            _xboxKeyDict["XUSB_GAMEPAD_A"] = "A";
            _xboxKeyDict["XUSB_GAMEPAD_B"] = "B";
            _xboxKeyDict["XUSB_GAMEPAD_X"] = "X";
            _xboxKeyDict["XUSB_GAMEPAD_Y"] = "Y";
            _xboxKeyDict["XUSB_GAMEPAD_LEFT_SHOULDER"] = "LB";
            _xboxKeyDict["XUSB_GAMEPAD_RIGHT_SHOULDER"] = "RB";
            _xboxKeyDict["XUSB_GAMEPAD_LEFT_TRIGGER"] = "LT";
            _xboxKeyDict["XUSB_GAMEPAD_RIGHT_TRIGGER"] = "RT";
            _xboxKeyDict["XUSB_GAMEPAD_LEFT_THUMB"] = "LS";
            _xboxKeyDict["XUSB_GAMEPAD_RIGHT_THUMB"] = "RS";
            _xboxKeyDict["XUSB_GAMEPAD_BACK"] = "Back";
            _xboxKeyDict["XUSB_GAMEPAD_START"] = "Start";
            _xboxKeyDict["XUSB_GAMEPAD_GUIDE"] = "Logo";
        }
    }
}
