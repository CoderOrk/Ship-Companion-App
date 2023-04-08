using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] Image image;
    [SerializeField] List<DestructionSO> destructions = new List<DestructionSO>();

    int randomInt;
    DestructionSO destruction;

    void Start()
    {
        randomInt = Random.Range(1, 101);

        if(randomInt <= 10)
        {
            PrintDestruction(destructions[0]);
        }

        if(randomInt > 10 && randomInt <= 20)
        {            
            PrintDestruction(destructions[1]);
        }

        if(randomInt > 20 && randomInt <= 25)
        {
            PrintDestruction(destructions[2]);
        }

        if(randomInt > 25 && randomInt <= 45)
        {
            PrintDestruction(destructions[3]);
        }

        if(randomInt > 45 && randomInt <= 60)
        {
            PrintDestruction(destructions[4]);
        }

        if(randomInt > 60 && randomInt <= 100)
        {
            PrintDestruction(destructions[5]);
        }

        void PrintDestruction(DestructionSO destruction)
        {
            title.text = destruction.GetTitle();
            description.text = destruction.getDescription();
        }
    }
}
