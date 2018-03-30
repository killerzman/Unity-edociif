using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class chatApp : MonoBehaviour {

	GameObject inputName, setName, chatLog, inputMessage, sendMessage, scrollRect;

	public String senderName;

	// Use this for initialization
	void Start(){
		inputName = gameObject.transform.Find("inputName").gameObject;
		setName = gameObject.transform.Find("setName").gameObject;
		chatLog = gameObject.transform.Find("chatArea/ScrollRect/chatLog").gameObject;
		scrollRect = gameObject.transform.Find("chatArea/ScrollRect").gameObject;
		inputMessage = gameObject.transform.Find("inputMessage").gameObject;
		sendMessage = gameObject.transform.Find("sendMessage").gameObject;
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
	}

	void setNameFunction(InputField inputNameField, Text chatLogText){
		if(inputNameField.text != "") {
			senderName = inputNameField.text;
         	chatLogText.text += "\nName changed to: " + senderName;
         	inputNameField.text = "";
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
         	chatLogText.text += "\n" + senderName + ": " + inputMessageField.text;
         	inputMessageField.text = "";
			//set focus to previous field
			inputMessageField.Select();
 			inputMessageField.ActivateInputField();
			//update position of scroll area to show latest text 
			Canvas.ForceUpdateCanvases();
			scrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
     	}
	}
}
