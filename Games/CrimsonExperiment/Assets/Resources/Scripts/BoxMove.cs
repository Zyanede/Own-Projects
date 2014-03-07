using UnityEngine;
using System.Collections;

public class BoxMove : MonoBehaviour {
	int move = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (move==1){
			transform.Translate(Vector3.right * 2 * Time.timeScale);
		}
		else{
			transform.Translate(Vector3.left * 2 * Time.timeScale);	
		}
		
		Vector3 temp = transform.position;
		if(temp.x <= 1){
			move = 1;
		}
		if(temp.x >= 9){
			move=0;
		}
		
	}
}
