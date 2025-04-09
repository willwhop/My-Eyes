using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

public class MovableNPCs : MonoBehaviour {
    //General AI
    private NavMeshAgent Npc;
    //private GameObject[] houses;
    //private GameObject selectedHouse;
    public GameObject sprite;

    public QuestGiverNPC questscript;
    private Vector3 NewDestination;
    private bool CanMove;
    public float WalkDistance;
    private float timer;
    private float timerWait;

    //eye objects
    private GameObject PlayerEyesCollisionBox;
    public GameObject Horroreyes;
    //private int houseSelected;
    private bool notHorrorEyesischecked;
    private bool HorrorEyesIsChecked;

    private Vector3 leftAngle1;
    private Vector3 leftAngle2;
    private Vector3 rightAngle1;
    private Vector3 rightAngle2;
    private Vector3 randLocation;
    private NavMeshHit NavHit;

    private int health;
    //private bool canhit;

    //dog AI
    public List<GameObject> PatrolPoints;
    private int CurrentPoint;
    private float timer2 = 0;
    private GameObject playerLocation;
    private GameObject PlayerCam;
    public Vector3 StartingLocationForPlayer;
    private bool HasHitPlayer = false;
    private float wait = 0;
    public Animator dog;
    public Collider bone;
    public GameObject dogbowl;

    // Start is called before the first frame update
    void Start() {

        //houses = GameObject.FindGameObjectsWithTag("house");
        Npc = gameObject.GetComponent<NavMeshAgent>();
        //houseSelected = Random.Range(0, houses.Length);
        //selectedHouse = houses[houseSelected];
        PlayerEyesCollisionBox = GameObject.FindGameObjectWithTag("PlayerEyesCollisionBox");
        Horroreyes = GameObject.FindGameObjectWithTag("ScaryEyes");
        PlayerCam = GameObject.FindGameObjectWithTag("PlayerCam");
        playerLocation = GameObject.FindGameObjectWithTag("Player");
        CanMove = true;
        timer = 0;
        timerWait = UnityEngine.Random.Range(2, 7);
        CurrentPoint = 0;
        StartingLocationForPlayer = GameObject.Find("PlayerSpawn").transform.position;
    }

