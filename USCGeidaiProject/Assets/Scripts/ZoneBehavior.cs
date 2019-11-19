using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBehavior : MonoBehaviour
{
    public string OwnerName = "Neko";

    private CursorManager csm;
    private SpriteAnimator sa;
    private AudioSource audio;

    private bool isInRange = false;
    private bool isSquishing = false;
    private bool isRestoring = true;
    private bool hasClicked = false;
    private float maxY;

    private int currentFrame = 0;
    private int numFrames;
    private int startFrame;

    void Awake()
    {
        csm = GameObject.Find("CanvasManager").GetComponent<CursorManager>();
        sa = GameObject.Find(OwnerName).GetComponent<SpriteAnimator>();
        audio = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        numFrames = sa.GetNumFrames();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (isInRange || isSquishing)
            {
                float mouseY = Input.mousePosition.y;
                if (!isSquishing)
                {
                    isSquishing = true;
                    csm.SetSquish();
                    audio.Play();

                    // make sure the start position marks the start of the frame
                    maxY = mouseY;
                    startFrame = currentFrame;
                }
                UpdateFrame(mouseY);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isSquishing)
            {
                isSquishing = false;
                isRestoring = true;

                if (isInRange) csm.SetPreparedSquish();
                else csm.SetIdle();
            }
        }

        if (isRestoring)
        {
            RestoreFrame();
        }
    }

    void OnMouseEnter()
    {
        isInRange = true;

        if (!isSquishing)
        {
            csm.SetPreparedSquish();
        }
    }

    void OnMouseExit()
    {
        isInRange = false;

        if (!isSquishing)
        {
            csm.SetIdle();
        }
    }

    private void UpdateFrame(float value)
    {
        // TODO: move collider up and down?
        currentFrame = (int) Map(maxY, maxY - 200f, 0f, (float) numFrames - 1f, value);
        sa.SetSprite(currentFrame);
    }

    private void RestoreFrame()
    {
        if (currentFrame > 0)
        {
            currentFrame--;
            sa.SetSprite(currentFrame);
        }
        else
        {
            isRestoring = false;
        }
    }

    // Helper functions =======================================================

    public float Map(float oldMin, float oldMax, float newMin, float newMax, float oldValue)
    {
        if (oldMin < oldMax)
        {
            if (oldValue <= oldMin) return newMin;
            else if (oldValue >= oldMax) return newMax;
        }
        else
        {
            if (oldValue >= oldMin) return newMin;
            else if (oldValue <= oldMax) return newMax;
        }

        float oldRange = (oldMax - oldMin);
        float newRange = (newMax - newMin);
        float newValue = (((oldValue - oldMin) * newRange) / oldRange) + newMin;
    
        return(newValue);
    }
}
