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
		if(SceneManager.GetActiveScene().name == "SelectDay" && (btn.name != "backToMenu")){
			if(GameObject.FindGameObjectWithTag("menuBackgroundMusic") != null){
				audioToFadeOut = GameObject.FindGameObjectWithTag("menuBackgroundMusic").GetComponent<AudioSource>();
				StartCoroutine(fadeOutAudio(audioToFadeOut,fadeOutDuration));
			}
		}
		StartCoroutine(delaySceneThenLoad(changeToScene,waitBeforeSwitchScene));
	}

	public IEnumerator fadeOutAudio(AudioSource audioToFadeOut, float fadeOutDuration){
		if(audioToFadeOut != null){
			float startVolume = audioToFadeOut.volume;
	
			while (audioToFadeOut.volume > 0) {
				audioToFadeOut.volume -= startVolume * Time.deltaTime / fadeOutDuration;
	
				yield return null;
			}
	
			audioToFadeOut.Stop ();
			audioToFadeOut.volume = startVolume;
		}
	}

	public IEnumerator delaySceneThenLoad(string changeToScene, float waitAndSwitchToScene){
		yield return new WaitForSeconds(waitAndSwitchToScene);
		SceneManager.LoadScene(changeToScene);
	}
}
