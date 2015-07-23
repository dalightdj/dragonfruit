using UnityEngine;
using System.Collections;

public class Touch_Input : MonoBehaviour {

	private Touch[] touches; 



	// Use this for initialization
	void Start () {
	
		//touches = new Touch[10];

	}
	
	// Update is called once per frame
	void Update () {
	
		touches = Input.touches;

	}

	void OnGUI(){

		foreach (Touch t in touches){

			GUI.Label(new Rect(t.position.x,t.position.y,100,100),"x coordinate: " + t.position.x + "y coordinate: " + t.position.y );

		}

	}
}
