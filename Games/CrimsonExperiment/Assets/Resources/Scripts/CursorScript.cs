using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {
	static Vector3 startPos, storyPos, contrPos, credPos;
	public static bool isStart, isStory, isContr, isCredits;
	
	// Use this for initialization
	void Start () {
		startPos = new Vector3(-2f, -0.3753215f, -4f);
		storyPos = new Vector3(-1.357587f, -1.088867f, -4f);
		credPos = new Vector3(-1.575191f, -1.7071f, -4f);
		contrPos = new Vector3(-1.797105f, -2.407412f, -4f);
		isStart = true;
	}
	
	// Update is called once per frame
	void Update () {
		switchCursor ();
	}
	
	
	void switchCursor(){
		
		//change boolean values based on button pressed
		if(Input.GetKeyDown("down")){
			if(isStart == true){
				transform.position = storyPos;
				isStart = false;
				isStory = true;
				isCredits = false;
				isContr = false;
				print ("isStory");
			}
			else if(isStory == true){
				transform.position = credPos;
				isStart = false;
				isStory = false;
				isCredits = true;
				isContr = false;
				print ("isCredit");
			}
			else if(isCredits == true){
				transform.position = contrPos;
				isStart = false;
				isStory = false;
				isCredits = false;
				isContr = true;
				print ("isContr");
			};
		}
		
		if(Input.GetKeyDown("up")){
			if(isStory == true){
				transform.position = startPos;
				isStart = true;
				isStory = false;
				isCredits = false;
				isContr = false;
				print ("isStart");
			}
			else if(isCredits == true){
				transform.position = storyPos;
				isStart = false;
				isStory = true;
				isCredits = false;
				isContr = false;
				print ("isStory");
			}
			else if(isContr == true){
				transform.position = credPos;
				isStart = false;
				isStory = false;
				isCredits = true;
				isContr = false;
				print ("isStory");
			}
		}
		
		
	}
	
}
