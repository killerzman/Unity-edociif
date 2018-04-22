using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickInstructions : MonoBehaviour {

	
	public GameObject containerPanel;
	public Button btn;
	public Text txt;
	public bool isTurnedOn = true;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(togglePanel);
	}
	
	void togglePanel(){
		if(isTurnedOn){
			btn.transform.Rotate(new Vector3(0,0,180));
			containerPanel.GetComponent<Image>().enabled = false;
			txt.enabled = false;
			isTurnedOn = false;
		}
		else{
			btn.transform.Rotate(new Vector3(0,0,-180));
			containerPanel.GetComponent<Image>().enabled = true;
			txt.enabled = true;
			isTurnedOn = true;
		}
	}
}
