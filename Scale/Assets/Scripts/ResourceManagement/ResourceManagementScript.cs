using UnityEngine;
using System.Collections;

public abstract class ResourceManagementScript : MonoBehaviour {

	float growthRate = 1;
	float count = 0;
	float growthRateDenominator = 1000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
		count += growthRate;
		
		if (count/growthRateDenominator >= 1) {
			addResources();
			count = 0;
		}
	}

	public abstract void addResources ();

	public void increaseGrowthRate(float increase){
		growthRate += increase;
	}
}
