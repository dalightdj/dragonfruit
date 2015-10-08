

                                                      ^
  SCALE    SCALE    SCALE   SC     SCALE              V  ___
 SCA  LE  SC   AL  SC   AL  SC	  SC                __X--  /|\
 SCA      SC       SC   AL  SC    SC             ---  #    --- 
  SCALE   SC       SCALESC  SC    SCALE         /|\   #  
      SC  SC       SC   AL  SC    SC            ---   #
 SC   AL  SC   AL  SC   AL  SC    SC                 ###
  SCALE    SCALE   SC   AL  SCALE  SCALE          #########
                                                
developed by "DragonFruit Games".

--------------------------------------------------------------

Inspired by https://github.com/QuasimodoNZ/MadHouse

--------------------------------------------------------------

Scale is a top-down City builder with an environmental twist.

1. Game Play.
2. Resources.
3. End-Game.
4. Structure.
	4.1 Scenes.
	4.2 Main scene structure.
5. Credits
--------------------------------------------------------------
1. GAME PLAY
--------------------------------------------------------------
To open a build menu swipe from a given point i nthe direction of the build menu you wish to open. 
Once open select a building then click on the building icon to build. 
The costs of each building will be displayed on the menu opened after selecting a building in the initial building menu. 
Your current resources and such are displayed in the top right hand and bottom left hand corners of the screen. 
The game will end when the timer runs out or if you reach certain fresh holds. 

--------------------------------------------------------------
2. RESOURCES
--------------------------------------------------------------
There are four main "Resources" in this game: population, materials, food, and pollution.

	population: Increased every cycle up to a hidden max 	
	population which is based on how many "housing" type 	
	buildings are built i.e. Houses, apartments, etc. 	
	Building any other type of buildings requires a portion 	
	of your people as a an "employment" cost.

	materials: The main resource for building everything.
	increased by building "production" type buildings. You 
	will get a certain amount every cycle based on how many 
	of these "production" buildings you have built. Will be 
	spent on building the majority of buildings.

	food: Created every cycle based on food production
 	buildings in play i.e orchard, farm, etc. an amount is
 	also used/eaten each cycle based on current population. 
	
	pollution: Every building has a pollution cost. having
 	this reach max pollution causes the end of the game. 

--------------------------------------------------------------
3. END-GAME
--------------------------------------------------------------
There are 3 ways to lose.
 Either you run out of food and your population dies out completely.
 You reach pollution freshhold and you destroy the earth.
 Or you survive the time-limit and the game ends.

--------------------------------------------------------------
4. STRUCTURE
--------------------------------------------------------------
	4.1 Scenes	
	--------------------------------------------------------
 	Divided into 4 main scene types. the intro scene. The 
	loadlevel scene. the main scene and then the variety of 
	end-game scenes.
	
	intro scene: Starts the game. Only contains a single 
	button. which transfers you to LoadLevel scene. 

	LoadLevel: Instantly calls to load the main scene. Acts
 	as a buffer between intro scene and main scene in order
 	to hide load time.
	
	Game Scene: Has all of the game logic in here. All 
	buildings placed and gui components plus touch inputs 
	scripts in this scene will be broken down in detail in
 	section 3.2. reaching certain fresh holds will transfer 
	you to one of the end game scenes. 
	

	End game: 3 different scenes all with the same 	functionality. restart button takes you back to main 
	scene. The visuals on these different scenes will be 
	dependant on freshhold broken in main scene.

	---------------------------------------------------------
	4.2 Main scene structure
	---------------------------------------------------------
	Game takes place in this scene. Number of objects and
 	scripts controlling game in this scene, which will be
 	detailed in this follwing secion:

	fader: The fader object has a script attatched
 	controlling the fade in to the main scene. The script is 
	called "Fade In". The texture attatched is what it will 
	fade in from. The script can be altered to fade out as 	well by changing the alpha to 1 and outting the fade
 	direction to 1 aswell.	

	sfx: Controls the SFX in the scene. alter the array size
 	on the attached SFX controller and drag and drop sfx 
	clips in to the empty array slots. Play effect by getting 
	script component and calling playClip(n) where n = index 
	of desired clip.

	Music: Same as above but clip will be set to loop and
 	continue playing until you change clip. No music stop
 	functionality.

	DayNightCycleLight: A rotating light to simulating the 
	day night cycle. Script attached simply rotated the light
  	based on "speed" variable.

	CloudSystem: A particle emission system to simulate
 	clouds see: 
	https://unity3d.com/learn/tutorials/modules/beginner/live
	-training-archive/particle-systems 
	for more information.

	grid: The underlying grid that is used for caluclating
 	where to build on the overlying terrain.

	Touch_Controller: Uses unity "touches" for working out 
	location of touch and touch type. If touch works sends
 	touch info and tile touched to BuildMenu in order to open 
	build options. Swipe threshold controls how fast a player 
	must swipe to open a buildmenu.

	BuildMenu: The prefabs holding the four directional build 
	menus.

	GUI: Has the "BUILD MENU SCRIPT" attatched. This script 
	controls opening and closing buildmenus along with 
	building. 

	Main Camera: Placed above terrain in order to view whole 
	scene. Also has Game controller script attatched which
 	controls resource management via attached different 
	resource managers. 


--------------------------------------------------------------
5.CREDITS
--------------------------------------------------------------
-thanks to http://www.freesfx.co.uk/ for sfx used in game.

-Also a thanks http://www.fsf.org/ a shining beacon of hope in the darkness of corporate greed. Please direct any donations their way.

-Thanks to Stuart Marshall for providing us with this project and helping to guide us along the way.

-Our tutor Julian for guiding us in our Agile practices and classics bants.

-To last years SWEN302 group that began this project. 
	
	
##############
DRAGONFRUIT.
##############