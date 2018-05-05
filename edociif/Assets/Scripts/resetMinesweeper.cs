using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetMinesweeper : MonoBehaviour {

	Button btn;

	public Sprite happyReset, sadReset, coolReset;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(resetGame);
	}

	void Update(){
		if(GameObject.Find("table").GetComponent<tableSpawner>().isGameOver){
			gameObject.GetComponent<Image>().sprite = sadReset;
		}
		if(GameObject.Find("table").GetComponent<tableSpawner>().isGameWon){
			gameObject.GetComponent<Image>().sprite = coolReset;
		}
	}

	void resetGame(){
		GameObject.Find("table").GetComponent<tableSpawner>().enabled = false;
		GameObject.Find("table").GetComponent<tableSpawner>().enabled = true;
		GameObject.Find("time").GetComponent<timeMinesweeper>().timer = 0;
		gameObject.GetComponent<Image>().sprite = happyReset;
	}
	
}