    //private void OnTriggerEnter(Collider other) {
    //    if (other == selectedHouse.GetComponent<Collider>()) {
    //       Destroy(gameObject);
    //    }
    //}
    // Update is called once per frame
    private void horrorEyes() {

        //canhit = true;

        RaycastHit hit;
        //angles of the rays
        leftAngle1 = Quaternion.Euler(0, 50, 0) * transform.forward;
        leftAngle2 = Quaternion.Euler(0, 25, 0) * transform.forward;
        rightAngle1 = Quaternion.Euler(0, -50, 0) * transform.forward;
        rightAngle2 = Quaternion.Euler(0, -25, 0) * transform.forward;

        //all rays for looking around
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            if (hit.collider.CompareTag("Player")) {
                if (hit.distance < 1f) {
                    Npc.speed = 0;
                    //play animation
                    Debug.Log("hit player 5");
                    gameObject.transform.LookAt(hit.collider.transform);
                }
                //check is attack animation currently playing 
                else if (hit.distance > 1f) {
                    Npc.SetDestination(hit.collider.transform.position);
                    gameObject.transform.LookAt(hit.collider.transform);
                    Npc.speed = 3.5f;
                }
            }
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(leftAngle1), out hit, 1000)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle1) * hit.distance, Color.blue);
            if (hit.collider.CompareTag("Player")) {
                if (hit.distance < 1f) {
                    Debug.Log("hit player 1");
                    Npc.speed = 0;
                    //play animation
                    gameObject.transform.LookAt(hit.collider.transform);
                }
                //check is attack animation currently playing 
                else if (hit.distance > 1f) {
                    Npc.SetDestination(hit.collider.transform.position);
                    gameObject.transform.LookAt(hit.collider.transform);
                    Npc.speed = 3.5f;
                }
            }
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(leftAngle2), out hit, 1000)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle2) * hit.distance, Color.blue);
            if (hit.collider.CompareTag("Player")) {
                if (hit.distance < 1f) {
                    Npc.speed = 0;
                    //play animation
                    Debug.Log("hit player 2");
                    gameObject.transform.LookAt(hit.collider.transform);
                }
                //check is attack animation currently playing 
                else if (hit.distance > 1f) {
                    Npc.SetDestination(hit.collider.transform.position);
                    gameObject.transform.LookAt(hit.collider.transform);
                    Npc.speed = 3.5f;
                }
            }
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(rightAngle1), out hit, 1000)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(rightAngle1) * hit.distance, Color.blue);
            if (hit.collider.CompareTag("Player")) {
                if (hit.distance < 1f) {
                    Npc.speed = 0;
                    Debug.Log("hit player 3");
                    gameObject.transform.LookAt(hit.collider.transform);
                    //play animation
                }
                //check is attack animation currently playing 
                else if (hit.distance > 1f) {
                    Npc.SetDestination(hit.collider.transform.position);
                    gameObject.transform.LookAt(hit.collider.transform);
                    Npc.speed = 3.5f;
                }
            }
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(rightAngle2), out hit, 1000)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(rightAngle2) * hit.distance, Color.blue);
            if (hit.collider.CompareTag("Player")) {
                if (hit.distance < 1f) {
                    Npc.speed = 0;
                    //play animation
                    Debug.Log("hit player 4");
                    gameObject.transform.LookAt(hit.collider.transform);
                }
                //check is attack animation currently playing 
                else if (hit.distance > 1f) {
                    Npc.SetDestination(hit.collider.transform.position);
                    gameObject.transform.LookAt(hit.collider.transform);
                    Npc.speed = 3.5f;
                }
            }
        }
        //if can move and hasnt hit the player set random location as the new destination
        if (CanMove == true) {
            if (NavMesh.SamplePosition(randLocation, out NavHit, 20f, NavMesh.AllAreas)) {
                NewDestination = NavHit.position;
                CanMove = false;

            }
        }
        if (CanMove == false) {
            if (timer >= 2) {
                CanMove = true;
                Debug.Log(CanMove);
                timer = 0;
                timerWait = UnityEngine.Random.Range(2, 7);
                Npc.SetDestination(NewDestination);
            }
        }
        else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle1) * 1000, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle2) * 1000, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(rightAngle1) * 1000, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(rightAngle2) * 1000, Color.red);
            //Npc.SetDestination(selectedHouse.transform.position);                
            Npc.SetDestination(NewDestination);
            Npc.speed = 3.5f;
        }


    }
    private void notHorrorEyes() {
        //human AI
        if (transform.CompareTag("Human")) {
            if (CanMove == true) {
                if (NavMesh.SamplePosition(randLocation, out NavHit, 20f, NavMesh.AllAreas)) {
                    NewDestination = NavHit.position;
                    CanMove = false;
                }
            }
            if (CanMove == false) {
                if (timer >= 2) {
                    CanMove = true;
                    Debug.Log(CanMove);
                    timer = 0;
                    timerWait = UnityEngine.Random.Range(2, 7);
                }
            }
            Npc.SetDestination(NewDestination);
        }

        //Npc.SetDestination(selectedHouse.transform.position);
        Npc.speed = 3.5f;

        //dog AI
        if (transform.CompareTag("Dog")) {
            RaycastHit hit;
            leftAngle1 = Quaternion.Euler(0, 50, 0) * transform.forward;
            leftAngle2 = Quaternion.Euler(0, 25, 0) * transform.forward;
            rightAngle1 = Quaternion.Euler(0, -50, 0) * transform.forward;
            rightAngle2 = Quaternion.Euler(0, -25, 0) * transform.forward;

            //all rays for looking around
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("Player")) {
                    HasHitPlayer = true;
                    if (hit.distance < 1f) {
                        Npc.speed = 0;
                        //play animation
                        Debug.Log("hit player 5");
                        gameObject.transform.LookAt(hit.collider.transform);
                        //get the bone collider
                        bone = questscript.QuestBone;
                        if (bone != null && bone.transform.IsChildOf(playerLocation.transform) == true) {
                            bone.transform.SetParent(gameObject.transform);
                            //play animation of dog playing with bone
                            Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBBB");
                            //should stop the dog

                        }


                        else {
                            playerLocation.transform.position = StartingLocationForPlayer;
                        }
                        
                    }

                    //stop dog
                    if (bone != null && bone.transform.IsChildOf(gameObject.transform) == true) {
                        Npc.speed = 0;
                        dog.SetBool("IsWalking", false);
                        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                        Npc.SetDestination(dogbowl.transform.position);
                        Debug.Log(NewDestination);
                    }
                    //check is attack animation currently playing 
                    else if (hit.distance > 1f) {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                        Npc.speed = 3.5f;
                        dog.SetBool("IsWalking", true);
                    }
                }
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(leftAngle1), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle1) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("Player")) {
                    HasHitPlayer = true;
                    if (hit.distance < 1f) {
                        Debug.Log("hit player 1");
                        Npc.speed = 0;
                        //play animation
                        gameObject.transform.LookAt(hit.collider.transform);
                        bone = GetComponent<QuestGiverNPC>().QuestBone;
                        if (bone.transform.IsChildOf(hit.collider.transform)) {
                            bone.transform.SetParent(gameObject.transform);
                            //play animation of dog playing with bone

                            if (bone.transform.IsChildOf(gameObject.transform)) {
                                Npc.speed = 0;
                            }
                        }
                        else {
                            playerLocation.transform.position = StartingLocationForPlayer;
                        }
                    }
                    //check is attack animation currently playing 
                    else if (hit.distance > 1f) {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                        Npc.speed = 3.5f;
                        dog.SetBool("IsWalking", true);
                    }
                }
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(leftAngle2), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle2) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("Player")) {
                    HasHitPlayer = true;
                    if (hit.distance < 1f) {
                        Npc.speed = 0;
                        //play animation
                        Debug.Log("hit player 2");
                        gameObject.transform.LookAt(hit.collider.transform);
                        bone = GetComponent<QuestGiverNPC>().QuestBone;
                        if (bone.transform.IsChildOf(hit.collider.transform)) {
                            bone.transform.SetParent(gameObject.transform);
                            //play animation of dog playing with bone

                            if (bone.transform.IsChildOf(gameObject.transform)) {
                                Npc.speed = 0;
                            }
                        }
                        else {
                            playerLocation.transform.position = StartingLocationForPlayer;
                        }
                    }
                    //check is attack animation currently playing 
                    else if (hit.distance > 1f) {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                        Npc.speed = 3.5f;
                        dog.SetBool("IsWalking", true);
                    }
                }
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(rightAngle1), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(rightAngle1) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("Player")) {
                    HasHitPlayer = true;
                    if (hit.distance < 1f) {
                        Npc.speed = 0;
                        Debug.Log("hit player 3");
                        gameObject.transform.LookAt(hit.collider.transform);
                        //play animation
                        bone = GetComponent<QuestGiverNPC>().QuestBone;
                        if (bone.transform.IsChildOf(hit.collider.transform)) {
                            bone.transform.SetParent(gameObject.transform);
                            //play animation of dog playing with bone


                            if (bone.transform.IsChildOf(gameObject.transform)) {
                                Npc.speed = 0;
                            }
                        }
                        else {
                            playerLocation.transform.position = StartingLocationForPlayer;
                        }
                    }
                    //check is attack animation currently playing 
                    else if (hit.distance > 1f) {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                        Npc.speed = 3.5f;
                        dog.SetBool("IsWalking", true);
                    }
                }
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(rightAngle2), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(rightAngle2) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("Player")) {
                    HasHitPlayer = true;
                    if (hit.distance < 1f) {
                        Npc.speed = 0;
                        //play animation
                        Debug.Log("hit player 4");
                        gameObject.transform.LookAt(hit.collider.transform);
                        bone = GetComponent<QuestGiverNPC>().QuestBone;
                        if (bone.transform.IsChildOf(hit.collider.transform)) {
                            bone.transform.SetParent(gameObject.transform);
                            //play animation of dog playing with bone

                            //should stop the dog
                            if (bone.transform.IsChildOf(gameObject.transform)) {
                                Npc.speed = 0;
                            }
                        }
                        else {
                            playerLocation.transform.position = StartingLocationForPlayer;
                        }
                    }
                    //check is attack animation currently playing 
                    else if (hit.distance > 1f) {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                        Npc.speed = 3.5f;
                        dog.SetBool("IsWalking", true);
                    }
                }
            }

            //makes it so that control points are the new destination
            if (HasHitPlayer == false) {
                foreach (GameObject point in PatrolPoints) {
                    //get the current point and set as new destination
                    if (point == PatrolPoints[CurrentPoint]) {
                        if (transform.position != point.transform.position) {
                            NewDestination = point.transform.position;
                            Npc.SetDestination(NewDestination);                            
                            dog.SetBool("IsWalking", true);
                        }
                        if (transform.position.x >= NewDestination.x) {
                            timer2 += Time.deltaTime;
                            float rand = UnityEngine.Random.Range(2, 7);
                            
                            
                            //Debug.Log(CurrentPoint);
                            //Debug.Log(timer2);
                            if (timer2 >= rand) {
                                
                                CurrentPoint += 1;
                                timer2 = 0;
                            }
                        }

                    }
                }
                if (CurrentPoint >= PatrolPoints.Count) {
                    CurrentPoint = 0;
                    dog.SetBool("IsWalking", false);
                }
            }
            else {

                wait += Time.deltaTime;
                if (wait >= 4) {
                    HasHitPlayer = false;
                    wait = 0;
                }
                
            }
        }
    }
    void Update() {
        timer += Time.deltaTime;
        randLocation = transform.position + UnityEngine.Random.insideUnitSphere * WalkDistance;
        //if player has horror eyes
        if (Horroreyes.transform.IsChildOf(PlayerEyesCollisionBox.transform)) {
            horrorEyes();
        }
        else {
            notHorrorEyes();
        }
        
        sprite.transform.LookAt(PlayerCam.transform.position);
        if (bone == null) {
        }

    }
}