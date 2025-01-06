using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MovableNPCs : MonoBehaviour {
    public NavMeshAgent Npc;
    private GameObject[] houses;
    private GameObject selectedHouse;

    public Transform PlayerEyesCollisionBox;
    //public GameObject Normaleyes;
    //public GameObject Cuteeyes;
    public GameObject Horroreyes;
    private int houseSelected;

    private Vector3 leftAngle1;
    private Vector3 leftAngle2;
    private Vector3 rightAngle1;
    private Vector3 rightAngle2;
    // Start is called before the first frame update
    void Start() {
        houses = GameObject.FindGameObjectsWithTag("house");
        houseSelected = Random.Range(0, houses.Length);
       // OriginalPosition = gameObject.transform.position;
        selectedHouse = houses[houseSelected];
    }

    private void OnTriggerEnter(Collider other) {
        if (other == selectedHouse.GetComponent<Collider>()) {
            Debug.Log("destroy");
                Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update() {
        //if player has horror eyes
        //MAKE CODE BELOW MORE CLEAN
        if (Horroreyes.transform.IsChildOf(PlayerEyesCollisionBox)) {
            RaycastHit hit;
            leftAngle1 = Quaternion.Euler(0, 50, 0) * transform.forward;
            leftAngle2 = Quaternion.Euler(0, 25, 0) * transform.forward;
            rightAngle1 = Quaternion.Euler(0, -50, 0) * transform.forward;
            rightAngle2 = Quaternion.Euler(0, -25, 0) * transform.forward;
            
            //all rays for looking around
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("playerCharacter")) {
                    if (hit.distance <= 10f) {
                        Npc.speed = 0;
                        //play animation
                    }
                    //check is attack animation currently playing 
                    else {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                    }
                }
                else {
                    Npc.SetDestination(selectedHouse.transform.position);
                }
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection(leftAngle1), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle1) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("playerCharacter")) {
                    if (hit.distance <= 10f) {
                        Npc.speed = 0;
                        //play animation
                    }
                    //check is attack animation currently playing 
                    else {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                    }
                }
                else {
                    Npc.SetDestination(selectedHouse.transform.position);
                }
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection(leftAngle2), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle2) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("playerCharacter")) {
                    if (hit.distance <= 10f) {
                        Npc.speed = 0;
                        //play animation
                    }
                    //check is attack animation currently playing 
                    else {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                    }
                }
                else {
                    Npc.SetDestination(selectedHouse.transform.position);
                }
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection(rightAngle1), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(rightAngle1) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("playerCharacter")) {
                    if (hit.distance <= 10f) {
                        Npc.speed = 0;
                        //play animation
                    }
                    //check is attack animation currently playing 
                    else {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                    }
                }
                else {
                    Npc.SetDestination(selectedHouse.transform.position);
                }
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection(rightAngle2), out hit, 1000)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(rightAngle2) * hit.distance, Color.blue);
                if (hit.collider.CompareTag("playerCharacter")) {
                    if (hit.distance <= 10f) {
                        Npc.speed = 0;
                        //play animation
                    }
                    //check is attack animation currently playing 
                    else {
                        Npc.SetDestination(hit.collider.transform.position);
                        gameObject.transform.LookAt(hit.collider.transform);
                    }
                }
                else {
                    Npc.SetDestination(selectedHouse.transform.position);
                }
            }
            else {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle1) * 1000, Color.red);
                Debug.DrawRay(transform.position, transform.TransformDirection(leftAngle2) * 1000, Color.red);
                Debug.DrawRay(transform.position, transform.TransformDirection(rightAngle1) * 1000, Color.red);
                Debug.DrawRay(transform.position, transform.TransformDirection(rightAngle2) * 1000, Color.red);
            }
        }
        else {
            Npc.SetDestination(selectedHouse.transform.position);
        }
    }
}
