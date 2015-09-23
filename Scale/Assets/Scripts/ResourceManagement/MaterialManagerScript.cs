using UnityEngine;
using System.Collections;

public class MaterialManagerScript : ResourceManagementScript {

	public override void addResources(){
		GameController.gameController.addResources (0, 1, 0, 0);
	}
}
