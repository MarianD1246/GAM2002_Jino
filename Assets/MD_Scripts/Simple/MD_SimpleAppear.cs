using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD_SimpleAppear : MonoBehaviour {
    MD_Singleton Values;


	void Start () {
        Values = MD_Singleton.MyValues;
        if (Values.MediumUnlocked)
        {
            gameObject.SetActive(false);
        }
	}
	

}
