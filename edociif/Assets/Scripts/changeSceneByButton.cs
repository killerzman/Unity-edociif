using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeSceneByButton : MonoBehaviour {

	[SerializeField] private string changeToScene = null;

	private AudioSource audioToFadeOut;

	private float fadeOutDuration;

	public float waitBeforeSwitchScene = 0.0f;

	Button btn;


	void Start(){
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(loadScene);
		fadeOutDuration = waitBeforeSwitchScene;
	}

	public void loadScene(){
		//fade out menu audio if we're on a certain scene and not press a certain button
		if(SceneManager.GetActiveScene().name == "SelectDay" && (btn.name != "backToMenu")){
			if(GameObject.FindGameObjectWithTag("menuBackgroundMusic") != null){
				audioToFadeOut = GameObject.FindGameObjectWithTag("menuBackgroundMusic").GetComponent<AudioSource>();
				StartCoroutine(fadeOutAudio(audioToFadeOut,fadeOutDuration));
			}
		}
		//delay scene by the number of seconds it takes the audio to fade out
		StartCoroutine(delaySceneThenLoad(changeToScene,waitBeforeSwitchScene));
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

	public IEnumerator delaySceneThenLoad(string changeToScene, float waitAndSwitchToScene){
		yield return new WaitForSeconds(waitAndSwitchToScene);
		SceneManager.LoadScene(changeToScene);
	}
}
