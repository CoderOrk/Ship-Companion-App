using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Destruction", fileName = "New Destruction")]

public class DestructionSO : ScriptableObject
{
    [SerializeField] string title;

    [TextArea(2, 6)]
    [SerializeField] string description;    
    [SerializeField] string odds;

    public string GetTitle()
    {
        return title;
    }

    public string getDescription()
    {
        return description;
    }
}
