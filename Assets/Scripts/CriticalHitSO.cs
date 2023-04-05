using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Critical Hit", fileName = "New Critical Hit")]
public class CriticalHitSO : ScriptableObject
{
    [SerializeField] string title = "Critical Hit Title Here";
    [TextArea(2, 4)]
    [SerializeField] string description = "Critical Hit Description Here";

    public string getTitle()
    {
        return title;
    }

    public string getDescription()
    {
        return description;
    }
}
