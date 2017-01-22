using UnityEngine;
using System.Collections;

public class StarLevel1 : MonoBehaviour {
	public LevelCounterSystem system;
	private SpriteRenderer _spriteRenderer;
	public Sprite spriteToChange;
	[SerializeField] private Sprite currentSprite;
	// Use this for initialization
	void Start () {
		currentSprite = GetComponent<SpriteRenderer>().sprite;
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (system.getLevelComplete () == true) 
		{
			_spriteRenderer.sprite = spriteToChange;
			Destroy (this);
		}
	}
}
