using UnityEngine;
using System.Collections;

public class TurretSpawn : MonoBehaviour {
/*	bool canSpawn = true;
	int count = 0;

	// Use this for initialization
	void Start () {
	StartCoroutine(SpawnTurret ());
	StartCoroutine(SpawnEnemy ());
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag("EndEnemy") == null){
			canSpawn = false;
		}
	}
	IEnumerator SpawnTurret(){
		while(canSpawn = true){
			if(GameObject.FindGameObjectWithTag("Turret") == null){
				yield return new WaitForSeconds(10);
				Instantiate (Robot, GameObject.Find ("TurretSpawnPoint").transform.position, Quaternion.identity);
			}
		}	
	}
	IEnumerator SpawnEnemy(){
		while (count < 10){
			Instantiate (EnemyPre, GameObject.Find ("EnemySpawnPoint").transform.positiion, Quaternion.identity);
			count++;
			yield return new WaitForSeconds(5);
		}
	}
*/}
