using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class MovableNPCs : MonoBehaviour {
    private NavMeshAgent Npc;
    //private GameObject[] houses;
    //private GameObject selectedHouse;
    private Vector3 NewDestination;
    private bool CanMove;
    public float WalkDistance;
    private float timer;
    private float timerWait;

    private GameObject PlayerEyesCollisionBox;
    public GameObject Horroreyes;
    //private int houseSelected;

    private Vector3 leftAngle1;
    private Vector3 leftAngle2;
    private Vector3 rightAngle1;
    private Vector3 rightAngle2;
    // Start is called before the first frame update
    void Start() {
        //houses = GameObject.FindGameObjectsWithTag("house");
        Npc = gameObject.GetComponent<NavMeshAgent>();
        //houseSelected = Random.Range(0, houses.Length);
        //selectedHouse = houses[houseSelected];
        PlayerEyesCollisionBox = GameObject.FindGameObjectWithTag("PlayerEyesCollisionBox");
        Horroreyes = GameObject.FindGameObjectWithTag("Horror Eyes");
        CanMove = true;
        timer = 0;
        timerWait = UnityEngine.Random.Range(2, 7);
    }

    //private void OnTriggerEnter(Collider other) {
    //    if (other == selectedHouse.GetComponent<Collider>()) {
    //       Destroy(gameObject);
    //    }
    //}
    // Update is called once per frame

    
    void Update() {
        timer += Time.deltaTime;
        Vector3 randLocation = transform.position + UnityEngine.Random.insideUnitSphere * WalkDistance;
        NavMeshHit NavHit;
        
        //if player has horror eyes
        if (Horroreyes.transform.IsChildOf(PlayerEyesCollisionBox.transform)) {
            RaycastHit hit;
            leftAngle1 = Quaternion.Euler(0, 50, 0) * transform.forward;
            leftAngle2 = Quaternion.Euler(0, 25, 0) * transform.forward;
            rightAngle1 = Quaternion.Euler(0, -50, 0) * transform.forward;
            rightAngle2 = Quaternion.Euler(0, -25, 0) * transform.forward;
            
            //all rays for looking around
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("playerCharacter")) {
                    if (hit.distance < 1f) {
                        Npc.speed = 0;
                        //play animation
                        Debug.Log("hit player 5");
                        gameObject.transform.LookAt(hit.collider.transform);
                    }
                    //check is attack animation currently playing 
                    else if(hit.distance > 1f) {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                        Npc.speed = 3.5f;
                    }
                }                
            }           
            else if (Physics.Raycast(transform.position, transform.TransformDirection(leftAngle1), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle1) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("playerCharacter")) {
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
                if (hit.collider.CompareTag("playerCharacter")) {
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
                if (hit.collider.CompareTag("playerCharacter")) {
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
                if (hit.collider.CompareTag("playerCharacter")) {
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
        else {
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
            //Npc.SetDestination(selectedHouse.transform.position);
            Npc.speed = 3.5f;
        }
    }
}
