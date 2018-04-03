using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameProgress : MonoBehaviour {

	public int progress = 1;

	//static int progressRemember;

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
		if(SceneManager.GetActiveScene().name == "SelectDay"){
			//progressRemember = progress;
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
