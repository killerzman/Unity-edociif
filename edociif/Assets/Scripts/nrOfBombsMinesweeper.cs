using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nrOfBombsMinesweeper : MonoBehaviour {

	int nrOfBombs;
	public Text text;

	// Use this for initialization
	void Start () {
		nrOfBombs = GameObject.Find("table").GetComponent<tableSpawner>().bombNumber;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = nrOfBombs.ToString();
	}
}
