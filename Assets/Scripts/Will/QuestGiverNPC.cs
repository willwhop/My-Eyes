using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiverNPC : MonoBehaviour
{
    public GameObject npc;
    public TextMesh dialouge;
    public Collider player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other == player) {
          if(gameObject.CompareTag(("NPC1"))) {
                dialouge.text = "hello";
                int pressed = 0;
                //if(controller pressed){
                //pressed += 1;
                //}
                if (pressed == 1) {
                    dialouge.text = "well i have a quest";
                }
                if (pressed == 6) {
                    //logic to add quest to ui
                }
            }
          else if (gameObject.CompareTag(("NPC2"))) {
                dialouge.text = "hello";

          }
          else if (gameObject.CompareTag(("NPC3"))) {
                dialouge.text = "hello";

          }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        //if gameobject has tag("name")
        //check if player has entered the collision box {
        //}
        //then check if trigger on controller is pressed{
        //stop movement
        //}

        //foreach press{
        // add 1 to the int
        //}
        //if int == 1{
        //dialouge.text = "hello";
        //}

        //^
        // |
        //do this for each name
    }
}
