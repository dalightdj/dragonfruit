using UnityEngine;
using System.Collections;

public class MaterialManagerScript : ResourceManagementScript {

	private float materialGrowthRate = 1;
	private float count = 0;

	public override void addResources(){
		GameController.gameController.addResources (0, 1, 0, 0);
	}
}
