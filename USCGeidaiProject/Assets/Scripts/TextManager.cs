using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public string[] EnglishLines;
    public string[] JapaneseLines;
    public Text EnglishText;
    public Text JapaneseText;

    public GameObject[] ActivationObjects;

    private int numLines;
    private int currentLine = 0;
    
    void Awake()
    {
        numLines = EnglishLines.Length;
        ActivateObjects(false);
    }

    public void NextLine()
    {
        currentLine++;

        if (currentLine >= numLines)
        {
            gameObject.SetActive(false);
            ActivateObjects(true);
            return;
        }

        EnglishText.text = EnglishLines[currentLine];
        JapaneseText.text = JapaneseLines[currentLine];
    }

    private void ActivateObjects(bool activate)
    {
        foreach (GameObject obj in ActivationObjects)
        {
            obj.SetActive(activate);
        }
    }
}
