using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour 
{
	private CreateFieldUI createFieldUI;
	private GameLoader gameLoader;


	// Use this for initialization
	private void Start () 
	{
		gameLoader = new GameLoader (this);
		createFieldUI = GetComponent<CreateFieldUI> ();
		createFieldUI.GetGameLoader(this.gameLoader);

	}

	public void UISet(int x, int y,char symbol)
	{
		createFieldUI.buttonField [x, y].GetComponentInChildren<Text>().text = symbol.ToString ();
		createFieldUI.buttonField [x, y].interactable = false;
		if (gameLoader.GetGameOver()) 
		{
			createFieldUI.slider.gameObject.SetActive (true);
			createFieldUI.setPlayers.gameObject.SetActive (true);
			createFieldUI.winText.text = gameLoader.GetPlayer ();
			SetInteracteble ();
		}
	}
	private void SetInteracteble()
	{
		for (int x = 0; x < GameManager.battleFieldSize; x++) 
		{
			for (int y = 0; y < GameManager.battleFieldSize; y++) 
			{
				createFieldUI.buttonField [x, y].interactable = false;
			}
		}
	}
}
