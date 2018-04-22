using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class searchFunction : MonoBehaviour {

	// Use this for initialization
	public GameObject urlBar;
	public GameObject prefabSearchResult;
	public GameObject searchResultAreaReference;

	public GameObject various_data;

	public GameObject siteSpace;
	string theSearchText;

	bool displayTheInfo=false;

	string possibleSiteName;
	string theDomain;
	string pageName;

	public void openNewSetOfSuggestions(string pagenamer, string sitenamer)
	{
		foreach (Transform child in searchResultAreaReference.transform) 
		{
		if(child.gameObject.name!="searchResults")
        GameObject.Destroy(child.gameObject);
		}

		foreach (Transform child in siteSpace.transform) 
		{
        GameObject.Destroy(child.gameObject);
		}

		for(int k=0;k<various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain.Length;k++)
					{
						GameObject theSpawnedSuggestion= Instantiate(prefabSearchResult);
						theSpawnedSuggestion.transform.parent=searchResultAreaReference.transform;

						theSpawnedSuggestion.GetComponent<searchResult>().pagename=pagenamer;
						theSpawnedSuggestion.GetComponent<searchResult>().sitename=sitenamer;
						theSpawnedSuggestion.GetComponent<searchResult>().domain=various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain[k];
						


						theSpawnedSuggestion.transform.Find("Text").gameObject.GetComponent<Text>().text=pagenamer+" - "+ sitenamer+various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain[k];
					}
		
	}
	 

	public void openWebsiteTab()
	{
		GameObject spawnedChat=null;
						GameObject siteBackground=null;
						Debug.Log("the site gets opened");		
						if(possibleSiteName=="infopedia")
						{
							spawnedChat=Instantiate(siteSpace.GetComponent<gatherSiteInfo>().sitePrefab1,siteSpace.transform.position,siteSpace.transform.rotation,siteSpace.transform);
							//spawnedChat.transform.parent=siteSpace.transform;
							siteBackground=spawnedChat.transform.Find("siteBackground").gameObject;
						}
						if(possibleSiteName=="bloatpedia")
						{
							spawnedChat=Instantiate(siteSpace.GetComponent<gatherSiteInfo>().sitePrefab2,siteSpace.transform.position,siteSpace.transform.rotation,siteSpace.transform);
							//spawnedChat.transform.parent=siteSpace.transform;
							siteBackground=spawnedChat.transform.Find("siteBackground").gameObject;
						}
						if(possibleSiteName=="thumbler")
						{
							spawnedChat=Instantiate(siteSpace.GetComponent<gatherSiteInfo>().sitePrefab3,siteSpace.transform.position,siteSpace.transform.rotation,siteSpace.transform);
							//spawnedChat.transform.parent=siteSpace.transform;
							siteBackground=spawnedChat.transform.Find("siteBackground").gameObject;
						}
						if(possibleSiteName=="thetriviasource")
						{
							spawnedChat=Instantiate(siteSpace.GetComponent<gatherSiteInfo>().sitePrefab4,siteSpace.transform.position,siteSpace.transform.rotation,siteSpace.transform);
							//spawnedChat.transform.parent=siteSpace.transform;
							siteBackground=spawnedChat.transform.Find("siteBackground").gameObject;
						}
						if(possibleSiteName=="trivialfacts")
						{
							spawnedChat=Instantiate(siteSpace.GetComponent<gatherSiteInfo>().sitePrefab5,siteSpace.transform.position,siteSpace.transform.rotation,siteSpace.transform);
							//spawnedChat.transform.parent=siteSpace.transform;
							siteBackground=spawnedChat.transform.Find("siteBackground").gameObject;
						}
						if(possibleSiteName=="infogalore")
						{
							spawnedChat=Instantiate(siteSpace.GetComponent<gatherSiteInfo>().sitePrefab6,siteSpace.transform.position,siteSpace.transform.rotation,siteSpace.transform);
							//spawnedChat.transform.parent=siteSpace.transform;
							siteBackground=spawnedChat.transform.Find("siteBackground").gameObject;
						}
						if(displayTheInfo)
						{
							int k=0; bool ok=false;

							while(k<6&&!ok)
							{
								
								if(pageName.ToLower()==spawnedChat.transform.parent.GetComponent<gatherSiteInfo>().SITE_INFO.GetComponent<objectiveGeneratorSearchTask>().requestSubject[k].ToLower())
								ok=true;
								k++;
								Debug.Log(pageName.ToLower()+" vs "+spawnedChat.transform.parent.GetComponent<gatherSiteInfo>().SITE_INFO.GetComponent<objectiveGeneratorSearchTask>().requestSubject[k-1].ToLower());
							}
							
							if(ok)
							{
								string getDomain, getSite, getContent, getFakeContent;

								getSite=spawnedChat.transform.parent.GetComponent<gatherSiteInfo>().SITE_INFO.GetComponent<objectiveGeneratorSearchTask>().theSite[k-1];
								getDomain=spawnedChat.transform.parent.GetComponent<gatherSiteInfo>().SITE_INFO.GetComponent<objectiveGeneratorSearchTask>().theDomain[k-1];
								getContent=spawnedChat.transform.parent.GetComponent<gatherSiteInfo>().SITE_INFO.GetComponent<objectiveGeneratorSearchTask>().theContent[k-1];
								getFakeContent=spawnedChat.transform.parent.GetComponent<gatherSiteInfo>().SITE_INFO.GetComponent<objectiveGeneratorSearchTask>().theFakeContent[k-1];

								if(getSite==""&&getDomain=="")
								spawnedChat.transform.Find("siteDescription").gameObject.GetComponent<Text>().text=getContent;
								else
								if(getSite.ToLower()==possibleSiteName.ToLower()&&getDomain.ToLower()==theDomain.ToLower())
								spawnedChat.transform.Find("siteDescription").gameObject.GetComponent<Text>().text=getContent;
								else
								if(getSite==""&&getDomain.ToLower()==theDomain.ToLower())
								spawnedChat.transform.Find("siteDescription").gameObject.GetComponent<Text>().text=getContent;
								else
								if(getSite.ToLower()==possibleSiteName.ToLower()&&getDomain.ToLower()=="")
								spawnedChat.transform.Find("siteDescription").gameObject.GetComponent<Text>().text=getContent;
								else
									spawnedChat.transform.Find("siteDescription").gameObject.GetComponent<Text>().text=getFakeContent;;
									



								spawnedChat.transform.Find("siteTitle").gameObject.GetComponent<Text>().text=spawnedChat.transform.parent.GetComponent<gatherSiteInfo>().SITE_INFO.GetComponent<objectiveGeneratorSearchTask>().requestSubject[k-1];

								
							}
						}
						switch(theDomain)
						{
							case ".com": siteBackground.GetComponent<Image>().color=Color.green;break;
							case ".net": siteBackground.GetComponent<Image>().color=Color.red;break;
							case ".io": siteBackground.GetComponent<Image>().color=Color.cyan;break;
							case ".ru": siteBackground.GetComponent<Image>().color=Color.yellow;break;
							case ".en": siteBackground.GetComponent<Image>().color=Color.gray;break;
							case ".kr": siteBackground.GetComponent<Image>().color=Color.white;break;
						}
	}

	public bool checkWord(string theCheckWord)
	{
		bool isTheWordCompany=false, isTheWordGame=false, isTheWordSoftware=false;

				for(int j=0;j<various_data.GetComponent<objectiveGeneratorSearchTask>().companyName.Length;j++)
				{
					if(theCheckWord.ToLower()==various_data.GetComponent<objectiveGeneratorSearchTask>().companyName[j].ToLower())
					{
						isTheWordCompany=true;
						Debug.Log("company");
					}
					
				}

				for(int j=0;j<various_data.GetComponent<objectiveGeneratorSearchTask>().gameName.Length;j++)
				{
					if(theCheckWord.ToLower()==various_data.GetComponent<objectiveGeneratorSearchTask>().gameName[j].ToLower())					
					{
						isTheWordGame=true;
						Debug.Log("game");
					}
				}

				for(int j=0;j<various_data.GetComponent<objectiveGeneratorSearchTask>().softwareName.Length;j++)
				{
					if(theCheckWord.ToLower()==various_data.GetComponent<objectiveGeneratorSearchTask>().softwareName[j].ToLower())					
					{
						isTheWordSoftware=true;
						Debug.Log("soft");
					}
				}

				if(isTheWordGame||isTheWordCompany||isTheWordSoftware)
				{	
					
					return true;
				
					
				}
				else
				{					
					return false;
				}

	}

	public void showSiteWithAllDomains()
	{
		for(int i=0;i<various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain.Length;i++)
		{
			GameObject theSpawnedSuggestion= Instantiate(prefabSearchResult);
			theSpawnedSuggestion.transform.parent=searchResultAreaReference.transform;
			theSpawnedSuggestion.GetComponent<searchResult>().domain=various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain[i];
			theSpawnedSuggestion.GetComponent<searchResult>().sitename=theSearchText;
			
			theSpawnedSuggestion.transform.Find("Text").gameObject.GetComponent<Text>().text=theSearchText+various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain[i];
		
		}
	}

	public void parseText()
	{
		displayTheInfo=false;	

		theSearchText=urlBar.transform.Find("Text").gameObject.GetComponent<Text>().text;
		Debug.Log(theSearchText);

		foreach (Transform child in searchResultAreaReference.transform) 
		{
		if(child.gameObject.name!="searchResults")
        GameObject.Destroy(child.gameObject);
		}

		foreach (Transform child in siteSpace.transform) 
		{
        GameObject.Destroy(child.gameObject);
		}

		bool itsItJustTheWebsiteName=false;
		for(int i=0;i<=various_data.GetComponent<objectiveGeneratorSearchTask>().siteName.Length-1;i++)
		{
			if(theSearchText==various_data.GetComponent<objectiveGeneratorSearchTask>().siteName[i])
			itsItJustTheWebsiteName=true;
		}
		if(itsItJustTheWebsiteName)
		showSiteWithAllDomains();
		else
		{
			//bool isTheWebsiteReal=true;
			char[] theConvertedText= theSearchText.ToCharArray();
			int i=0;
			while(i<theConvertedText.Length && theConvertedText[i]!='.')
			{

				i++;
			}
			if(i==theConvertedText.Length)
			{
			//isTheWebsiteReal=false;
			Debug.Log("it's a word");

				if(checkWord(theSearchText))
					for(int k=0;k<various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain.Length;k++)
					{
						GameObject theSpawnedSuggestion= Instantiate(prefabSearchResult);
						theSpawnedSuggestion.transform.parent=searchResultAreaReference.transform;

						theSpawnedSuggestion.GetComponent<searchResult>().pagename=theSearchText;
						theSpawnedSuggestion.GetComponent<searchResult>().sitename=various_data.GetComponent<objectiveGeneratorSearchTask>().siteName[k];

						theSpawnedSuggestion.transform.Find("Text").gameObject.GetComponent<Text>().text=theSearchText+" - "+ various_data.GetComponent<objectiveGeneratorSearchTask>().siteName[k];
					}
					
				
				else
				{
					Debug.Log("the search is neither a site nor a word");
				} 

			}
			else//for complex searches(either direct link to site.domain or site.domain/pageName)
			{
				int dotLocation=i;
				char[] temporaryPossibleSiteName= new char[i];
				for(int j=0;j<i;j++)
					temporaryPossibleSiteName[j]=theConvertedText[j];
				possibleSiteName= new string(temporaryPossibleSiteName);

				Debug.Log(possibleSiteName);

				while(i<theConvertedText.Length && theConvertedText[i]!='/')
				{

					i++;
				}
				
				char[] possibleExtension=new char[i-dotLocation];
				for(int j=dotLocation;j<i;j++)
				{
					possibleExtension[j-dotLocation]=theConvertedText[j];
					//Debug.Log(theConvertedText[j]);
				}
				

				theDomain= new string(possibleExtension);
				Debug.Log(theDomain);

				Debug.Log(theDomain.Length);

				bool realSite=false;
				bool realDomain=false;

				
				for(int j=0;j<various_data.GetComponent<objectiveGeneratorSearchTask>().siteName.Length;j++)
				{
					if(possibleSiteName.Equals (various_data.GetComponent<objectiveGeneratorSearchTask>().siteName[j]))					
					{
						realSite=true;
						Debug.Log("site");
					
					}
					//Debug.Log("comparing "  + various_data.GetComponent<objectiveGeneratorSearchTask>().siteName[j]);
				}

				if(realSite)
					for(int j=0;j<various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain.Length;j++)
					{
						if(theDomain.Equals (various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain[j]))					
						{
							realDomain=true;
							Debug.Log("domain");
						}
					}
				else
				{
					Debug.Log("not a real site");
				}

				Debug.Log(possibleSiteName.Length);

				if(realDomain)
				{
					if(i==theSearchText.Length)
					{
						openWebsiteTab();
							
					}
					else
					{
						i++;
						int slashPos=i;
						
						char[] possiblePageName= new char[theConvertedText.Length-slashPos];
						Debug.Log("continue the search for the word from pos "+ (theConvertedText.Length-slashPos-1));
						
						while(i<theSearchText.Length)
						{
							possiblePageName[i-slashPos]=theConvertedText[i];
							i++;

						}
						pageName = new string(possiblePageName);


						Debug.Log(pageName);

						if(checkWord(pageName))
						{
							Debug.Log("page "+pageName+" gets opened");
							displayTheInfo=true;
							openWebsiteTab();
						}
						else
							{
								Debug.Log("404");
								//spawnedChat.transform.Find("siteTitle").gameObject.GetComponent<Text>().text="404";
							}
					}
				}
				else
				Debug.Log("bad site request");


			}
		
		}
	}

	void Start () {
		urlBar=gameObject.transform.parent.gameObject;
		various_data=GameObject.Find("EventSystem");
		siteSpace=gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("siteContent").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Button>().onClick.RemoveAllListeners();		
		gameObject.GetComponent<Button>().onClick.AddListener(parseText);
	}
}
