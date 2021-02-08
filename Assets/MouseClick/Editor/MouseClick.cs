using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AillieoUtils
{
    public static class MouseClick
    {
        private static readonly MouseInterfaces mouse;
        static MouseClick()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                    mouse = new MouseWindows();
                    break;
                case RuntimePlatform.OSXEditor:
                    mouse = new MouseOSX();
                    break;
                default:
                    Debug.LogError($"Not supported platform: {Application.platform}");
                    break;
            }
        }

        public static Vector2Int GetMousePosition()
        {
            return mouse.GetMousePosition();
        }

        public static void SetMousePosition(Vector2Int position)
        {
            mouse.SetMousePosition(position);
        }

        public static void Click(Vector2Int position)
        {
            mouse.Click(position);
        }

        public static Vector2 GetMousePositionInView()
        {
            Vector2 position = Input.mousePosition;
            return new Vector2(position.x, Screen.height - position.y);
        }
    }
}