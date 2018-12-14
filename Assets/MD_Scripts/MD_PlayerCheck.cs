using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD_PlayerCheck : MD_StaticInheritane {

    MD_Singleton Values;
    private GameObject SwitchPrevention;

    private void Start()
    {
        Values = MD_Singleton.MyValues;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
           PlayerDead = true;
        }
        if (collision.gameObject.tag == "StarPoints")
        {
            PointsCollected ++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "RespawnPoint")
        {
            RespawnPoint = new Vector3 (collision.gameObject.transform.position.x , collision.gameObject.transform.position.y , -1);
            if (OutsideSpeed < SpeedCap) 
            {
                OutsideSpeed += 0.05f;
                //print(OutsideSpeed);
                if (OutsideSpeed > 4.84f && isEasy)  //Easy 4-4.8 //med 4.85-5.65 //hard 5.7-6.1
                {
                    isEasy = false;
                    isMedium = true;
                    SwitchEtM = true;
                    OutsideSpeed = 4.8f;
                    print("Switching to med");

                }
                if (OutsideSpeed > 5.69f && isMedium)
                {
                    isMedium = false;
                    isHard = true;
                    SwitchMtH = true;
                    OutsideSpeed = 5.65f;
                    print("Switching to hard");
                }
            }
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "Trap" || collision.gameObject.tag == "StartRoom")
        {
            SwitchPrevention = LastRoom;
            LastRoom = CurrentRoom;
            CurrentRoom = collision.gameObject;
            if (LastRoom == CurrentRoom)
            {
                LastRoom = SwitchPrevention;
            }
        }
        if (collision.gameObject.tag == "MedUnlocked" && !Values.MediumUnlocked)
        {
            Values.MediumUnlocked = true;
            print("Med Unlocked"); 
        }
        if (collision.gameObject.tag == "HardUnlocked" && !Values.HardUnlocked)
        {
            Values.HardUnlocked = true;
            print("Hard Unlocked"); 
        }
    }

}
