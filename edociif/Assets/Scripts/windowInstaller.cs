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
	bool evilTermAdded = false;
	string nameOfInstalledProduct = "default";
	string nameOfOfferedProduct1 = "def1";
	string nameOfOfferedProduct2 = "def2";
	string nameOfOfferedProduct3 = "def3";
	Text welcomeText, welcomeInstruction; Button welcomeNext;
	Button offer1Next, offer1Back; Toggle offer1Toggle; Text offer1ToggleText; Image offer1Image;
	Button offer2Next, offer2Back; Toggle offer2Toggle; Text offer2ToggleText; Image offer2Image;
	Button offer3Next, offer3Back; Toggle offer3Toggle; Text offer3ToggleText; Image offer3Image;
	Button confirmNext, confirmBack, confirmBlockInstall; Text confirmText; Dropdown confirmDropdown; Toggle confirmTermsToggle; Text terms;
	GameObject progressBar; Text progressBarText;
	Button doneNext; Text doneText;
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
	public string[] offerTxt = new string[]{
		"By checking this box, you agree to installing ",
		"We hope you will love our new addon for maximum performance: ",
		"Enjoy another part of life by experiencing ",
		"Do what you were made for with ",
		"We wish you the best of both worlds by using ",
		"This is our best product yet, you don't want to miss out ",
		"Get in touch with the latest and greatest by checking out ",
		"Time to experience a new part of life with ",
		"No more malware! Be protected by ",
		"Create your own world and break the rules: ",
		"Free yourself; we're bringing you the solution: ",
		"I agree to installing ",
		"Our best experience yet available, don't miss ",
	};
	public string[] confirmBeginTxt = new string[]{
		"Are you sure you want to install ",
		"We're all ready to install ",
		"Confirm installation for ",
		"Let's do this and install ",
		"Installing is all ready to go for ",
		"Begin installing ",
		"Proceed installing ",
		"Let's install ",
		"Do you want to install "
	};
	public string[] doneTxt = new string[]{
		"We're done! We have installed ",
		"Successfully installed ",
		"We've done with installing ",
		"Procedure complete! Install done for ",
		"We're happy to tell you we're done installing "
	};

	public string[] softwareName = new string[]
    {
		"Vlender",
		"Baya",
		"Steme",
		"Bicord",
		"Runety",
		"Naw-dacity",
		"Brome",
		"Oxplor",
		"Walp'Ems",
		"Talk Time",
		"Ospap",
		"Terra Protect",
		"Bimbows",
		"Rode Clocks",
		"Meezual Studio",
		"Gimb",
		"Geel-Power Walkthrough"
    };

	public string[] offerName = new string[]{
		"Draw.com",
		"Draw Util SAI",
		"Core Movie Maker",
		"Adoub PictureStore",
		"ScreamStage",
		"Squad Looker",
		"DelayWeight",
		"FastMoment",
		"xCube Direct",
		"Ihcamah",
		"Workplace Sentence",
		"Workplace StrengthDot",
		"Flinch",
		"Igame",
		"Bad New Experiences",
		"Strobe"
	};
	public string[] evilTerms = new string[]{
		"By agreeing to those terms, we have your permission of accessing your contact data.",
		"We may monitor your internet traffic for better results tailored to you.",
		"We will track your user created files for our machine learning algorithms.",
		"Location information may be derived from your device's GPS signal, WiFi network or cell towers.",
		"We may gather information about how you use our product for better understanding of what the consumers want.",
		"We reserve the right to change, suspend or fully remove any product or content.",
		"We use the information we collect to send you promotional messages and content and otherwise market to you on and off our services."
	};

	public Sprite[] offerPics;

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

		//the window installer is set into multiple stages
		//initialize every object for every stage of the installer
		contentStages = GameObject.Find("contentStages");

		stageWelcome = GameObject.Find("stageWelcome");
		welcomeText = GameObject.Find("welcomeText").GetComponent<Text>();
		welcomeInstruction = GameObject.Find("welcomeInstruction").GetComponent<Text>();
		welcomeNext = GameObject.Find("welcomeNext").GetComponent<Button>();
		//use this function to make a stage interactable and visible or otherwise depending on the bool
		//false : make it "invisible" ; true : make it interactable
		setCanvasGroup(stageWelcome, false); 

		stageOffer1 = GameObject.Find("stageOffer1");
		offer1Next = GameObject.Find("offer1Next").GetComponent<Button>();
		offer1Back = GameObject.Find("offer1Back").GetComponent<Button>();
		offer1Toggle = GameObject.Find("offer1Toggle").GetComponent<Toggle>();
		offer1ToggleText = GameObject.Find("offer1ToggleText").GetComponent<Text>();
		offer1Image = GameObject.Find("offer1Image").GetComponent<Image>();
		setCanvasGroup(stageOffer1, false);

		stageOffer2 = GameObject.Find("stageOffer2");
		offer2Next = GameObject.Find("offer2Next").GetComponent<Button>();
		offer2Back = GameObject.Find("offer2Back").GetComponent<Button>();
		offer2Toggle = GameObject.Find("offer2Toggle").GetComponent<Toggle>();
		offer2ToggleText = GameObject.Find("offer2ToggleText").GetComponent<Text>();
		offer2Image = GameObject.Find("offer2Image").GetComponent<Image>();
		setCanvasGroup(stageOffer2, false);

		stageOffer3 = GameObject.Find("stageOffer3");
		offer3Next = GameObject.Find("offer3Next").GetComponent<Button>();
		offer3Back = GameObject.Find("offer3Back").GetComponent<Button>();
		offer3Toggle = GameObject.Find("offer3Toggle").GetComponent<Toggle>();
		offer3ToggleText = GameObject.Find("offer3ToggleText").GetComponent<Text>();
		offer3Image = GameObject.Find("offer3Image").GetComponent<Image>();
		setCanvasGroup(stageOffer3, false);

		stageConfirmInstall = GameObject.Find("stageConfirmInstall");
		confirmNext = GameObject.Find("confirmNext").GetComponent<Button>();
		confirmBack = GameObject.Find("confirmBack").GetComponent<Button>();
		confirmBlockInstall = GameObject.Find("confirmBlockInstall").GetComponent<Button>();
		confirmText = GameObject.Find("confirmText").GetComponent<Text>();
		confirmDropdown = GameObject.Find("confirmDropdown").GetComponent<Dropdown>(); 
		confirmTermsToggle = GameObject.Find("confirmTermsToggle").GetComponent<Toggle>();
		terms = GameObject.Find("terms").GetComponent<Text>();
		setCanvasGroup(stageConfirmInstall, false);

		stageInstalling = GameObject.Find("stageInstalling");
		progressBar = GameObject.Find("progressBar");
		progressBarText = GameObject.Find("progressBarText").GetComponent<Text>();
		setCanvasGroup(stageInstalling, false);

		stageDoneInstalling = GameObject.Find("stageDoneInstalling");
		doneNext = GameObject.Find("doneNext").GetComponent<Button>();
		doneText = GameObject.Find("doneText").GetComponent<Text>();
		setCanvasGroup(stageDoneInstalling, false);

		stagenr = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(hasInfoBeenGenerated == false){
			generateRandomInfo();
			hasInfoBeenGenerated = true;
		}

		//remembering what stage the installer is at by using increasing numbers
		//0 for first stage, 1 for second stage and so on
		//in case of higher difficulties, the stage may vary
		//checking isVisible so the canvas group isn't updated every frame, just once
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
					confirmBlockInstall.onClick.RemoveAllListeners();
					confirmNext.onClick.AddListener(delegate{pressNext(stageConfirmInstall);});
					confirmBack.onClick.AddListener(delegate{pressBack(stageConfirmInstall);});
					confirmBlockInstall.onClick.AddListener(delegate{destroyWindow();});
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
			if(difficulty == 2){
				if(isVisible == false){
					setCanvasGroup(stageConfirmInstall, true);
					isVisible = true;
					confirmNext.onClick.RemoveAllListeners();
					confirmBack.onClick.RemoveAllListeners();
					confirmBlockInstall.onClick.RemoveAllListeners();
					confirmNext.onClick.AddListener(delegate{pressNext(stageConfirmInstall);});
					confirmBack.onClick.AddListener(delegate{pressBack(stageConfirmInstall);});
					confirmBlockInstall.onClick.AddListener(delegate{destroyWindow();});
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
			if(difficulty == 2){
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
					confirmBlockInstall.onClick.RemoveAllListeners();
					confirmNext.onClick.AddListener(delegate{pressNext(stageConfirmInstall);});
					confirmBack.onClick.AddListener(delegate{pressBack(stageConfirmInstall);});
					confirmBlockInstall.onClick.AddListener(delegate{destroyWindow();});
				}
			}
		}
		else if(stagenr == 5){
			if(difficulty == 2){
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

		//if terms are agreed to, make install button interactable
		if(confirmTermsToggle.isOn){
			confirmNext.interactable = true;
		}
		else{
			confirmNext.interactable = false;
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

		//generating info at script runtime
		//such as name of the installed product, offered products, greeting messages etc.

		nameOfInstalledProduct = softwareName[Random.Range(0, softwareName.Length)];

		List<string> offerProductList = new List<string>(offerName);
		int indexForOfferProductList = Random.Range(0,offerProductList.Count);
		nameOfOfferedProduct1 = offerProductList[indexForOfferProductList];
		offerProductList.RemoveAt(indexForOfferProductList);
		indexForOfferProductList = Random.Range(0,offerProductList.Count);
		nameOfOfferedProduct2 = offerProductList[indexForOfferProductList];
		offerProductList.RemoveAt(indexForOfferProductList);
		indexForOfferProductList = Random.Range(0,offerProductList.Count);
		nameOfOfferedProduct3 = offerProductList[indexForOfferProductList];
		offerProductList.RemoveAt(indexForOfferProductList);

		welcomeText.text = welcText[Random.Range(0,welcText.Length)] + nameOfInstalledProduct;
		welcomeInstruction.text = welcInstr[Random.Range(0,welcInstr.Length)];

		List<string> offerList = new List<string>(offerTxt);
		int indexForOfferList = Random.Range(0,offerList.Count);
		offer1ToggleText.text = offerList[indexForOfferList] + nameOfOfferedProduct1;
		offerList.RemoveAt(indexForOfferList);
		indexForOfferList = Random.Range(0,offerList.Count);
		offer2ToggleText.text = offerList[indexForOfferList] + nameOfOfferedProduct2;
		offerList.RemoveAt(indexForOfferList);
		indexForOfferList = Random.Range(0,offerList.Count);
		offer3ToggleText.text = offerList[indexForOfferList] + nameOfOfferedProduct3;
		offerList.RemoveAt(indexForOfferList);

		List<Sprite> offerImgs = new List<Sprite>(offerPics);
		int indexForOfferImgs = Random.Range(0, offerImgs.Count);
		offer1Image.sprite = offerPics[indexForOfferImgs];
		offerImgs.RemoveAt(indexForOfferImgs);
		indexForOfferImgs = Random.Range(0, offerImgs.Count);
		offer2Image.sprite = offerPics[indexForOfferImgs];
		offerImgs.RemoveAt(indexForOfferImgs);
		indexForOfferImgs = Random.Range(0, offerImgs.Count);
		offer3Image.sprite = offerPics[indexForOfferImgs];
		offerImgs.RemoveAt(indexForOfferImgs);

		confirmText.text = "";
		confirmText.text += confirmBeginTxt[Random.Range(0,confirmBeginTxt.Length)] + nameOfInstalledProduct;

		if(Random.Range(0,2) % 2 == 1){
			terms.text = terms.text.Insert(terms.text.IndexOf('\n') + 1, '\n' + evilTerms[Random.Range(0,evilTerms.Length)] + '\n');
			evilTermAdded = true;
		}

		doneText.text = doneTxt[Random.Range(0,doneTxt.Length)] + nameOfInstalledProduct;
		doneText.text += "\nPress finish to close the installer.";
		
		progressBarText.text = progBarTxt[Random.Range(0,progBarTxt.Length)];
	}

	void pressNext(GameObject obj){
		//make the current object invisible and go to the next stage
		setCanvasGroup(obj, false);
		isVisible = false;
		stagenr++;
		if(obj.name == "stageDoneInstalling"){
			//destroy the installer window at finish
			destroyWindow();
		}
		else if(obj.name == "stageConfirmInstall"){
			//in case an offered product is installed or the install dropdown value points to an admin file location
			//or an evil term has been accepted to
			//increase the mistake counter
			if((difficulty == 1 && offer1Toggle.isOn) || 
			   (difficulty == 2 && (offer1Toggle.isOn || offer2Toggle.isOn)) ||
			   (difficulty == 3 && (offer1Toggle.isOn || offer2Toggle.isOn || offer3Toggle.isOn)) ||
			   (confirmDropdown.value == 0) ||
			   (evilTermAdded == true)
			){
				GameObject.Find("mistakePanel").GetComponent<mistakeHandler>().mistakeCounterToModify++;
			}
			
		}
	}

	void pressBack(GameObject obj){
		//make the current object invisible and go to the previous stage
		setCanvasGroup(obj, false);
		isVisible = false;
		stagenr--;
	}

	void destroyWindow(){
		//destroy the installer window
		Destroy(contentStages.transform.parent.transform.parent.GetComponent<windowProp>().referenceTaskbarSlot);
		Destroy(contentStages.transform.parent.transform.parent.gameObject);
	}
	
	IEnumerator progressBarTransition(){
		//smoothly fill the progress bar by using a slider and calculations over time
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
