using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignFriends : MonoBehaviour {
    public GameObject windowReference, iconReference;
    public GameObject Friend1, Friend2, Friend3;
    private GameObject Friend;
    public string Name="Default";
    private string Name1,Name2,Name3;

    void Start () {
        //initiate the friend list with windowReference and iconReference
        //Friend 1
        Friend1.GetComponent<createWindow>().windowReference = windowReference;
        Friend1.GetComponent<createWindow>().iconReference = iconReference;
        //Friend 2
        Friend2.GetComponent<createWindow>().windowReference = windowReference;
        Friend2.GetComponent<createWindow>().iconReference = iconReference;
        //Friend 3
        Friend3.GetComponent<createWindow>().windowReference = windowReference;
        Friend3.GetComponent<createWindow>().iconReference = iconReference;
    }
    private void Update()
    {
        //get the names from each chat window
        Name1 = Friend1.GetComponent<globalName>().Name;
        Name2 = Friend2.GetComponent<globalName>().Name;
        Name3 = Friend3.GetComponent<globalName>().Name;
        //check if one name was changed in one of the chat windows
        if (Name1 != Name)
            Name = Name1;
        else
        {
            if (Name2 != Name)
                Name = Name2;
            else
                 if (Name3 != Name)
                     Name = Name3;
        }    
        //assign the name to each chat window ( in case it was not chaned, this won't do anything)
        Friend1.GetComponent<globalName>().Name=Name;
        Friend2.GetComponent<globalName>().Name=Name;
        Friend3.GetComponent<globalName>().Name=Name;
    }

}
