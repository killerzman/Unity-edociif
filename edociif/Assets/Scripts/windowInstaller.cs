using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class windowInstaller : MonoBehaviour {

	public int difficulty = 1; // 1 - easy, 2 - medium, 3 - hard
	GameObject contentStages;
	GameObject stageWelcome, stageOffer1, stageOffer2, stageOffer3, stageConfirmInstall, stageInstalling, stageDoneInstalling;
	int stagenr = 0;
	bool hasInfoBeenGenerated;
	bool isVisible;
	string nameOfInstalledProduct = "default";
	Text welcomeText, welcomeInstruction; Button welcomeNext;
	Button offer1Next, offer1Back;
	Button offer2Next, offer2Back;
	Button offer3Next, offer3Back;
	Button confirmNext, confirmBack;
	GameObject progressBar; Text progressBarText;
	Button doneNext;
	public string[] welcText = new string[]{
		"Hello and welcome to ",
		"Welcome to ",
		"Greetings! You're installing ",
		"Installer for ",
		"Let's install "
	};
	public string[] welcInstr = new string[]{
		"To proceed, press Next",
		"To continue installing this software, please press Next",
		"Press Next to continue",
		"Press Next to proceed",
		"Begin installing by pressing Next"
	};
	public string[] progBarTxt = new string[]{
		"Generating splines...",
		"Lighting invisible spots...",
		"Destroying your house...",
		"Converting code into sentient machine...",
		"Dominating the world...",
		"Working on discombobulations...",
		"Cloning unicorns...",
		"Doing laundry...",
		"Washing the dishes...",
		"Stopping world peace...",
		"Navigating through your spaghetti code..."
	};

	// Use this for initialization
	void Start () {
		Random.InitState(System.Environment.TickCount);

		hasInfoBeenGenerated = false;
		isVisible = false;

		//in case the value in the inspector isn't set properly
		if(difficulty < 1){
			difficulty = 1;
		}

		else if(difficulty > 3){
			difficulty = 3;
		}

		contentStages = GameObject.Find("contentStages");

		stageWelcome = GameObject.Find("stageWelcome");
		welcomeText = GameObject.Find("welcomeText").GetComponent<Text>();
		welcomeInstruction = GameObject.Find("welcomeInstruction").GetComponent<Text>();
		welcomeNext = GameObject.Find("welcomeNext").GetComponent<Button>();
		setCanvasGroup(stageWelcome, false);

		stageOffer1 = GameObject.Find("stageOffer1");
		offer1Next = GameObject.Find("offer1Next").GetComponent<Button>();
		offer1Back = GameObject.Find("offer1Back").GetComponent<Button>();
		setCanvasGroup(stageOffer1, false);

		stageOffer2 = GameObject.Find("stageOffer2");
		offer2Next = GameObject.Find("offer2Next").GetComponent<Button>();
		offer2Back = GameObject.Find("offer2Back").GetComponent<Button>();
		setCanvasGroup(stageOffer2, false);

		stageOffer3 = GameObject.Find("stageOffer3");
		offer3Next = GameObject.Find("offer3Next").GetComponent<Button>();
		offer3Back = GameObject.Find("offer3Back").GetComponent<Button>();
		setCanvasGroup(stageOffer3, false);

		stageConfirmInstall = GameObject.Find("stageConfirmInstall");
		confirmNext = GameObject.Find("confirmNext").GetComponent<Button>();
		confirmBack = GameObject.Find("confirmBack").GetComponent<Button>();
		setCanvasGroup(stageConfirmInstall, false);

		stageInstalling = GameObject.Find("stageInstalling");
		progressBar = GameObject.Find("progressBar");
		progressBarText = GameObject.Find("progressBarText").GetComponent<Text>();
		setCanvasGroup(stageInstalling, false);

		stageDoneInstalling = GameObject.Find("stageDoneInstalling");
		doneNext = GameObject.Find("doneNext").GetComponent<Button>();
		setCanvasGroup(stageDoneInstalling, false);

		stagenr = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(hasInfoBeenGenerated == false){
			generateRandomInfo();
			hasInfoBeenGenerated = true;
		}

		if(stagenr == 0){
			if(isVisible == false){
				setCanvasGroup(stageWelcome, true);
				isVisible = true;
				welcomeNext.onClick.RemoveAllListeners();
				welcomeNext.onClick.AddListener(delegate{pressNext(stageWelcome);});
			}
		}
		else if(stagenr == 1){
			if(isVisible == false){
				setCanvasGroup(stageOffer1, true);
				isVisible = true;
				offer1Next.onClick.RemoveAllListeners();
				offer1Back.onClick.RemoveAllListeners();
				offer1Next.onClick.AddListener(delegate{pressNext(stageOffer1);});
				offer1Back.onClick.AddListener(delegate{pressBack(stageOffer1);});
			}
		}
		else if(stagenr == 2){
			if(difficulty == 1){
				if(isVisible == false){
					setCanvasGroup(stageConfirmInstall, true);
					isVisible = true;
					confirmNext.onClick.RemoveAllListeners();
					confirmBack.onClick.RemoveAllListeners();
					confirmNext.onClick.AddListener(delegate{pressNext(stageConfirmInstall);});
					confirmBack.onClick.AddListener(delegate{pressBack(stageConfirmInstall);});
				}
			}
			if(difficulty >= 2){
				if(isVisible == false){
					setCanvasGroup(stageOffer2, true);
					isVisible = true;
					offer2Next.onClick.RemoveAllListeners();
					offer2Back.onClick.RemoveAllListeners();
					offer2Next.onClick.AddListener(delegate{pressNext(stageOffer2);});
					offer2Back.onClick.AddListener(delegate{pressBack(stageOffer2);});
				}
			}
		}
		else if(stagenr == 3){
			if(difficulty == 1){
				if(isVisible == false){
					setCanvasGroup(stageInstalling, true);
					isVisible = true;
					StartCoroutine(progressBarTransition());
				}
			}
			if(difficulty >= 2){
				if(isVisible == false){
					setCanvasGroup(stageConfirmInstall, true);
					isVisible = true;
					confirmNext.onClick.RemoveAllListeners();
					confirmBack.onClick.RemoveAllListeners();
					confirmNext.onClick.AddListener(delegate{pressNext(stageConfirmInstall);});
					confirmBack.onClick.AddListener(delegate{pressBack(stageConfirmInstall);});
				}
			}
			if(difficulty == 3){
				if(isVisible == false){
					setCanvasGroup(stageOffer3, true);
					isVisible = true;
					offer3Next.onClick.RemoveAllListeners();
					offer3Back.onClick.RemoveAllListeners();
					offer3Next.onClick.AddListener(delegate{pressNext(stageOffer3);});
					offer3Back.onClick.AddListener(delegate{pressBack(stageOffer3);});
				}
			}
		}
		else if(stagenr == 4){
			if(difficulty == 1){
				if(isVisible == false){
					setCanvasGroup(stageDoneInstalling, true);
					isVisible = true;
					doneNext.onClick.RemoveAllListeners();
					doneNext.onClick.AddListener(delegate{pressNext(stageDoneInstalling);});
				}
			}
			if(difficulty >= 2){
				if(isVisible == false){
					setCanvasGroup(stageInstalling, true);
					isVisible = true;
					StartCoroutine(progressBarTransition());
				}
			}
			if(difficulty == 3){
				if(isVisible == false){
					setCanvasGroup(stageConfirmInstall, true);
					isVisible = true;
					confirmNext.onClick.RemoveAllListeners();
					confirmBack.onClick.RemoveAllListeners();
					confirmNext.onClick.AddListener(delegate{pressNext(stageConfirmInstall);});
					confirmBack.onClick.AddListener(delegate{pressBack(stageConfirmInstall);});
				}
			}
		}
		else if(stagenr == 5){
			if(difficulty >= 2){
				if(isVisible == false){
					setCanvasGroup(stageDoneInstalling, true);
					isVisible = true;
					doneNext.onClick.RemoveAllListeners();
					doneNext.onClick.AddListener(delegate{pressNext(stageDoneInstalling);});
				}
			}
			if(difficulty == 3){
				if(isVisible == false){
					setCanvasGroup(stageInstalling, true);
					isVisible = true;
					StartCoroutine(progressBarTransition());
				}
			}
		}
		else if(stagenr == 6){
			if(difficulty == 3){
				if(isVisible == false){
					setCanvasGroup(stageDoneInstalling, true);
					isVisible = true;
					doneNext.onClick.RemoveAllListeners();
					doneNext.onClick.AddListener(delegate{pressNext(stageDoneInstalling);});
				}
			}
		}
	}

	void setCanvasGroup(GameObject obj, bool enable){
		if(enable == true){
			obj.GetComponent<CanvasGroup>().alpha = 1;
			obj.GetComponent<CanvasGroup>().interactable = true;
			obj.GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
		else{
			obj.GetComponent<CanvasGroup>().alpha = 0;
			obj.GetComponent<CanvasGroup>().interactable = false;
			obj.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

	void generateRandomInfo(){
		welcomeText.text = welcText[Random.Range(0,welcText.Length)] + nameOfInstalledProduct;
		welcomeInstruction.text = welcInstr[Random.Range(0,welcInstr.Length)];

		progressBarText.text = progBarTxt[Random.Range(0,progBarTxt.Length)];
	}

	void pressNext(GameObject obj){
		setCanvasGroup(obj, false);
		isVisible = false;
		stagenr++;
		if(obj.name == "stageDoneInstalling"){
			Destroy(contentStages.transform.parent.transform.parent.GetComponent<windowProp>().referenceTaskbarSlot);
			Destroy(contentStages.transform.parent.transform.parent.gameObject);
		}
	}

	void pressBack(GameObject obj){
		setCanvasGroup(obj, false);
		isVisible = false;
		stagenr--;
	}
	
	IEnumerator progressBarTransition(){
		float progressTime = 3.0f;
		float progressBarValue = progressBar.GetComponent<Slider>().value = 0;
		while (progressBarValue < 1){
			progressBarValue += (1/progressTime) * Time.deltaTime;
			progressBar.GetComponent<Slider>().value = progressBarValue;
			yield return null;
		}
		//setCanvasGroup(stageInstalling, false);
		isVisible = false;
		stagenr++;
	}
}
