using UnityEngine;
using System.Collections;

public class FoodManagerScript : ResourceManagementScript {

	private float foodGrowthRate = 1;
	private float count = 0;

	public override void addResources(){
		GameController.gameController.addResources (0, 0, 0, 1);
	}
}
