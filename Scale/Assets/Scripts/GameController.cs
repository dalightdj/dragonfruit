using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public int timeLimit = 60;//the losing condition i.e. 60 seconds

	private float time;
	private GameObject[] scoreTexts;//the Text components that will show the score

	// Use this for initialization
	void Start () {
		scoreTexts = GameObject.FindGameObjectsWithTag ("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {

		//A simple countdown
		time += Time.deltaTime;
		for(int i = 0; i<scoreTexts.Length; i++){
			scoreTexts[i].GetComponent<Text>().text = string.Format("{0:n0}", ((timeLimit+0.5)-time));
		}



		//END GAME
		if (time >= timeLimit) {
			Application.LoadLevel("Ending");
		}
	}
}
