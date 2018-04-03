using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quitAppByButton : MonoBehaviour {

	Button btn;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(quitApp);
	}
	
	void quitApp(){
		Application.Quit();
	}
}
