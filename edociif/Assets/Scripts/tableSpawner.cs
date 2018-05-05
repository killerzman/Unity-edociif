using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tableSpawner : MonoBehaviour {

	const int SquareSize=16;

	public GameObject prefabSquare;
	public int table_width=9;
	public int table_height=9;

	public int bombNumber=10;
	public int revealedNumber = 0;

	public struct bombPos{public int x;public int y;};
	public bombPos[] bombe= new bombPos[920];

	public Sprite[] bombIndicators=new Sprite[8];
	public Sprite square;
	public Sprite square_empty;

	public GameObject[,] tableSquares= new GameObject[33,33];

	GameObject windowReference;
	
	public bool isGameOver=false;
	public bool isGameWon=false;
	public bool firstClick=false;

	void OnDisable()
	{
		/*for(int i=0;i<table_height;i++)
		{
			for(int j=0;j<table_width;j++)
			{
				tableSquares[i,j]=null;
			}
		}*/
		foreach (Transform child in gameObject.transform) 
		{
     		GameObject.Destroy(child.gameObject);
 		}
 		
	}



	void clickEvent(int i, int j)
	{
		if(firstClick)
		{
			bombe[0].x=i;
			bombe[0].y=j;
			generateTable();
			generateNumbers();
			firstClick=false;
		}
		if(!isGameOver)
		{
			Debug.Log("Clicked on"+i+" "+j);
			if(tableSquares[i,j].GetComponent<minesweeperSquare>().isBomb)
			{
				Debug.Log("gameOver");
				for(int k=1;k<=bombNumber;k++)
				{
					tableSquares[bombe[k].x,bombe[k].y].GetComponent<Image>().color=Color.red;
				}
				isGameOver=true;
			}
			else{
				fillFnc(i,j);
				if(revealedNumber + bombNumber >= table_height * table_width){
					isGameWon = true;
				}
			}
		}
	}

	void OnEnable () {
		if(table_width<9)
			table_width=9;
		if(table_height<9)
			table_height=9;
			if(table_width>32)
			table_width=32;
		if(table_height>32)
			table_height=32;
		firstClick=true;
		isGameOver=false;
		gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<windowProp>().windowWidth=SquareSize*table_width;
		gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<windowProp>().windowHeight=SquareSize*table_height+64;

		int maxNrBombs=table_width*table_height*90/100;
		int minNrBombs=table_width*table_height/10;

		if(bombNumber>maxNrBombs)
			bombNumber=maxNrBombs;
		if(bombNumber<minNrBombs)
			bombNumber=minNrBombs;

		

		for(int i=0;i<table_height;i++)
		{
			for(int j=0;j<table_width;j++)
			{
				int closureI = i;
				int closureJ = j;
				tableSquares[i,j]=(GameObject)Instantiate(prefabSquare);

				tableSquares[i,j].transform.SetParent(gameObject.transform);
				tableSquares[i,j].transform.localPosition=new Vector2(j*SquareSize,512-i*SquareSize);
				tableSquares[i,j].transform.localScale=new Vector2(0.9f,0.9f);
				//tableSquares[i,j].GetComponent<minesweeperSquare>().i=i;
				//tableSquares[i,j].GetComponent<minesweeperSquare>().j=j;
				tableSquares[i,j].GetComponent<Button>().onClick.AddListener(()=>clickEvent(closureI,closureJ));
				tableSquares[i,j].GetComponent<Image>().color=new Color32(135,135,135,255);
				
			}
		}
		//generateTable();
		//generateNumbers();

	}
	
void Start()
{
	OnEnable();
}

	void generateTable()
	{
		for(int k=1;k<=bombNumber;k++)
		{
			int x,y;
			bool ok=true;
			do
			{
				ok=true;
			x=Random.Range(0,table_height);
			y=Random.Range(0,table_width);
			bombe[k].x=x;
			bombe[k].y=y;

				for(int u=0;u<k;u++)
				{
					if(bombe[u].x==x&&bombe[u].y==y)
					ok=false;
				}

			}while(!ok);

			//tableSquares[x,y].GetComponent<Image>().color=Color.red;
			Debug.Log(x+" "+y);
			tableSquares[x,y].GetComponent<minesweeperSquare>().isBomb=true;


			
		}
	}

	bool insideMatrix(int i, int j)
	{
		if(i<0||i>=table_height||j<0||j>=table_width)
			return false;
		return true;
	}

int[] posx=new int[]{0,1,1, 1, 0,-1,-1,-1};
int[] posy=new int[]{1,1,0,-1,-1,-1, 0, 1};

	void generateNumbers()
	{
		int bombNr=0;
		for(int i=0;i<table_height;i++)
		{
			for(int j=0;j<table_width;j++)
			{
				bombNr=0;
				if(!tableSquares[i,j].GetComponent<minesweeperSquare>().isBomb)
				{
					
					for(int k=0;k<8;k++)
					{
						int newi,newj;
						newi=i+posx[k];
						newj=j+posy[k];
						if(insideMatrix(newi,newj))
						{
							if(tableSquares[newi,newj].GetComponent<minesweeperSquare>().isBomb)
							{
								bombNr++;
							}
						}
					}
				}
				if(bombNr>0)
				{
					//tableSquares[i,j].transform.Find("indicator").gameObject.GetComponent<Image>().enabled=true;
					tableSquares[i,j].transform.Find("indicator").gameObject.GetComponent<Image>().sprite=bombIndicators[bombNr-1];
					tableSquares[i,j].GetComponent<minesweeperSquare>().isNumber=true;
					
				}

			}
		}
		
	}
	

	void fillFnc(int i, int j)
	{
		tableSquares[i,j].GetComponent<Image>().color=new Color32(50,50,50,255);
		if(tableSquares[i,j].GetComponent<minesweeperSquare>().isRevealed==true) return;
		revealedNumber++;
		if(tableSquares[i,j].GetComponent<minesweeperSquare>().isNumber)
			tableSquares[i,j].transform.Find("indicator").gameObject.GetComponent<Image>().enabled=true;
		if(!tableSquares[i,j].GetComponent<minesweeperSquare>().isNumber)
		{
			tableSquares[i,j].GetComponent<minesweeperSquare>().isRevealed=true;

			for(int x=0;x<8;x+=2)
				{
					int newi=i+posx[x];
					int newj=j+posy[x];
					if(insideMatrix(newi,newj))
					{
						fillFnc( newi, newj);
					}
					
				}
		}
	}

	void Update () {
		
	}
}
