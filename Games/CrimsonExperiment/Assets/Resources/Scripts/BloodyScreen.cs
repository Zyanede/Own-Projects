using UnityEngine;
using System.Collections;

public class BloodyScreen : MonoBehaviour {
	
	public float LockedZ = -1.655468f;
	GameObject Player, BS;
	//Vector3 Vy, Vx;
	Vector3 V;
	// Use this for initialization
	void Start () {
	Player = GameObject.FindGameObjectWithTag("MainCamera");
	BS = GameObject.FindGameObjectWithTag("BS");
	BS.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Vx.x = this.transform.position.x;
    	//Vy.y = this.transform.position.y;
//		V = Player.transform.position;
//		BS.transform.position = new Vector3(V.x, V.y +1.5f, LockedZ);
		if(PlayerHealth.curHP>=6){
			BS.renderer.enabled = false;
		}
		else if(PlayerHealth.curHP<=5){
			BS.renderer.enabled = true;
		}
		//transform.position.x = Vx.x;
		//transform.position.y = Vy.y + 1.5f;
	}
}
