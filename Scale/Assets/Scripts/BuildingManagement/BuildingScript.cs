using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

	//these affect how much each resource increases/decreases
	public int populationGrowth;
	public int materialGrowth;
	public int pollutionGrowth;
	public int foodGrowth;

	//these are the material costs for building this building
	public int populationCost;
	public int materialCost;
	public int pollutionCost;
	public int employmentCost;

	//a short description of what this building does
	public string description;

	//for playing the building sound effect
	private SFXController SFX;

	void Start(){
		GameController gc = GameController.gameController;
		gc.addResourceGrowthRate (populationGrowth, materialGrowth, pollutionGrowth, foodGrowth);

		//Play the building sound effect
		GameObject musicPlayer = GameObject.FindWithTag ("SFX");
		SFX = musicPlayer.GetComponent ("SFXController") as SFXController;
		SFX.playClip (0);
	}

}
