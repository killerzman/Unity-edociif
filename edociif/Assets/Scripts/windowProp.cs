using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[ExecuteInEditMode]

public class windowProp : MonoBehaviour{

    public Color borderColor = new Color(0,85,234);
    public int windowWidth = 400;
    public int windowHeight = 300;
    public int barHeight = 30;
    public bool barless = false;
    public Sprite barImage, windowIcon;
    public string windowName;
    public bool isMinimized = false;

    GameObject theBar;
    GameObject theWindowContent;
    GameObject theWindowBorder;
    GameObject theIcon;
    GameObject theName;
    GameObject theButtonMinimize;
    GameObject theButtonClose;

    //to not be allocated below
    public GameObject referenceTaskbarSlot;



    // Use this for initialization
    void Start () {
        theBar = gameObject.transform.Find("windowBar").gameObject;                                             //searching for the children for future reference
        theWindowContent = gameObject.transform.Find("windowContent").gameObject;
        theWindowBorder = gameObject.transform.Find("windowBorder").gameObject;
        theIcon = gameObject.transform.Find("windowIcon").gameObject;
        theName = gameObject.transform.Find("windowName").gameObject;
        theButtonMinimize = gameObject.transform.Find("windowButtonMinimize").gameObject;
        theButtonClose = gameObject.transform.Find("windowButtonClose").gameObject;



    }
	
	// Update is called once per frame
	void Update () {
        theWindowContent.GetComponent<RectTransform>().sizeDelta = new Vector2(windowWidth,windowHeight); //setting dynamically the size of the window

        if (gameObject.transform.GetSiblingIndex() + 1 == gameObject.transform.parent.childCount)         //handler for focus priority
        {
            theWindowBorder.SetActive(true);
            
            if(!isMinimized)
                referenceTaskbarSlot.transform.Find("taskbarFocus").gameObject.SetActive(true);
            else
                referenceTaskbarSlot.transform.Find("taskbarFocus").gameObject.SetActive(false);
        }
        else
        { 
            theWindowBorder.SetActive(false);
            referenceTaskbarSlot.transform.Find("taskbarFocus").gameObject.SetActive(false);
        }


        if (!barless){
            theBar.GetComponent<RectTransform>().sizeDelta = new Vector2(windowWidth+8, barHeight);                     //bar builder
            theBar.SetActive(true);
            theBar.GetComponent<Image>().sprite = barImage;
            theBar.GetComponent<Image>().color = borderColor;

            theIcon.GetComponent<RectTransform>().localPosition = new Vector2(-windowWidth/2+15,barHeight/2);           
            theIcon.SetActive(true);
            theIcon.GetComponent<Image>().sprite = windowIcon;

            theName.GetComponent<RectTransform>().localPosition = new Vector2(-windowWidth/2+35,barHeight/2);
            theName.SetActive(true);
            theName.GetComponent<Text>().text = windowName;

            theButtonMinimize.GetComponent<RectTransform>().localPosition = new Vector2(windowWidth/2 - 35,barHeight/2);
            theButtonMinimize.SetActive(true);

            theButtonClose.GetComponent<RectTransform>().localPosition = new Vector2(windowWidth/2+2, barHeight/2);
            theButtonClose.SetActive(true);
        }
        else{
            theBar.SetActive(false);
            theIcon.SetActive(false);
            theName.SetActive(false);
            theButtonMinimize.SetActive(false);
            theButtonClose.SetActive(false);
        }
        if(!isMinimized){                                                                   //turns window invisible and turns off input when minimized
            gameObject.GetComponent<CanvasGroup>().alpha = 1;
            gameObject.GetComponent<CanvasGroup>().interactable = true;
            gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
            referenceTaskbarSlot.transform.localScale = new Vector2(1, 1);                  //shrinks taskbar icon
        }
        else{
            gameObject.GetComponent<CanvasGroup>().alpha = 0;
            gameObject.GetComponent<CanvasGroup>().interactable = false;
            gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
            referenceTaskbarSlot.transform.localScale = new Vector2(0.75f, 0.75f);
        }
        theWindowBorder.GetComponent<RectTransform>().sizeDelta= new Vector2(windowWidth+8, windowHeight+8);  //border builder
        theWindowBorder.GetComponent<Image>().color = borderColor;

        
    }

}
