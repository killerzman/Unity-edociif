using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroyMenuBGMusic : MonoBehaviour {

	private bool objHasBeenTransformed = false;

	void Awake(){
		GameObject[] objs = GameObject.FindGameObjectsWithTag("menuBackgroundMusic");
		if(objs.Length > 1)
			Destroy(this.gameObject);
		
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		if(objHasBeenTransformed == false && SceneManager.GetActiveScene().name.Contains("Level")){
			GameObject newGO = new GameObject();
			this.gameObject.transform.SetParent(newGO.transform, false);
			newGO.name = "bgMusic";
			objHasBeenTransformed = true;
			Destroy(newGO);
		}
	}
}
