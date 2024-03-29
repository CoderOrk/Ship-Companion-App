using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Layout")]
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] AudioSource audioSource;

    [Header("Objects To Reset")]
    [SerializeField] List<TraverseEventSO> traverseEventsList= new List<TraverseEventSO>();
    [SerializeField] List<SpaceStationEventSO>  ssEventsList = new List<SpaceStationEventSO>();

    public static int eventsSinceKraken = 6;
    public static int eventsSinceSpecDelivery = 6;
    public static int traverseMercShips = 2;
    public static int spaceStationMercShips = 1;
    public static bool isInBattle = false;


    // void Awake()
    // {
    //     traversePicker = GetComponent<TraversePicker>();
    //     ssEventPicker = GetComponent<SSEventPicker>();
    // }

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

    public int GetSpaceStationMercShips()
    {
        return spaceStationMercShips;
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
        LoadScene(1);
        audioPlayer.PlayStartSFX();
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

    public void ResetGameEvents()
    {
        ResetssEventsList();
        ResetTraverseEventsList();
    }

    void ResetTraverseEventsList()
    {
        for(int i = 0; i < traverseEventsList.Count; i++)
        {
            traverseEventsList[i].ResetTraverseEvent();
        }

    }

    void ResetssEventsList()
    {
        for(int i = 0; i < ssEventsList.Count; i++)
        {
            ssEventsList[i].ResetSSEvent();
        }
    }
}
