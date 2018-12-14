using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD_PlatformGenerator : MD_StaticInheritane {

    MD_Singleton Values;
    public GameObject StartingPlatform;
    public GameObject MedStartingPlatform;
    public GameObject HardStartingPlatform;
    public GameObject[] EasyTraps;
    public GameObject[] MediumTraps;
    public GameObject[] HardTraps;
    public GameObject RoomDestoyer;
    private float previous =-1, previouss=-1, previousss=-1, previoussss=-1, previousssss=-1;
    private bool justResseted;

    private GameObject GenerationPoint;
    private float easyPlatformWidth;
    private int trapArrayIndex;
    private Vector3 StartPosition;


    void Start()
    {
        Values = MD_Singleton.MyValues;
        SwitchEtM = false;
        SwitchMtH = false;

        if (Values.StartEasy || Values.EasyOnly)
        {
            NewestSpawnedRoom = Instantiate(StartingPlatform, transform.position, transform.rotation);

        }
        if (Values.MediumOnly || Values.StartMeduim)
        {
            NewestSpawnedRoom = Instantiate(MedStartingPlatform, transform.position, transform.rotation);
        }
        if (Values.HardOnly || Values.StartHard)
        {
                NewestSpawnedRoom = Instantiate(HardStartingPlatform, transform.position, transform.rotation);
        }

        GenerationPoint = GameObject.FindGameObjectWithTag("GenerationPoint");
        easyPlatformWidth = EasyTraps[0].GetComponent<BoxCollider2D>().size.x;
        StartPosition = transform.position; 
    }
	

	void Update () {
        if (RestartLevel)
        {
            transform.position = StartPosition;
           
            if (Values.EasyOnly || Values.StartEasy)
            {
                NewestSpawnedRoom = Instantiate(StartingPlatform,transform.position, transform.rotation);
                isEasy = true;
                isMedium = false;
                isHard = false;
            }
            if (Values.MediumOnly || Values.StartMeduim)
            {
                NewestSpawnedRoom = Instantiate(MedStartingPlatform,transform.position,transform.rotation);
                isMedium = true;
                isEasy = false;
                isHard = false;
            }
            if (Values.HardOnly || Values.StartHard)
            {
                NewestSpawnedRoom = Instantiate(HardStartingPlatform, transform.position, transform.rotation);
                isHard = true;
                isMedium = false;
                isEasy = false;
            }
            Instantiate(RoomDestoyer);
            justResseted = true;
            RestartLevel = false;
        }

        if (transform.position.x < GenerationPoint.transform.position.x && SwitchEtM && !RestartLevel)
        {
            previous = -1;
            previouss = previous;
            previousss = previouss;
            previoussss = previousss;
            previousssss = previoussss;
            SwitchEtM = false;
            transform.position = new Vector3(transform.position.x + easyPlatformWidth, transform.position.y, transform.position.z);
            NewestSpawnedRoom = Instantiate(MedStartingPlatform, transform.position, transform.rotation);
        }

        if (transform.position.x < GenerationPoint.transform.position.x && SwitchMtH && !RestartLevel)
        {
            previous = -1;
            previouss = previous;
            previousss = previouss;
            previoussss = previousss;
            previousssss = previoussss;
            transform.position = new Vector3(transform.position.x + easyPlatformWidth, transform.position.y, transform.position.z);
            NewestSpawnedRoom = Instantiate(HardStartingPlatform, transform.position, transform.rotation);
            SwitchMtH = false;
        }

        if (transform.position.x < GenerationPoint.transform.position.x && isEasy && !RestartLevel)
        { 
            trapArrayIndex = Random.Range(0, EasyTraps.Length);
            if (trapArrayIndex != previous && trapArrayIndex != previouss && trapArrayIndex != previousss && trapArrayIndex != previoussss && trapArrayIndex != previousssss)
            {
                previousssss = previoussss;
                previoussss = previousss;
                previousss = previouss;
                previouss = previous;
                previous = trapArrayIndex;
                transform.position = new Vector3(transform.position.x + easyPlatformWidth, transform.position.y, transform.position.z);
                NewestSpawnedRoom = Instantiate(EasyTraps[trapArrayIndex], transform.position, transform.rotation);
            }
        }

        if (transform.position.x < GenerationPoint.transform.position.x && isMedium && !SwitchEtM && !RestartLevel)
        {
            trapArrayIndex = Random.Range(0, MediumTraps.Length);
            if (trapArrayIndex != previous && trapArrayIndex != previouss && trapArrayIndex != previousss && trapArrayIndex != previoussss && trapArrayIndex != previousssss)
            {
                previousssss = previoussss;
                previoussss = previousss;
                previousss = previouss;
                previouss = previous;
                previous = trapArrayIndex;
                transform.position = new Vector3(transform.position.x + easyPlatformWidth, transform.position.y, transform.position.z);
                NewestSpawnedRoom = Instantiate(MediumTraps[trapArrayIndex], transform.position, transform.rotation);
            }
        }

        if (transform.position.x < GenerationPoint.transform.position.x && isHard && !SwitchMtH && !RestartLevel)
        {
            trapArrayIndex = Random.Range(0, HardTraps.Length);
            if (trapArrayIndex != previous && trapArrayIndex != previouss && trapArrayIndex != previousss && trapArrayIndex != previoussss && trapArrayIndex != previousssss)
            {
                previousssss = previoussss;
                previoussss = previousss;
                previousss = previouss;
                previouss = previous;
                previous = trapArrayIndex;
                transform.position = new Vector3(transform.position.x + easyPlatformWidth, transform.position.y, transform.position.z);
                NewestSpawnedRoom = Instantiate(HardTraps[trapArrayIndex], transform.position, transform.rotation);
            }
        }
    }
}

//generation Point on camera
//Generate manager at ground position 