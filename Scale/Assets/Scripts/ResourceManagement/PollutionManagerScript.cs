using UnityEngine;
using System.Collections;

public class PollutionManagerScript : MonoBehaviour {

	private float pollutionGrowthRate = 1;
	private float count = 0;

	// Update is called once per frame
	void Update () {
		count += pollutionGrowthRate;
		
		if (count/100 >= 1) {
			GameController.gameController.addResources (0, 0, 1, 0);
			count = 0;
		}
	}
}
