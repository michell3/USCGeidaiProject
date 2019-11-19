using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject CanvasNeighborhood;
    public GameObject CanvasInteractive;

    private CursorManager csm;

    void Awake()
    {   
        csm = GetComponent<CursorManager>();
        SetNeighborhood();
    }

    public void SetInteractive()
    {
        CanvasNeighborhood.SetActive(false);
        CanvasInteractive.SetActive(true);
        csm.SetIdle();
    }

    public void SetNeighborhood()
    {
        CanvasNeighborhood.SetActive(true);
        CanvasInteractive.SetActive(false);
        csm.SetDefault();
    }
}
