using UnityEngine;
using System.Collections;

public class inspector : MonoBehaviour {
	
	//initialized as the current position of the camera
	Vector3 cameraPos = new Vector3();
	//used to cast the game object curPass to
	CheckInfection ci = new CheckInfection();
	//the object selected to start inspection
	GameObject curPass;
	//the object to cast the individual body parts to durring inspection
	GameObject curBodyPart;
	//The return point for the camera after done with an inspection
	Vector3 cameraReturn;
	//used for error checking before starting inspection...ensures a passenger object is selected
	string checkForPass = "Pass";
	//used for error checking durring inspection...ensures body part is selected
	string checkForCheck = "Check";
	
	
	//initializes the game objects
	void Awake() {
		curPass = new GameObject();
		curBodyPart = new GameObject();
	}
	
	//the actual inspection method
	void Inspection(){
		//Raycasts on left click to try and find a passenger prefab
		if(Input.GetMouseButtonDown (0)){
			RaycastHit hit = new RaycastHit();
			Ray ray = new Ray();
			
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit, 1000f) && Input.GetMouseButtonDown(0)){
				//casts tag to string in order to confirm the correct prefab was selecteed
				string check = (string)hit.collider.gameObject.tag;
				//checks
				if(check.Contains(checkForPass)){
					//sets curPass as selected object
					curPass = hit.collider.gameObject;
					//casts object to a CheckInfection
					ci = (CheckInfection)curPass.GetComponent("CheckInfection");

				}
			}
			
			//Sets the return spot for the camera when done with inspection
			cameraReturn = Camera.main.transform.position;
			//BELOW SCRIPTS NOT COMPLETE.  THESE WILL MOVE THE CAMERA TO THE CORRECT SPOT FOR INSPECTION
			/*however much to move the camera away from the passenger*/
			Vector3 moveCamera = curPass.transform.position + camera.transform.position;
			transform.position = Vector3.Lerp(transform.position, moveCamera/*wherever we're sending the camera*/, /*value to "smooth the transition*/ 20* Time.deltaTime);
			//We Need to be able to click on a passenger only if the cursor is on a GameOBject
			//ABOVE SCRIPTS NOT COMPLETE.  THESE WILL MOVE THE CAMERA TO THE CORRECT SPOT FOR INSPECTION
			//***Display ci.speak wherever it needs to be***
		}
		
		//Backs out from a selection
		if(Input.GetMouseButtonDown (1)){
			//returns camera to spot before inspection
			Camera.main.transform.Translate(cameraReturn);
			//resets ci to a blank new CheckInfection
			ci = new CheckInfection();
		}
		
		//What happens when you click an object durring an inspection
		if(Input.GetMouseButtonDown (0)){
			//checks to make sure ci has been initialized
			if(ci.temperature != null){
				RaycastHit hit = new RaycastHit();
				Ray ray = new Ray();
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, 1000f) && Input.GetMouseButtonDown(0)){
					//checks to make sure a "checkable" object has been selected
					string check = (string)hit.collider.gameObject.tag;
					if(check.Contains(checkForCheck)){
						//casts curBodyPart to selected object
						curBodyPart = hit.collider.gameObject;
					}
				}
			}
		}
		
		//fever check
		if(curBodyPart.tag == /*tag of fever check collider */ "feverCheck"){
			//perform animation for check
			//ANIMATION GOES HERE
			//adds temperature to the displayed information
			ci.speak+=("\nTemperature (in Fahrenheit): " + ci.temperature);
		}
		//blood pressure check
		if(curBodyPart.tag == /*tag of BP check collider */ "BPCheck"){
			//perform animation for check
			//ANIMATION GOES HERE
			//adds blood pressure to available information
			ci.speak+=("\nBlood Pressure: " + ci.systolicBP + " / "+ ci.diastolicBP);
		} 
		
	}
	// Update is called once per frame
	void Update () {
		Inspection ();
	}
}
