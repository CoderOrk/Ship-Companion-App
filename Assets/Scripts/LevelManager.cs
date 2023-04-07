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

    public static int eventsSinceKraken = 6;
    public static int eventsSinceSpecDelivery = 6;
    public static int traverseMercShips = 2;
    public static int spaceStationMercShips = 1;
   public static bool isInBattle = false;

   void Start() 
   {
        if(isInBattle && buttonText != null)
        {
            buttonText.text = "End Battle";
        }
   }

   public int GetEventsSinceKraken()
   {
        return eventsSinceKraken;
   }

   public void IncrementEventsSinceKraken()
    {
        eventsSinceKraken++;
    }

    public void ResetEventsSinceKraken()
    {
        eventsSinceKraken = 0;
    }

    public int GetEventsSinceSpecDelivery()
    {
        return eventsSinceSpecDelivery;
    }

    public void IncrementEventsSinceSpecDelivery()
    {
        eventsSinceSpecDelivery++;
    }

    public void ResetEventsSinceSpecDelivery()
    {
        eventsSinceSpecDelivery = 0;
    }

    public int GetTraverseMercShips()
    {
        return traverseMercShips;
    }

    public void DecrementTraverseMercShips()
    {
        traverseMercShips--;
    }

    public int GetSpaceStationMercShips()
    {
        return spaceStationMercShips;
    }

    public void DecrementSpaceStationMercShips()
    {
        spaceStationMercShips--;
    }

    public void PrintResources()
    {
        Debug.Log("<b>Resources</b>" + "\n" +
        "Events Since Kraken: " + GetEventsSinceKraken().ToString() + "\n" +
        "Events Since Special Delivery: " + GetEventsSinceSpecDelivery().ToString() + "\n" +
        "Traverse Merc Ships Remaining: " + GetTraverseMercShips().ToString() + "\n" +
        "Space Station Merc Ships Remaining: " + GetSpaceStationMercShips().ToString());
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

        public void ToggleBattle()
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
