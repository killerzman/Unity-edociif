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

    GameObject theText;

    // Use this for initialization
    void Start(){
        theSecureIcon = gameObject.transform.Find("windowContent/secureStatus").gameObject;
        referenceLogic = GameObject.Find("EventSystem");
        theAntivirusIcon1 = gameObject.transform.Find("windowContent/interrogationPanel/response1/icon1").gameObject;
        theAntivirusIcon2 = gameObject.transform.Find("windowContent/interrogationPanel/response1/icon2").gameObject;
        theResponseIcon1 = gameObject.transform.Find("windowContent/interrogationPanel/response2/icon1").gameObject;
        theResponseIcon2 = gameObject.transform.Find("windowContent/interrogationPanel/response2/icon2").gameObject;
        theText= gameObject.transform.Find("windowContent/Text").gameObject;
    }

    void Update(){

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
