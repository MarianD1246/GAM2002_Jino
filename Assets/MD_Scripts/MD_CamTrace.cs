using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD_CamTrace : MD_StaticInheritane { 

    private GameObject ThePlayer;
    private Vector3 BestAngle = new Vector3(4.7f, 2.5f, -10);
    private Vector3 Velocity = new Vector3 (0,0,0);
    private readonly float Smoothener = 0.125f;
    private readonly float SpeedofSmooth = 6.7f;

    private void Start()
    {
        ThePlayer = GameObject.FindGameObjectWithTag("Player");
        transform.SetParent(ThePlayer.transform);
    }

    private void LateUpdate()
    {
        if (isDashed)
        {
            transform.SetParent(ThePlayer.transform);
            isDashed = false;
        }
        transform.position = Vector3.SmoothDamp(transform.position, ThePlayer.transform.position + BestAngle, ref Velocity, Smoothener, SpeedofSmooth, Time.deltaTime);
    }
}
