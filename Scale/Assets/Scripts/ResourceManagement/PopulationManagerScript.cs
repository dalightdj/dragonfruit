using UnityEngine;
using System.Collections;

//A class for managing the population. It inherits from the ResourceManagementScript
public class PopulationManagerScript : ResourceManagementScript {

	private float maxPopulation = 0;
	private float currentPopulation = 5;
	private float employed;//currentPop - employed = unemployed
	public float foodRequirementPerPerson = 0.001f;

	// Use this for initialization
	void Start () {
		maxPopulation = GameController.gameController.getTotalPopulation ();
		GameController.gameController.addResources (-(maxPopulation-currentPopulation), 0, 0, 0);
		increaseGrowthRate (10);
	}
	

	// Update is called once per frame
	void Update () {
		//Make sure there is enough food

		if (GameController.gameController.sufficientResourses (0, 0, 0, foodRequirementPerPerson * currentPopulation)) {
			GameController.gameController.addResources (0, 0, 0, -(foodRequirementPerPerson * currentPopulation));
		} else {//If not enough food then population starts plummeting
			GameController.gameController.addResources (-0.15f, 0, 0, 0);
		}

		//Do not exceed max population
		if (GameController.gameController.getTotalPopulation() < maxPopulation) {
			print ("C:" + currentPopulation);
			print ("T:" + GameController.gameController.getTotalPopulation());
			print ("M:" + maxPopulation);
			base.Update ();//Call the ResourceManagementScript's update method
		}
	}

	public override void addResources(){
		GameController.gameController.addResources (1, 0, 0, 0);
		currentPopulation++;
	}

	public void increaseMaxPopulation(int increase){
		maxPopulation += increase;
	}

	public void addEmployed(float increase){
		employed += increase;
	}

	public bool hasSufficientUnemployed(int population){
		return (currentPopulation-employed) > population;
	}

	public int getUnemployed(){
		return (int) (currentPopulation-employed);
	}
}