using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chatTextUpdater : MonoBehaviour {

	public int dataPosition;
	public GameObject infoSource;
	public bool allowUpdate=true;


	Text theText;

	// Use this for initialization
	void Start(){
		theText=gameObject.GetComponent<Text>();
		infoSource=gameObject.transform.root.Find("CONTACT_DATA").gameObject;
		
		
		theText.text=infoSource.GetComponent<assignFriends>().chatTextBackup[dataPosition];
		//theText.text=infoSource.GetComponent<assignFriends>().chatTextBackup[dataPosition].text;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(allowUpdate)
		infoSource.GetComponent<assignFriends>().chatTextBackup[dataPosition]=theText.text;
		

	}
}
