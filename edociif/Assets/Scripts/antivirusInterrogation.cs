using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class antivirusInterrogation : MonoBehaviour {

    
    public int virusType;//for tests. 0=none, 1=worm, 2=trojan

    public Sprite secureIcon;
    public Sprite secureIcon_alternate;
    public Sprite insecureIcon;


    public Sprite interogationSecure, interogationWorm, interogationTrojan;

    int randomNumber;

    public bool[] lies;
    public Sprite[] theSprites= new Sprite[3];
    public Sprite[] antivirusIcons = new Sprite[3];


    public Sprite[] theResponseIcon1 = new Sprite[3];
    public Sprite[] theResponseIcon2 = new Sprite[3];
    public Sprite[] theResponseIcon3 = new Sprite[3];
    public Sprite[] theResponseIcon4 = new Sprite[3];

    public int[] systType = new int[3]; //remember which output each antivirus gives
    int keepRightReference;

    // Use this for initialization
    public void generateVirus () 
    {
        virusType=Random.Range(0,3);

        lies = new bool[3];

        randomNumber = Random.Range(0,5);

        if (randomNumber / 3 == 0)
            {
            lies[0] = true;

            }
        else
            lies[0] = false;

        if (randomNumber % 3 == 0)
            {
            lies[1] = lies[0];
            }
        else
            lies[1] = !lies[0];

        if (lies[0] == lies[1])
            { 
            lies[2] = !lies[0]; 
            }
        else
        {
            lies[2] = (Random.Range(0, 2) == 1);
            //Debug.Log("a");
        }


        Debug.Log("seed: " + randomNumber);

        /*if (lies[0])
            Debug.Log("1 liar");
        else
            Debug.Log("1 right");

        if (lies[1])
            Debug.Log("2 liar");
        else
            Debug.Log("2 right");

        if (lies[2])
            Debug.Log("3 liar");
        else
            Debug.Log("3 right");*/

        

            for(int i=0;i<3;i++)
            {          
                if(!lies[i])
                    {
                    systType[i] = virusType;
                    keepRightReference = i;
                    if(virusType==0)
                        {
                            if (Random.Range(0, 2) == 1)
                                theSprites[i] = secureIcon;
                            else
                                theSprites[i] = secureIcon_alternate;
                        }
                        if (virusType == 1) 
                        {
                        theSprites[i] = insecureIcon;
                        //add worm case here
                        }
                        if (virusType == 2)
                        {
                        theSprites[i] = insecureIcon;
                        //add trojan case here
                        }
                        
                    }
               }
            for (int i = 0; i < 3; i++)
            {
                if(lies[i])
                {
                    if (systType[keepRightReference] == 0)
                        systType[i] = Random.Range(1, 3); //orig 0 2
                    if (systType[keepRightReference] == 2)
                        systType[i] = Random.Range(0, 2); //orig -1 1
                    if (systType[keepRightReference] == 1)
                        if (Random.Range(0, 2) == 1)
                            systType[i] = 0;
                        else
                            systType[i] = 2;
                    
                    if(systType[i]==0)
                        if (Random.Range(0, 2) == 1)
                            theSprites[i] = secureIcon;
                        else
                            theSprites[i] = secureIcon_alternate;
                    else
                        {
                        theSprites[i] = insecureIcon;
                        }
                    theResponseIcon1[i] = antivirusIcons[(i + 1) % 3];
                    theResponseIcon3[i] = antivirusIcons[(i + 2) % 3];
                    
                    if (systType[(i + 1) % 3] == 0)                             //interrogation response for first antivirus (always fake)
                        {
                        if (Random.Range(0, 2) == 1)
                            theResponseIcon2[i] = interogationWorm;
                        else
                            theResponseIcon2[i] = interogationTrojan;
                        }

                    if (systType[(i + 1) % 3] == 2)
                        {
                        if (Random.Range(0, 2) == 1)
                            theResponseIcon2[i] = interogationSecure;
                        else
                            theResponseIcon2[i] = interogationWorm;
                        }
                    if (systType[(i + 1) % 3] == 1)
                        {
                        if (Random.Range(0, 2) == 1)
                            theResponseIcon2[i] = interogationSecure;
                        else
                            theResponseIcon2[i] = interogationTrojan;
                        }

                if (systType[(i + 2) % 3] == 0)                             //interrogation response for second antivirus (always fake)
                {
                    if (Random.Range(0, 2) == 1)
                        theResponseIcon4[i] = interogationWorm;
                    else
                        theResponseIcon4[i] = interogationTrojan;
                }

                if (systType[(i + 2) % 3] == 2)
                {
                    if (Random.Range(0, 2) == 1)
                        theResponseIcon4[i] = interogationSecure;
                    else
                        theResponseIcon4[i] = interogationWorm;
                }
                if (systType[(i + 2) % 3] == 1)
                {
                    if (Random.Range(0, 2) == 1)
                        theResponseIcon4[i] = interogationSecure;
                    else
                        theResponseIcon4[i] = interogationTrojan;
                }
            }
            

//                Debug.Log(i + "is" + systType[i]);
            }
        for (int i = 0; i < 3; i++)
            if(!lies[i])
            {
                theResponseIcon1[i] = antivirusIcons[(i + 1) % 3];
                theResponseIcon3[i] = antivirusIcons[(i + 2) % 3];
                if (systType[(i + 1) % 3] == 0)
                    theResponseIcon2[i] = interogationSecure;
                if (systType[(i + 1) % 3] == 1)
                    theResponseIcon2[i] = interogationWorm;
                if (systType[(i + 1) % 3] == 2)
                    theResponseIcon2[i] = interogationTrojan;

                if (systType[(i + 2) % 3] == 0)
                    theResponseIcon4[i] = interogationSecure;
                if (systType[(i + 2) % 3] == 1)
                    theResponseIcon4[i] = interogationWorm;
                if (systType[(i + 2) % 3] == 2)
                    theResponseIcon4[i] = interogationTrojan;
            }
    }
	
    void Start()
    {
        generateVirus();
    }
	// Update is called once per frame
	
}

