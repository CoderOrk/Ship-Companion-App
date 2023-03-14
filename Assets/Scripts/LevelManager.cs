using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] AudioSource audioSource;

   public static bool isInBattle = false;

   void Start() 
   {
        if(isInBattle && buttonText != null)
        {
            buttonText.text = "End Battle";
        }
   }

    public void LoadStart()
    {
        LoadScene(0);
    }

    public void LoadMenu()
    {
        audioPlayer.PlayStartSFX();
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
        if(!isInBattle)
        {
            isInBattle = true;
            buttonText.text = "End Battle";
            audioPlayer.PlayBattleMusic();
        }else
        {
            isInBattle = false;
            buttonText.text = "Battle";
            audioPlayer.PlayDefaultMusic();
        }
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
