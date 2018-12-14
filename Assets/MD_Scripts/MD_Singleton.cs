using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MD_Singleton : MonoBehaviour {

    public static MD_Singleton MyValues;

    public bool MediumUnlocked;
    public bool HardUnlocked;

    public bool StartEasy = true;
    public bool StartMeduim = false;
    public bool StartHard = false;

    public bool EasyOnly = false;
    public bool MediumOnly = false;
    public bool HardOnly = false;

    public float ChoosenEasySpeed;      //Easy 4.00-4.80  
    
    public float ChoosenMediumSpeed;    //Med  4.85-5.65
    public float ChoosenHardSpeed;      //hard 5.70-6.10

    public float CurrentPoints;
    public float HighestDistanceTraveled;
    public float Lives = 0;

    private void Awake()
    {
        if (MyValues == null)
        {
            DontDestroyOnLoad(gameObject);
            MyValues = this;
        }
        else if (MyValues != this)
        {
            Destroy(gameObject);
        }
        
    }
    public void SaveGameData()
    {
        print("saving");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameJinoData.info");
        PlayerData data = new PlayerData();

        data.ALLPoints = CurrentPoints;
        data.ALLDistance = HighestDistanceTraveled;
        data.AllLife = Lives;
        data.isHardUnlocked = HardUnlocked;
        data.isMedUnlocked = MediumUnlocked;
        data.SetEasySpeed = ChoosenEasySpeed;
        data.SetMedSpeed = ChoosenMediumSpeed;
        data.SetHardSpeed = ChoosenHardSpeed;

        bf.Serialize(file, data);
        file.Close();
    }
    public void LoadGameData()
    {
        if (File.Exists(Application.persistentDataPath + "/GameJinoData.info"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameJinoData.info", FileMode.Open);
            PlayerData data = (PlayerData) bf.Deserialize(file);
            file.Close();

            CurrentPoints = data.ALLPoints ;
            HighestDistanceTraveled = data.ALLDistance ;
            Lives = data.AllLife;
            HardUnlocked = data.isHardUnlocked;
            MediumUnlocked = data.isMedUnlocked;
            ChoosenEasySpeed = data.SetEasySpeed;
            ChoosenMediumSpeed = data.SetMedSpeed;
            ChoosenHardSpeed = data.SetHardSpeed;
        }
    }
}

[Serializable]
class PlayerData
{
    public float ALLPoints;
    public float ALLDistance;
    public float AllLife;

    public bool isMedUnlocked;
    public bool isHardUnlocked;

    public float SetEasySpeed;
    public float SetMedSpeed;
    public float SetHardSpeed;
}



//load on enable
//save when moving scene
//https://www.youtube.com/watch?v=J6FfcJpbPXE&t=982s