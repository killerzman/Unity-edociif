using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gatherContacts : MonoBehaviour {

    public GameObject prefabInstance;
    public GameObject infoSource;
    public int nrOfContacts;

    public GameObject avatarRef;
    public GameObject nameRef;
    public GameObject statusRef;

	// Use this for initialization
	void Start () 
    {
        infoSource = gameObject.transform.root.Find("CONTACT_DATA").gameObject;

        nrOfContacts = infoSource.GetComponent<assignFriends>().nameList.Length;
        for(int i=0;i<nrOfContacts;i++)
        {
            GameObject createdObj=(GameObject)Instantiate(prefabInstance,gameObject.transform.position,gameObject.transform.rotation,gameObject.transform);
            
            //avatarRef = createdObj.transform.Find("iconText").gameObject;
            nameRef = createdObj.transform.Find("userName").gameObject;
            statusRef = createdObj.transform.Find("userStatus").gameObject; 

            nameRef.GetComponent<Text>().text=infoSource.GetComponent<assignFriends>().nameList[i];
            statusRef.GetComponent<Text>().text=infoSource.GetComponent<assignFriends>().statusList[i];
        }
        

        //Debug.Log(nrOfContacts + "  ws");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
