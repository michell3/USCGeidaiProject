using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject CanvasNeighborhood;
    public GameObject CanvasInteractive;

    public GameObject[] AnimalManagers;

    private CursorManager csm;
    private GameObject currentManager;

    void Awake()
    {   
        csm = GetComponent<CursorManager>();
        SetNeighborhood();

        foreach (GameObject animal in AnimalManagers)
        {
            animal.SetActive(false);
        }
    }

    public void SetInteractive(string animalName)
    {
        CanvasNeighborhood.SetActive(false);

        switch(animalName)
        {
            case "Neko":
                currentManager = AnimalManagers[0];
                break;
            
            case "Hebi":
                currentManager = AnimalManagers[1];
                break;
            
            default:
                break;
        }
        currentManager.SetActive(true);
        CanvasInteractive.SetActive(true);
        csm.SetIdle();
    }

    public void SetNeighborhood()
    {
        CanvasNeighborhood.SetActive(true);
        CanvasInteractive.SetActive(false);
        if (currentManager != null) currentManager.SetActive(false);

        // set cursor
        csm.SetDefault();
    }
}
