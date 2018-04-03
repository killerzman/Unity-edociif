using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetAndPressNo : MonoBehaviour {

	Button btn;

	GameObject confirmationObj, resetGameButton;

	Text resetText;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		confirmationObj = GameObject.Find("confirmation").gameObject;
		resetText = GameObject.Find("resetGameText").GetComponent<Text>();
		resetGameButton = GameObject.Find("resetGameButton").gameObject;
		btn.onClick.AddListener(onNo);
	}
	
	// Update is called once per frame
	void onNo(){
		resetGameButton.GetComponent<Image>().enabled = true;
		resetGameButton.GetComponent<Button>().enabled = true;
		resetText.enabled = true;
		confirmationObj.GetComponent<CanvasGroup>().alpha = 0;
        confirmationObj.GetComponent<CanvasGroup>().interactable = false;
        confirmationObj.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
}
