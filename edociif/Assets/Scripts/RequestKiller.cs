using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestKiller : MonoBehaviour {

	// Use this for initialization
	public GameObject contactManipulator;
	
	void Start()
	{
		contactManipulator=gameObject.transform.root.Find("CONTACT_DATA").gameObject.GetComponent<assignFriends>().additionalDataReference;
	}
	void changeList()
	{
		gameObject.transform.parent.Find("chatArea/ScrollRect/chatLog").gameObject.GetComponent<chatTextUpdater>().allowUpdate=false;
		contactManipulator.GetComponent<objectiveGeneratorSearchTask>().SpawnAdditionalContact(gameObject.transform.parent.Find("chatArea/ScrollRect/chatLog").gameObject.GetComponent<chatTextUpdater>().dataPosition);
		
		Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<windowProp>().referenceTaskbarSlot);
		Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
		gameObject.GetComponent<Button>().onClick.AddListener(changeList);
	}
}
