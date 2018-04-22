using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class onClickPlaySound : MonoBehaviour {

	EventSystem system;
	public AudioSource audioL; 
    public AudioSource audioR;
    public AudioSource audioM;

	void Start(){
        system = EventSystem.current;
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){ //l-click
            if (system.IsPointerOverGameObject())
                audioL.Play();
        }
        if(Input.GetMouseButtonDown(1)){ //r-click
            if (system.IsPointerOverGameObject())
                audioR.Play();
        }
        if(Input.GetMouseButtonDown(2)){ //m-click
            if (system.IsPointerOverGameObject())
                audioM.Play();
        }
	}
}
