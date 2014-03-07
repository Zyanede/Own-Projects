using UnityEngine;
using System.Collections;

public class PauseText : MonoBehaviour {
	int pause = 0;
	double placement = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("return")){
			if (pause == 1){
				pause = 0;
			}
			else{
				pause = 1;
			}
		}
		
		if (pause == 1 && placement < 10){
			placement += 1;
			transform.Translate(Vector3.up * 1);
		}
		
		if(pause == 0 && placement > 0){
			//Time.timeScale = 1;
			transform.Translate(Vector3.down * 1);
			placement --;
		}
		
		
		if (placement == 0){
			Time.timeScale = 1;
		}
		else{
			Time.timeScale = 0;
		}
		
		
		/*if (pause == 1){
			Time.timeScale = 0;
		}
		if (pause == 0){
			Time.timeScale = 1;
		}*/
		
		
		
	}
}
