using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MovableNPCs : MonoBehaviour
{
    public NavMeshAgent Npc;
    private GameObject[] houses;
    private GameObject selectedHouse;
    private Vector3 OriginalPosition;
    private int houseSelected;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        houses = GameObject.FindGameObjectsWithTag("house");
        houseSelected = Random.Range(0, houses.Length);
        OriginalPosition = gameObject.transform.position;
        selectedHouse = houses[houseSelected];
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other == selectedHouse.GetComponent<Collider>()) {
            if (timer >= 3) {
                Debug.Log("hello");
                
                Destroy(gameObject);
            }
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (OriginalPosition == selectedHouse.transform.position) {
            houseSelected = Random.Range(0, houses.Length);
            selectedHouse = houses[houseSelected];
        }
        OnTriggerEnter(selectedHouse.GetComponent<Collider>());
        //if player has normal eyes
        //npcs should just walk around town find the closest building entrancee then walk and be destroyed there.
        //entrances should also spawn new npcs
        Npc.SetDestination(selectedHouse.transform.position);
        

        //if player has cute eyes

        //if player has horror eyes
        //Raycast hit;
        //if(physics.Raycast(origin, trasnform.TrasformDirection(Vector3.Forward), 1000)){
          //if (gameObject.CompareTag("")) {

          //}
        //}
    }
}
