﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    // animation frames
    public Sprite[] SquishDown;
    public Sprite[] StretchRight;
    public Sprite[] Grab;

    // audio
    public AudioClip SquishClip;
    public AudioClip StretchClip;
    public AudioClip GrabClip;
    public AudioClip RestoreClip;

    private SpriteRenderer sr;
    private AudioSource audioSource;
    private int numSquishFrames;

    // TODO: Populate frames from resources folder

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

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

            case "Grab":
                sr.sprite = Grab[index];
                break;
            
            default:
                break;
        }
    }

    public void PlayAudio(string animName)
    {
        switch(animName)
        {
            case "Squish":
                audioSource.clip = SquishClip;
                audioSource.loop = true;
                break;

            case "Stretch":
                audioSource.clip = StretchClip;
                audioSource.loop = true;
                break;

            case "Grab":
                audioSource.clip = GrabClip;
                audioSource.loop = true;
                break;

            case "Restore":
                audioSource.clip = RestoreClip;
                audioSource.loop = false;
                break;
            
            default:
                break;
        }
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
