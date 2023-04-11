using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SSEventPicker : MonoBehaviour
{
    [Header("Layout")]
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] GameObject navGroup;
    [SerializeField] GameObject eventNavGroup;
    [SerializeField] GameObject ignoreButton;

    [Header("Specific Events")]
    [SerializeField] SpaceStationEventSO dryDock;
    [SerializeField] SpaceStationEventSO marginalInventory;
    [SerializeField] SpaceStationEventSO decentInventory;
    [SerializeField] SpaceStationEventSO fatInventory;

    [Header("Random Events")]
    [SerializeField] List<SpaceStationEventSO> randomSSEvents = new List<SpaceStationEventSO>();

    [Header("Level Manager")]
    [SerializeField] LevelManager levelManager;

    SpaceStationEventSO ssEvent = null;

    void Start()
    {
        ssEvent = GetSSEvent(RollDice());
        PrintSSEvent(ssEvent);
    }

    int RollDice()
    {
        int roll = Random.Range(1, 101);
        Debug.Log(roll.ToString());
        return roll;
;
    }

    SpaceStationEventSO GetSSEvent(int diceRoll)
    {
        SpaceStationEventSO randomSSEvent = null;

        if(diceRoll <=20)
        {
            randomSSEvent = dryDock;
        }

        if(diceRoll > 20 && diceRoll <= 40)
        {            
            randomSSEvent = marginalInventory;
        }

        if(diceRoll > 40 && diceRoll <= 60)
        {            
            randomSSEvent = decentInventory;
        }

        if(diceRoll > 60 && diceRoll <= 80)
        {            
            randomSSEvent = fatInventory;
        }

        if(diceRoll > 80)
        {
            while(randomSSEvent == null)
            {
                int randomIndex = Random.Range(0, randomSSEvents.Count);
                if(randomSSEvents[randomIndex].HasLimitedRepeats() && 
                    randomSSEvents[randomIndex].GetTimesDrawn() >= randomSSEvents[randomIndex].GetNumOfRepeats())
                    {
                        Debug.Log(randomSSEvents[randomIndex].GetTitle() + " Repeats Exceeded");
                        randomSSEvent = null;
                    }else
                    {
                        randomSSEvent = randomSSEvents[randomIndex];
                        randomSSEvent.IncrementTimesDrawn();
                    }
            }
        }

        Debug.Log("Drew: " + randomSSEvent.GetTitle());
        return randomSSEvent;
    }

    void PrintSSEvent(SpaceStationEventSO ssEvent)
    {
        if(ssEvent.CanIgnore())
        {
            ignoreButton.SetActive(true);
        }

        PrintTitle(ssEvent);
        PrintDescription(ssEvent);
    }

    void PrintTitle(SpaceStationEventSO ssEvent)
    {
        title.text = ssEvent.GetTitle();
    }

    void PrintDescription(SpaceStationEventSO ssEvent)
    {
        description.text = ssEvent.GetDescription();
    }

        public void RefuseEventAction()
    {
        ssEvent.DecrementTimesDrawn();
        levelManager.LoadMenu();
    }

    public void ResetSSEventPicker()
    {
        for(int i = 0; i < randomSSEvents.Count; i++)
        {
            randomSSEvents[i].ResetSSEvent();
        }
    }
}