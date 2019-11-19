using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D Default;
    public Texture2D Idle;
    public Texture2D Squish;
    public Texture2D PreparedSquish;

    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpotCorner = Vector2.zero;
    private Vector2 hotSpotCenter;
    private Vector2 hotSpotCenterSmall;

    void Awake()
    {
        hotSpotCenter = new Vector2(Idle.width / 2f, Idle.height / 2f);
        hotSpotCenterSmall = new Vector2(Default.width / 2f, Default.height / 2f);
        Cursor.SetCursor(Default, hotSpotCenter, cursorMode);
    }

    public void SetDefault()
    {
        Cursor.SetCursor(Default, hotSpotCenterSmall, cursorMode);
    }

    public void SetIdle()
    {
        Cursor.SetCursor(Idle, hotSpotCenter, cursorMode);
    }

    public void SetSquish()
    {
        Cursor.SetCursor(Squish, hotSpotCenter, cursorMode);
    }

    public void SetPreparedSquish()
    {
        Cursor.SetCursor(PreparedSquish, hotSpotCenter, cursorMode);
    }
}
