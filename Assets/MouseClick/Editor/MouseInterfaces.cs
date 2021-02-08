using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils
{
    public interface MouseInterfaces
    {
        Vector2Int GetMousePosition();
        void SetMousePosition(Vector2Int position);
        void Click(Vector2Int position);
    }
}
