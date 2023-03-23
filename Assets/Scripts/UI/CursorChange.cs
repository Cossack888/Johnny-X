using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public NewMovement movement;

    private void Update()
    {
        if (movement.weaponDrawn)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
          else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

    
}
