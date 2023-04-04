using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Destruction : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] Image image;

    void Start()
    {
        title.text = "Destructions!";
        description.text = "You have been Destructionsed!";
    }
}
