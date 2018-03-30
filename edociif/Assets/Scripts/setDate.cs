using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setDate : MonoBehaviour {

	public Text textDate;
	
	// Update is called once per frame
	void Update(){
		textDate.text = DateTime.Now.ToString("dd/MM/yyyy");
	}
}
