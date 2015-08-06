using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Touch_Input : MonoBehaviour {

	private Touch[] touches; 
	private Dictionary<Touch, GameObject> touches_for_use;

	public BuildMenuScript BMS; 

	
	public Material selectedMaterial;

	/*Variables for GUI rotation*/
	private float rotAngle = 0;
	private Vector2 pivotPoint;

	private Vector3 MouseOrigin;
	private Vector3 mouseFinish;


	void Start(){
		touches_for_use = new Dictionary<Touch, GameObject> ();
	}

	// Update is called once per frame
	void Update () {
	
		touches = Input.touches;
		foreach (Touch t in touches) {



			if(t.phase == TouchPhase.Began){
							
				Ray screenRay = Camera.main.ScreenPointToRay (t.position);
				
				RaycastHit hit;
				
				if (Physics.Raycast (screenRay, out hit)) {
					print ("User tapped on game object " + hit.collider.gameObject.name);
					GameObject selectedObject_Touch = hit.collider.gameObject;

					touches_for_use.Add(t, selectedObject_Touch);
					//Destroy (selectedObject_Touch);
				} else {
					print ("touched nothing");
				}

			}


			foreach( KeyValuePair<Touch, GameObject> tch in touches_for_use){

				if(tch.Key.phase == TouchPhase.Ended){

					Ray screenRay = Camera.main.ScreenPointToRay (tch.Key.position);
					
					RaycastHit hit;
					
					if (Physics.Raycast (screenRay, out hit)) {
						print ("User ended swipe on game object: " + hit.collider.gameObject.name);
						GameObject selectedObject_Touch = hit.collider.gameObject;

						TileEnum dir = selectedObject_Touch.GetComponent<TileEnum>();

						BMS.callMenu(dir.Tiles_Loc ,tch.Key.position);



						Destroy (selectedObject_Touch);
					} else {
						print ("end phase landed on");
					}

				}

			}


		}


		if (Input.GetMouseButtonDown (0)) {

			MouseOrigin = Input.mousePosition;


			Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (mouseRay, out hit)) {
				print ("User tapped on game object " + hit.collider.gameObject.name);
				GameObject selectedObject_Mouse = hit.collider.gameObject;



				/*Get the pivot*/
				//pivotPoint = new Vector2(Screen.width / 2, Screen.height / 2);
				//GUIUtility.RotateAroundPivot(, pivotPoint);
				//GUI.Label(new Rect(Input.mousePosition.x, Input.mousePosition.y, 100,100),"X position: " + t.position.x + "y coordinate: " + t.position.y );

				
				Destroy (selectedObject_Mouse);
			} else {
				print ("nada");
			}
		}


		if(Input.GetMouseButtonUp(0)){

			mouseFinish = Input.mousePosition;

			/*Get the pivot*/
			pivotPoint = new Vector2(Screen.width / 2, Screen.height / 2);

			GUIUtility.RotateAroundPivot(Vector3.Angle(MouseOrigin, mouseFinish)  ,pivotPoint);
			GUI.Label(new Rect(Input.mousePosition.x, Input.mousePosition.y, 100,100),"X position: " + Input.mousePosition.x + "y coordinate: " + Input.mousePosition.y );
			GUIUtility.RotateAroundPivot(-Vector3.Angle(MouseOrigin, mouseFinish)  ,pivotPoint);
			print ("yolo");
		}

	}
				void OnGUI(){
					
					foreach (Touch t in touches){
						
						GUI.Label(new Rect(t.position.x,t.position.y,100,100),"x coordinate: " + t.position.x + "y coordinate: " + t.position.y );

		}

	}
}
