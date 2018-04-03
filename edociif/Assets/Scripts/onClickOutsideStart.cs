using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickOutsideStart : MonoBehaviour {

	GameObject menu;

	void Start()
	{
		menu = gameObject.transform.Find("startMenu").gameObject;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")){
            //RaycastHit hit = new RaycastHit();      
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 pos = Input.mousePosition;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (!(Physics2D.Raycast(pos, Vector2.right, 5)))
                {
                    menu.GetComponent<CanvasGroup>().alpha = 0;
                    menu.GetComponent<CanvasGroup>().interactable = false;
                    menu.GetComponent<CanvasGroup>().blocksRaycasts = false;
                    GetComponent<onClickStart>().isStartOpened = false;
                }
            }
		}
	}
	
}
