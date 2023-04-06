using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TraversePicker : MonoBehaviour
{

    [Header("Layout")]
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] Image image;

    [Header("Alls Well")]
    [SerializeField] TraverseEventSO allsWell;
    [SerializeField] int allsWellPencentage = 85;

    [Header("Traverse Events")]
    [SerializeField] List<TraverseEventSO> traverseEventList = new List<TraverseEventSO>();
    
    TraverseEventSO randomTraverseEvent = null;

    TraverseSO traverseAction = null;


    void Start()
    {
        getTraverseEvent();
        displayTraverseAction();
    }

    void getTraverseEvent()
    {
        int randomNum;
        randomNum = Random.Range(1, 101);
        Debug.Log(randomNum.ToString());

        if(randomNum <= allsWellPencentage)
        {
            randomTraverseEvent = allsWell;
            traverseAction = randomTraverseEvent.GetFirstAction();
        }else
        {
            while(randomTraverseEvent == null)
            {
                int randomIndex = Random.Range(0, traverseEventList.Count);
                if(traverseEventList[randomIndex].GetFirstAction().GetWasDrawn() == true && 
                    traverseEventList[randomIndex].GetFirstAction().GetDoesRepeat() == false)
                {
                    Debug.Log("Drawn: " + traverseEventList[randomIndex].GetFirstAction().GetWasDrawn().ToString());
                    Debug.Log("Repeats: " + traverseEventList[randomIndex].GetFirstAction().GetDoesRepeat().ToString());
                    Debug.Log(traverseEventList[randomIndex].GetFirstAction().GetTitle() + " Skipped");

                    break;
                }else
                {
                    Debug.Log("Drawn: " + traverseEventList[randomIndex].GetFirstAction().GetWasDrawn().ToString());
                    Debug.Log("Repeats: " + traverseEventList[randomIndex].GetFirstAction().GetDoesRepeat().ToString());
                    Debug.Log(traverseEventList[randomIndex].GetFirstAction().GetTitle() + " Drawn");

                    traverseEventList[randomIndex].GetFirstAction().SetWasDrawn(true);
                    randomTraverseEvent = traverseEventList[randomIndex];
                }
            }
        }
    }

    void displayTraverseAction()
    {
        title.text = randomTraverseEvent.GetFirstAction().GetTitle();
        description.text = randomTraverseEvent.GetFirstAction().GetDescription();

        if(randomTraverseEvent == allsWell)
        {
            return;                
        }else
        {
            image.sprite = randomTraverseEvent.GetFirstAction().GetImage();
            image.enabled = true;                
        }

    }

}
