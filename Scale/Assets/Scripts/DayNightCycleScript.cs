using UnityEngine;
using System.Collections;

public class DayNightCycleScript : MonoBehaviour {

	public float speed = 10f;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.right, speed * Time.deltaTime);
	}
}
