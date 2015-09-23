using UnityEngine;
using System.Collections;

public class PollutionManagerScript : ResourceManagementScript {

	public override void addResources(){
		GameController.gameController.addResources (0, 0, 1, 0);
	}
}
