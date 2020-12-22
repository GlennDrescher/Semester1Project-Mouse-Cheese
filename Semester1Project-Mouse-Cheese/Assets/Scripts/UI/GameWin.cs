using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    public static GameWin Singleton;
    private bool GameOver;

    private void Awake()
    {
        Singleton = this;
    }

    public void Start()
    {
        GameOver = false;
    }

    public void Mousewin()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        GameOver = true;
    }
    public void Cheesewin()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        GameOver = true;
    }
    private void Update()
    {
        if(GameOver == true)
        {
            Time.timeScale = 0f;
        }
    }
}
