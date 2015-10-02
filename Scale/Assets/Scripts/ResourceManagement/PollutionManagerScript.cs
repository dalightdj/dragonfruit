using UnityEngine;
using System.Collections;

//A script for managing the pollution. It inherits from the ResourceManagementScript
public class PollutionManagerScript : ResourceManagementScript {

	public override void addResources(){
		GameController.gameController.addResources (0, 0, 1, 0);
	}
}
