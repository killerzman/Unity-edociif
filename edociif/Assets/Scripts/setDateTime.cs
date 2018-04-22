using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setDateTime : MonoBehaviour {

	public Text textDateTime;
	public bool newLineBetweenDateAndTime = true;
	
	// Update is called once per frame
	void Update(){
		if(newLineBetweenDateAndTime){
			textDateTime.text = DateTime.Now.ToString("HH:mm") + "\n" + DateTime.Now.ToString("dd/MM/yyyy");
		}
		else{
			textDateTime.text = DateTime.Now.ToString("HH:mm") + " " + DateTime.Now.ToString("dd/MM/yyyy");
		}
	}
}
