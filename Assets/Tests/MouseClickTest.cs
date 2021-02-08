using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AillieoUtils;

public class MouseClickTest : MonoBehaviour
{
    private Vector2Int min;
    private Vector2Int max;
    private Rect rectInView;
    private bool autoClick = false;

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            autoClick = true;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Escape))
        {
            autoClick = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            Vector2Int pos = MouseClick.GetMousePosition();
            min = Vector2Int.Min(min, pos);
            max = Vector2Int.Max(max, pos);
            Vector2 posInView = MouseClick.GetMousePositionInView();
            rectInView.min = Vector2.Min(rectInView.min, posInView);
            rectInView.max = Vector2.Max(rectInView.max, posInView);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            Vector2Int pos = MouseClick.GetMousePosition();
            Vector2 posInView = MouseClick.GetMousePositionInView();
            min = pos;
            max = pos;
            rectInView = new Rect(posInView, Vector2.zero);
        }

        if (autoClick && Application.isFocused)
        {
            MouseClick.Click(new Vector2Int(
                UnityEngine.Random.Range(min.x, max.x),
                UnityEngine.Random.Range(min.y, max.y)));
        }
    }

    private void OnFocusChanged(bool isFocused)
    {
        if (!isFocused)
        {
            autoClick = false;
        }
    }

    private void Awake()
    {
        Application.focusChanged += OnFocusChanged;
    }

    private void OnDestroy()
    {
        Application.focusChanged -= OnFocusChanged;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 500, 200), $"Keys:\nS to Start\nD or Esc to stop\n9 to extend\n0 to reset", new GUIStyle() { fontSize = 30 });
        GUI.Box(rectInView, GUIContent.none);
    }
#endif
}
