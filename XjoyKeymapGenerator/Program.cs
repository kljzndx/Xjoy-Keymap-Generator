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

    internal class Program
    {
        static Dictionary<JoyconKey, XboxKey> _keymaps = new Dictionary<JoyconKey, XboxKey>();

        static void Main(string[] args)
        {
            InitKeymap();

            while (true)
            {
                Console.WriteLine("----------- Result ------------");
                List<string> mapLines = _keymaps.Select(p => $"{p.Key}: {p.Value}").ToList();
                OutputResult(mapLines);
                Console.WriteLine("----------- Result ------------");

                Console.WriteLine("1  Edit");
                Console.WriteLine("2  Save");
                Console.Write("Which command do you want to execute (1 or 2): ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Write("Which line do you want to edit (1 ~ 22): ");
                    input = Console.ReadLine();
                    int jcId = int.Parse(input) - 1;

                    OutputXboxKeys();
                    Console.Write("Which value do you want to set (1 ~ 18): ");
                    input = Console.ReadLine();
                    int xboxId = int.Parse(input) - 1;

                    _keymaps[(JoyconKey)jcId] = (XboxKey)xboxId;
                    continue;
                }

                if (input == "2")
                {
                    SaveFile(mapLines);
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

        static void OutputXboxKeys()
        {
            for (int i = 0; i < 18; i++)
                Console.WriteLine($"{i:DD}  {(XboxKey)i}");
        }

        static void OutputResult(List<string> lines)
        {
            for (int i = 0; i < 22; i++)
                Console.WriteLine($"{i:DD}  {lines[i]}");
        }

        static void SaveFile(List<string> lines)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var str in lines)
                stringBuilder.AppendLine(str);
            string result = stringBuilder.ToString();

            File.WriteAllText("keymap.yaml", result, Encoding.UTF8);
        }
    }
}
