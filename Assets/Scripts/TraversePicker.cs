using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TraversePicker : MonoBehaviour
{
    [SerializeField] List<TraverseSO> traverseList = new List<TraverseSO>();

    TraverseSO randomTraverseAction;

    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] Image image;
    [SerializeField] TraverseSO allsWell;

    int randomNum;

    void Awake()
    {

    }

    void Start()
    {
        getTraverseAction();
        displayTravereAction();
    }

    void getTraverseAction()
    {
        randomNum = Random.Range(1, 101);
        Debug.Log(randomNum.ToString());

        if(randomNum <= 80)
        {
            randomTraverseAction = allsWell;
        }else
        {
            int randomIndex = Random.Range(0, traverseList.Count);
            randomTraverseAction = traverseList[randomIndex]; 
        }

    }

    void displayTravereAction()
    {
        title.text = randomTraverseAction.getTitle();
        description.text = randomTraverseAction.getDescription();

        if(randomTraverseAction == allsWell)
        {
            return;                
        }else
        {
            image.enabled = true;                
            image.sprite = randomTraverseAction.getImage();
        }

    }

}
