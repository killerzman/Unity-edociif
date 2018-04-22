using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameProgress : MonoBehaviour {

	//progress is 1 for an empty save state
	//each time you complete a level, progress gets incremented by one
	//ex: progress = 4 -> access to level 4
	int progress;

	string savePath;

	public GameObject[] buttonsAvailable;

	public void SetProgress(int nr){
		//set progress in script and save progress to file
		progress = nr;
		StreamWriter writer = new StreamWriter(savePath);
		writer.WriteLine(progress.ToString());
		writer.Close();
	}

	public int GetProgress(){
		return progress;
	}

	void Start(){
		savePath = Application.streamingAssetsPath + "/Savefile/savefile.txt";
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

		//constantly reading for changes in save file
		//reads the first line of the save file which contains the progress
		StreamReader reader = new StreamReader(savePath);
		progress = int.Parse(reader.ReadLine().ToString());
		reader.Close();

	}

}
