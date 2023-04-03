using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Travese Action", fileName = "New Traverse Action")]

public class TraverseSO : ScriptableObject
{

    [SerializeField] string titleText = "Traverse Title Text Here";
    [TextArea(2, 6)]
    [SerializeField] string descriptionText = "Traverse Description Text Here";

    [SerializeField] Sprite actionImage;

    public string getTitle()
    {
        return titleText;
    }

    public string getDescription()
    {
        return descriptionText;
    }

    public Sprite getImage()
    {
        return actionImage;
    }
}
