using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeMinesweeper : MonoBehaviour {

	public Text text;

	public float timer = 0;

	public bool isCountingDown;

	bool coroutineStarted = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(timerFunc());
		coroutineStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
		isCountingDown = !GameObject.Find("table").GetComponent<tableSpawner>().firstClick &&
						!GameObject.Find("table").GetComponent<tableSpawner>().isGameOver;
		if(coroutineStarted == false){
			if(isCountingDown == true){
				//starting countdown and setting a bool to reflect that
				StartCoroutine(timerFunc());
				coroutineStarted = true;
			}
		}
		if(timer >= 1000)
			timer = 999;
		text.text = ((int)timer).ToString();
	}

	IEnumerator timerFunc(){
		while(isCountingDown){
			timer += Time.deltaTime;
			yield return null;
		}
		coroutineStarted = false;
	}
}
