using UnityEngine;
using System.Collections;

//A class for controlling the resources within the game. Each resource should have a manager script that inherits this class
public abstract class ResourceManagementScript : MonoBehaviour {

	float growthRate = 0;
	float growthRateDenominator = 1000;
	float currentGrowth = 0;//this is used to keep track of the growth of the resource

	
	// Update is called once per frame. This method is made virtual so that it can be called by its inheriting classes
	public virtual void Update () {
		//Increase the current growth each frame
		currentGrowth += growthRate;

		//If the current growth is large enough then increase this resource
		if (currentGrowth/growthRateDenominator >= 1) {
			addResources();
			currentGrowth = 0;
		}
	}

	//Each sub-class must implement their own addResources method because they increase a particular resource
	public abstract void addResources ();

	public void increaseGrowthRate(float increase){
		growthRate += increase;
	}
}
