using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public Sprite[] SquishDown;

    private SpriteRenderer sr;
    private int numSquishFrames;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        numSquishFrames = SquishDown.Length;
        SetSprite(0);
    }

    public int GetNumFrames()
    {
        return numSquishFrames;
    }

    public void SetSprite(int index)
    {
        sr.sprite = SquishDown[index];
    }
}
