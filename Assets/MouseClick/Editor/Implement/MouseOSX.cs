using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace AillieoUtils
{
    public class MouseOSX : MouseInterfaces
    {
        public void Click(Vector2Int position)
        {
            OSX.Click(position.x, position.y);
        }

        public Vector2Int GetMousePosition()
        {
            CGPoint position = OSX.GetMousePosition();
            return new Vector2Int((int)position.x, (int)position.y);
        }

        public void SetMousePosition(Vector2Int position)
        {
            OSX.SetMousePosition(position.x, position.y);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CGPoint
        {
            public double x;
            public double y;

            public CGPoint(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private static class OSX
        {
            [DllImport("__Internal")]
            public static extern void SetMousePosition(int x, int y);

            [DllImport("__Internal")]
            public static extern CGPoint GetMousePosition();

            [DllImport("__Internal")]
            public static extern void Click(int x, int y);
        }
    }

}
