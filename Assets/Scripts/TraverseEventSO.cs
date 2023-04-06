using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traverse Event", fileName = "New Traverse Event")]

public class TraverseEventSO : ScriptableObject
{
    [Header("Traverse Event")]
    [SerializeField] List<TraverseSO> traverseActionsList = new List<TraverseSO>();

    public TraverseSO GetFirstAction()
    {
        return traverseActionsList[0];
    }

    public TraverseSO GetTraverseAction(int index)
    {
        return traverseActionsList[index];
    }
}
