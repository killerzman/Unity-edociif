using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class quitAppByButton : MonoBehaviour {

	private AudioSource audioToFadeOut;

	public float fadeOutDuration;

	Button btn;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(quitApp);
	}
	
	void quitApp(){
		//start fading out menu audio if we can find the audio source game object
		if(SceneManager.GetActiveScene().name == "Menu"){
			if(GameObject.FindGameObjectWithTag("menuBackgroundMusic") != null){
				audioToFadeOut = GameObject.FindGameObjectWithTag("menuBackgroundMusic").GetComponent<AudioSource>();
				StartCoroutine(fadeOutAudio(audioToFadeOut,fadeOutDuration));
			}
		}
		//delay quitting the app by the time it takes for the audio to fade out
		StartCoroutine(delayQuit(fadeOutDuration));
	}

	public IEnumerator delayQuit(float fadeOutDuration){
		yield return new WaitForSeconds(fadeOutDuration);
		Application.Quit();
	}

	public IEnumerator fadeOutAudio(AudioSource audioToFadeOut, float fadeOutDuration){
		if(audioToFadeOut != null){
			float startVolume = audioToFadeOut.volume;

			//set the audio's volume lower every update
			while (audioToFadeOut.volume > 0) {
				audioToFadeOut.volume -= startVolume * Time.deltaTime / fadeOutDuration;
	
				yield return null;
			}
	
			//stop the audio and set back the volume to normal
			audioToFadeOut.Stop ();
			audioToFadeOut.volume = startVolume;
		}
	}
}
