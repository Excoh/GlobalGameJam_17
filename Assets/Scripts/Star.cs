﻿using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class Star : MonoBehaviour {

    public Sprite spriteToChange;
    public bool isGoal;
    public bool isChosen;
    public GameObject circleUIEffect;
    public bool effectToggle;
    public Vector3 startScale;

    private Change2DColor col;
    [SerializeField]private SpriteRenderer ren;
    [SerializeField]private StarManager _starManager;
    [SerializeField]private GazeAware _gazeAwareComponent;

    private float currentTime;
    private bool isLooking;
	// Use this for initialization

	void Start () {
        _gazeAwareComponent = GetComponent<GazeAware>();
        _starManager = GameObject.FindGameObjectWithTag("StarManager").GetComponent<StarManager>();
        col = GetComponent<Change2DColor>();
        ren = GetComponent<SpriteRenderer>();
        startScale = transform.localScale;
	}

    public bool Chosen
    {
        set { isChosen = value; }
        get { return isChosen; }
    }
	
	// Update is called once per frame
	void Update () {

        if (_gazeAwareComponent.HasGazeFocus)
        {
            if (!isChosen && _starManager.canLook)
            {
                if (!isLooking)
                {
                    isLooking = true;
                    currentTime = Mathf.Round(Time.time);
                }
                StartLooking();
            }
            else print("This star is chosen already.");
        }
        else isLooking = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Effect();
        }
	}

    void StartLooking()
    {
        if (Time.time - currentTime >= _starManager.LookTime)
        {
            Debug.Log("This star is chosen.");
            isChosen = true;
            ren.sprite = spriteToChange; // to show that the star have been chosen
            _starManager.CheckStars(this.gameObject);

            if (isChosen) Effect();

        }
    }

    public void ResetColor()
    {
        Debug.Log("Resetting Colors");
        ren.sprite = col.currentSprite;
    }

    public void Effect()
    {

            Instantiate(circleUIEffect, transform.position, Quaternion.identity);
            //transform.localscale
    }
}
