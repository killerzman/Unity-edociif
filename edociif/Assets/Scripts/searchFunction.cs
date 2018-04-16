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
	string theSearchText;

	public void showSiteWithAllDomains()
	{
		for(int i=0;i<various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain.Length;i++)
		{
			GameObject theSpawnedSuggestion= Instantiate(prefabSearchResult);
			theSpawnedSuggestion.transform.parent=searchResultAreaReference.transform;

			theSpawnedSuggestion.transform.Find("Text").gameObject.GetComponent<Text>().text=theSearchText+various_data.GetComponent<objectiveGeneratorSearchTask>().siteDomain[i];
		}
	}

	public void parseText()
	{
		theSearchText=urlBar.transform.Find("Text").gameObject.GetComponent<Text>().text;
		Debug.Log(theSearchText);

		foreach (Transform child in searchResultAreaReference.transform) 
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
			bool isTheWebsiteReal=true;
			char[] theConvertedText= theSearchText.ToCharArray();
			int i=0;
			while(i<theConvertedText.Length && theConvertedText[i]!='.')
			{
				
				i++;
			}
			if(i==theConvertedText.Length)
			{
				isTheWebsiteReal=false;
				Debug.Log("it's a word");
			}
			else
			{
				char[] temporaryPossibleSiteName= new char[100];
				for(int j=0;j<i;j++)
					temporaryPossibleSiteName[j]=theConvertedText[j];

				string possibleSiteName= new string(temporaryPossibleSiteName);

				Debug.Log(possibleSiteName);
			}
			

		}
	}

	void Start () {
		urlBar=gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Button>().onClick.RemoveAllListeners();		
		gameObject.GetComponent<Button>().onClick.AddListener(parseText);
	}
}
