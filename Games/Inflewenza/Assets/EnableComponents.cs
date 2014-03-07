using UnityEngine;
using System.Collections;

public class EnableComponents : MonoBehaviour
{
    private UIPanel myLight;
    
    
    void Start ()
    {
        myLight = GetComponent<UIPanel>();
    }
    
    
    void Update ()
    {
        if(Input.GetButtonDown("buttonY"))
        {
			Time.timeScale = 0;
            myLight.enabled = true;
        }
		if(Input.GetButtonDown("buttonB"))
        {
			Time.timeScale = 1;
            myLight.enabled = false;
        }
    }
}