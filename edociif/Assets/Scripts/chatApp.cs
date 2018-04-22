using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class chatApp : MonoBehaviour {

	GameObject inputName, setName, chatLog, inputMessage, sendMessage, scrollRect;

	public string senderName;

	public GameObject dataBase,mistakePanel,correctProgress;
	

	// Use this for initialization
	void Start(){
		inputName = gameObject.transform.Find("inputName").gameObject;
		setName = gameObject.transform.Find("setName").gameObject;
		chatLog = gameObject.transform.Find("chatArea/ScrollRect/chatLog").gameObject;
		scrollRect = gameObject.transform.Find("chatArea/ScrollRect").gameObject;
		inputMessage = gameObject.transform.Find("inputMessage").gameObject;
		sendMessage = gameObject.transform.Find("sendMessage").gameObject;


		dataBase=GameObject.Find("EventSystem");
		mistakePanel=gameObject.transform.root.Find("mistakePanel").gameObject;
		correctProgress=gameObject.transform.root.Find("objectiveCounter").gameObject;
		
	}
	
	// Update is called once per frame
	void Update(){
		InputField inputNameField = inputName.GetComponent<InputField>();
		Button setNameButton = setName.GetComponent<Button>();
		Text chatLogText = chatLog.GetComponent<Text>();
		InputField inputMessageField = inputMessage.GetComponent<InputField>();
		Button sendMessageButton = sendMessage.GetComponent<Button>();

		if(inputNameField.text != "" && Input.GetKey(KeyCode.Return)) {
			setNameFunction(inputNameField,chatLogText);
     	}

		if(inputMessageField.text != "" && Input.GetKey(KeyCode.Return)) {
         	sendMessageFunction(inputMessageField,chatLogText);
     	}

		//listeners for button clicks
		setNameButton.onClick.AddListener(delegate{setNameFunction(inputNameField,chatLogText);});
		sendMessageButton.onClick.AddListener(delegate{sendMessageFunction(inputMessageField,chatLogText);});
        //senderName = gameObject.transform.parent.GetComponent<windowProp>().icon.GetComponent<globalName>().Name;
		

    }

	void setNameFunction(InputField inputNameField, Text chatLogText){
		if(inputNameField.text != "") {
            senderName = inputNameField.text;
            chatLogText.text += "\nName changed to: " + senderName;
            inputNameField.text = "";
            //assign the name to this chat window
            gameObject.transform.parent.GetComponent<windowProp>().icon.GetComponent<globalName>().Name = senderName;
            
            //set focus to previous field
            inputNameField.Select();
 			inputNameField.ActivateInputField();
			//update position of scroll area to show latest text
			Canvas.ForceUpdateCanvases();
			scrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
     	}
	}
	void sendMessageFunction(InputField inputMessageField, Text chatLogText){
		if(inputMessageField.text != "") {

			 int number = gameObject.transform.Find("chatArea/ScrollRect/chatLog").gameObject.GetComponent<chatTextUpdater>().dataPosition;
			 if(inputMessageField.text.ToLower().Contains(  dataBase.GetComponent<objectiveGeneratorSearchTask>().theAnswer[number].ToLower()))
			 {
				Debug.Log("correct answer");
				//mistakePanel.GetComponent<mistakeHandler>().mistakeCounter++;
				correctProgress.GetComponent<progressHandler>().incrementNumber();
				gameObject.transform.Find("RequestKiller").gameObject.GetComponent<RequestKiller>().changeList(false);
			 }
			 else
			 {
				mistakePanel.GetComponent<mistakeHandler>().mistakeCounterToModify++;
				Debug.Log("wrong answer");
				//mistakePanel.transform.root.Find("mistakeCounter/mistakeNumber").gameObject.GetComponent<Text>().text="x"+(mistakePanel.GetComponent<mistakeHandler>().mistakesUntilFail-mistakePanel.GetComponent<mistakeHandler>().mistakeCounterToModify);
				gameObject.transform.Find("RequestKiller").gameObject.GetComponent<RequestKiller>().changeList(true);
			 }

         	chatLogText.text += "\n" + senderName + ": " + inputMessageField.text;
         	
			 Debug.Log("comparing "+ inputMessageField.text.ToLower()+" and "+dataBase.GetComponent<objectiveGeneratorSearchTask>().theAnswer[number].ToLower());
			 
			 
			 inputMessageField.text = "";
			//set focus to previous field
			inputMessageField.Select();
 			inputMessageField.ActivateInputField();
			//update position of scroll area to show latest text 
			Canvas.ForceUpdateCanvases();
			scrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;

			



			gameObject.transform.Find("inputMessage").gameObject.SetActive(false);
			
     	}
	}
}
