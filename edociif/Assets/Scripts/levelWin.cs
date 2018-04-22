using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelWin : MonoBehaviour {

	string savePath; //to locate save file path

	public int numberLevel = 0; //using this to store the current level's number

	public bool hasLevelBeenWon = false; //to determine if the script should show the win panel

	public AudioSource audioWin;

	// Use this for initialization
	void Start () {
		savePath = Application.streamingAssetsPath + "/Savefile/savefile.txt";
	}
	
	// Update is called once per frame
	void Update () {
		if(hasLevelBeenWon == true){

			//read first line of save file to get current progress
			StreamReader reader = new StreamReader(savePath);
			int p = int.Parse(reader.ReadLine().ToString());
			reader.Close();

			//if this level hasn't already been beaten, increase the progress counter
			//since progress number is equal to the highest level available to play
			if(numberLevel == p){
				p++;
			}

			//write progress in save file
			StreamWriter writer = new StreamWriter(savePath);
			writer.WriteLine(p.ToString());
			writer.Close();

			//show win panel
			gameObject.GetComponent<CanvasGroup>().alpha = 1;
			gameObject.GetComponent<CanvasGroup>().interactable = true;
			gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

			//play win sound
			if(audioWin != null){
				StartCoroutine(playWin());
			}

			//switch to scene after the sound is done
			StartCoroutine(switchToScene());

			//setting this to false to avoid repetition of this function
			hasLevelBeenWon = false;
		}
	}

	IEnumerator playWin(){
		audioWin.Play();
		yield return null;
	}

	IEnumerator switchToScene(){
		//wait for sound to finish
		while(audioWin.isPlaying){
			yield return null;
		}

		//load scene after sound finished playing
		SceneManager.LoadScene("SelectDay");
	}
}
