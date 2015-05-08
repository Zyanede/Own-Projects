using UnityEngine;
using System.Collections;

public class RandomPlatforms : MonoBehaviour {
	GameObject player; 
	public Transform platform;
    Vector3 v;
	static Vector3 v2;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		v = new Vector3(transform.position.x-8, -.4f, -8f);

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x <= v.x){
			float width = transform.position.x-4;
			float height = Random.Range (-5, -3);
			Instantiate(platform, new Vector3(width, height, -8), transform.rotation);
			v.x -= Random.Range(8,12);
			
		}
	}
	
	/* void OnTriggerEnter(Collider other){
  	 	if (other.tag == "Spawn"){
			Instantiate(platform, new Vector3(transform.position.x-6, -1, -8), transform.rotation);
		}
	}*/
	
}
