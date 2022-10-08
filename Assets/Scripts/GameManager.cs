using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Events")] 
    public UnityEvent onWinGame;
    public UnityEvent onLoseGame;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void WinGame()
    {
        onWinGame.Invoke();
    }

    public void LoseGame()
    {
        onLoseGame.Invoke();
    }
}
