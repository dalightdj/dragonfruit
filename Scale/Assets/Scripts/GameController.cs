using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController gameController;

	public int timeLimit = 60;//the losing condition i.e. 60 seconds

	private float time;
	private GameObject[] scoreTexts;//the Text components that will show the score
	
	private int totalPopulation;
	private int totalMaterial;
	private int totalPollution;
	private int totalFood;

	private PopulationManagerScript populationManager;
	private FoodManagerScript foodManager;
	
	//Ensures GameController is a singleton
	void Awake () 
	{
		if(gameController != null)
		{
			Destroy(this.gameObject);
		}
		else
		{
			gameController = this;
		}

		populationManager = gameObject.AddComponent<PopulationManagerScript>();
		foodManager = gameObject.AddComponent<FoodManagerScript> ();
	}


	// Use this for initialization
	void Start () {
		scoreTexts = GameObject.FindGameObjectsWithTag ("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {

		//A simple countdown
		time += Time.deltaTime;
		for(int i = 0; i<scoreTexts.Length; i++){
			Text textComponent = scoreTexts[i].GetComponent<Text>();

			textComponent.text = string.Format("{0:n0}", ((timeLimit+0.5)-time));
			textComponent.text = textComponent.text + "  Pop:" + totalPopulation + "  Mat:" + totalMaterial + "  Pol:" + totalPollution + "  Food:" + totalFood;
		}


		//END GAME
		if (time >= timeLimit) {
			Application.LoadLevel("Ending");
		}
	}

	public void addResources(int population, int material, int pollution, int food){
		print ("Add resources: pop=" + population + " material=" + material + " pollution=" + pollution + " food=" + food);
		totalPopulation += population;
		totalMaterial += material;
		totalPollution += pollution;
		totalFood += food;
	}

	public bool sufficientResourses(int population, int material, int pollution, int food){
		if (totalPopulation < population || totalMaterial < material || totalPollution < pollution || totalFood < food) {
			return false;
		}
		return true;
	}

	public void increaseMaxPopulation(int increase){
		populationManager.increaseMaxPopulation (increase);
	}

	public void addEmployed(int increase){
		populationManager.addEmployed (increase);
	}

	public bool sufficientUnemployed(int population){
		return populationManager.hasSufficientUnemployed (population);
	}
}
