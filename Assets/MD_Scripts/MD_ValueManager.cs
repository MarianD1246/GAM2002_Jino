using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD_ValueManager : MD_StaticInheritane {

    MD_Singleton Values;
    private readonly float easyStartSpeed = 3.95f;
    private readonly float medStartSpeed = 4.80f;
    private readonly float hardStartSpeed = 5.65f;
    private readonly float inSpeedCap = 6.10f;

    private void Start()
    {
        Values = MD_Singleton.MyValues;
        if (Values.Lives >= 1) {
            NoLivesLeft = false;
        }
        if (Values.Lives == 0) {
            NoLivesLeft = true;

        }
        if (Values.EasyOnly)
        {
            OutsideSpeed = Values.ChoosenEasySpeed;
            SpeedCap = Values.ChoosenEasySpeed;
            isEasy = true;
            isMedium = false;
            isHard = false;
            
        }
        if (Values.MediumOnly)
        {
            OutsideSpeed = Values.ChoosenMediumSpeed;
            SpeedCap = Values.ChoosenMediumSpeed;
            isEasy = false;
            isMedium = true;
            isHard = false;
        }
        if (Values.HardOnly)
        {
            OutsideSpeed = Values.ChoosenHardSpeed;
            SpeedCap = Values.ChoosenHardSpeed;
            isEasy = false;
            isMedium = false;
            isHard = true;
        }
        if (Values.StartEasy)
        {
            OutsideSpeed = easyStartSpeed;
            SpeedCap = inSpeedCap;
            isEasy = true;
            isMedium = false;
            isHard = false;
        }
        if (Values.StartMeduim)
        {
            OutsideSpeed = medStartSpeed;
            SpeedCap = inSpeedCap;
            isEasy = false;
            isMedium = true;
            isHard = false;
        }
        if (Values.StartHard)
        {
            OutsideSpeed = hardStartSpeed;
            SpeedCap = inSpeedCap;
            isEasy = false;
            isMedium = false;
            isHard = true;
        }
    }

}
