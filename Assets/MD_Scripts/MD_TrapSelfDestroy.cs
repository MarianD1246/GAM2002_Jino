using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD_TrapSelfDestroy : MD_StaticInheritane {

	void Update () {
        if (gameObject != CurrentRoom && gameObject != LastRoom && gameObject != NewestSpawnedRoom)
        {
            Destroy(gameObject);
        }
    }
}
