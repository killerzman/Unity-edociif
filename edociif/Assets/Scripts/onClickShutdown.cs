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
		restartOrShutdownPanel.GetComponent<CanvasGroup>().alpha = 1;
        restartOrShutdownPanel.GetComponent<CanvasGroup>().interactable = true;
        restartOrShutdownPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
		text.color = new Color(255,0,0);
		text.text = "Shutting down...";
		StartCoroutine(delaySceneThenLoad("Menu",3f));
	}

	public IEnumerator delaySceneThenLoad(string changeToScene, float waitAndSwitchToScene){
		    yield return new WaitForSeconds(waitAndSwitchToScene);
		    SceneManager.LoadScene(changeToScene);
	}
}
