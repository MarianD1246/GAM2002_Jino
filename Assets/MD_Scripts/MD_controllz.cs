using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class MD_controllz : MD_StaticInheritane {

    private float StartSpeed;
    private float PCJump;
    private Rigidbody2D PCRB;
    private bool Grounded;
    private float DashDistance;
    private float checkRadius;
    [SerializeField]
    private GameObject[] PlayerStateArray;
    private GameObject CrouchedPlayer;
    private GameObject NormalPlayer;
    private bool smalljump;
    private float TimeCrouched;
    private float CrouchDur;
    private bool incrouch;
    private GameObject TheCamera;
    private Vector3 StartPosition;
    private bool finalTask;
    private float holdspeed;
    private float DashTimmer;
    private bool NoDash;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool Respanwed;
    private Vector3 CalcPoitnsFrom;

	private void Start (){
        Respanwed = false;
        doCrouch = false;
        doJump = false;
        PlayerDead = false;
        Dashing = false;
        checkRadius = 0.15f;
        //StartSpeed = 4.6f;     //Startspeed = OutsideSpeed;     
        //OutsideSpeed = StartSpeed;
        StartSpeed = OutsideSpeed;
        PCJump = 5.7f;
        PCRB = GetComponent<Rigidbody2D>();
        DashDistance = 2.5f;
        isDashed = false;
        PlayerStateArray = GameObject.FindGameObjectsWithTag("PC").OrderBy(go => go.name).ToArray();
        CrouchedPlayer = PlayerStateArray[0];
        CrouchedPlayer.SetActive(false);
        NormalPlayer = PlayerStateArray[1];
        smalljump = false;
        CrouchDur = 6f;
        incrouch = false;
        TheCamera = GameObject.FindGameObjectWithTag("MainCamera");
        StartPosition = transform.position;
        finalTask = false;
        RespawnPoint = StartPosition;
    }

    private void Update(){
        if (incrouch && TimeCrouched <= Time.time)
        {
            RevertFromCrouch();
        }
        if (isDashed)
        {
            Dashbutton();
        }
        if (doJump)
        {
            Jumpbutton();
            doJump = false;
        }
        if (doCrouch)
        {
            CrouchRoll();
            doCrouch = false;
        }
        if (PlayerDead && !finalTask)
        {
            StopPlayer();
            CalculatePoints();
            finalTask = true;
        }
    }

    private void FixedUpdate (){
        Run();
	}

    private void Run()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        PCRB.velocity = new Vector2(OutsideSpeed, PCRB.velocity.y);
    }

    public void Jumpbutton()
    {
        RevertFromCrouch();
        if (Grounded) //&& !incrouch) can't jump while crouched
        {
            PCRB.velocity = Vector2.up * PCJump;
            smalljump = true;
        }
        if (!Grounded && smalljump){
            smalljump = false;
            PCRB.velocity = Vector2.zero;  //set velocity to 0
            PCRB.velocity = Vector2.up * PCJump / 2;
        }
    }

    public void Dashbutton()
    {
        if (!Grounded && DashTimmer <= Time.time)
        {
            TheCamera.transform.SetParent(null);
            transform.position = new Vector3(transform.position.x + DashDistance, transform.position.y, transform.position.z);
            PCRB.velocity = Vector2.zero;
            Dashing = false;
            DashTimmer = Time.time + 0.5f;
        }
        if (Grounded && DashTimmer <= Time.time)
        {
            TheCamera.transform.SetParent(null);
            transform.position = new Vector3(transform.position.x + DashDistance, transform.position.y, transform.position.z);
            Dashing = false;
            DashTimmer = Time.time + 0.5f;
        }
    }

    public void CrouchRoll()
    {
        if (!Grounded && !Dashing)
        {
           PCRB.velocity = Vector2.down * PCJump * 2.1f;
        }
        if (Grounded && !Dashing)
        {
            Crouch();
        }
    }

    private void Crouch()
    {
        TimeCrouched = Time.time + CrouchDur;
        incrouch = true;
        CrouchedPlayer.SetActive(true);
        NormalPlayer.SetActive(false);
    }

    private void RevertFromCrouch()
    {
        NormalPlayer.SetActive(true);
        CrouchedPlayer.SetActive(false);
        incrouch = false;
    }
    
    private void StopPlayer()
    {
        holdspeed = OutsideSpeed;
        OutsideSpeed = 0;
        DashDistance = 0;
    }
    private void CalculatePoints()
    {
        if (!Respanwed)
        {
            DistanceTraveled = transform.position.x - StartPosition.x;
        }
        if (Respanwed)
        {
            DistanceTraveled = transform.position.x - CalcPoitnsFrom.x;
        }
        float RawPoints = (DistanceTraveled * holdspeed) /10; // replace with actual points
        PointsMade = Mathf.RoundToInt(RawPoints) + (PointsCollected * 10);
        PointsCollected = 0;
        
    }

    public void LevelReset() {
        MD_Singleton.MyValues.SaveGameData();
        PointsMade = 0;
        DistanceTraveled = 0;
        RestartLevel = true;
        PlayerDead = false;
        transform.position = StartPosition;
        RevertFromCrouch();
        OutsideSpeed = StartSpeed;
        DashDistance = 3f;
        finalTask = false;
    }

    // Values.CurrentPoints += PointsMade; 

    public void PlayerRespawn() {
        MD_Singleton.MyValues.SaveGameData();
        if (!NoLivesLeft)
        {
            MD_Singleton.MyValues.Lives--;
            Respanwed = true;
            CalcPoitnsFrom = RespawnPoint;
            PointsMade = 0;
            PlayerDead = false;
            transform.position = RespawnPoint;
            RevertFromCrouch();
            OutsideSpeed = holdspeed;
            DashDistance = 2.5f;
            finalTask = false;
        }
        if(MD_Singleton.MyValues.Lives == 0) { NoLivesLeft = true; }
    }
    public void ToMenu() {
        MD_Singleton.MyValues.SaveGameData();
        SceneManager.LoadScene("MainMenu");
    }

    public void TapToStart()
    {
        //set other canvases false
        //set this one true
        //finalTask = false; //remove other finalTask = false;
    }
}

// To do
//
  