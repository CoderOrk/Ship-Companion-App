using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traverse Event", fileName = "New Traverse Event")]

public class TraverseEventSO : ScriptableObject
{
    [Header("Traverse Event")]
    [SerializeField] List<TraverseSO> traverseActionsList = new List<TraverseSO>();

    [Header("Repeat Settings")]
    [SerializeField] bool hasLimitedRepeats = false;
    [SerializeField] int numOfRepeats;
    [SerializeField] bool hasEventSpacing = false;
    [SerializeField] int eventSpacing;

    [Header("Layer Settings")]
    [SerializeField] bool canIgnore = false;
    [SerializeField] bool canInvestigate = false;
    [SerializeField] bool hasMultipleLayers;

    public bool HasLimitedRepeats()
    {
        return hasLimitedRepeats;
    }

    public int GetNumOfRepeats()
    {
        return numOfRepeats;
    }

    public bool HasEventSpacing()
    {
        return hasEventSpacing;
    }

    public int GetEventSpacing()
    {
        return eventSpacing;
    }

    public bool CanIgnore()
    {
        return canIgnore;
    }

    public bool CanInvestigate()
    {
        return canInvestigate;
    }

    public bool HasMultipleLayers()
    {
        return hasMultipleLayers;
    }

    public TraverseSO GetFirstAction()
    {
        return traverseActionsList[0];
    }

    public TraverseSO GetTraverseAction(int index)
    {
        return traverseActionsList[index];
    }
}
