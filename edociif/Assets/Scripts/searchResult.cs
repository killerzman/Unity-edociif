using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class searchResult : MonoBehaviour {

	public GameObject urlBar;
	public GameObject urlButton;

	public string sitename;
	public string domain;
	public string pagename;


	public void executeCode()
	{
		Debug.Log("mere");
		if(sitename!="" && domain!="" && pagename=="")
		{
		urlBar.GetComponent<InputField>().text=sitename+domain;
		urlButton.GetComponent<searchFunction>().parseText();
		}
		if(pagename!=""&&sitename!=""&& domain=="")
		{
		urlButton.GetComponent<searchFunction>().openNewSetOfSuggestions(pagename, sitename);
		}
		if(sitename!="" && domain!="" && pagename!="")
		{
		urlBar.GetComponent<InputField>().text=sitename+domain+"/"+pagename;
		urlButton.GetComponent<searchFunction>().parseText();
		}
		
		
		Debug.Log(sitename+domain);
		
	}

	// Use this for initialization
	void Start () {
		urlBar=gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("header/urlBar").gameObject;
		urlButton=gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("header/urlBar/Button").gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
		gameObject.GetComponent<Button>().onClick.AddListener(executeCode);
	}
}
