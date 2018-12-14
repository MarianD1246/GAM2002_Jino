using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MD_MenuManager : MonoBehaviour {

    MD_Singleton Values;

    public GameObject MenuHolder;
    public GameObject ShopMenu;
    public GameObject PlayModeMenu;
    public Text LivesDisplayed;
    public Text PointsDisplayed;
    public GameObject NotEnoughPoints;

    public Text StartMed;           //Lock - locked
    public Text StartMedLock;
    public Text PracticeMed;
    public Text PracticeMedLock;
    public Text StartHard;
    public Text StartHardLock;
    public Text PracticeHard;
    public Text PracticeHardLock;

    public Slider PracticeEasySpeed;
    public Text DisplayPracticeEasySpeed;
    public Slider PracticeMedSpeed;
    public Text DisplayPracticeMedSpeed;
    public Slider PracticeHardSpeed;
    public Text DisplayPracticeHardSpeed;


    void Start () {
        Values = MD_Singleton.MyValues;
        MenuHolder.SetActive(true);
        ShopMenu.SetActive(false);
        PlayModeMenu.SetActive(false);
        NotEnoughPoints.SetActive(false);

         Values.LoadGameData();
	}

    public void SellectGameMode() {
        MenuHolder.SetActive(false);
        PlayModeMenu.SetActive(true);
        ShopMenu.SetActive(false);

        PracticeEasySpeed.value = Values.ChoosenEasySpeed;
        PracticeMedSpeed.value = Values.ChoosenMediumSpeed;
        PracticeHardSpeed.value = Values.ChoosenHardSpeed;

        if (!Values.MediumUnlocked)
        {
            PracticeMed.text = "";
            StartMed.text = "";
            PracticeMedLock.text = "Locked";
            StartMedLock.text = "Locked";
        }
        if (Values.MediumUnlocked)
        {
            PracticeMed.text = "Practice:Medium";
            StartMed.text = "Start at Medium";
            PracticeMedLock.text = "";
            StartMedLock.text = "";
        }

        if (!Values.HardUnlocked)
        {
            StartHard.text = "";
            StartHardLock.text= "Locked";
            PracticeHard.text = "";
            PracticeHardLock.text = "Locked";
        }
        if (Values.HardUnlocked)
        {
            StartHard.text = "Start at Hard";
            StartHardLock.text = "";
            PracticeHard.text = "Practice:Hard";
            PracticeHardLock.text = "";
        }
    }

    public void GoToShop() {
        MenuHolder.SetActive(false);
        PlayModeMenu.SetActive(false);
        ShopMenu.SetActive(true);
        LivesDisplayed.text = "Lives: " + Values.Lives;
        PointsDisplayed.text = "Points: " + Values.CurrentPoints + "P";
        if (Values.CurrentPoints < 200)
        {
            NotEnoughPoints.SetActive(true);
        }
    }

    public void BuyLives() {
        if (Values.CurrentPoints >= 200)
        {
            Values.CurrentPoints -= 200;
            Values.Lives++;
        }
        LivesDisplayed.text = "Lives: " + Values.Lives;
        PointsDisplayed.text = "Points: " + Values.CurrentPoints + "P";
        if (Values.CurrentPoints < 200)
        {
            NotEnoughPoints.SetActive(true);
        }
    }

    public void GoBacktoMainMenu() {
        ShopMenu.SetActive(false);
        PlayModeMenu.SetActive(false);
        MenuHolder.SetActive(true);
        NotEnoughPoints.SetActive(false);
    }

    public void StartEasy()
    {
        Values.StartEasy = true;
        Values.StartMeduim = false;
        Values.StartHard = false;
        Values.EasyOnly = false;
        Values.MediumOnly = false;
        Values.HardOnly = false;
        SceneManager.LoadScene("TheGame");
    }
    public void PracticeEasy()
    {
        Values.StartEasy = false;
        Values.StartMeduim = false;
        Values.StartHard = false;
        Values.EasyOnly = true;
        Values.MediumOnly = false;
        Values.HardOnly = false;
        Values.ChoosenEasySpeed = 4.0f + (PracticeEasySpeed.value/10);
        SceneManager.LoadScene("TheGame");
    }
    public void UpdatePracticeEasy()
    {
        DisplayPracticeEasySpeed.text = "4." + PracticeEasySpeed.value;
    }

    public void StartMedium()
    {
        if (Values.MediumUnlocked)
        {
            Values.StartEasy = false;
            Values.StartMeduim = true;
            Values.StartHard = false;
            Values.EasyOnly = false;
            Values.MediumOnly = false;
            Values.HardOnly = false;
            SceneManager.LoadScene("TheGame");
        }
    }
    public void PracticeMedium()
    {
        if (Values.MediumUnlocked)
        {
            Values.StartEasy = false;
            Values.StartMeduim = false;
            Values.StartHard = false;
            Values.EasyOnly = false;
            Values.MediumOnly = true;
            Values.HardOnly = false;
            Values.ChoosenMediumSpeed = 4 + (PracticeMedSpeed.value / 10);
            SceneManager.LoadScene("TheGame");
        }
    }
    public void UpdatePracticeMedium()
    {
        float displayspeed = 4 + (PracticeMedSpeed.value / 10);
        DisplayPracticeMedSpeed.text =  "" + displayspeed;
    }

    public void StartHardest()
    {
        if (Values.HardUnlocked)
        {
            Values.StartEasy = false;
            Values.StartMeduim = false;
            Values.StartHard = true;
            Values.EasyOnly = false;
            Values.MediumOnly = false;
            Values.HardOnly = false;
            SceneManager.LoadScene("TheGame");
        }
    }
    public void PracticeHardest()
    {
        if (Values.HardUnlocked)
        {
            Values.StartEasy = false;
            Values.StartMeduim = false;
            Values.StartHard = false;
            Values.EasyOnly = false;
            Values.MediumOnly = false;
            Values.HardOnly = true;
            Values.ChoosenHardSpeed = 5.6f + (PracticeHardSpeed.value / 10); 
            SceneManager.LoadScene("TheGame");
        }
    }
    public void UpdatePracticeHard()
    {
        float displayspeed = 5.6f + (PracticeHardSpeed.value / 10);
        DisplayPracticeHardSpeed.text = "" + displayspeed;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
