/////////////////////////////////////////////
///Zapp's Uber fading timer script///////////
/////////////////////////////////////////////
///v3.141////////////////////////////////////
/////////////////////////////////////////////
///Brought to you by the letter Z..//////////
/////////////////////////////////////////////
///And a grant from the MyWallet Foundation//
/////////////////////////////////////////////
using UnityEngine;
using System.Collections;
 
public class quaranteenCount : MonoBehaviour {
 
public int minutes;
public int seconds;
public int fraction;	
public int num_Infected;
public float startTime;
float FadeStartTime;
float FadeTime;
 
public float playTime;
public float FadeSpeed;
 
public Color TimerColor = new Color(1,1,1,0);
 
 
bool go = false;
public bool fadeIn = false;
public bool fadeOut = false;	
 
 
 
	void Start () 
	{
		num_Infected =1;
		StartTimer();
		FadeIn();
		
 
		if(FadeSpeed == 0)
		{
			FadeSpeed = 1;
		}
		//guiText.material.color = TimerColor;
	}
 
 
	void Update () 
	{
 
		//This is for testing, make sure to remove it after your done.
		if(Input.GetMouseButtonDown(0))
		{
			num_Infected = num_Infected+1;
			if(!go)
			{
				StartTimer();
			}
			Fade();
		}
		if(Input.GetButtonDown("buttonA")){
			num_Infected++;
			UILabel subtitle = GameObject.Find("Label2").GetComponent<UILabel>();
			subtitle.text = string.Format("A Pressed");
		}
		if(Input.GetButtonDown("buttonX")){
			num_Infected++;
			UILabel subtitle = GameObject.Find("Label2").GetComponent<UILabel>();
			subtitle.text = string.Format("X Pressed");
		}
		if(Input.GetButtonDown("buttonY")){
			num_Infected++;
			UILabel subtitle = GameObject.Find("Label2").GetComponent<UILabel>();
			subtitle.text = string.Format("Y Pressed");
		}
		if(Input.GetButtonDown("buttonB")){
			num_Infected++;
			UILabel subtitle = GameObject.Find("Label2").GetComponent<UILabel>();
			subtitle.text = string.Format("B Pressed");
		}
		{
			playTime = Time.time - startTime;
			minutes = (int)(playTime/60f );
			seconds = (int)(playTime % 60f);
			fraction =  (int)((playTime *10) %10);
			if(seconds%10==0&&fraction==0&&fraction==0){
				seconds=0;
				num_Infected++;
				return;
			}
			//UILabel subtitle = GameObject.Find("Label2").GetComponent<UILabel>();
			//subtitle.text = string.Format("Quaranteen Count: "+ (num_Infected/4)/2);
		}
 
		if(fadeIn)
		{
			FadeIn();
		}
 
		if(fadeOut)
		{
			FadeOut();
		}
 
	}
 
	public void StartTimer()
	{
		startTime = Time.time;
		go = true;
		FadeStartTime = Time.time;
		fadeIn = true;
	}
 
	public void StopTimer()
	{
		go = false;
	}
 
	public void Fade()
	{
		if( !fadeIn && !fadeOut )
		{
			FadeStartTime = Time.time;
			if(TimerColor.a == 1)
			{
				Debug.Log(TimerColor.a);
				fadeOut = true;
			}
			else
			{
				//guiText.enabled = true;
				fadeIn = true;
			}
		}
		else
		{
 
			FadeStartTime = Time.time - ((1 - FadeTime) / FadeSpeed);
			fadeIn = !fadeIn;
			fadeOut = !fadeOut;
 
		}
	}
 
	void FadeIn()
	{
		FadeTime = (Time.time - FadeStartTime) * FadeSpeed;
		TimerColor.a = Mathf.SmoothStep(0, 1, FadeTime );
		//guiText.material.color = TimerColor;
		if(TimerColor.a == 1)
		{
			fadeIn = false;
		}
	}
 
	void FadeOut()
	{
		FadeTime = (Time.time - FadeStartTime) * FadeSpeed;
		TimerColor.a = Mathf.SmoothStep(1, 0, FadeTime );
		//guiText.material.color = TimerColor;
		if(TimerColor.a == 0)
		{
			fadeOut = false;
		}
	}
}
