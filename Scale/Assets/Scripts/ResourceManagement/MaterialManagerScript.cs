using UnityEngine;
using System.Collections;

public class MaterialManagerScript : MonoBehaviour {

	private float materialGrowthRate = 1;
	private float count = 0;
	

	// Update is called once per frame
	void Update () {	
		count += materialGrowthRate;
		
		if (count/100 >= 1) {
			GameController.gameController.addResources (0, 1, 0, 0);
			count = 0;
		}
	}
}
