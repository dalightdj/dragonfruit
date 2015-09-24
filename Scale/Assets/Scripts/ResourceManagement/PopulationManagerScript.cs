using UnityEngine;
using System.Collections;

public class PopulationManagerScript : ResourceManagementScript {

	private int maxPopulation = 50;
	private int currentPopulation = 5;
	private int employed;//currentPop - employed = unemployed
	public float foodRequirementPerPerson = 0.01f;

	// Use this for initialization
	void Start () {
		GameController.gameController.addResources (currentPopulation, 0, 0, 0);
	}
	

	// Update is called once per frame
	void Update () {
		//make sure there is enough food
		if (GameController.gameController.sufficientResourses (0, 0, 0, foodRequirementPerPerson * currentPopulation)) {
			GameController.gameController.addResources (0, 0, 0, -(foodRequirementPerPerson * currentPopulation));
		} else {
			GameController.gameController.addResources (-0.5f, 0, 0, 0);
		}

		//do not exceed max population
		if (GameController.gameController.getTotalPopulation() < maxPopulation) {
			currentPopulation++;
			base.Update ();
		}
	}

	public override void addResources(){
		GameController.gameController.addResources (1, 0, 0, 0);
	}

	public void increaseMaxPopulation(int increase){
		maxPopulation += increase;
	}

	public void addEmployed(int increase){
		employed += increase;
	}

	public bool hasSufficientUnemployed(int population){
		return (currentPopulation-employed) > population;
	}
}