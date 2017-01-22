using UnityEngine;
using System.Collections;

public class StarManager : MonoBehaviour {

    public GameObject[] allStars;
    public ArrayList chosenStars;
    private int starMax = 3; // the max of stars to look at
    private int lookTime = 1; // time it takes until the star is "captured"
    private bool levelFinished;

    public int LookTime { get { return lookTime; } }
    public int StarMax { get { return starMax; } }
    public bool HasFinishedLevel { get { return levelFinished; } }
	// Use this for initialization
	void Start () {
        chosenStars = new ArrayList();
        allStars = GameObject.FindGameObjectsWithTag("Star");
	}

    void PrintTime()
    {
        Debug.Log("The time is " + Mathf.Round(Time.time));
    }

    public void CheckStars(GameObject star) // check to see 
    { 
        if (chosenStars.Count < starMax)
        {
            chosenStars.Add(star);
        }

        if (chosenStars.Count >= starMax)
        {
            for (int i = 0; i < chosenStars.Count; i++)
            {
                GameObject tempChosenStar = (GameObject)chosenStars[i];
                if (tempChosenStar.GetComponent<Star>().isGoal == false)
                {
                    levelFinished = false;
                    break; // if it encounters the first false, then leave
                }
                else
                {
                    levelFinished = true;
                }
            }

            if (!levelFinished)
            {
                ResetStars();
                chosenStars.Add(star);
                Debug.Log("You didn't find the right combination!");
            }
        }

        if (levelFinished)
        {
            Debug.Log("You have completed the level!");
        }

    }

    void ResetStars()
    {
        foreach (GameObject star in allStars)
        {
            star.GetComponent<Star>().Chosen = false;
        }
        chosenStars.Clear();
        Debug.Log("Everything is resetted.");
    }
}
