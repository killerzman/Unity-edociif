using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assignFriends : MonoBehaviour {
    public GameObject additionalDataReference;
    public GameObject windowReference, iconReference;
    public GameObject Friend1, Friend2, Friend3;
    private GameObject Friend;
    public string Name = "Default";
    private string Name1, Name2, Name3;

    public string[] nameList = new string[] { };
    public int[] reqType = new int[] { };
    public string[] statusList = new string[] { };
    public bool[] requestGiver=new bool[]{ };

    public string[] chatTextBackup= new string[]{ };

    public GameObject prefabContact;

    public bool refreshList=true;
    
}
