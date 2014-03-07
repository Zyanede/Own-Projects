using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("down")){
			 transform.Translate(Vector3.down * 2);
		}
		if(Input.GetKeyDown ("up")){
			 transform.Translate(Vector3.up * 2);
		}
		
		Vector3 temp = transform.position;
		if(temp.y == 1){
			temp.y = 7;
		}
		if(temp.y == 9){
			temp.y = 3;
		}
		transform.position = temp;
		
		if(Input.GetKeyDown ("return") && temp.y == 7){
			Application.LoadLevel("test field");
		}
	}
}
