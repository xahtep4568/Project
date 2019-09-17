using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetPlayerUI : MonoBehaviour 
{
	private string getSymb;
	private Button button;
	private CreateFieldUI createFieldUI;

	void SetPlayer()
	{
		createFieldUI.SetSymb(getSymb[0]);
	}

	private void Start()
	{
		createFieldUI = GameObject.Find ("Main Camera").GetComponent<CreateFieldUI> ();
		button = GetComponent<Button> ();
		getSymb = GetComponentInChildren<Text> ().text.ToString ();
		button.onClick.AddListener (delegate {this.SetPlayer ();});
	}
}
