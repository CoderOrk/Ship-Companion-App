using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traverse Event", fileName = "New Traverse Event")]

public class TraverseEventSO : ScriptableObject
{
    [Header("Event Actions")]
    [SerializeField] List<TraverseSO> traverseActionsList = new List<TraverseSO>();

    [Header("Event Repeat Settings")]
    [SerializeField] bool hasLimitedRepeats = false;
    [SerializeField] int numOfRepeats;
    [SerializeField] int timesDrawn = 0;
    [SerializeField] bool hasEventSpacing = false;
    [SerializeField] int eventSpacing;
    [SerializeField] bool isKraken = false;
    [SerializeField] bool isSpecDelivery = false;

    [Header("Event Layer Settings")]
    [SerializeField] bool canIgnore = false;
    [SerializeField] bool canInvestigate = false;
    [SerializeField] bool randomizeFirstAction = false;

    public int GetActionListLength()
    {
        return traverseActionsList.Count;
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
    
    public bool HasEventSpacing()
    {
        return hasEventSpacing;
    }

    public int GetEventSpacing()
    {
        return eventSpacing;
    }

    public bool IsKraken()
    {
        return isKraken;
    }

    public bool IsSpecDelivery()
    {
        return isSpecDelivery;
    }

    public bool CanIgnore()
    {
        return canIgnore;
    }

    public bool CanInvestigate()
    {
        return canInvestigate;
    }

    public bool RandomizeFirstAction()
    {
        return randomizeFirstAction;
    }

    public TraverseSO GetFirstAction()
    {
        return traverseActionsList[0];
    }

    public TraverseSO GetTraverseAction(int index)
    {
            return traverseActionsList[index];
    }

    public void ResetTraverseEvent()
    {
        timesDrawn = 0;
    }

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

}
