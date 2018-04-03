using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveGeneratorSearchTask : MonoBehaviour {

    // Use this for initialization

    public bool isRequestingCompany, isRequestingProductByCompanySoft, isRequestingProductByCompanyGame, isRequestingYear, isRequestingLike, isReqGame, isReqSoft, isReqCompany; 

    public string[] companyName = new string[] 
    { 
    "Ramsom",
    "Valov",
    "Wcafee",
    "Bojang",
    "Stopping Without Scissors",
    "Lid Software",
    "Treide Realms",
    "Broteam",
    "Apogeu",
    "Sortha",
    "Remedee",
    "Basepunch",
    "Kneehit",
    "Ben a ton",
    "Bethmeta",
    "Revolver Rigidal",
    "Overmill",
    "Dela Program",
    "Earthquake Studios",
    "Flat Silver"
    };

    public string[] softwareName = new string[]
    {
    "Bobo",
    "Kiltzerman",
    "Ma nama not eem portant"
    };

    public string[] gameName = new string[]
    {
    "2fort_nite",
    "jok fayn",
    "epik gae"
    };

    public string[] greet = new string[]
    {
    "Ay! ",
    "Hello. ",
    "Hey, you! ",
    "Hi. ",
    "hi..... ",
    "hey buddy. ",
    "can you help a buddy out? ",
    "lend a hand over here?",
    "help. "
    };

    public string[] requestInfoIntro = new string[]
    {
    "Can you please tell me ",
    "Mind telling me ",
    "I need you to tell me "
    };

    public string[] requestLikeIntro = new string[]
   {
    "Can you please like my page about ",
    "Mind liking my page about ",
    "I need you to like my page about "
   };

    int requestNumber;

    void Start()
    {
        requestNumber = Random.Range(1, 6);

        //Debug.Log(greet[Random.Range(0, greet.Length - 1)]);

        switch(requestNumber)
        {
            case 1:
                if (Random.Range(0, 2) == 1)
                    isReqGame = true;
                else
                    isReqSoft = true;
             
                isRequestingCompany = true;
                if(isReqSoft)
                    Debug.Log(greet[Random.Range(0, greet.Length)]+requestInfoIntro[Random.Range(0, requestInfoIntro.Length)]+"who made the software "+softwareName[Random.Range(0, softwareName.Length)]+"?");
                    else
                    Debug.Log(greet[Random.Range(0, greet.Length)]+requestInfoIntro[Random.Range(0, requestInfoIntro.Length)] + "who made the game " + softwareName[Random.Range(0, gameName.Length)]+"?");
                break;

            case 2:
                isRequestingLike = true;
                Debug.Log(greet[Random.Range(0, greet.Length )]+requestLikeIntro[Random.Range(0, requestLikeIntro.Length)] + companyName[Random.Range(0, companyName.Length)]);

                break;
            case 3:
                isRequestingProductByCompanySoft = true;
                Debug.Log(greet[Random.Range(0, greet.Length )]+requestInfoIntro[Random.Range(0, requestInfoIntro.Length)] + "who was " + softwareName[Random.Range(0, softwareName.Length)]+ " made by?");

                break;
            case 4:
                isRequestingYear = true;
                Debug.Log(greet[Random.Range(0, greet.Length )]+requestInfoIntro[Random.Range(0, requestInfoIntro.Length)] + "what year was " + softwareName[Random.Range(0, softwareName.Length)] + " made in?");
                break;
            case 5:
                Debug.Log(greet[Random.Range(0, greet.Length )]+requestInfoIntro[Random.Range(0, requestInfoIntro.Length )] + "what products did " + companyName[Random.Range(0, companyName.Length)] + " develop??");
                isRequestingProductByCompanyGame = true;
                break;
        }

    }

}
