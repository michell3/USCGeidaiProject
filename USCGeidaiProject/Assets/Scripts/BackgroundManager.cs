using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] Panels;

    private int currentPanel;
    private int numPanels;

    void Awake()
    {
        numPanels = Panels.Length;
        currentPanel = 0;
        for (int i = 1; i < numPanels; i++)
        {
            Panels[i].SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Left();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Right();
        }
    }

    public void Left()
    {
        int newPanel = currentPanel - 1;
        if (newPanel < 0)
        {
            newPanel = numPanels - 1;
        }
        SetPanel(newPanel);
    }

    public void Right()
    {
        int newPanel = currentPanel + 1;
        if (newPanel >= numPanels)
        {
            newPanel = 0;
        }
        SetPanel(newPanel);
    }

    private void SetPanel(int newPanel)
    {
        Panels[currentPanel].SetActive(false);
        currentPanel = newPanel;
        Panels[currentPanel].SetActive(true);
    }
}
