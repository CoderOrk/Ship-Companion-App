using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Critical Hit", fileName = "New Critical Hit")]
public class CriticalHitSO : ScriptableObject
{
    [SerializeField] string title = "Critical Hit Title Here";
    [TextArea(2, 4)]
    [SerializeField] string description = "Critical Hit Description Here";

    [SerializeField] int amountHit;


    public string getTitle()
    {
        return title;
    }

    public string getDescription()
    {
        return description;
    }

    public void incrementAmountHit()
    {
        amountHit += 1;
    }

    public int getAmountHit()
    {
        return amountHit;
    }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;

}
