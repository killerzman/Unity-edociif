using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class onPressBackgroundButton : MonoBehaviour {


	public RawImage image;

    public VideoClip videoToPlay;

    private VideoPlayer videoPlayer;

	Color imageColor;
	bool flag = false;
	Button btn;
	int numberOfPresses = 0;
	public int pressesUntilPlay = 0;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		//setting rawimage's alpha to 0 because it covers the menu
		imageColor = new Color(255,255,255);
		imageColor.a = 0;
		image.color = imageColor;
		btn.onClick.AddListener(counter);
	}
	
	void counter(){
		//play a video if a certain number of presses has been achieved
		if(flag == false){
			numberOfPresses += 1;
			if(numberOfPresses == pressesUntilPlay){
				//set the flag to true to prevent further counting
				flag = true;
				StartCoroutine(playVideo());
			}
		}
	}

	IEnumerator playVideo(){
		//add a video player to the scene and set its' video to play
		videoPlayer = gameObject.AddComponent<VideoPlayer>();
		videoPlayer.playOnAwake = false;
		videoPlayer.source = VideoSource.VideoClip;
		videoPlayer.clip = videoToPlay;
		//prepare the video player
		videoPlayer.Prepare();
		while (!videoPlayer.isPrepared)
        {
            yield return null;
        }
		//setting the rawimage's texture to be the video player's texture
		image.texture = videoPlayer.texture;
		imageColor = new Color(255,255,255);
		//setting alpha to half so it doesn't tamper with the other ui elements
		imageColor.a = 0.5f;
		image.color = imageColor;
		//play until end
		videoPlayer.Play();
		while(videoPlayer.isPlaying){
			yield return null;
		}
		//destroy the video player at the end
		Destroy(videoPlayer);
		//reset flag and number of presses
		flag = false;
		numberOfPresses = 0;
	}
}
