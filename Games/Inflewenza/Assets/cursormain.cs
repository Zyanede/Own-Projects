using UnityEngine;
using System.Collections;

public class cursormain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.lockCursor=false;
	Screen.showCursor=true;
		var mousePos = Input.mousePosition;
		Vector3 cursorPos = new Vector3((Screen.height/2)/2,(Screen.width/2)/2);
		mousePos = cursorPos;
	}
	
	void toggleinput(){
			if(Screen.showCursor==true){
			Debug.Log ("cursor false");
			Screen.showCursor=false;
			}else{
			Screen.showCursor=true;
			Debug.Log ("cursor true");
			}
		}
	// Update is called once per frame
	void FixedUpdate () {
		
	if(Input.GetButtonDown("buttonA")){
			Debug.Log ("A Button was Pressed!");
			toggleinput();
	}
		if (Input.GetKeyDown("left ctrl"))
{
			OVRDevice.ResetOrientation(50);
}
	}
}
