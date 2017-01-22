using UnityEngine;
using Tobii.EyeTracking;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GazeAware))]
public class Arrow : MonoBehaviour {
	
    //public Sprite spriteToChange;
	public bool debug;
    private GazeAware _gazeAwareComponent;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite currentSprite;
    //public Rigidbody rb;
	public BeaconScript system;
	public GameObject waterTrigger;
	// Use this for initialization
	void Start () 
	{
        currentSprite = GetComponent<SpriteRenderer>().sprite;
        _gazeAwareComponent = GetComponent<GazeAware>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject focusedObject = EyeTracking.GetFocusedObject ();
		if (_gazeAwareComponent.HasGazeFocus || debug == true)
        {
            if (gameObject.name == "EndArrow")
            {
                Debug.Log("Exiting");
                Application.Quit();
            }
            Debug.Log("Looking at Sprite");
            //_spriteRenderer.sprite = spriteToChange;
            //rb.useGravity = true;
			//waterTrigger.GetComponent<Rigidbody2D>().isKinematic = false;
			system.setisMovingTrue ();


        }
        else _spriteRenderer.sprite = currentSprite;
	}
}
