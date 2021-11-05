using System;
using System.Collections.Generic;
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
        static Dictionary<JoyconKey, XboxKey> _keymap = new Dictionary<JoyconKey, XboxKey>();

        static void Main(string[] args)
        {

        }

        static void InitKeymap()
        {
            _keymap[JoyconKey.L_DPAD_LEFT] = XboxKey.XUSB_GAMEPAD_DPAD_LEFT;
            _keymap[JoyconKey.L_DPAD_DOWN] = XboxKey.XUSB_GAMEPAD_DPAD_DOWN;
            _keymap[JoyconKey.L_DPAD_UP] = XboxKey.XUSB_GAMEPAD_DPAD_UP;
            _keymap[JoyconKey.L_DPAD_RIGHT] = XboxKey.XUSB_GAMEPAD_DPAD_RIGHT;
            _keymap[JoyconKey.L_DPAD_SL] = XboxKey.DISABLE;
            _keymap[JoyconKey.L_DPAD_SR] = XboxKey.DISABLE;
            _keymap[JoyconKey.L_SHOULDER] = XboxKey.XUSB_GAMEPAD_LEFT_SHOULDER;
            _keymap[JoyconKey.L_TRIGGER] = XboxKey.XUSB_GAMEPAD_LEFT_TRIGGER;
            _keymap[JoyconKey.L_CAPTURE] = XboxKey.XUSB_GAMEPAD_BACK;
            _keymap[JoyconKey.L_MINUS] = XboxKey.XUSB_GAMEPAD_BACK;
            _keymap[JoyconKey.L_STICK] = XboxKey.XUSB_GAMEPAD_LEFT_THUMB;
            _keymap[JoyconKey.R_BUT_A] = XboxKey.XUSB_GAMEPAD_B;
            _keymap[JoyconKey.R_BUT_B] = XboxKey.XUSB_GAMEPAD_A;
            _keymap[JoyconKey.R_BUT_X] = XboxKey.XUSB_GAMEPAD_Y;
            _keymap[JoyconKey.R_BUT_Y] = XboxKey.XUSB_GAMEPAD_X;
            _keymap[JoyconKey.R_BUT_SL] = XboxKey.DISABLE;
            _keymap[JoyconKey.R_BUT_SR] = XboxKey.DISABLE;
            _keymap[JoyconKey.R_SHOULDER] = XboxKey.XUSB_GAMEPAD_RIGHT_SHOULDER;
            _keymap[JoyconKey.R_TRIGGER] = XboxKey.XUSB_GAMEPAD_RIGHT_TRIGGER;
            _keymap[JoyconKey.R_HOME] = XboxKey.XUSB_GAMEPAD_START;
            _keymap[JoyconKey.R_PLUS] = XboxKey.XUSB_GAMEPAD_START;
            _keymap[JoyconKey.R_STICK] = XboxKey.XUSB_GAMEPAD_RIGHT_THUMB;
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
    }
}
