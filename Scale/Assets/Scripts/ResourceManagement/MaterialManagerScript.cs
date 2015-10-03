using UnityEngine;
using System.Collections;

//A script for managing the material resources. It inherits from the ResourceManagementScript
public class MaterialManagerScript : ResourceManagementScript {

	public override void addResources(){
		GameController.gameController.addResources (0, 1, 0, 0);
	}
}
