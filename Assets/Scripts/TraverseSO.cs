using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Travese Action", fileName = "New Traverse Action")]

public class TraverseSO : ScriptableObject
{

    [SerializeField] string titleText = "Traverse Title Text Here";
    [TextArea(2, 6)]
    [SerializeField] string descriptionText = "Traverse Description Text Here";
    [SerializeField] bool doesRepeat;
    [SerializeField] Sprite actionImage;

    bool wasDrawn = false;

    public string GetTitle()
    {
        return titleText;
    }

    public string GetDescription()
    {
        return descriptionText;
    }

    public bool GetDoesRepeat()
    {
        return doesRepeat;
    }

    public Sprite GetImage()
    {
        return actionImage;
    }

    public void SetWasDrawn(bool drawn)
    {
        wasDrawn = drawn;
    }

    public bool GetWasDrawn()
    {
        return wasDrawn;
    }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;

}
