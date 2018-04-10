using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class onClickShutdown : MonoBehaviour {

	public GameObject restartOrShutdownPanel;

	public Text text;

	Button btn;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(showShutdown);
	}
	
	void showShutdown(){
		//show hidden panel informing about shutting down and delay scene loading
		restartOrShutdownPanel.GetComponent<CanvasGroup>().alpha = 1;
        restartOrShutdownPanel.GetComponent<CanvasGroup>().interactable = true;
        restartOrShutdownPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
		text.color = new Color(255,0,0);
		text.text = "Shutting down...";
		StartCoroutine(delaySceneThenLoad("Menu",3f));
	}

	public IEnumerator delaySceneThenLoad(string changeToScene, float waitAndSwitchToScene){
			//load the menu after waiting a number of seconds
		    yield return new WaitForSeconds(waitAndSwitchToScene);
		    SceneManager.LoadScene(changeToScene);
	}
}
