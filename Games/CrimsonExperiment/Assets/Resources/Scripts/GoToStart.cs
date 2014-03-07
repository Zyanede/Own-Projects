using UnityEngine;
using System.Collections;

public class GoToStart : MonoBehaviour {
	public Transform start;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown){
			Instantiate(start, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
