using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameProgress : MonoBehaviour {

	//progress is 1 for an empty save state
	//each time you complete a level, progress gets incremented by one
	//ex: progress = 4 -> access to level 4
	public int progress = 1;

	public GameObject[] buttonsAvailable; 

	public void SetProgress(int nr){
		progress = nr;
	}

	public int GetProgress(){
		return progress;
	}

	public void IncrementProgressByOne(){
		progress += 1;
	}


	void Update(){
		//make levels available on the select screen depending on the progress
		if(SceneManager.GetActiveScene().name == "SelectDay"){
			for(int i = 0; i < buttonsAvailable.Length; i++){
				if(i < progress){
					buttonsAvailable[i].GetComponent<Button>().interactable = true;
				}
				else
					buttonsAvailable[i].GetComponent<Button>().interactable = false;
			}
		}
	}

}
