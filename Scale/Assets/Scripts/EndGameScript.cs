using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("ReturnToOpening");
	}

	IEnumerator ReturnToOpening(){
		yield return new WaitForSeconds(120);
		Application.LoadLevel ("OpeningPan");
	}

	public void StartGame(){
		Application.LoadLevel ("Game");
	}
}
