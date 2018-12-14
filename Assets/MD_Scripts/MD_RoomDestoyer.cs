using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD_RoomDestoyer : MD_StaticInheritane { 

    private GameObject[] ClonedRooms;

	void Start () {
        ClonedRooms = GameObject.FindGameObjectsWithTag("Trap");
    }
	
	void Update () {
		for (int i=0; i < ClonedRooms.Length; i++)
        {
            if (NewestSpawnedRoom != ClonedRooms[i])
            {
                Destroy(ClonedRooms[i]);
            }
        }
        
        Destroy(gameObject);

    }

}