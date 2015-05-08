using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {
	public Transform storyScreen;
	public Transform creditsScreen;
	public Transform controlScreen;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SwitchScreens ();
	}
	
	void SwitchScreens(){
		//Pressing enter key on each cursor option:
		if (Input.GetKeyDown("return")){
			if(CursorScript.isStart == true)
				Application.LoadLevel("build1");
			
			if(CursorScript.isStory == true){
				Instantiate(storyScreen, transform.position, transform.rotation);
				Destroy (this.gameObject);
			}
			
			if(CursorScript.isContr == true){
				Instantiate(controlScreen, transform.position, transform.rotation);
				Destroy (this.gameObject);
			}
			
			if(CursorScript.isCredits == true){
				Instantiate(creditsScreen, transform.position, transform.rotation);
				Destroy (this.gameObject);
			}
		}
	}
}
