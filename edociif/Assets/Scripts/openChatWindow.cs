using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openChatWindow : MonoBehaviour {

	// Use this for initialization
	public GameObject chatWindowPrefab;

	public GameObject windowTabReference;
	
	public GameObject windowName;
	public GameObject theText;

	public GameObject windowref;//to only allow one instance
	public int dataPosition; //for the backup purposes


	public GameObject taskbarRef;
	public GameObject prefabTaskbar;
	public void CreateWindow()
	{
		if(windowref==null)
		{Vector3 zeroPos=Vector3.zero;
		GameObject theTaskBarIcon=Instantiate(prefabTaskbar);
		
		
		theTaskBarIcon.transform.SetParent(taskbarRef.transform);

		GameObject theWindow=Instantiate(chatWindowPrefab, gameObject.transform.parent.position,gameObject.transform.rotation,windowTabReference.transform);
		//theWindow.transform.position=Vector3.zero;
		
		theWindow.GetComponent<windowProp>().referenceTaskbarSlot=theTaskBarIcon;
		theTaskBarIcon.GetComponent<openWindow>().windowObj=theWindow;
		windowName=theWindow.transform.Find("windowName").gameObject;
		windowName.GetComponent<Text>().text="Talk Time - "+gameObject.transform.Find("userName").GetComponent<Text>().text;
		//windowName.transform.parent=windowTabReference.transform;
		
		GameObject chatLog= theWindow.transform.Find("windowContent/chatArea/ScrollRect/chatLog").gameObject;
		//Debug.Log(chatLog.name);
		chatLog.GetComponent<chatTextUpdater>().dataPosition=dataPosition;
		//theWindow.GetComponent<windowProp>().windowIcon=gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<windowProp>().windowIcon;
		windowName.GetComponent<Text>().text="Talk Time - "+gameObject.transform.Find("userName").GetComponent<Text>().text;	
		
		windowref=theWindow;

		//theWindow.GetComponent<windowProp>().
		}
	}

	void Start () {
	gameObject.GetComponent<Button>().onClick.AddListener(CreateWindow);
	windowTabReference=gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
	taskbarRef=gameObject.transform.root.Find( "Screen/taskbar/windowIcons").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.parent.GetComponent<gatherContacts>().infoSource.GetComponent<assignFriends>().chatTextBackup[dataPosition]=gameObjec;
	}
}
