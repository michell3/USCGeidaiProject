using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBehavior : MonoBehaviour
{
    // zone information
    public string OwnerName = "Neko";
    public string AnimName = "Squish";
    public bool IsHorizontal = false;
    public float Range = -200f;
    public int NumFrames = 19;

    private CursorManager csm;
    private SpriteAnimator sa;

    // state information
    private bool isInRange = false;
    private bool isPressing = false;
    private bool isRestoring = true;
    private float maxVal;
    private int currentFrame = 0;

    // TODO: get this working
    private int startFrame;

    // TODO: deactivate other zones

    void Awake()
    {
        csm = GameObject.Find("CanvasManager").GetComponent<CursorManager>();
        sa = GameObject.Find(OwnerName).GetComponent<SpriteAnimator>();
    }

    void FixedUpdate()
    {
        // mouse pressed
        if ((isInRange || isPressing) && Input.GetMouseButton(0))
        {
            // get input value
            float mouseVal;
            if (IsHorizontal) mouseVal = Input.mousePosition.x;
            else mouseVal = Input.mousePosition.y;

            // if this is the start of the press
            if (!isPressing)
            {
                isPressing = true;
                csm.SetSquish();
                sa.PlayAudio();

                // make sure the start position marks the start frame
                maxVal = mouseVal;
                startFrame = currentFrame;
            }
            UpdateFrame(mouseVal);

            // TODO: dragging too far restores animation
        }

        // mouse released
        if (isPressing && Input.GetMouseButtonUp(0))
        {
            isPressing = false;
            isRestoring = true;

            // update cursor
            if (isInRange) csm.SetPreparedSquish();
            else csm.SetIdle();
        }

        // restore animation to initial frame
        if (isRestoring)
        {
            RestoreFrame();
        }
    }

    void OnMouseEnter()
    {
        isInRange = true;

        // update cursor
        if (!isPressing) csm.SetPreparedSquish();
    }

    void OnMouseExit()
    {
        isInRange = false;

        // update cursor
        if (!isPressing) csm.SetIdle();
    }    

    // Helper functions =======================================================

    // update frame of animation based on input
    private void UpdateFrame(float value)
    {
        // TODO: move collider up and down?
        currentFrame = (int) Map(maxVal, maxVal + Range, 0f, (float) NumFrames - 1f, value);
        sa.SetSprite(AnimName, currentFrame);
    }

    // restore animation to starting state
    private void RestoreFrame()
    {
        if (currentFrame > 0)
        {
            currentFrame--;
            sa.SetSprite(AnimName, currentFrame);
        }
        else
        {
            isRestoring = false;
        }
    }

    // mapping function
    private float Map(float oldMin, float oldMax, float newMin, float newMax, float oldValue)
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