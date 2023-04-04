using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Travese Action", fileName = "New Traverse Action")]

public class TraverseSO : ScriptableObject
{

    [SerializeField] string titleText = "Traverse Title Text Here";
    [TextArea(2, 6)]
    [SerializeField] string descriptionText = "Traverse Description Text Here";
    [SerializeField] bool repeats;
    [SerializeField] Sprite actionImage;

    bool drawn = false;

    public string getTitle()
    {
        return titleText;
    }

    public string getDescription()
    {
        return descriptionText;
    }

    public bool GetRepeats()
    {
        return repeats;
    }

    public Sprite getImage()
    {
        return actionImage;
    }

    public void SetDrawn(bool wasDrawn)
    {
        drawn = wasDrawn;
    }

    public bool GetDrawn()
    {
        return drawn;
    }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;

}
