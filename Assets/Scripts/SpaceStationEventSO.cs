using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Space Station Event", fileName = "New Space Station Event", order = 0)]
public class SpaceStationEventSO : ScriptableObject 
{
    [Header("Event Content")]
    [SerializeField] string titleText;
    [TextArea(2, 6)]
    [SerializeField] string descriptionText;

    [Header("Event Repeat Settings")]
    [SerializeField] bool hasLimitedRepeats = false;
    [SerializeField] int numOfRepeats = 0;
    [SerializeField] int timesDrawn = 0;
    [SerializeField] bool canIgnore = false;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    public string GetTitle()
    {
        return titleText;
    }

    public string GetDescription()
    {
        return descriptionText;
    }

    public bool HasLimitedRepeats()
    {
        return hasLimitedRepeats;
    }

    public int GetNumOfRepeats()
    {
        return numOfRepeats;
    }

    public void DecrementTimesDrawn()
    {
        timesDrawn--;
    }

    public void IncrementTimesDrawn()
    {
        timesDrawn++;
    }

    public int GetTimesDrawn()
    {
        return timesDrawn;
    }    

    public bool CanIgnore()
    {
        return canIgnore;
    }

    public void ResetSSEvent()
    {
        timesDrawn = 0;
    }
}