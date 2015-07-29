using UnityEngine;
using System.Collections;

public class Touch_Input : MonoBehaviour {

	private Touch[] touches; 

	public Material selectedMaterial;

	// Use this for initialization
	void Start () {
	
		//touches = new Touch[10];

	}
	
	// Update is called once per frame
	void Update () {
	
		touches = Input.touches;
		foreach(Touch t in touches){


			Ray screenRay = Camera.main.ScreenPointToRay(t.position);
			
			RaycastHit hit;
			if (Physics.Raycast(screenRay, out hit))
			{
				print("User tapped on game object " + hit.collider.gameObject.name);
				Renderer selectedRenderer = hit.collider.gameObject.GetComponent<Renderer>();
				selectedRenderer.GetComponent<Material>().SetColor("_Color", Color.red);
			}

		}

	}


	void OnMouseDown(){

		Ray  mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(mouseRay, out hit))
		{
			print("User tapped on game object " + hit.collider.gameObject.name);
			Renderer selectedRenderer = hit.collider.gameObject.GetComponent<Renderer>();
			selectedRenderer.GetComponent<Material>().SetColor("_Color", Color.red);
		}

	}

	void OnGUI(){

		foreach (Touch t in touches){

			GUI.Label(new Rect(t.position.x,t.position.y,100,100),"x coordinate: " + t.position.x + "y coordinate: " + t.position.y );

		}

	}
}
