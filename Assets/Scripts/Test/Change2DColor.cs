using UnityEngine;
using Tobii.EyeTracking;

[RequireComponent(typeof(GazeAware))]
public class Change2DColor : MonoBehaviour {

    public Sprite spriteToChange;
    public Sprite chosenColor;

    private GazeAware _gazeAwareComponent;
    private SpriteRenderer _spriteRenderer;
    private Star isChosenStar;
    [SerializeField] private Sprite currentSprite;

	// Use this for initialization
	void Start () {
        currentSprite = GetComponent<SpriteRenderer>().sprite;
        _gazeAwareComponent = GetComponent<GazeAware>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        isChosenStar = GetComponent<Star>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!isChosenStar.Chosen)
        {
            if (_gazeAwareComponent.HasGazeFocus)
            {
                Debug.Log("Looking at Sprite");

                _spriteRenderer.sprite = spriteToChange;


            }
            else _spriteRenderer.sprite = currentSprite;
        }
	}
}
