using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	GameObject platform;
	public float minWidth = 2;
	public float maxWidth = 6;
	static Vector3 temp;
	// Use this for initialization
	void Start () {
		platform = GameObject.Find("Platform");
		float x = Random.Range (minWidth,maxWidth);
		temp = new Vector3(x, 5f, 3.0f); 
		transform.localScale = temp;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
