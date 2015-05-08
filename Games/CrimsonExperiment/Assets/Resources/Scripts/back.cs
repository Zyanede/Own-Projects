using UnityEngine;
using System.Collections;

public class back : MonoBehaviour {
	
	int pause = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("return"))
		{
			//AsyncOperation test = Application.LoadLevelAsync ("menu");
			if(pause == 0){
				pause = 1;
			}
			else{
				pause = 0;
			}
		}
		
		
	}
}
