using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TraversePicker : MonoBehaviour
{

    [Header("Layout")]
    [SerializeField] GameObject navGroup;
    [SerializeField] GameObject eventNavGroup;
    [SerializeField] GameObject ignoreButton;
    [SerializeField] GameObject investigateButton;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] Image image;

    [Header("Alls Well")]
    [SerializeField] TraverseEventSO allsWell;
    [SerializeField] int allsWellPencentage = 85;

    [Header("Level Manager")]
    [SerializeField] LevelManager levelManager;

    [Header("Traverse Events")]
    [SerializeField] List<TraverseEventSO> traverseEventList = new List<TraverseEventSO>();
    
    TraverseEventSO randomTraverseEvent = null;

    void Start()
    {
        audioPlayer.PlayEngineRampUpSFX();
        levelManager.IncrementEventsSinceKraken();
        levelManager.IncrementEventsSinceSpecDelivery();
        GetTraverseEvent();
        PrintFirstTraverseAction(randomTraverseEvent);
        // levelManager.PrintResources();
    }

    void GetTraverseEvent()
    {
        int randomNum;
        randomNum = Random.Range(1, 101);
        // Debug.Log(randomNum.ToString());

        if(randomNum <= allsWellPencentage)
        {
            randomTraverseEvent = allsWell;
        }else
        {
            while(randomTraverseEvent == null)
            {
                // Debug.Log("In While Loop");
                int randomIndex = Random.Range(0, traverseEventList.Count);
                    // Debug.Log("Drew Event # " + randomIndex.ToString());
                if(traverseEventList[randomIndex].HasLimitedRepeats() == true && 
                    traverseEventList[randomIndex].GetTimesDrawn() >= traverseEventList[randomIndex].GetNumOfRepeats())
                {
                    // Debug.Log("Exceeded Repeat Limit");
                    randomTraverseEvent = null;
                }else
                {
                    randomTraverseEvent = traverseEventList[randomIndex];

                    if(randomTraverseEvent.HasEventSpacing())
                    {
                        if(randomTraverseEvent.IsKraken())
                        {
                            if(levelManager.GetEventsSinceKraken() >= randomTraverseEvent.GetEventSpacing())
                            {
                                levelManager.ResetEventsSinceKraken();
                            }else
                            {
                                // Debug.Log("Banished The Kraken");
                                randomTraverseEvent = null;
                            }
                        }

                        if(randomTraverseEvent != null && randomTraverseEvent.IsSpecDelivery())
                        {
                            if(levelManager.GetEventsSinceSpecDelivery() >= randomTraverseEvent.GetEventSpacing())
                            {
                                levelManager.ResetEventsSinceSpecDelivery();
                            }else
                            {
                                // Debug.Log("Shot Down SpecDelivery");
                                randomTraverseEvent = null;
                            }
                        }
                    }

                    if(randomTraverseEvent != null && randomTraverseEvent.HasLimitedRepeats())
                    {
                        // Debug.Log("Has Limited Repeats Loop");
                        traverseEventList[randomIndex].IncrementTimesDrawn();
                    }

                }
            }

            // Debug.Log("Out of While Loop");
        }
    }

    void PrintFirstTraverseAction(TraverseEventSO traverseEvent)
    {
        if(randomTraverseEvent.RandomizeFirstAction())
        {
            Investigate();
        }else
        {
            PrintTraverseAction(traverseEvent, 0);
        }

        if(traverseEvent.CanIgnore())
        {
            ignoreButton.SetActive(true);
            EnableEventNav();
        }
        if(traverseEvent.CanInvestigate())
        {
            investigateButton.SetActive(true);
            EnableEventNav();
        }
    }

    void PrintTraverseAction(TraverseEventSO traverseEvent, int index)
    {
        PrintTitle(traverseEvent, index);
        PrintDescription(traverseEvent, index);
        PrintImage(traverseEvent, index);
    }

    void PrintTitle(TraverseEventSO traverseEvent, int index)
    {
        title.text = traverseEvent.GetTraverseAction(index).GetTitle();
    }

    void PrintDescription(TraverseEventSO traverseEvent, int index)
    {
        description.text = traverseEvent.GetTraverseAction(index).GetDescription();
    }

    void PrintImage(TraverseEventSO traverseEvent, int index)
    {
        if(traverseEvent.GetTraverseAction(index).GetImage() == null)
        {
            return;
        }else
        {
            image.sprite = traverseEvent.GetTraverseAction(index).GetImage();
            image.enabled = true;                
        }
    }

    void EnableEventNav()
    {
        eventNavGroup.SetActive(true);
        navGroup.SetActive(false);
    }

    void EnableNavGroup()
    {
        navGroup.SetActive(true);
        ignoreButton.SetActive(false);
        investigateButton.SetActive(false);
        eventNavGroup.SetActive(false);
    }

    public void IgnoreEventAction()
    {
        randomTraverseEvent.DecrementTimesDrawn();
        levelManager.LoadMenu();
    }

    public void Investigate()
    {
        EnableNavGroup();
        if(randomTraverseEvent.GetActionListLength() > 1)
        {
            int randomIndex = Random.Range(1, randomTraverseEvent.GetActionListLength());
            PrintTraverseAction(randomTraverseEvent, randomIndex);
        }else
        {
            levelManager.LoadMenu();
        }
    }
}
