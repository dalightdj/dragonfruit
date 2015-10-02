using UnityEngine;
using System.Collections;

//A script for managing the food resources. It inherits from the ResourceManagementScript
public class FoodManagerScript : ResourceManagementScript {

	public override void addResources(){
		GameController.gameController.addResources (0, 0, 0, 1);
	}
}
