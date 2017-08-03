using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas helpMenu;
	public Button startText;
	public Button exitText;
	public Button helpText;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		helpMenu = helpMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		helpText = helpText.GetComponent<Button> ();
		quitMenu.enabled = false;
		helpMenu.enabled = false;
	}
	
	public void ExitPress (){
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		helpText.enabled = false;
	}

	public void NoPress(){
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		helpText.enabled = true;
	}

	public void BackPress(){
		helpMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		helpText.enabled = true;
	}

	public void HelpPress(){
		helpMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		helpText.enabled = false;
	}

	public void StartLevel(){
		SceneManager.LoadScene ("Level1");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
