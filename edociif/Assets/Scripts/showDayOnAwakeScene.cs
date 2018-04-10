using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showDayOnAwakeScene : MonoBehaviour {

	public GameObject showDayPanel;
	public Text dayText;
	public string textToShowOnDayText;
	public float timeToFadeIn;
	public float timeToFadeOut;
	public AudioSource audioToPlay;

	Color textColor;

	void Start () {
		//show day number whenever a level scene is loaded
		//reveal hidden panel to show the number
		showDayPanel.GetComponent<CanvasGroup>().alpha = 1;
        showDayPanel.GetComponent<CanvasGroup>().interactable = true;
        showDayPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
		textColor = Color.white;
		textColor.a = 1f;
		dayText.color = textColor;
		dayText.text = textToShowOnDayText;
		//do a fade in for the text and a fade out for the text and panel
		StartCoroutine(fadeInText(dayText, textColor, timeToFadeIn));
		StartCoroutine(fadeOutTextAndPanel(dayText, textColor, timeToFadeIn, timeToFadeOut, showDayPanel));
	}
	
	public IEnumerator fadeInText(Text dayText, Color textColor, float timeToFadeIn){
		float originalAlpha = textColor.a;
		Color colorToImplement = textColor;

		//fade in the text by modifying the alpha to be bigger every update
		while(textColor.a > 0){
			textColor.a -= originalAlpha * Time.deltaTime / timeToFadeIn;
			colorToImplement.a = (textColor.a - 1) * -1;
			dayText.color = colorToImplement;
			yield return null;
		}

	}

	public IEnumerator fadeOutTextAndPanel(Text dayText, Color textColor, float timeToFadeIn, float timeToFadeOut, GameObject showDayPanel){
		//wait for the time it takes to fade in and then start the fade out
		yield return new WaitForSeconds(timeToFadeIn);
		float originalAlpha = textColor.a;

		//fade out the text and panel by modifying the alpha to be smaller every update
		while(textColor.a > 0){
			textColor.a -= originalAlpha * Time.deltaTime / timeToFadeOut;
			showDayPanel.GetComponent<CanvasGroup>().alpha = textColor.a;
			dayText.color = textColor;
			yield return null;
		}

		//make the panel non-interactable
		showDayPanel.GetComponent<CanvasGroup>().interactable = false;
        showDayPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

	}

}
