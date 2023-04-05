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
    [SerializeField] AudioPlayer audioPlayer;

    void Start() 
    {
        audioPlayer.PlayExplosionSFX();
        GetRandomCriticalHit();
        PrintCriticalHit();
    }

    void GetRandomCriticalHit()
    {
        int randomIndex = Random.Range(0, criticalList.Count);

        randomCriticalHit = criticalList[randomIndex];
    }


    void PrintCriticalHitTitle()
    {
        title.text = randomCriticalHit.getTitle();
    }

    void PrintCriticalHitDescription()
    {
            description.text = randomCriticalHit.getDescription();
    }

    void PrintCriticalHit()
    {
        PrintCriticalHitTitle();
        PrintCriticalHitDescription();
    }

    
}
