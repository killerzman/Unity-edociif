using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCountdown : MonoBehaviour {

	public float initialTime;
	public float timeUntilZero;
	public bool isCountingDown; //using this bool to determine if countdown should still run
	public bool punishByGameOver = false; //using this bool to determine the punishment for reaching 0 on the countdown
	public Text timeText;
	bool coroutineStarted = false; //using this bool if a countdown coroutine has already started so multiple coroutines can't be run
	bool flagForTimeUntil0 = false; //using this bool to determine if time has reached 0 for correct mistake handling

	void Awake(){ //using awake for correct countdown handling
		timeUntilZero = initialTime;
		StartCoroutine(countdown());
		coroutineStarted = true;
	}

	void Update(){
		if(coroutineStarted == false){
			if(isCountingDown == true){
				//starting countdown and setting a bool to reflect that
				StartCoroutine(countdown());
				coroutineStarted = true;
			}
		}
		if(timeUntilZero <= 0){
			if(punishByGameOver == true && flagForTimeUntil0 == false){
				//game over
				GameObject.Find("mistakePanel").GetComponent<mistakeHandler>().mistakeCounterToModify =
				GameObject.Find("mistakePanel").GetComponent<mistakeHandler>().mistakesUntilFail;
				flagForTimeUntil0 = true;
			}
			else if(punishByGameOver == false && flagForTimeUntil0 == false){
				//increase the mistake counter
				GameObject.Find("mistakePanel").GetComponent<mistakeHandler>().mistakeCounterToModify++;
				flagForTimeUntil0 = true;
			}
		}
		try{
			if(timeUntilZero > 0){
				//show time left if time > 0
				timeText.text = ((int)timeUntilZero).ToString();
			}
			else{
				timeText.text = "";
			}
		}
		catch{}
	}

	//public functions for adding, getting, setting time, pausing and resuming the countdown
	public void addTime(float t){
		timeUntilZero += t;
	}

	public float getTime(){
		return timeUntilZero;
	}

	public void setTime(float t){
		timeUntilZero = t;
	}

	public void stopCountdown(){
		isCountingDown = false;
	}

	public void startCountdown(){
		isCountingDown = true;
	}

	public void toggleCountdown(){
		if(isCountingDown){
			isCountingDown = false;
		}
		else isCountingDown = true;
	}

	IEnumerator countdown(){
		while(timeUntilZero > 0 && isCountingDown == true){
			timeUntilZero -= Time.deltaTime;
			yield return null;
		}
		//if time reaches 0 or the counting down bool is set to false, stop the coroutine and reflect that in coroutineStarted
		coroutineStarted = false;
	}
}
