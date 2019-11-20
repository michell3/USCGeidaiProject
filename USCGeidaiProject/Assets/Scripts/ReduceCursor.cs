using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceCursor : MonoBehaviour
{
    private CursorManager csm;

    // TODO: fix this nonsense

    void Awake()
    {
        csm = GameObject.Find("CanvasManager").GetComponent<CursorManager>();
    }

    void OnMouseEnter()
    {
        csm.SetDefault();
    }

    void OnMouseExit()
    {
        csm.SetIdle();
    }
}
