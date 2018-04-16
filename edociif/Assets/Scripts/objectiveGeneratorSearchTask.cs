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

    int maxNrOfContacts=6;
    int currentContactSlot;

    
    public string[] theRequest= new string[6];
    public string[] theAnswer= new string[6];
    public string[] theSite= new string[6];
    public string[] theContent= new string[6];
    public int[] siteTemplate=new int[6];
    public bool[] siteRequireInfo = new bool[6];
    public bool[] siteIsSafe=new bool[6];
    public string[] siteUsername = new string[6];
    public string[] sitePassword = new string[6];

    public string[] requestSubject= new string[6];

    public GameObject CONTACT_DATA;

    public int randomIncrement=1;


    public void SpawnAdditionalContact(int numberOfSlotRemoved)
    {
        for(int i=numberOfSlotRemoved+1;i<maxNrOfContacts;i++)
            {
                theRequest[i-1]=theRequest[i];
                theAnswer[i-1]=theAnswer[i];
                theSite[i-1]=theSite[i];
                theContent[i-1]=theContent[i];
                siteTemplate[i-1]=siteTemplate[i];
                siteRequireInfo[i-1]=siteRequireInfo[i];
                siteIsSafe[i-1]=siteIsSafe[i];
                siteUsername[i-1]=siteUsername[i];
                sitePassword[i-1]=sitePassword[i];
                requestSubject[i-1]=requestSubject[i];
                userName[i-1]=userName[i];
                
                CONTACT_DATA.GetComponent<assignFriends>().chatTextBackup[i-1]=CONTACT_DATA.GetComponent<assignFriends>().chatTextBackup[i];
                CONTACT_DATA.GetComponent<assignFriends>().nameList[i-1]=CONTACT_DATA.GetComponent<assignFriends>().nameList[i];
                CONTACT_DATA.GetComponent<assignFriends>().reqType[i-1]=CONTACT_DATA.GetComponent<assignFriends>().reqType[i];
                CONTACT_DATA.GetComponent<assignFriends>().statusList[i-1]=CONTACT_DATA.GetComponent<assignFriends>().statusList[i];
                CONTACT_DATA.GetComponent<assignFriends>().requestGiver[i-1]=CONTACT_DATA.GetComponent<assignFriends>().requestGiver[i];
                
                
                
                
            }
            Debug.Log("progress1");


            currentContactSlot=maxNrOfContacts-1;
            makeContact();
            CONTACT_DATA.GetComponent<assignFriends>().refreshList=true;
    }//moves everything 

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

    public string[] siteName = new string[]
    {
        "infopedia",
        "bloatpedia",
        "thumbler",
        "thetriviasource",
        "trivialfacts",
        "infogalore"
    };

   public string[] siteDomain = new string[]
   {
       ".com",
       ".net",
       ".io",
       ".ru",
       ".en",
       ".kr"
   };

    public string[] userName= new string[]
    {
        "Aaron",
        "Beatrice",
        "Cory",
        "Darren",
        "Elliot",
        "Foo",
        "Garry",
        "Harry",
        "Irwin",
        "Jake",
        "Kenett",
        "Louise",
        "Manny",
        "Norman",
        "Oleg",
        "Patty",
        "Quagmire",
        "Ron",
        "Shaggy",
        "Tomm",
        "Ulan",
        "Warren",
        "Xen",
        "York",
        "Zena"

    };

    public string[] userStatus= new string[]
    {
        "finally home",
        "listening to music",
        "just seen a great movie",
        "amazing day today",
        "awful day",
        "please don't disturb",
        "better be important",
        "someone wanna talk?",
        "i'm so wasted today",
        "i'm dead",
        "my cat is sick :(",
        "let's chat!",
        "generic status",
        "statuses are dumb",
        "grinding"
    };

    string message = "";

    


   public void informationCompanyGetGame()
   {
        bool wasTheRequiredInfoUsed=false;
        wikiDescription = "";

        int seedForRNG = (int)(theImportantInfo.Substring(0, 1).ToCharArray()[0]) + (int)(theImportantInfo.Substring(1, 2).ToCharArray()[0]);
        Debug.Log("the seed is:" + seedForRNG);
        UnityEngine.Random.InitState(seedForRNG);

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
                    case 0:wikiDescription += theCompany + " was founded in " + foundedDate+". ";break;
                    case 1: if(UnityEngine.Random.Range(0,2)==1)
                            wikiDescription += "The company has a good reputation for releasing quality video games. "; 
                            else
                            wikiDescription += "The company has a negative reputation for releasing broken and overpriced video games. "; break;
                    case 2: if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription += "At the gate of bankruptcy, the company shut down in " + disbandedDate + ", after " + (disbandedDate - foundedDate) + " years from being founded. ";
                        else
                            wikiDescription += "After " + (disbandedDate - foundedDate) + " years from being founded, the company was disbanded for undocumented reasons in " + disbandedDate + ". "; break;
                    case 3: wikiDescription += "There are no controversies that involve the company."; break;
                    case 4:
                        wikiDescription += "The prefered game genre developed by this company is ";
                        int gameGenraRNG = UnityEngine.Random.Range(0, 9);
                        switch (gameGenraRNG)
                        {
                            case 0: wikiDescription += "first person shooters. "; break;
                            case 1: wikiDescription += "RPGs. "; break;
                            case 2: wikiDescription += "MMORPGs. "; break;
                            case 3: wikiDescription += "puzzles. "; break;
                            case 4: wikiDescription += "simulators. "; break;
                            case 5: wikiDescription += "sandbox. "; break;
                            case 6: wikiDescription += "freeroam. "; break;
                            case 7: wikiDescription += "survival. "; break;
                            case 8: wikiDescription += "arcade. "; break;
                        }
                        break;

                }
                    if (!wasTheRequiredInfoUsed)
                    {
                    if(UnityEngine.Random.Range(0,4)==3)
                        {
                        wikiDescription +="The definitory product of "+theCompany +" is the videogame "+ theImportantInfo+". ";
                        wasTheRequiredInfoUsed = true;
                        }
                    }
            }

        }
        if (!wasTheRequiredInfoUsed)
        {
            wikiDescription += "The definitory product of " + theCompany + " is the videogame " + theImportantInfo + ". ";
            wasTheRequiredInfoUsed = true;
        }
    }


    public void informationCompanyGetSoft()
    {
        bool wasTheRequiredInfoUsed = false;
        wikiDescription = "";

        int seedForRNG = (int)(theImportantInfo.Substring(0, 1).ToCharArray()[0]) + (int)(theImportantInfo.Substring(1, 2).ToCharArray()[0]);
        //Debug.Log("the seed is:" + seedForRNG);
        UnityEngine.Random.InitState(seedForRNG);

        int nrOfCases = 5;
        bool[] alreadyWritten = new bool[nrOfCases];


        for (int i = 0; i < nrOfCases; i++)
        {
            int infoNumber = UnityEngine.Random.Range(0, nrOfCases);
            //Debug.Log("nr=" + infoNumber);
            if (!alreadyWritten[infoNumber])
            {
                alreadyWritten[infoNumber] = true;
                switch (infoNumber)
                {
                    case 0: wikiDescription += theCompany + " was founded in " + foundedDate + ". "; break;
                    case 1:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription += "The company has a good reputation for releasing quality software. ";
                        else
                            wikiDescription += "The company has a negative reputation for releasing bloatware and overpriced, unstable pieces of software. "; break;
                    case 2:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription += "At the gate of bankruptcy, the company shut down in " + disbandedDate + ", after " + (disbandedDate-foundedDate) + " years from being founded. ";
                        else
                            wikiDescription += "After " + (disbandedDate - foundedDate) + " years from being founded, the company was disbanded for undocumented reasons in "+disbandedDate+". "; break;
                    case 3: wikiDescription += "There are no controversies that involve the company. "; break;
                    case 4: wikiDescription += "The prefered game genre developed by this company is ";
                        int gameGenraRNG = UnityEngine.Random.Range(0, 6);
                        switch(gameGenraRNG)
                        {
                            case 0: wikiDescription += "image editors. ";break;
                            case 1: wikiDescription += "3d model editors. "; break;
                            case 2: wikiDescription += "IDEs. "; break;
                            case 3: wikiDescription += "chat apps. "; break;
                            case 4: wikiDescription += "web browsers. "; break;
                            case 5: wikiDescription += "antiviruses. "; break;
                            
                        }
                        break;


                }
                if (!wasTheRequiredInfoUsed)
                {
                    if (UnityEngine.Random.Range(0, 4) == 3)
                    {
                        wikiDescription += "The definitory product of " + theCompany + " is the software " + theImportantInfo + ". ";
                        wasTheRequiredInfoUsed = true;
                    }
                }
            }

        }
        if (!wasTheRequiredInfoUsed)
        {
            wikiDescription += "The definitory product of " + theCompany + " is the software " + theImportantInfo + ". ";
            wasTheRequiredInfoUsed = true;
        }
    }

    public void informationGetCompanyGame()
    {
        bool wasTheRequiredInfoUsed = false;
        wikiDescription = "";

        int seedForRNG = (int)(theImportantInfo.Substring(0, 1).ToCharArray()[0]) + (int)(theImportantInfo.Substring(1, 2).ToCharArray()[0]);
        Debug.Log("the seed is:" + seedForRNG);
        UnityEngine.Random.InitState(seedForRNG);

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
                    case 0: wikiDescription += theGame + " started development in " + foundedDate + ". "; break;
                    case 1:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription += "The game has a good reputation for bringing interesting mechanics. ";
                        else
                            wikiDescription += "The game has a negative reputation for unstable perfomance and unfair amount of paid DLCs. "; break;
                    case 2:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription += "After most of the community left, the game became officially unsupported " + disbandedDate + ", after " + (disbandedDate - foundedDate) + " years from starting development. ";
                        else
                            wikiDescription += "After " + (disbandedDate - foundedDate) + " years from starting development, the game officially lost support for undocumented reasons in " + disbandedDate + ". "; break;
                    case 3: wikiDescription += "There are no controversies that involving the game."; break;
                    case 4:
                        wikiDescription += "The game genre is that of ";
                        int gameGenraRNG = UnityEngine.Random.Range(0, 9);
                        switch (gameGenraRNG)
                        {
                            case 0: wikiDescription += "first person shooter. "; break;
                            case 1: wikiDescription += "RPG. "; break;
                            case 2: wikiDescription += "MMORPG. "; break;
                            case 3: wikiDescription += "puzzle. "; break;
                            case 4: wikiDescription += "simulator. "; break;
                            case 5: wikiDescription += "sandbox. "; break;
                            case 6: wikiDescription += "freeroam. "; break;
                            case 7: wikiDescription += "survival. "; break;
                            case 8: wikiDescription += "arcade. "; break;
                        }
                        break;

                }
                if (!wasTheRequiredInfoUsed)
                {
                    if (UnityEngine.Random.Range(0, 4) == 3)
                    {
                        wikiDescription += "The game \"" +theGame+ "\" is the definitory game developed and released by " + theImportantInfo + ". ";
                        wasTheRequiredInfoUsed = true;
                    }
                }
            }

        }
        if (!wasTheRequiredInfoUsed)
        {
            wikiDescription += "The game \"" + theGame + "\" is the definitory game developed and released by " + theImportantInfo + ". ";
            wasTheRequiredInfoUsed = true;
        }
    }

    public void informationGetCompanySoft()
    {
        bool wasTheRequiredInfoUsed = false;
        wikiDescription = "";

        int seedForRNG = (int)(theImportantInfo.Substring(0, 1).ToCharArray()[0]) + (int)(theImportantInfo.Substring(1, 2).ToCharArray()[0]);
        Debug.Log("the seed is:" + seedForRNG);
        UnityEngine.Random.InitState(seedForRNG);

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
                    case 0: wikiDescription += theGame + " was released in " + foundedDate + ". "; break;
                    case 1:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription += "The software has a good reputation for being useful for both professionals and beginners. ";
                        else
                            wikiDescription += "The software has a negative reputation for unstable perfomance and unfair amount of issues. "; break;
                    case 2:
                        if (UnityEngine.Random.Range(0, 2) == 1)
                            wikiDescription += "As of today, the software dropped support since " + disbandedDate + ", after " + (disbandedDate - foundedDate) + " years from being released. ";
                        else
                            wikiDescription += "After " + (disbandedDate - foundedDate) + " years from release, the software officially lost support for undocumented reasons in " + disbandedDate + ". "; break;
                    case 3: wikiDescription += "There are no controversies that involve the software."; break;
                    case 4:
                        wikiDescription += "The game genre is that of ";
                        int gameGenraRNG = UnityEngine.Random.Range(0, 9);
                        switch (gameGenraRNG)
                        {
                            case 0: wikiDescription += "first person shooter. "; break;
                            case 1: wikiDescription += "RPG. "; break;
                            case 2: wikiDescription += "MMORPG. "; break;
                            case 3: wikiDescription += "puzzle. "; break;
                            case 4: wikiDescription += "simulator. "; break;
                            case 5: wikiDescription += "sandbox. "; break;
                            case 6: wikiDescription += "freeroam. "; break;
                            case 7: wikiDescription += "survival. "; break;
                            case 8: wikiDescription += "arcade. "; break;
                        }
                        break;

                }
                if (!wasTheRequiredInfoUsed)
                {
                    if (UnityEngine.Random.Range(0, 4) == 3)
                    {
                        wikiDescription += "The software \"" + theGame + "\" is the definitory product developed and released by " + theImportantInfo + ". ";
                        wasTheRequiredInfoUsed = true;
                    }
                }
            }

        }
        if (!wasTheRequiredInfoUsed)
        {
            wikiDescription += "The software \"" + theGame + "\" is the definitory product developed and released by " + theImportantInfo + ". ";
            wasTheRequiredInfoUsed = true;
        }
    }


    int requestNumber;

    string wikiTitle, wikiDescription;

    Text socialTitle, socialDescription;

    

    void makeContact()
    {
        message="";
        UnityEngine.Random.InitState(System.Environment.TickCount+randomIncrement);
        randomIncrement++;

        //int s=UnityEngine.Random.value;
        

        //wikiTitle = GameObject.Find("wikiTitle").GetComponent<Text>();
        //wikiDescription = GameObject.Find("wikiDescription").GetComponent<Text>();
        //socialTitle = GameObject.Find("socialTitle").GetComponent<Text>();
        //socialDescription = GameObject.Find("socialDescription").GetComponent<Text>();

        requestNumber = 1;//UnityEngine.Random.Range(1,4);

        message = greet[UnityEngine.Random.Range(0, greet.Length)];

        bool uniqueSoftware=false;
        do
        {   uniqueSoftware=true;
            theSoftware=softwareName[UnityEngine.Random.Range(0, softwareName.Length)];
            for(int i=0;i<maxNrOfContacts;i++)
                if(i!=currentContactSlot)
                    if(theSoftware==requestSubject[i])
                    uniqueSoftware=false;
        }while(!uniqueSoftware);

        requestSubject[currentContactSlot]=theSoftware;

        //theSoftware = softwareName[UnityEngine.Random.Range(0, softwareName.Length)];
        theCompany = companyName[UnityEngine.Random.Range(0, companyName.Length)];
        theGame = gameName[UnityEngine.Random.Range(0, gameName.Length)];
        foundedDate = UnityEngine.Random.Range(1970, 2014);
        disbandedDate = UnityEngine.Random.Range(foundedDate+1, 2018);
        
                                                                                                //case of company-game, company-software, game-company and software-company 
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
                    wikiTitle = theCompany;
                    theImportantInfo = theSoftware;
                    informationCompanyGetSoft();
                }
                else if(isRequestingProductByCompanyGame)
                {
                    message += requestInfoIntro[UnityEngine.Random.Range(0, requestInfoIntro.Length)] + "what game did " + theCompany + " develop?";
                    wikiTitle = theCompany;
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
                        wikiTitle = theGame;
                        theImportantInfo = theCompany;
                        informationGetCompanyGame();
                    }
                    else
                    {
                        theSoftware = softwareName[UnityEngine.Random.Range(0, softwareName.Length)];
                        theCompany = companyName[UnityEngine.Random.Range(0, companyName.Length)];
                        message += requestInfoIntro[UnityEngine.Random.Range(0, requestInfoIntro.Length)] + "who was " + theSoftware + " made by?";
                        wikiTitle = theSoftware;
                        theImportantInfo = theCompany;
                        informationGetCompanySoft();
                    }
                }
                
           
        

        //Debug.Log( message+currentContactSlot);
 

        theAnswer[currentContactSlot]=theImportantInfo;
        
        theRequest[currentContactSlot]=message;
        
        theContent[currentContactSlot]=wikiDescription;
        theSite[currentContactSlot]= siteName[UnityEngine.Random.Range(0,theSite.Length)]+siteDomain[currentContactSlot];

        bool uniqueName=false;
        do
        {   uniqueName=true;
            CONTACT_DATA.GetComponent<assignFriends>().nameList[currentContactSlot]=userName[UnityEngine.Random.Range(0, userName.Length)];
            for(int i=0;i<maxNrOfContacts;i++)
                if(i!=currentContactSlot)
                    if(CONTACT_DATA.GetComponent<assignFriends>().nameList[currentContactSlot]==CONTACT_DATA.GetComponent<assignFriends>().nameList[i])
                    uniqueName=false;
        }while(!uniqueName);

              
        CONTACT_DATA.GetComponent<assignFriends>().chatTextBackup[currentContactSlot]=CONTACT_DATA.GetComponent<assignFriends>().nameList[currentContactSlot]+": " +theRequest[currentContactSlot];
        //Debug.Log(CONTACT_DATA.GetComponent<assignFriends>().chatTextBackup[currentContactSlot]);
        if(UnityEngine.Random.Range(0,2)==1)
        CONTACT_DATA.GetComponent<assignFriends>().statusList[currentContactSlot]=userStatus[UnityEngine.Random.Range(0,userStatus.Length)];

        
    }
    void Start()
    {
        for(currentContactSlot=0;currentContactSlot<maxNrOfContacts;currentContactSlot++)
        {
            makeContact();Debug.Log("repeated");
        }
    CONTACT_DATA.GetComponent<assignFriends>().refreshList=true;
       
    }
    
}
