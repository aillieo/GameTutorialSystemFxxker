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
            throw new System.NotImplementedException();
        }

        public Vector2Int GetMousePosition()
        {
            throw new System.NotImplementedException();
        }

        public void SetMousePosition(Vector2Int position)
        {
            throw new System.NotImplementedException();
        }

        [DllImport("__Internal")]
        private static extern void SetMousePosition(int x, int y);

    }

}