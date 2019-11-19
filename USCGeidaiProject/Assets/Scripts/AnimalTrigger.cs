using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTrigger : MonoBehaviour
{
    public string AnimalName = "Neko";

    private CanvasManager cm;

    void Awake()
    {
        cm = GameObject.Find("CanvasManager").GetComponent<CanvasManager>();
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked " + AnimalName);
        cm.SetInteractive(AnimalName);
    }
}
