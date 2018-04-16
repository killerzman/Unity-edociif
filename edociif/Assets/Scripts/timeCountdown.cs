using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeCountdown : MonoBehaviour {

	public float initialTime;
	public float timeUntilZero;
	public bool isCountingDown;
	bool coroutineStarted = false;

	void Awake(){
		timeUntilZero = initialTime;
		StartCoroutine(countdown());
		coroutineStarted = true;
	}

	void Update(){
		if(coroutineStarted == false){
			if(isCountingDown == true){
				StartCoroutine(countdown());
				coroutineStarted = true;
			}
		}
	}

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
		coroutineStarted = false;
	}
}
