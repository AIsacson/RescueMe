using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EndGameController : MonoBehaviour {
	
	public Text rescueMsg;
	public Canvas endGame;

	void Start () {
		rescueMsg.text = "";
		endGame.enabled = false;
	}

	public void Congrats(){
		rescueMsg.text = "You have been rescued !";
		Invoke ("MenuBack", 3);
	}

	void MenuBack(){
		endGame.enabled = true;
	}
}
