﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public static Levels Instance = null;
    private int offset;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        offset = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void retry()
    {
        SceneManager.LoadScene(offset);
    }

    public void loadNextScene()
    {
        if (offset < Configs.NUMBER_OF_LEVELS)
        {
            offset++;
            SceneManager.LoadScene(offset);
        }
        else
        {
            Debug.Log("Game completed");
            // Handle end of the entire game
            displayMenu();
        }
    }

    public void displayWinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public void displayGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void displayMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public int getOffset()
    {
        return offset;
    }
    public void setOffset(int offset) {
        this.offset = offset;
    }
}
