using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateFieldUI : MonoBehaviour 
{
	private Transform panelPref;
	private GridLayoutGroup gameCells;
	private float sizeWidth;
	private float sizeHeight;
	private int tempSize;
	public Button[,] buttonField;
	public GameObject setPlayers;
	public Text playerText;
	public Text winText;
	internal Slider slider;
	private Button startButton;
	private Text fieldSizeText;
	private int gameFieldSize;
	private GameObject fieldSizeObject;
	private char playerSymb = 'O';
	private GameLoader gameLoader;
	private Button buttonPref;
	private UIController uiController;

	private void Start()
	{
		gameCells = GameObject.Find("GamePanel").GetComponentInChildren<GridLayoutGroup> ();
		panelPref = GameObject.Find("GameField").GetComponent<Transform> ();
		buttonPref = Resources.Load<Button> ("Button");
		sizeWidth = gameCells.cellSize.x;
		sizeHeight = gameCells.cellSize.y;
		fieldSizeObject = GameObject.Find("FieldSize");
		slider = fieldSizeObject.GetComponentInChildren<Slider> ();
		startButton = fieldSizeObject.GetComponentInChildren<Button> ();
		fieldSizeText = fieldSizeObject.GetComponentInChildren<Text> ();
		slider.onValueChanged.AddListener (delegate{this.ChangeText();});
		startButton.onClick.AddListener(SetSize);
	}
	private void SetSize()
	{
		gameFieldSize = (int)slider.value;
		gameLoader.Generate (gameFieldSize,playerSymb);
		UiCreate (gameFieldSize);
	}
	private void ChangeText()
	{
		fieldSizeText.text = "Field size " + slider.value + "X" + slider.value;
	}
	public void SetSymb(char value)
	{
		playerSymb = value;
		playerText.text = "First:"+playerSymb;
	}
	public void GetGameLoader(GameLoader gameLoader)
	{
		this.gameLoader = gameLoader;
	}

	public void UiCreate(int size)
	{
		slider.gameObject.SetActive (false);
		setPlayers.gameObject.SetActive (false);
		winText.text = "";
		Vector2 newSize = new Vector2 (sizeWidth / size, sizeHeight / size);
		if (buttonField != null) {
			for (int i = 0; i < tempSize; i++) 
			{
				for (int j = 0; j < tempSize; j++) 
				{
					Destroy (buttonField [i, j].gameObject);
				}
			}
		}
		buttonField = new Button[size, size];
		tempSize = size;
		gameCells.cellSize = newSize;
		for (int i = 0; i < size; i++) 
		{
			for (int j = 0; j < size; j++) 
			{
				buttonField [i, j] = Instantiate (buttonPref);
				buttonField [i, j].transform.SetParent (panelPref, false);
				var i1 = i;
				var j1 = j;
				buttonField [i, j].onClick.AddListener (delegate {this.gameLoader.SetCoord(i1, j1);});
			}
		}
	}
}
