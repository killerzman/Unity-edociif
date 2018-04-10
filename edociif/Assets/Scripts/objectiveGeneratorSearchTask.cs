using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectiveGeneratorSearchTask : MonoBehaviour {

    // Use this for initialization

    public bool isRequestingCompany, isRequestingProductByCompanySoft, isRequestingProductByCompanyGame, isRequestingYear, isRequestingLike, isRequestingSoftware, isRequestingGame;
    public string theCompany, theProduct, theGame, theSoftware;
    public int year, disbandedDate, foundedDate;

    String theImportantInfo;

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
    "Geel-Power Walkthrough",
    "Draw.com",
    "Draw Util SAI",
    "Core Movie Maker",
    "Adoub PictureStore",
    "ScreamStage",//opera
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

    public string[] gameName = new string[]
    {
    "Ritecraft",
    "Brust",
    "Konter Srayk",
    "Cream 4très",
    "Mortal2",
    "Walrus Principle",
    "Surgeon Emulator",
    "Bomb Trader",
    "Cave Looker",
    "Bio-mock",
    "Batterman & Ark-man in city",
    "Light Spirit",
    "Nuke Dukem",
    "Reviving Darkness",
    "FlyIn: Las Vegas",
    "Gary's dom",
    "Biggest burglary vehicles",
    "Wound Individual",//hitman
    "Zumma",
    "Celebrity's territory of confrontation",
    "Devil's Column",//saint's row
    "Hilarious Joe",//serious sam
    "Lame Vegan Girl",
    "BARELY COLD",
    "Right 5 Live",
    "Rummstein: The Old Chaos",
    "Shut Up and boom",
    "Light Traitors",
    "Soil-Teir",
    "Young Paper 6",
    "Require Documents",
    "Karfield Kart",
    "Because I want so 3",
    "Desire for Velocity",
    "Spaceship Championship",
    "Mail 2",
    "EarthQuake",
    "Loss: The Downward Spiral",
    "Hitman Faith",
    "The Trivia Game",
    "ColdEdge Florida",
    "Towns Cloud Vectors",
    "Dead and a half",
    "Minimal Suffering",
    "People Avoid",
    "Paycheck Night",
    "Jon Nancy's Stealth Adevtures",
    "BomberTale"
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

    string message = "";

   public void informationCompanyGetGame()
   {
        bool wasTheRequiredInfoUsed=false;
        wikiDescription.text = "";

        int seedForRNG = (int)(theImportantInfo.Substring(0, 1).ToCharArray()[0]) + (int)(theImportantInfo.Substring(1, 2).ToCharArray()[0]);
        Debug.Log("the seed is:" + seedForRNG);
        UnityEngine.Random.seed = seedForRNG;

        int nrOfCases = 5;
        bool[] alreadyWritten = new bool[nrOfCases];


        for (int i = 0; i < nrOfCases; i++)
        {
            int infoNumber = UnityEngine.Random.Range(0, nrOfCases);
            Debug.Log("nr=" + infoNumber);
            if(!alreadyWritten[infoNumber])
            {
                alreadyWritten[infoNumber] = true;
                switch(infoNumber)
                {
                    case 0:wikiDescription.text += theCompany + " was founded in " + foundedDate+". ";break;
                    case 1: if(UnityEngine.Random.Range(0,2)==1)
                            wikiDescription.text += "The company has a good reputation for releasing quality video games. "; 
                            else
                            wikiDescription.text += "The company has a negative reputation for releasing broken and overpriced video games. "; break;
                    case 2: if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription.text += "At the gate of bankruptcy, the company shut down in " + disbandedDate + ", after " + (disbandedDate - foundedDate) + " years from being founded. ";
                        else
                            wikiDescription.text += "After " + (disbandedDate - foundedDate) + " years from being founded, the company was disbanded for undocumented reasons in " + disbandedDate + ". "; break;
                    case 3: wikiDescription.text += "There are no controversies that involve the company."; break;
                    case 4:
                        wikiDescription.text += "The prefered game genre developed by this company is ";
                        int gameGenraRNG = UnityEngine.Random.Range(0, 9);
                        switch (gameGenraRNG)
                        {
                            case 0: wikiDescription.text += "first person shooters. "; break;
                            case 1: wikiDescription.text += "RPGs. "; break;
                            case 2: wikiDescription.text += "MMORPGs. "; break;
                            case 3: wikiDescription.text += "puzzles. "; break;
                            case 4: wikiDescription.text += "simulators. "; break;
                            case 5: wikiDescription.text += "sandbox. "; break;
                            case 6: wikiDescription.text += "freeroam. "; break;
                            case 7: wikiDescription.text += "survival. "; break;
                            case 8: wikiDescription.text += "arcade. "; break;
                        }
                        break;

                }
                    if (!wasTheRequiredInfoUsed)
                    {
                    if(UnityEngine.Random.Range(0,4)==3)
                        {
                        wikiDescription.text +="The definitory product of "+theCompany +" is the videogame "+ theImportantInfo+". ";
                        wasTheRequiredInfoUsed = true;
                        }
                    }
            }

        }
        if (!wasTheRequiredInfoUsed)
        {
            wikiDescription.text += "The definitory product of " + theCompany + " is the videogame " + theImportantInfo + ". ";
            wasTheRequiredInfoUsed = true;
        }
    }


    public void informationCompanyGetSoft()
    {
        bool wasTheRequiredInfoUsed = false;
        wikiDescription.text = "";

        int seedForRNG = (int)(theImportantInfo.Substring(0, 1).ToCharArray()[0]) + (int)(theImportantInfo.Substring(1, 2).ToCharArray()[0]);
        Debug.Log("the seed is:" + seedForRNG);
        UnityEngine.Random.seed = seedForRNG;

        int nrOfCases = 5;
        bool[] alreadyWritten = new bool[nrOfCases];


        for (int i = 0; i < nrOfCases; i++)
        {
            int infoNumber = UnityEngine.Random.Range(0, nrOfCases);
            Debug.Log("nr=" + infoNumber);
            if (!alreadyWritten[infoNumber])
            {
                alreadyWritten[infoNumber] = true;
                switch (infoNumber)
                {
                    case 0: wikiDescription.text += theCompany + " was founded in " + foundedDate + ". "; break;
                    case 1:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription.text += "The company has a good reputation for releasing quality software. ";
                        else
                            wikiDescription.text += "The company has a negative reputation for releasing bloatware and overpriced, unstable pieces of software. "; break;
                    case 2:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription.text += "At the gate of bankruptcy, the company shut down in " + disbandedDate + ", after " + (disbandedDate-foundedDate) + " years from being founded. ";
                        else
                            wikiDescription.text += "After " + (disbandedDate - foundedDate) + " years from being founded, the company was disbanded for undocumented reasons in "+disbandedDate+". "; break;
                    case 3: wikiDescription.text += "There are no controversies that involve the company. "; break;
                    case 4: wikiDescription.text += "The prefered game genre developed by this company is ";
                        int gameGenraRNG = UnityEngine.Random.Range(0, 6);
                        switch(gameGenraRNG)
                        {
                            case 0: wikiDescription.text += "image editors. ";break;
                            case 1: wikiDescription.text += "3d model editors. "; break;
                            case 2: wikiDescription.text += "IDEs. "; break;
                            case 3: wikiDescription.text += "chat apps. "; break;
                            case 4: wikiDescription.text += "web browsers. "; break;
                            case 5: wikiDescription.text += "antiviruses. "; break;
                            
                        }
                        break;


                }
                if (!wasTheRequiredInfoUsed)
                {
                    if (UnityEngine.Random.Range(0, 4) == 3)
                    {
                        wikiDescription.text += "The definitory product of " + theCompany + " is the software " + theImportantInfo + ". ";
                        wasTheRequiredInfoUsed = true;
                    }
                }
            }

        }
        if (!wasTheRequiredInfoUsed)
        {
            wikiDescription.text += "The definitory product of " + theCompany + " is the software " + theImportantInfo + ". ";
            wasTheRequiredInfoUsed = true;
        }
    }

    public void informationGetCompanyGame()
    {
        bool wasTheRequiredInfoUsed = false;
        wikiDescription.text = "";

        int seedForRNG = (int)(theImportantInfo.Substring(0, 1).ToCharArray()[0]) + (int)(theImportantInfo.Substring(1, 2).ToCharArray()[0]);
        Debug.Log("the seed is:" + seedForRNG);
        UnityEngine.Random.seed = seedForRNG;

        int nrOfCases = 5;
        bool[] alreadyWritten = new bool[nrOfCases];


        for (int i = 0; i < nrOfCases; i++)
        {
            int infoNumber = UnityEngine.Random.Range(0, nrOfCases);
            Debug.Log("nr=" + infoNumber);
            if (!alreadyWritten[infoNumber])
            {
                alreadyWritten[infoNumber] = true;
                switch (infoNumber)
                {
                    case 0: wikiDescription.text += theGame + " started development in " + foundedDate + ". "; break;
                    case 1:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription.text += "The game has a good reputation for bringing interesting mechanics. ";
                        else
                            wikiDescription.text += "The game has a negative reputation for unstable perfomance and unfair amount of paid DLCs. "; break;
                    case 2:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription.text += "After most of the community left, the game became officially unsupported " + disbandedDate + ", after " + (disbandedDate - foundedDate) + " years from starting development. ";
                        else
                            wikiDescription.text += "After " + (disbandedDate - foundedDate) + " years from starting development, the game officially lost support for undocumented reasons in " + disbandedDate + ". "; break;
                    case 3: wikiDescription.text += "There are no controversies that involving the game."; break;
                    case 4:
                        wikiDescription.text += "The game genre is that of ";
                        int gameGenraRNG = UnityEngine.Random.Range(0, 9);
                        switch (gameGenraRNG)
                        {
                            case 0: wikiDescription.text += "first person shooter. "; break;
                            case 1: wikiDescription.text += "RPG. "; break;
                            case 2: wikiDescription.text += "MMORPG. "; break;
                            case 3: wikiDescription.text += "puzzle. "; break;
                            case 4: wikiDescription.text += "simulator. "; break;
                            case 5: wikiDescription.text += "sandbox. "; break;
                            case 6: wikiDescription.text += "freeroam. "; break;
                            case 7: wikiDescription.text += "survival. "; break;
                            case 8: wikiDescription.text += "arcade. "; break;
                        }
                        break;

                }
                if (!wasTheRequiredInfoUsed)
                {
                    if (UnityEngine.Random.Range(0, 4) == 3)
                    {
                        wikiDescription.text += "The game \"" +theGame+ "\" is the definitory game developed and released by " + theImportantInfo + ". ";
                        wasTheRequiredInfoUsed = true;
                    }
                }
            }

        }
        if (!wasTheRequiredInfoUsed)
        {
            wikiDescription.text += "The game \"" + theGame + "\" is the definitory game developed and released by " + theImportantInfo + ". ";
            wasTheRequiredInfoUsed = true;
        }
    }

    public void informationGetCompanySoft()
    {
        bool wasTheRequiredInfoUsed = false;
        wikiDescription.text = "";

        int seedForRNG = (int)(theImportantInfo.Substring(0, 1).ToCharArray()[0]) + (int)(theImportantInfo.Substring(1, 2).ToCharArray()[0]);
        Debug.Log("the seed is:" + seedForRNG);
        UnityEngine.Random.seed = seedForRNG;

        int nrOfCases = 5;
        bool[] alreadyWritten = new bool[nrOfCases];


        for (int i = 0; i < nrOfCases; i++)
        {
            int infoNumber = UnityEngine.Random.Range(0, nrOfCases);
            Debug.Log("nr=" + infoNumber);
            if (!alreadyWritten[infoNumber])
            {
                alreadyWritten[infoNumber] = true;
                switch (infoNumber)
                {
                    case 0: wikiDescription.text += theGame + " was released in " + foundedDate + ". "; break;
                    case 1:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription.text += "The software has a good reputation for being useful for both professionals and beginners. ";
                        else
                            wikiDescription.text += "The software has a negative reputation for unstable perfomance and unfair amount of issues. "; break;
                    case 2:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription.text += "As of today, the software dropped support since " + disbandedDate + ", after " + (disbandedDate - foundedDate) + " years from being released. ";
                        else
                            wikiDescription.text += "After " + (disbandedDate - foundedDate) + " years from release, the software officially lost support for undocumented reasons in " + disbandedDate + ". "; break;
                    case 3: wikiDescription.text += "There are no controversies that involve the software."; break;
                    case 4:
                        wikiDescription.text += "The game genre is that of ";
                        int gameGenraRNG = UnityEngine.Random.Range(0, 9);
                        switch (gameGenraRNG)
                        {
                            case 0: wikiDescription.text += "first person shooter. "; break;
                            case 1: wikiDescription.text += "RPG. "; break;
                            case 2: wikiDescription.text += "MMORPG. "; break;
                            case 3: wikiDescription.text += "puzzle. "; break;
                            case 4: wikiDescription.text += "simulator. "; break;
                            case 5: wikiDescription.text += "sandbox. "; break;
                            case 6: wikiDescription.text += "freeroam. "; break;
                            case 7: wikiDescription.text += "survival. "; break;
                            case 8: wikiDescription.text += "arcade. "; break;
                        }
                        break;

                }
                if (!wasTheRequiredInfoUsed)
                {
                    if (UnityEngine.Random.Range(0, 4) == 3)
                    {
                        wikiDescription.text += "The software \"" + theGame + "\" is the definitory product developed and released by " + theImportantInfo + ". ";
                        wasTheRequiredInfoUsed = true;
                    }
                }
            }

        }
        if (!wasTheRequiredInfoUsed)
        {
            wikiDescription.text += "The software \"" + theGame + "\" is the definitory product developed and released by " + theImportantInfo + ". ";
            wasTheRequiredInfoUsed = true;
        }
    }


    int requestNumber;

    Text wikiTitle, wikiDescription;

    Text socialTitle, socialDescription;

    

    void Start()
    {

        

        //int s=UnityEngine.Random.value;
        

        wikiTitle = GameObject.Find("wikiTitle").GetComponent<Text>();
        wikiDescription = GameObject.Find("wikiDescription").GetComponent<Text>();
        socialTitle = GameObject.Find("socialTitle").GetComponent<Text>();
        socialDescription = GameObject.Find("socialDescription").GetComponent<Text>();

        requestNumber = UnityEngine.Random.Range(1,4);

        message = greet[UnityEngine.Random.Range(0, greet.Length)];

        theSoftware = softwareName[UnityEngine.Random.Range(0, softwareName.Length)];
        theCompany = companyName[UnityEngine.Random.Range(0, companyName.Length)];
        theGame = gameName[UnityEngine.Random.Range(0, gameName.Length)];
        foundedDate = UnityEngine.Random.Range(1970, 2014);
        disbandedDate = UnityEngine.Random.Range(foundedDate+1, 2018);

        switch (requestNumber)
        {
            case 1:                                                                                         //case of company-game, company-software, game-company and software-company 
                if (UnityEngine.Random.Range(0, 2) == 1)
                    isRequestingCompany = true;
                else
                    if (UnityEngine.Random.Range(0, 2) == 1)
                    isRequestingProductByCompanyGame = true;
                else
                    isRequestingProductByCompanySoft = true;
                             
                if (isRequestingProductByCompanySoft)
                {                                        
                    message += requestInfoIntro[UnityEngine.Random.Range(0, requestInfoIntro.Length)] + "what software did " + theCompany + " make?";
                    wikiTitle.text = theCompany;
                    theImportantInfo = theSoftware;
                    informationCompanyGetSoft();
                }
                else if(isRequestingProductByCompanyGame)
                {
                    message += requestInfoIntro[UnityEngine.Random.Range(0, requestInfoIntro.Length)] + "what game did " + theCompany + " develop?";
                    wikiTitle.text = theCompany;
                    theImportantInfo = theGame;
                    informationCompanyGetGame();
                }
                
                else if(isRequestingCompany)
                {       
                    if (UnityEngine.Random.Range(0, 2) == 1)
                    {
                        theGame = gameName[UnityEngine.Random.Range(0, gameName.Length)];
                        theCompany = companyName[UnityEngine.Random.Range(0, companyName.Length)];
                        message += requestInfoIntro[UnityEngine.Random.Range(0, requestInfoIntro.Length)] + "who was " + theGame + " made by?";
                        wikiTitle.text = theGame;
                        theImportantInfo = theCompany;
                        informationGetCompanyGame();
                    }
                    else
                    {
                        theSoftware = softwareName[UnityEngine.Random.Range(0, softwareName.Length)];
                        theCompany = companyName[UnityEngine.Random.Range(0, companyName.Length)];
                        message += requestInfoIntro[UnityEngine.Random.Range(0, requestInfoIntro.Length)] + "who was " + theSoftware + " made by?";
                        wikiTitle.text = theSoftware;
                        theImportantInfo = theCompany;
                        informationGetCompanySoft();
                    }
                }
                break;

            case 2:
                {
                    isRequestingLike = true;

                    if (UnityEngine.Random.Range(0, 2) == 1)
                        isRequestingCompany = true;
                    else
                    if (UnityEngine.Random.Range(0, 2) == 1)
                        isRequestingProductByCompanyGame = true;
                    else
                        isRequestingProductByCompanySoft = true;

                    if (isRequestingProductByCompanySoft)
                    {
                        message += requestLikeIntro[UnityEngine.Random.Range(0, requestLikeIntro.Length)] + theSoftware + " from " + theCompany + "?";
                        socialTitle.text = theSoftware;
                        theImportantInfo = "Like our software: " + theSoftware + " - made by " + theCompany;
                    }
                    else if (isRequestingProductByCompanyGame)
                    {
                        
                        message += requestLikeIntro[UnityEngine.Random.Range(0, requestLikeIntro.Length)] + theGame + " from " + theCompany + "?";
                        socialTitle.text = theGame;
                        theImportantInfo = "Like our game: " + theGame + " - made by " + theCompany;
                    }

                    else if (isRequestingCompany)
                    {
                        theCompany = softwareName[UnityEngine.Random.Range(0, softwareName.Length)];
                        if (UnityEngine.Random.Range(0, 2) == 1)
                        {
                            message += requestLikeIntro[UnityEngine.Random.Range(0, requestLikeIntro.Length)] + " the company known as " + theCompany + ", popular for their game \"" + theGame + "\"?";
                            wikiTitle.text = theGame;
                            theImportantInfo = "Like our company: " + theCompany + ", creators of " + theGame;
                        }
                        else
                        {
                            message += requestLikeIntro[UnityEngine.Random.Range(0, requestLikeIntro.Length)] + " the company known as " + theCompany + ", popular for developing the software \"" + theSoftware + "\"?"; ;
                            wikiTitle.text = theSoftware;
                            theImportantInfo = "Like our company: " + theCompany;
                        }

                    }
                }
                break;
            case 3:
                {
                    isRequestingYear = true;
                    int currentYear = DateTime.Now.Year;
                    year = UnityEngine.Random.Range(1960, currentYear);
                    theSoftware = softwareName[UnityEngine.Random.Range(0, softwareName.Length)];
                    message += requestInfoIntro[UnityEngine.Random.Range(0, requestInfoIntro.Length)] + "what year was " + theSoftware + " made in?";
                }
                break;
          
        }

        Debug.Log("case " + requestNumber + ": " + message);


        


    }

}
