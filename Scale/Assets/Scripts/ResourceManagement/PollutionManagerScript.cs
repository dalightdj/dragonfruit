using UnityEngine;
using System.Collections;

public class PollutionManagerScript : ResourceManagementScript {

	private float pollutionGrowthRate = 1;
	private float count = 0;

	public override void addResources(){
		GameController.gameController.addResources (0, 0, 1, 0);
	}
}
