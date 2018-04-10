using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onPressDefaultSites : MonoBehaviour {

	public Button goToSiteButton;
	public GameObject sitePreset;

	onPressHomeButtonBrowser set;

	// Use this for initialization
	void Start () {
		set = FindObjectOfType<onPressHomeButtonBrowser>();
		goToSiteButton.onClick.AddListener(openPreset);
	}

	void openPreset(){
		sitePreset.GetComponent<CanvasGroup>().alpha = 1;
		sitePreset.GetComponent<CanvasGroup>().interactable = true;
		sitePreset.GetComponent<CanvasGroup>().blocksRaycasts = true;
		set.setSitePreset(sitePreset);
	}
}
