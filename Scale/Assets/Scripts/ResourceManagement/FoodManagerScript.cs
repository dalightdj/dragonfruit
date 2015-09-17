using UnityEngine;
using System.Collections;

public class FoodManagerScript : MonoBehaviour {

	private float foodGrowthRate = 1;
	private float count = 0;

	// Update is called once per frame
	void Update () {
		count += foodGrowthRate;

		if (count/1000 >= 1) {
			GameController.gameController.addResources (0, 0, 0, 1);
			count = 0;
		}
	}
}
