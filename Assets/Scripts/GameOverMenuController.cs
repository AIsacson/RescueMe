using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenuController : MonoBehaviour {

	public Canvas gameOverMenu;
	public Text gameOver;
	public Button restart;
	public Button menuBack;

	// Use this for initialization
	void Start () {
		gameOverMenu = gameOverMenu.GetComponent<Canvas> ();
		restart = restart.GetComponent<Button> ();
		menuBack = menuBack.GetComponent<Button> ();
		gameOverMenu.enabled = false;
		gameOver.enabled = false;
	}

	public void GameOver(){
		gameOverMenu.enabled = true;
		gameOver.enabled = true;
	}

	public void Restart(){
		SceneManager.LoadScene ("Level1");
	}

	public void MenuBack(){
		SceneManager.LoadScene ("Menu");
	}
}
