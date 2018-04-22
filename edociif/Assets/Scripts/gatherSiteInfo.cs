using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatherSiteInfo : MonoBehaviour {

	// Use this for initialization
	public GameObject SITE_INFO;

	public bool displaySite = false;

	public GameObject siteTitle;
	public GameObject siteDesc;

	public GameObject shownSite;

	public GameObject sitePrefab1;
	public GameObject sitePrefab2;
	public GameObject sitePrefab3;
	public GameObject sitePrefab4;
	public GameObject sitePrefab5;
	public GameObject sitePrefab6;
	
	void Start () {
		SITE_INFO=GameObject.Find("EventSystem");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
