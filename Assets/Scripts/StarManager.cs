using UnityEngine;
using System.Collections;

public class StarManager : MonoBehaviour {

    public GameObject[] allStars;
    public ArrayList chosenStars;
    private int starMax = 3; // the max of stars to look at
    private int lookTime = 1; // time it takes until the star is "captured"
    private bool levelFinished;
	public GameObject arrow;

    public bool canLook;
    public bool isResetting;
    public int starsLookedAt;

    public GameObject gemHolder;
    public changeGem g;

    public int LookTime { get { return lookTime; } }
    public int StarMax { get { return starMax; } }
    public bool HasFinishedLevel { get { return levelFinished; } }
	// Use this for initialization
	void Start () {
        chosenStars = new ArrayList();
        canLook = true;
        starsLookedAt = 0;
        allStars = GameObject.FindGameObjectsWithTag("Star");
        g = gemHolder.GetComponent<changeGem>();
	}

    void PrintTime()
    {
        Debug.Log("The time is " + Mathf.Round(Time.time));
    }

    public void CheckStars(GameObject star) // check to see 
    {

        if (starsLookedAt < starMax && !isResetting)
        {
            chosenStars.Add(star);
            Debug.Log("The current chosen star count: " + chosenStars.Count);
            starsLookedAt++;
        }


        if (chosenStars.Count == starMax)
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
                if(!isResetting)
                {
                    StartCoroutine("Reset");
                }
                Debug.Log("You didn't find the right combination!");
            }
            else
            {
                Debug.Log("You have finished the level!");
                g.UpdateColor();
                arrow.GetComponent<Collider>().enabled = true;
                arrow.GetComponent<SpriteRenderer>().enabled = true;
                ClearStars();
            }
        }



    }

    IEnumerator Reset()
    {
        isResetting = true;
        canLook = false;
        yield return new WaitForSeconds(2);
        canLook = true;
        isResetting = false;
        ResetStars();
    }

    void ClearStars()
    {
        foreach(GameObject star in allStars)
        {
            if (!star.GetComponent<Star>().isGoal)
            {
                Destroy(star);
            }
        }
    }

    void ResetStars()
    {
        foreach (GameObject star in allStars)
        {
            star.GetComponent<Star>().Chosen = false;
            star.GetComponent<Star>().ResetColor();
        }
        chosenStars.Clear();
        starsLookedAt = 0;
        Debug.Log("Everything is resetted.");
    }
}
