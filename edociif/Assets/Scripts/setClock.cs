using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setClock : MonoBehaviour {

	//array of sprites for numbers 0-9
	public Sprite[] sprites = new Sprite[10];

	GameObject Hour0, Hour1, Minute0, Minute1;

	// Use this for initialization
	void Start(){
		Hour0 = gameObject.transform.Find("Hour0").gameObject;
		Hour1 = gameObject.transform.Find("Hour1").gameObject;
		Minute0 = gameObject.transform.Find("Minute0").gameObject;
		Minute1 = gameObject.transform.Find("Minute1").gameObject;
	}
	
	// Update is called once per frame
	void Update(){
		//assign each digit the current time
		//ex: 23:40 h0 = 2, h1 = 3, m0 = 4, m1 = 0
		int h0 = int.Parse(DateTime.Now.ToString("HH"))/10;
		int h1 = int.Parse(DateTime.Now.ToString("HH"))%10;
		int m0 = int.Parse(DateTime.Now.ToString("mm"))/10;
		int m1 = int.Parse(DateTime.Now.ToString("mm"))%10;
		//assign sprite from the array of sprites according to each digit
		Hour0.GetComponent<Image>().sprite = sprites[h0];
		Hour1.GetComponent<Image>().sprite = sprites[h1];
		Minute0.GetComponent<Image>().sprite = sprites[m0];
		Minute1.GetComponent<Image>().sprite = sprites[m1];
	}
}
