using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroyMenuBGMusic : MonoBehaviour {

	private bool objHasBeenTransformed = false;

	void Awake(){
		//leave just one audio source for the menu audio
		GameObject[] objs = GameObject.FindGameObjectsWithTag("menuBackgroundMusic");
		if(objs.Length > 1)
			Destroy(this.gameObject);
		
		//keep the audio source alive between scenes
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		//if the audio source hasn't been tampered with and the current scene is a level
		//then assign a new game object the audio source's transform and destroy it
		if(objHasBeenTransformed == false && SceneManager.GetActiveScene().name.Contains("Level")){
			GameObject newGO = new GameObject();
			this.gameObject.transform.SetParent(newGO.transform, false);
			newGO.name = "bgMusic";
			objHasBeenTransformed = true;
			Destroy(newGO);
		}
	}
}
