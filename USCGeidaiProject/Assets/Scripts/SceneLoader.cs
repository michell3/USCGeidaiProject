using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string StartSceneName = "NeighborhoodScene";

    public void LoadStart()
    {
        SceneManager.LoadScene(StartSceneName);
    }
}
