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
		/*print ("Population");
		GameController.gameController.addResources (0, 0, 0, -(foodRequirementPerPerson*currentPopulation));

		count += populationGrowthRate;


		print ("Max pop:" + maxPopulation);
		if (count/1000 >= 1) {
			if(currentPopulation+1 <= maxPopulation){
				currentPopulation += 1;
				GameController.gameController.addResources(1, 0, 0, 0);
			}
			count = 0;
		}
		*/

		GameController.gameController.addResources (0, 0, 0, -(foodRequirementPerPerson*currentPopulation));

		print ("Max pop:" + maxPopulation);
		print ("Current pop:" + currentPopulation);
		if (GameController.gameController.getTotalPopulation() < maxPopulation) {
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