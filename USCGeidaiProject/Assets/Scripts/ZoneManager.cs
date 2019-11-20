using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public GameObject[] Zones;

    private int currentZone;

    public void SetZone(string animName)
    {
        int index;
        switch (animName)
        {
            case "Squish":
                index = 0;
                break;

            case "Stretch":
                index = 1;
                break;

            case "Grab":
                index = 2;
                break;

            default:
                index = 0;
                break;
        }

        for (int i = 0; i < Zones.Length; i++)
        {
            if (i != index)
            {
                Zones[i].SetActive(false);
            }
        }
    }

    public void ResetZones()
    {
        foreach (GameObject zone in Zones)
        {
            zone.SetActive(true);
        }
    }
}
