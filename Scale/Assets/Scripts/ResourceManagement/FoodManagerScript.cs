using UnityEngine;
using System.Collections;

public class FoodManagerScript : ResourceManagementScript {

	public override void addResources(){
		GameController.gameController.addResources (0, 0, 0, 1);
	}
}
