using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class mistakeHandler : MonoBehaviour {

	public int mistakeCounterToModify = 0;
	public int mistakeCounter = 0;
	public int mistakesUntilFail = 3;
	public AudioClip gameOverClip;
	public VideoClip mistakeVideo;
	public RawImage mistakeVideoLocation;
	VideoPlayer mistakeVideoPlayer;
	GameObject gameOverPanel;
	GameObject mistakePanel;
	AudioSource gameOverAudio;
	AudioSource mistakeAudio;
	Color panelColor;
	Text gameOverText;

	void Start () {
		gameOverAudio = GameObject.Find("gameOverPanel/audioSource").GetComponent<AudioSource>();
		gameOverPanel = GameObject.Find("gameOverPanel");
		gameOverText = GameObject.Find("gameOverPanel/Text").GetComponent<Text>();
		mistakePanel = GameObject.Find("mistakePanel");
		mistakeAudio = GameObject.Find("mistakePanel/audioSource").GetComponent<AudioSource>();
		gameOverAudio.clip = gameOverClip;
		gameOverText.color = Color.red;
		gameOverText.text = "You failed...";
		panelColor = Color.black;
		panelColor.a = 127;
		gameOverPanel.GetComponent<Image>().color = panelColor;
		gameOverPanel.GetComponent<CanvasGroup>().alpha = 0;
		gameOverPanel.GetComponent<CanvasGroup>().interactable = false;
		gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	

	void Update () {
		if(mistakeCounterToModify > mistakeCounter){
			mistakeCounter = mistakeCounterToModify;
			if(mistakeCounterToModify < mistakesUntilFail){
				StartCoroutine(playVid());
				mistakeAudio.Play();
			}
		}
		if(mistakeCounter >= mistakesUntilFail){
			mistakeCounter = 0;
			mistakeCounterToModify = 0;
			gameOverPanel.GetComponent<CanvasGroup>().alpha = 1;
			gameOverPanel.GetComponent<CanvasGroup>().interactable = true;
			gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
			StartCoroutine(changeToScene("Menu"));
		}
	}

	public IEnumerator changeToScene(string scene){
		gameOverAudio.Play();
		yield return new WaitForSeconds(gameOverAudio.clip.length);
		SceneManager.LoadScene(scene);
	}

	public IEnumerator playVid(){
		//add a video player to the scene and set its' video to play
		mistakeVideoPlayer = gameObject.AddComponent<VideoPlayer>();
		mistakeVideoPlayer.playOnAwake = false;
		mistakeVideoPlayer.source = VideoSource.VideoClip;
		mistakeVideoPlayer.clip = mistakeVideo;
		//prepare the video player
		mistakeVideoPlayer.Prepare();
		while (!mistakeVideoPlayer.isPrepared)
        {
            yield return null;
        }
		//setting the rawimage's texture to be the video player's texture
		mistakeVideoLocation.texture = mistakeVideoPlayer.texture;
		Color imageColor = new Color(255,255,255);
		//setting alpha to half so it doesn't tamper with the other ui elements
		imageColor.a = 1f;
		mistakeVideoLocation.color = imageColor;
		//play until end
		mistakeVideoPlayer.Play();
		while(mistakeVideoPlayer.isPlaying){
			yield return null;
		}
		//destroy the video player at the end
		Destroy(mistakeVideoPlayer);
	}
}
