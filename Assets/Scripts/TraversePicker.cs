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
        int randomIndex = Random.Range(0, traverseList.Count);
        randomTraverseAction = traverseList[randomIndex];
    }

    void displayTravereAction()
    {
        title.text = randomTraverseAction.getTitle();
        description.text = randomTraverseAction.getDescription();
        image.sprite = randomTraverseAction.getImage();

    }

}
