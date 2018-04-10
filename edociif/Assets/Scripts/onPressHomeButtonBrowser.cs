using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onPressHomeButtonBrowser : MonoBehaviour {

    GameObject presetToDisable;

	Button btn;

	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(disablePreset);
	}
	
	public void setSitePreset(GameObject obj){
		presetToDisable = obj;
	}

	void disablePreset(){
		presetToDisable.GetComponent<CanvasGroup>().alpha = 0;
		presetToDisable.GetComponent<CanvasGroup>().interactable = false;
		presetToDisable.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

}
