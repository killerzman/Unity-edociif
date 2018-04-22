using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressHandler : MonoBehaviour {

	// Use this for initialization
	public int numberToWin, startNumber=0, timeAddedPerCorrect=30; 
	public GameObject textChanger;
	public GameObject winObject;
	public GameObject clockObject;

	public void incrementNumber()
	{
		startNumber++;
		textChanger.GetComponent<Text>().text=startNumber+"/"+numberToWin;
		clockObject.GetComponent<timeCountdown>().timeUntilZero+=timeAddedPerCorrect;
		if(numberToWin==startNumber)
		{
			winObject.GetComponent<levelWin>().hasLevelBeenWon=true;
		}
	}

	void Start()
	{
		textChanger=gameObject.transform.Find("correctNumber").gameObject;
		winObject=gameObject.transform.parent.gameObject.transform.Find("winObject").gameObject;
		clockObject=gameObject.transform.parent.gameObject.transform.Find("countdownObject").gameObject;
		textChanger.GetComponent<Text>().text=startNumber+"/"+numberToWin;
	}
}
