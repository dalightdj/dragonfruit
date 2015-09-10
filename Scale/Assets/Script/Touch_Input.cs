using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Touch_Input : MonoBehaviour {
	
	private Touch[] touches; 
	private Dictionary<Touch, GameObject> touches_for_use;
	
	public GameObject gameGUI; 
	private BuildMenuScript BMS;
	
	public Material selectedMaterial;

	//for highlighting
	private Color highLightColor;
	private String tag;
	
	/*Variables for GUI rotation*/
	private float rotAngle = 0;
	private Vector2 pivotPoint;
	
	private Vector3 MouseOrigin;
	private Vector3 mouseFinish;
	
	private Boolean swiped = false;
	
	public int swipeThreshold = 10;
	void Start(){
		touches_for_use = new Dictionary<Touch, GameObject> ();
		BMS = gameGUI.GetComponent<BuildMenuScript> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		touches = Input.touches;
		foreach (Touch t in touches) {
			
			//when the touch first happens.
			if (t.phase == TouchPhase.Began) {
				
				Ray screenRay = Camera.main.ScreenPointToRay (t.position);
				
				RaycastHit hit;
				//if the ray hits an object we add it to the touches we are going to use map.
				//the key in the map is the touch and the value is a reference to the object first touched.
				if (Physics.Raycast (screenRay, out hit)) {
					print ("User tapped on game object " + hit.collider.gameObject.name);
					GameObject selectedObject_Touch = hit.collider.gameObject;
					
					touches_for_use.Add (t, selectedObject_Touch);
					//Destroy (selectedObject_Touch);
				} else {
					print ("touched nothing");
				}
				
			}
			
		}
		
		//now we iterate through all usable touches
		foreach( KeyValuePair<Touch, GameObject> tch in touches_for_use){
			
			//default direction.
			BuildMenuScript.Direction dir = BuildMenuScript.Direction.UP;

			//Get the change in positions of the touch from its last check.
			Vector2 moved = tch.Key.deltaPosition;

			//up down swipe
			if(Math.Abs(moved.x) < Math.Abs (moved.y) ){

				//down swipe
				if(moved.y < -swipeThreshold){
					tag = "Down";
					dir = BuildMenuScript.Direction.DOWN;
					highLightColor = Color.red;
					swiped = true;
					
				}
				//up swipe
				else if (moved.y > swipeThreshold){
					tag = "Up";
					dir = BuildMenuScript.Direction.UP;
					highLightColor = Color.blue;
					swiped = true;
				}
			}
			//left right swipe
			else if(Math.Abs(moved.x) > Math.Abs (moved.y) ){
				//left swipe
				if(moved.x < -swipeThreshold){
					tag = "Left";
					dir = BuildMenuScript.Direction.LEFT;
					highLightColor = Color.green;
					swiped = true;
				}
				//right swipe
				else if(moved.x > swipeThreshold){
					tag = "Right";
					dir = BuildMenuScript.Direction.RIGHT;
					highLightColor = Color.magenta;
					swiped = true;
				}
				
			}

			
			if(swiped){
				BMS.callMenu(dir, tch.Value);
				startLight(tch.Value);
				removeTouch(tch.Key);

			}
						
		}
		
		//-----------mouse methods--------------------

		if (Input.GetMouseButtonDown (0)) {
			
			MouseOrigin = Input.mousePosition;
			
			Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (mouseRay, out hit)) {
				print ("User tapped on game object " + hit.collider.gameObject.name);
				GameObject selectedObject_Mouse = hit.collider.gameObject;
				

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
	//removes the touch from the map and also turns swiped to false.
	void removeTouch(Touch t){
		
		touches_for_use.Remove (t);
		swiped = false;
		
	}
	//adds the highlgihting for a given tile. will add a point light 1 unit above teh given game object
	void startLight(GameObject obj){
		
		GameObject lightGameObject = new GameObject("The Light");
		Light lightComp = lightGameObject.AddComponent<Light>();
		lightComp.color = highLightColor;
		lightGameObject.tag = tag;
		Vector3 raise = new Vector3 (0,1,0);
		lightGameObject.transform.position = obj.transform.position + raise;
		
		
	}
}