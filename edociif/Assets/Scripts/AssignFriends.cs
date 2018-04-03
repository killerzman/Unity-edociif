using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignFriends : MonoBehaviour {
    public GameObject windowReference, iconReference;
    public GameObject Friend1, Friend2, Friend3;
    private GameObject Friend;
    public string Name="Default";
    private string Name1,Name2,Name3;
    // Use this for initialization
    void Start () {
        //initiate the friend list with windowReference and iconReference
        Friend1.GetComponent<createWindow>().windowReference = windowReference;
        Friend1.GetComponent<createWindow>().iconReference = iconReference;
        Friend2.GetComponent<createWindow>().windowReference = windowReference;
        Friend2.GetComponent<createWindow>().iconReference = iconReference;
        Friend3.GetComponent<createWindow>().windowReference = windowReference;
        Friend3.GetComponent<createWindow>().iconReference = iconReference;
    }
    private void Update()
    {
        Name1 = Friend1.GetComponent<globalName>().Name;
        Name2 = Friend2.GetComponent<globalName>().Name;
        Name3 = Friend3.GetComponent<globalName>().Name;
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
        Friend1.GetComponent<globalName>().Name=Name;
        Friend2.GetComponent<globalName>().Name=Name;
        Friend3.GetComponent<globalName>().Name=Name;
    }

}
