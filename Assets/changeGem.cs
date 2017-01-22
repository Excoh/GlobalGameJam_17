using UnityEngine;
using System.Collections;

public class changeGem : MonoBehaviour {

    public Sprite spriteToChange;
    public SpriteRenderer ren;

	// Use this for initialization
	void Start () {
        ren = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateColor()
    {
        ren.sprite = spriteToChange;
    }
}
