using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD_Simple2 : MonoBehaviour {
    MD_Singleton Values;

    void Start()
    {
        Values = MD_Singleton.MyValues;
        if (Values.HardUnlocked)
        {
            gameObject.SetActive(false);
        }
    }


}
