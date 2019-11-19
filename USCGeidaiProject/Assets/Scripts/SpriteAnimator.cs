using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    // animation frames
    public Sprite[] SquishDown;
    public Sprite[] StretchRight;

    private SpriteRenderer sr;
    private AudioSource audio;
    private int numSquishFrames;

    // TODO: Populate frames from resources folder

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

        // initialize states
        numSquishFrames = SquishDown.Length;
        sr.sprite = SquishDown[0];
    }

    public int GetNumFrames()
    {
        return numSquishFrames;
    }

    public void SetSprite(string animName, int index)
    {
        switch(animName)
        {
            case "Squish":
                sr.sprite = SquishDown[index];
                break;

            case "Stretch":
                sr.sprite = StretchRight[index];
                break;
            
            default:
                break;
        }
    }

    public void PlayAudio()
    {
        audio.Play();
    }
}
