using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CritPicker : MonoBehaviour
{
    [SerializeField] List<CriticalHitSO> criticalList = new List<CriticalHitSO>();

    CriticalHitSO randomCriticalHit;

    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    int amountHit;

    void Start() 
    {
        getRandomCriticalHit();
        printCriticalHitTitle();
        printCriticalHitDescription();    
    }

    void getRandomCriticalHit()
    {
        int randomIndex = Random.Range(0, criticalList.Count);

        criticalList[randomIndex].incrementAmountHit();
        randomCriticalHit = criticalList[randomIndex];
    }


    void printCriticalHitTitle()
    {
        title.text = randomCriticalHit.getTitle();
    }

    void printCriticalHitDescription()
    {
        if(randomCriticalHit.getAmountHit() >= 2)
        {
            description.text = "You've been Critically Hit 2 times in the same location!" + "<br>" +
                                "Your ship is lost!";
        }else
        {
            description.text = randomCriticalHit.getDescription() + "<br>" +
                                "Amount Hit: " + randomCriticalHit.getAmountHit();
        }
    }

    
}
