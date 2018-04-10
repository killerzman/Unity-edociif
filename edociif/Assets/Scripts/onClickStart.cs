using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickStart : MonoBehaviour {

	public bool isStartOpened = false;
	GameObject menu;
	// Use this for initialization
	void Start () {
		Button btn = gameObject.GetComponent<Button>();
		menu = gameObject.transform.Find("startMenu").gameObject;
		//closing start menu at the start
		hideOrShowObject(menu, 0, false, false);
		btn.onClick.AddListener(clickStart);
	}
	
	void clickStart(){
		if(isStartOpened == false){
			//show the menu when it hasn't been opened yet
			hideOrShowObject(menu, 1, true, true);
			isStartOpened = true;
		}
		else{
			//close the menu when it's already opened
			hideOrShowObject(menu, 0, false, false);
			isStartOpened = false;
		}
	}

	void hideOrShowObject(GameObject obj, int alphaValue, bool interactable, bool blocksRaycasts){
		//setting visibility/interactability depending on the situation
		obj.GetComponent<CanvasGroup>().alpha = alphaValue;
		obj.GetComponent<CanvasGroup>().interactable = interactable;
		obj.GetComponent<CanvasGroup>().blocksRaycasts = blocksRaycasts;
	}
}
