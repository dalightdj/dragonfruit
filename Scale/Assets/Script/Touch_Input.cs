using UnityEngine;
using System.Collections;

public class Touch_Input : MonoBehaviour {

	private Touch[] touches; 
	
	public Material selectedMaterial;

	/*Variables for GUI rotation*/
	private float rotAngle = 0;
	private Vector2 pivotPoint;

	private Vector3 MouseOrigin;
	private Vector3 mouseFinish;

	// Update is called once per frame
	void Update () {
	
		touches = Input.touches;
		foreach (Touch t in touches) {


			Ray screenRay = Camera.main.ScreenPointToRay (t.position);
			
			RaycastHit hit;
	
			if (Physics.Raycast (screenRay, out hit)) {
				print ("User tapped on game object " + hit.collider.gameObject.name);
				GameObject selectedObject_Touch = hit.collider.gameObject;
				Destroy (selectedObject_Touch);
			} else {
				print ("nada");
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
