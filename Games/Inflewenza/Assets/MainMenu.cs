using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void update(){
		 
		Debug.Log("Exit was clicked!");
		
		
	}
		
	void OnStartClicked(){
		Application.LoadLevel("airplane_scene");
			}
		

	void OnExitClicked(){
		Application.LoadLevel("Main");
	}
}
