using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {
	public float lifespan = 1;

	// Use this for initialization
	void Start () {
	
		Destroy (this.gameObject,lifespan);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//If the bullet collides with an enemy it is destroyed
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Enemy" ){
			Destroy(this.gameObject);
		}

	}
	
}
