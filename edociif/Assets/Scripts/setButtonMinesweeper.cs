using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setButtonMinesweeper : MonoBehaviour {

	GameObject getCol, getRow, getMines, tableRef;

	void onSet()
	{
			if(getCol.GetComponent<InputField>().text != "")
				tableRef.GetComponent<tableSpawner>().table_width=int.Parse (getCol.GetComponent<InputField>().text); 
			if(getRow.GetComponent<InputField>().text != "")
				tableRef.GetComponent<tableSpawner>().table_height=int.Parse (getRow.GetComponent<InputField>().text); 
			if(getMines.GetComponent<InputField>().text != "")
				tableRef.GetComponent<tableSpawner>().bombNumber=int.Parse (getMines.GetComponent<InputField>().text); 

				tableRef.GetComponent<tableSpawner>().enabled=false;
				tableRef.GetComponent<tableSpawner>().enabled=true;

	}

	void Start () {
		getCol=gameObject.transform.parent.gameObject.transform.Find("columns").gameObject;
		getRow=gameObject.transform.parent.gameObject.transform.Find("rows").gameObject;
		getMines=gameObject.transform.parent.gameObject.transform.Find("mines").gameObject;
		tableRef=gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("table").gameObject;

		gameObject.GetComponent<Button>().onClick.AddListener(onSet);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
