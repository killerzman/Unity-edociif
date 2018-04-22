using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class antivirusUpdater : MonoBehaviour {

    public int antivirusNumber;
    public GameObject referenceLogic;

    antivirusInterrogation aI;
    Type typeaI;

    GameObject theSecureIcon;
    GameObject theAntivirusIcon1;
    GameObject theAntivirusIcon2;
    GameObject theResponseIcon1;
    GameObject theResponseIcon2;

    GameObject trojanButton;
    GameObject wormButton;
    GameObject ignoreButton;

    GameObject theText;

    GameObject objectiveReference;
    //GameObject timeReference;

    GameObject mistakeReference;

    // Use this for initialization


    void buttonPress(int emergencyNumber)
    {   
        if(!referenceLogic.GetComponent<antivirusInterrogation>().lies[antivirusNumber-1])
        {
            if(emergencyNumber==referenceLogic.GetComponent<antivirusInterrogation>().virusType)
                {
                    objectiveReference.GetComponent<progressHandler>().incrementNumber();
                    
                }
        }
        else
        mistakeReference.GetComponent<mistakeHandler>().mistakeCounterToModify++;

        referenceLogic.GetComponent<antivirusInterrogation>().generateVirus();

    }

    void Start(){
        theSecureIcon = gameObject.transform.Find("windowContent/secureStatus").gameObject;
        referenceLogic = GameObject.Find("EventSystem");
        theAntivirusIcon1 = gameObject.transform.Find("windowContent/interrogationPanel/response1/icon1").gameObject;
        theAntivirusIcon2 = gameObject.transform.Find("windowContent/interrogationPanel/response1/icon2").gameObject;
        theResponseIcon1 = gameObject.transform.Find("windowContent/interrogationPanel/response2/icon1").gameObject;
        theResponseIcon2 = gameObject.transform.Find("windowContent/interrogationPanel/response2/icon2").gameObject;
        theText= gameObject.transform.Find("windowContent/Text").gameObject;

        trojanButton= gameObject.transform.Find("windowContent/trojanMethodButton").gameObject;
        wormButton= gameObject.transform.Find("windowContent/wormMethodButton").gameObject;
        ignoreButton= gameObject.transform.Find("windowContent/ignoreMethod").gameObject;

        objectiveReference=gameObject.transform.root.transform.Find("objectiveCounter").gameObject;
        mistakeReference=gameObject.transform.root.transform.Find("mistakePanel").gameObject;
        //timeReference=gameObject.transform.root.transform.Find("countdownObject").gameObject;

    }

    void Update(){

        trojanButton.GetComponent<Button>().onClick.RemoveAllListeners();
        trojanButton.GetComponent<Button>().onClick.AddListener(delegate{buttonPress(2);});

        wormButton.GetComponent<Button>().onClick.RemoveAllListeners();
        wormButton.GetComponent<Button>().onClick.AddListener(delegate{buttonPress(1);});

        ignoreButton.GetComponent<Button>().onClick.RemoveAllListeners();
        ignoreButton.GetComponent<Button>().onClick.AddListener(delegate{buttonPress(0);});

        theSecureIcon.GetComponent<Image>().sprite = referenceLogic.GetComponent<antivirusInterrogation>().theSprites[antivirusNumber-1];
        theAntivirusIcon1.GetComponent<Image>().sprite = referenceLogic.GetComponent<antivirusInterrogation>().theResponseIcon1[antivirusNumber - 1];
        theAntivirusIcon2.GetComponent<Image>().sprite = referenceLogic.GetComponent<antivirusInterrogation>().theResponseIcon2[antivirusNumber - 1];
        theResponseIcon1.GetComponent<Image>().sprite = referenceLogic.GetComponent<antivirusInterrogation>().theResponseIcon3[antivirusNumber - 1];
        theResponseIcon2.GetComponent<Image>().sprite = referenceLogic.GetComponent<antivirusInterrogation>().theResponseIcon4[antivirusNumber - 1];

        switch(referenceLogic.GetComponent<antivirusInterrogation>().systType[antivirusNumber-1])
        {
            case 0: theText.GetComponent<Text>().text = "Secure";break;
            case 1: theText.GetComponent<Text>().text = "Worm detected!"; break;
            case 2: theText.GetComponent<Text>().text = "Trojan found!"; break;
        }



        /*bool lie = referenceLogic.GetComponent<antivirusInterrogation>().lies[antivirusNumber-1];
         if (lie)
             if (referenceLogic.GetComponent<antivirusInterrogation>().virusType == 0)
             {
                 theSecureIcon.GetComponent<Image>().sprite = referenceLogic.GetComponent<antivirusInterrogation>().insecureIcon;
             }
             else theSecureIcon.GetComponent<Image>().sprite = referenceLogic.GetComponent<antivirusInterrogation>().secureIcon;

         else
             if (referenceLogic.GetComponent<antivirusInterrogation>().virusType == 0)
             { 
                 theSecureIcon.GetComponent<Image>().sprite = referenceLogic.GetComponent<antivirusInterrogation>().secureIcon; 
             }
             else theSecureIcon.GetComponent<Image>().sprite = referenceLogic.GetComponent<antivirusInterrogation>().insecureIcon;*/

    }
	
}
