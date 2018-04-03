using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class createWindow : MonoBehaviour, IPointerDownHandler {

	public GameObject windowPrefab, iconPrefab;
    public GameObject windowReference, iconReference;
    public bool isUnique, resizeable = true,talkapp=false;
    GameObject textReference;
    bool initialpress = false;
    public int duplicates=0;
    private GameObject Fl;

    void Start()
    {
        textReference = gameObject.transform.Find("iconText").gameObject;
        
    }

    void Update()
    {
        if(resizeable)
          gameObject.transform.localScale = new Vector2((float)Screen.height / 1200, (float)Screen.height / 1200);
    }
    public IEnumerator countdown()          //time limit for a successful double click
    {
        yield return new WaitForSeconds(0.5f);
        initialpress = false;
    }

    public void OnPointerDown(PointerEventData eventData)       //on click
    {
        if (!initialpress)                  //register first click
        {
            initialpress = true;
            StartCoroutine(countdown());    //start countdown
        }

        else
        {
            if ((isUnique == true && duplicates == 0) || isUnique == false)
            { 
                GameObject windowClone = (GameObject)Instantiate(windowPrefab);     //create the window and save the reference
                windowClone.transform.localScale = new Vector2((float)Screen.height / 600, (float)Screen.height / 600);
                windowClone.transform.SetParent(windowReference.transform, false);   //assign it to parent
                windowClone.transform.localPosition = new Vector2(0, 0);

                GameObject iconClone = (GameObject)Instantiate(iconPrefab);     //create the icon and save the reference 
                iconClone.transform.SetParent(iconReference.transform, false);   //assign the icon to parent

                windowClone.GetComponent<windowProp>().windowName = textReference.GetComponent<Text>().text; //set window title
                windowClone.GetComponent<windowProp>().windowIcon = gameObject.GetComponent<Image>().sprite; //set window icon
                windowClone.GetComponent<windowProp>().referenceTaskbarSlot = iconClone; //initiate taskbar slot and keep reference
                windowClone.GetComponent<windowProp>().isMinimized = false;
                windowClone.GetComponent<windowProp>().icon = this.gameObject;
                iconClone.transform.GetComponent<openWindow>().windowObj = windowClone; //set windoe reference inside taskbar slot

                iconClone.transform.Find("taskbarIconFrame").gameObject.GetComponent<Image>().sprite = windowClone.GetComponent<windowProp>().windowIcon; //set taskbar icon

                if(talkapp)
                {
                    //Fl=Friend list
                    Fl = windowClone.transform.Find("windowContent").gameObject.transform.Find("FriendList").gameObject;
                    Fl.GetComponent<AssignFriends>().windowReference = windowReference;
                    Fl.GetComponent<AssignFriends>().iconReference = iconReference;
                }
                duplicates++;
            }
        }
    }
		
}
