using System;
using System.Collections.Generic;
using System.IO;
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
        public MainWindow()
        {
            InitKeyAssets();

            InitializeComponent();
            this.DataContext = this;
        }

        public List<KeyValuePair<string, string>> JcKeyDictList { get; set; }
        public List<KeyValuePair<string, string>> XboxKeyDictList { get; set; }
        public List<JcButtonSetting> ButtonSettings { get; set; }

        private void InitKeyAssets()
        {
            var jcKeyDict = new Dictionary<string, string>();
            jcKeyDict["L_DPAD_LEFT"] = "(L) Left";
            jcKeyDict["L_DPAD_DOWN"] = "(L) Down";
            jcKeyDict["L_DPAD_UP"] = "(L) Up";
            jcKeyDict["L_DPAD_RIGHT"] = "(L) Right";
            jcKeyDict["L_DPAD_SL"] = "(L) SL";
            jcKeyDict["L_DPAD_SR"] = "(L) SR";
            jcKeyDict["L_SHOULDER"] = "(L) L";
            jcKeyDict["L_TRIGGER"] = "(L) ZL";
            jcKeyDict["L_CAPTURE"] = "(L) Capture";
            jcKeyDict["L_MINUS"] = "(L) Minus";
            jcKeyDict["L_STICK"] = "(L) Stick";
            jcKeyDict["R_BUT_A"] = "(R) A";
            jcKeyDict["R_BUT_B"] = "(R) B";
            jcKeyDict["R_BUT_X"] = "(R) X";
            jcKeyDict["R_BUT_Y"] = "(R) Y";
            jcKeyDict["R_BUT_SL"] = "(R) SL";
            jcKeyDict["R_BUT_SR"] = "(R) SR";
            jcKeyDict["R_SHOULDER"] = "(R) R";
            jcKeyDict["R_TRIGGER"] = "(R) ZR";
            jcKeyDict["R_HOME"] = "(R) Home";
            jcKeyDict["R_PLUS"] = "(R) Plus";
            jcKeyDict["R_STICK"] = "(R) Stick";
            JcKeyDictList=jcKeyDict.ToList();

            var xboxKeyDict = new Dictionary<string, string>();
            xboxKeyDict["DISABLE"] = "DISABLE";
            xboxKeyDict["XUSB_GAMEPAD_DPAD_LEFT"] = "Left";
            xboxKeyDict["XUSB_GAMEPAD_DPAD_DOWN"] = "Down";
            xboxKeyDict["XUSB_GAMEPAD_DPAD_UP"] = "Up";
            xboxKeyDict["XUSB_GAMEPAD_DPAD_RIGHT"] = "Right";
            xboxKeyDict["XUSB_GAMEPAD_A"] = "A";
            xboxKeyDict["XUSB_GAMEPAD_B"] = "B";
            xboxKeyDict["XUSB_GAMEPAD_X"] = "X";
            xboxKeyDict["XUSB_GAMEPAD_Y"] = "Y";
            xboxKeyDict["XUSB_GAMEPAD_LEFT_SHOULDER"] = "LB";
            xboxKeyDict["XUSB_GAMEPAD_RIGHT_SHOULDER"] = "RB";
            xboxKeyDict["XUSB_GAMEPAD_LEFT_TRIGGER"] = "LT";
            xboxKeyDict["XUSB_GAMEPAD_RIGHT_TRIGGER"] = "RT";
            xboxKeyDict["XUSB_GAMEPAD_LEFT_THUMB"] = "LS";
            xboxKeyDict["XUSB_GAMEPAD_RIGHT_THUMB"] = "RS";
            xboxKeyDict["XUSB_GAMEPAD_BACK"] = "Back";
            xboxKeyDict["XUSB_GAMEPAD_START"] = "Start";
            xboxKeyDict["XUSB_GAMEPAD_GUIDE"] = "Logo";
            XboxKeyDictList = xboxKeyDict.ToList();
            this.Resources.Add("XboxKeyDictList", XboxKeyDictList);

            ButtonSettings = new List<JcButtonSetting>(new[]
            {
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_DPAD_LEFT"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_DPAD_LEFT")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_DPAD_DOWN"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_DPAD_DOWN")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_DPAD_UP"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_DPAD_UP")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_DPAD_RIGHT"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_DPAD_RIGHT")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_DPAD_SL"), GetKvp(XboxKeyDictList, "DISABLE")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_DPAD_SR"), GetKvp(XboxKeyDictList, "DISABLE")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_SHOULDER"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_LEFT_SHOULDER")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_TRIGGER"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_LEFT_TRIGGER")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_CAPTURE"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_BACK")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_MINUS"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_BACK")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "L_STICK"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_LEFT_THUMB")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_BUT_A"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_B")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_BUT_B"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_A")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_BUT_X"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_Y")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_BUT_Y"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_X")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_BUT_SL"), GetKvp(XboxKeyDictList, "DISABLE")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_BUT_SR"), GetKvp(XboxKeyDictList, "DISABLE")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_SHOULDER"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_RIGHT_SHOULDER")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_TRIGGER"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_RIGHT_TRIGGER")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_HOME"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_START")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_PLUS"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_START")),
                new JcButtonSetting(GetKvp(JcKeyDictList, "R_STICK"), GetKvp(XboxKeyDictList, "XUSB_GAMEPAD_RIGHT_THUMB")),
            });
        }

        private KeyValuePair<string, string> GetKvp(IEnumerable<KeyValuePair<string, string>> dict, string key)
        {
            return dict.First(d => d.Key == key);
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
