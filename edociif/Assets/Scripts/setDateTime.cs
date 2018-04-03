using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setDateTime : MonoBehaviour {

	public Text textDateTime;
	
	// Update is called once per frame
	void Update(){
		textDateTime.text = DateTime.Now.ToString("HH:mm") + "\n" + DateTime.Now.ToString("dd/MM/yyyy");
	}
}
