using UnityEngine;
using System.Collections;

public class LevelCounterSystem : MonoBehaviour {
	public static int levelCounter;
	public static bool level1complete;
	public GameObject arrow;
	public AudioSource audioSource;
	public AudioClip BGM;
	public AudioClip Splash;
	// Use this for initialization
	void Start () 
	{
		levelCounter = 0;
		level1complete = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log (levelCounter);
		if (levelCounter == 12) 
		{
			level1complete = true;
			arrow.GetComponent<Collider>().enabled = true;
			arrow.GetComponent<SpriteRenderer> ().enabled = true;
			Debug.Log ("Complete");
		}
	}
	public void playSplashSound () 
	{
		audioSource.clip = Splash;
		audioSource.Play ();

	}
	public void addCounter()
	{
		levelCounter++;
	}

	public bool getLevelComplete()
	{
		return level1complete;
	}
}
