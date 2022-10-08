using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    public int CurrentSceneIndex => SceneManager.GetActiveScene().buildIndex;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(CurrentSceneIndex);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = CurrentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
