using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTouch : MD_StaticInheritane {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

#if  UNITY_ANDROID
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) //Phone build
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 TestPoint = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "DashButton")
            {
                isDashed = true;
                Dashing = true;
            }
            else if (hit.collider == null || hit.collider.tag != "DashButton") { Dashing = false; }

            if (TestPoint.x > 0.5f && !PlayerDead && !Dashing)
            {
                doJump = true;
            }
            if (TestPoint.x <= 0.5f && !PlayerDead && !Dashing)
            {
                doCrouch = true;
            }
        }
#endif

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))    //PC Test
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 TestPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            //Debug.Log(hit.collider);
            if (hit.collider != null && hit.collider.tag == "DashButton")   //
            {
                isDashed = true;
                Dashing = true;
            }
            else if (hit.collider == null || hit.collider.tag != "DashButton"){ Dashing = false; }

            if (TestPoint.x > 0.5f && !PlayerDead && !Dashing)
            {
                doJump = true;
            }
            if (TestPoint.x <= 0.5f && !PlayerDead && !Dashing)
            {
                doCrouch = true;
            }
        }
#endif
    }

    
}

//https://stackoverflow.com/questions/38565746/tap-detection-on-a-gameobject-in-unity
//https://forum.unity.com/threads/how-to-use-ray2d-and-raycasthit2d.239895/
//https://docs.unity3d.com/Manual/PlatformDependentCompilation.html (Platform dependent compilation)
