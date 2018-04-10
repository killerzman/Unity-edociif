using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class onClickRestart : MonoBehaviour {

	public GameObject restartOrShutdownPanel;

	public Text text;

	Button btn;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(showRestart);
	}
	
	void showRestart(){
		//show hidden panel informing about restarting and delay scene loading
		restartOrShutdownPanel.GetComponent<CanvasGroup>().alpha = 1;
        restartOrShutdownPanel.GetComponent<CanvasGroup>().interactable = true;
        restartOrShutdownPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
		text.color = new Color(0,100,0);
		text.text = "Restarting...";
		StartCoroutine(delaySceneThenLoad(SceneManager.GetActiveScene().name,3f));
	}

	public IEnumerator delaySceneThenLoad(string changeToScene, float waitAndSwitchToScene){
			//load the current scene again after a number of seconds
		    yield return new WaitForSeconds(waitAndSwitchToScene);
		    SceneManager.LoadScene(changeToScene);
	}
}
