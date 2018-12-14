using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MD_UIManager : MD_StaticInheritane {

    MD_Singleton Values;

    public Text TotalPoints;
    public Text ThisRoundPointsMade;
    public Text DistanceTraveledText;
    public Text TotalDistanceTraveled;
    public GameObject HighScore;
    public Text PLives;
    public GameObject EndMenu;
    public GameObject outOflife;
    private bool showEnd = false;
    private bool UpdateText = false;
    private bool CountPoitns = false;
    private float smallDelay;

    private void Start()
    {
        Values = MD_Singleton.MyValues;
        EndMenu.SetActive(false);
        HighScore.SetActive(false);
        outOflife.SetActive(false);
    }

    private void Update()
    {
        if (PlayerDead && !showEnd)
        {
            EndMenu.SetActive(true);
            showEnd = true;
            UpdateText = true;
            CountPoitns = true;
            smallDelay = Time.time + .1f;
        }
        if (!PlayerDead && showEnd)
        {
            EndMenu.SetActive(false);
            showEnd = false;
            UpdateText = false;
            HighScore.SetActive(false);
            outOflife.SetActive(false);
        }
        if (UpdateText)
        {
            if (CountPoitns && smallDelay < Time.time)
            {
                Values.CurrentPoints += PointsMade; 
                CountPoitns = false;
            }
            if (Values.HighestDistanceTraveled < DistanceTraveled)
            {
                Values.HighestDistanceTraveled = DistanceTraveled;
                HighScore.SetActive(true);
            }
            if (NoLivesLeft)
            {
                outOflife.SetActive(true);
            }
            DistanceTraveledText.text = "Distance Traveled: " + DistanceTraveled.ToString("F0") +"m";
            TotalDistanceTraveled.text = "Distance Traveled: " + Values.HighestDistanceTraveled.ToString("F0") + "m";
            ThisRoundPointsMade.text = "Points Earned: " + PointsMade + "P";
            TotalPoints.text = "Total Points: " + Values.CurrentPoints + "P";
            PLives.text = "Lives: " + Values.Lives;
        }
    }
}
