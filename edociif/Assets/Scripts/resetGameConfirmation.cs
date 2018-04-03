using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class resetGameConfirmation : MonoBehaviour {

	Button btn;

	GameObject confirmationObj;

	Text resetText;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		confirmationObj = GameObject.Find("confirmation");
		resetText = GameObject.Find("resetGameText").GetComponent<Text>();
		btn.onClick.AddListener(onConfirmation);
	}
	
	void onConfirmation(){
		btn.GetComponent<Image>().enabled = false;
		btn.GetComponent<Button>().enabled = false;
		resetText.enabled = false;
		confirmationObj.GetComponent<CanvasGroup>().alpha = 1;
        confirmationObj.GetComponent<CanvasGroup>().interactable = true;
        confirmationObj.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
