using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace AillieoUtils
{
    public class MouseWindows : MouseInterfaces
    {
        public Vector2Int GetMousePosition()
        {
            LPPOINT p;
            if (GetCursorPos(out p))
            {
                return new Vector2Int(p.X, p.Y);
            }

            return Vector2Int.zero;
        }

        public void SetMousePosition(Vector2Int position)
        {
            Vector2Int systemPoint = ScreenToSystemSpace(position);
            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, systemPoint.x, systemPoint.y, 0, new UIntPtr(0));
        }

        public void Click(Vector2Int position)
        {
            Vector2Int systemPoint = ScreenToSystemSpace(position);
            mouse_event(MouseEventFlag.Move | MouseEventFlag.LeftDown | MouseEventFlag.LeftUp | MouseEventFlag.Absolute, systemPoint.x, systemPoint.y, 0, new UIntPtr(0));
        }

        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LPPOINT
        {
            public int X;
            public int Y;

            public LPPOINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out LPPOINT lpPoint);

        private static Vector2Int ScreenToSystemSpace(Vector2Int screenPoint)
        {
            return new Vector2Int(
                (int)((double)screenPoint.x / Screen.width * 0xffff),
                (int)((double)screenPoint.y / Screen.height * 0xffff));
        }
    }

}