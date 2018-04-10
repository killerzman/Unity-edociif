using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class playVideo : MonoBehaviour {

	public bool onAwake;

	public bool itLoops;

	public RawImage image;

    public VideoClip videoToPlay;

	private VideoPlayer videoPlayer;

	bool flag = false;

	void Update(){
		if(onAwake){
			if(itLoops){
				if(flag == false){
					flag = true;
					StartCoroutine(playVid(itLoops));
				}
			}
			else{
				if(flag == false){
					StartCoroutine(playVid(itLoops));
				}
			}
		}
	}

	public IEnumerator playVid(bool loop){
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
		Color imageColor = new Color(255,255,255);
		//setting alpha to half so it doesn't tamper with the other ui elements
		imageColor.a = 1f;
		image.color = imageColor;
		//play until end
		videoPlayer.Play();
		while(videoPlayer.isPlaying){
			yield return null;
		}
		//destroy the video player at the end
		Destroy(videoPlayer);
		if(loop){
			flag = false;
		}
		else{
			flag = true;
		}
	}
}
