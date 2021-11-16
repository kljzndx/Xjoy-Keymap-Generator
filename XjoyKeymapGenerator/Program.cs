using ConsoleTables;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XjoyKeymapGenerator
{
    enum JoyconKey
    {
        L_DPAD_LEFT,
        L_DPAD_DOWN,
        L_DPAD_UP,
        L_DPAD_RIGHT,
        L_DPAD_SL,
        L_DPAD_SR,
        L_SHOULDER,
        L_TRIGGER,
        L_CAPTURE,
        L_MINUS,
        L_STICK,
        R_BUT_A,
        R_BUT_B,
        R_BUT_X,
        R_BUT_Y,
        R_BUT_SL,
        R_BUT_SR,
        R_SHOULDER,
        R_TRIGGER,
        R_HOME,
        R_PLUS,
        R_STICK,
    }

    enum XboxKey
    {
        DISABLE,
        XUSB_GAMEPAD_DPAD_LEFT,
        XUSB_GAMEPAD_DPAD_DOWN,
        XUSB_GAMEPAD_DPAD_UP,
        XUSB_GAMEPAD_DPAD_RIGHT,
        XUSB_GAMEPAD_A,
        XUSB_GAMEPAD_B,
        XUSB_GAMEPAD_X,
        XUSB_GAMEPAD_Y,
        XUSB_GAMEPAD_LEFT_SHOULDER,
        XUSB_GAMEPAD_RIGHT_SHOULDER,
        XUSB_GAMEPAD_LEFT_TRIGGER,
        XUSB_GAMEPAD_RIGHT_TRIGGER,
        XUSB_GAMEPAD_LEFT_THUMB,
        XUSB_GAMEPAD_RIGHT_THUMB,
        XUSB_GAMEPAD_BACK,
        XUSB_GAMEPAD_START,
        XUSB_GAMEPAD_GUIDE,
    }

    enum JoyconButton
    {
        SL_on_left_joycon = 4,
        SR_on_left_joycon = 5,
        L = 6,
        ZL = 7,
        Analog_button_on_left_joycon = 10,
        SL_on_right_joycon = 15,
        SR_on_right_joycon = 16,
        R = 17,
        ZR = 18,
        Analog_button_on_right_joycon = 21,
    }

    enum XboxButton
    {
        LB = 9,
        RB = 10,
        LT = 11,
        RT = 12,
        Left_analog_button = 13,
        Right_analog_button = 14,
        Xbox_logo_button = 17,
    }

    internal class Program
    {
        static Dictionary<JoyconKey, XboxKey> _keymaps = new Dictionary<JoyconKey, XboxKey>();
        static Dictionary<int, JoyconButton> _jcBtnMaps = new Dictionary<int, JoyconButton>();
        static Dictionary<int, XboxButton> _xboxBtnMaps = new Dictionary<int, XboxButton>();

        static void Main(string[] args)
        {
            Console.WriteLine("XJoy keymap file generator v1.1");
            Console.WriteLine("Made by kljzndx");
            Console.WriteLine();

            InitKeymap();
            InitButtonMaps();

            while (true)
            {
                List<string> mapLines = _keymaps.Select(p => $"{p.Key}: {p.Value}").ToList();
                OutputResult(mapLines);

                Console.WriteLine("1   Help");
                Console.WriteLine("2   Edit");
                Console.WriteLine("3   Save");
                Console.Write("Which command do you want to execute (1 ~ 3): ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    OutputJoyconButtonNames();
                    OutputXboxButtonNames();

                    Console.Write("Press enter to exit");
                    Console.ReadLine();
                    continue;
                }

                if (input == "2")
                {
                    Console.Write("Which line do you want to edit (1 ~ 22): ");
                    input = Console.ReadLine();
                    int jcId;

                    if (int.TryParse(input, out jcId)) jcId -= 1;
                    else continue;

                    OutputXboxKeys();
                    Console.Write("Which button do you want to set (1 ~ 18): ");
                    input = Console.ReadLine();
                    int xboxId;

                    if (int.TryParse(input, out xboxId)) xboxId -= 1;
                    else continue;

                    if (jcId > 0 && jcId < 22 && xboxId > 0 && xboxId < 18)
                        _keymaps[(JoyconKey)jcId] = (XboxKey)xboxId;

                    continue;
                }

                if (input == "3")
                {
                    SaveFile(mapLines);
                    Console.ReadLine();
                    break;
                }
            }
        }

        static void InitKeymap()
        {
            _keymaps[JoyconKey.L_DPAD_LEFT] = XboxKey.XUSB_GAMEPAD_DPAD_LEFT;
            _keymaps[JoyconKey.L_DPAD_DOWN] = XboxKey.XUSB_GAMEPAD_DPAD_DOWN;
            _keymaps[JoyconKey.L_DPAD_UP] = XboxKey.XUSB_GAMEPAD_DPAD_UP;
            _keymaps[JoyconKey.L_DPAD_RIGHT] = XboxKey.XUSB_GAMEPAD_DPAD_RIGHT;
            _keymaps[JoyconKey.L_DPAD_SL] = XboxKey.DISABLE;
            _keymaps[JoyconKey.L_DPAD_SR] = XboxKey.DISABLE;
            _keymaps[JoyconKey.L_SHOULDER] = XboxKey.XUSB_GAMEPAD_LEFT_SHOULDER;
            _keymaps[JoyconKey.L_TRIGGER] = XboxKey.XUSB_GAMEPAD_LEFT_TRIGGER;
            _keymaps[JoyconKey.L_CAPTURE] = XboxKey.XUSB_GAMEPAD_BACK;
            _keymaps[JoyconKey.L_MINUS] = XboxKey.XUSB_GAMEPAD_BACK;
            _keymaps[JoyconKey.L_STICK] = XboxKey.XUSB_GAMEPAD_LEFT_THUMB;
            _keymaps[JoyconKey.R_BUT_A] = XboxKey.XUSB_GAMEPAD_B;
            _keymaps[JoyconKey.R_BUT_B] = XboxKey.XUSB_GAMEPAD_A;
            _keymaps[JoyconKey.R_BUT_X] = XboxKey.XUSB_GAMEPAD_Y;
            _keymaps[JoyconKey.R_BUT_Y] = XboxKey.XUSB_GAMEPAD_X;
            _keymaps[JoyconKey.R_BUT_SL] = XboxKey.DISABLE;
            _keymaps[JoyconKey.R_BUT_SR] = XboxKey.DISABLE;
            _keymaps[JoyconKey.R_SHOULDER] = XboxKey.XUSB_GAMEPAD_RIGHT_SHOULDER;
            _keymaps[JoyconKey.R_TRIGGER] = XboxKey.XUSB_GAMEPAD_RIGHT_TRIGGER;
            _keymaps[JoyconKey.R_HOME] = XboxKey.XUSB_GAMEPAD_START;
            _keymaps[JoyconKey.R_PLUS] = XboxKey.XUSB_GAMEPAD_START;
            _keymaps[JoyconKey.R_STICK] = XboxKey.XUSB_GAMEPAD_RIGHT_THUMB;
        }

        static void InitButtonMaps()
        {
            foreach (var item in Enum.GetValues(typeof(JoyconButton)))
                _jcBtnMaps[(int)item] = (JoyconButton)item;

            foreach (var item in Enum.GetValues(typeof(XboxButton)))
                _xboxBtnMaps[(int)item] = (XboxButton)item;
        }

        static void OutputJoyconButtonNames()
        {
            Console.WriteLine("|--------------------- JoyCon ----------------------|");
            ConsoleTable table = new ConsoleTable("ID", "Key", "Button name");

            for (int i = 0; i < 22; i++)
                table.AddRow((i + 1).ToString("D2"), ((JoyconKey)i).ToString(), _jcBtnMaps.ContainsKey(i) ? _jcBtnMaps[i].ToString() : "");

            table.Write(Format.MarkDown);
        }

        static void OutputXboxButtonNames()
        {
            Console.WriteLine("|------------------------ Xbox --------------------------|");
            ConsoleTable table = new ConsoleTable("ID", "Key", "Button name");

            for (int i = 0; i < 18; i++)
                table.AddRow((i + 1).ToString("D2"), ((XboxKey)i).ToString(), _xboxBtnMaps.ContainsKey(i) ? _xboxBtnMaps[i].ToString() : "");

            table.Write(Format.MarkDown);
        }

        static void OutputXboxKeys()
        {
            Console.WriteLine("----------- Xbox Buttons ------------");
            for (int i = 0; i < 18; i++)
                Console.WriteLine($"{(i + 1):D2}  {(XboxKey)i}");
            Console.WriteLine("----------- Xbox Buttons ------------");
        }

        static void OutputResult(List<string> lines)
        {
            Console.WriteLine("----------- Result ------------");
            for (int i = 0; i < 22; i++)
                Console.WriteLine($"{(i + 1):D2}  {lines[i]}");
            Console.WriteLine("----------- Result ------------");
        }

        static void SaveFile(List<string> lines)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("# To disable any button, set \"DISABLE\" to the value");
            foreach (var str in lines)
                stringBuilder.AppendLine(str);
            string result = stringBuilder.ToString();

            File.WriteAllText("keymap.yaml", result, Encoding.UTF8);
            Console.WriteLine("Save successfully");
        }
    }
}
