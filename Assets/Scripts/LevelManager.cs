using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadStart()
    {
        LoadScene(0);
    }

    public void LoadMenu()
    {
        LoadScene(1);
    }

    public void LoadOptions()
    {
        LoadScene(2);
    }

        public void LoadTraverse()
    {
        LoadScene(3);
    }

    public void LoadDestruction()
    {
        LoadScene(4);
    }

        public void LoadCriticalHit()
    {
        LoadScene(5);
    }

        public void LoadSpaceStation()
    {
        LoadScene(6);
    }

        public void LoadBattle()
    {
        LoadScene(7);
    }

    void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
