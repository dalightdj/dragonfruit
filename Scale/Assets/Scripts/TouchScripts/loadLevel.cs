using UnityEngine;
using System.Collections;

//for laoding the next scene. loads scene instantly from loading scene.
public class loadLevel : MonoBehaviour {


	// Use this for initialization
	void Start () {
		//simply loads next level
		Application.LoadLevel ("Game");
	
	}
	

}
