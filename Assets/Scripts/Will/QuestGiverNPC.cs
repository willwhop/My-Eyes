using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestGiverNPC : MonoBehaviour
{
    public GameObject npc;
    private List<GameObject> QuestObject;
    public string[] dia;
    public TextMesh dialouge;
    public Collider player;
    public InputActionReference trigger;
    private int pressed;
    private bool canSpeak;
    // Start is called before the first frame update
    void Start()
    {
        //Add string array for dialouge
        pressed = 0;
        //QuestObject = GameObject.FindGameObjectsWithTag("QuestObject");
        QuestObject.Add(GameObject.FindGameObjectWithTag("QuestObject"));
        Debug.Log(QuestObject.Count);
        canSpeak = true;
    }

    private void OnTriggerStay(Collider other) {
        if (other == player) {
            if (gameObject.CompareTag(("NPC1"))) {
                gameObject.transform.LookAt(player.transform.position);
                if(trigger.action.IsPressed()) {  
                    pressed++; 
                }
                if (canSpeak == true) {
                    if (pressed == 1) {
                        dialouge.text = "I have a quest";
                    }
                    else if (pressed == 6) {
                        //logic to add quest to ui
                        pressed = 0;
                    }
                }
                if (canSpeak == false) {
                    pressed = 0;
                    dialouge.text = "thanks for the item";
                }
                foreach (GameObject item in QuestObject) {
                    if (trigger.action.IsPressed()) {
                        if (item.name == "QuestItem1") {
                            if (item.transform.IsChildOf(player.transform)) {
                                Destroy(item);
                                QuestObject.Remove(item);
                                dialouge.text = "thanks";
                                canSpeak = false;
                            }
                        }
                    }
                }
            }
          else if (gameObject.CompareTag(("NPC2"))) {
                gameObject.transform.LookAt(player.transform.position);
                if (trigger.action.IsPressed()) {
                    pressed++;
                }
                foreach (GameObject item in QuestObject) {
                    if (item.name == "QuestItem2") {
                        if (item.transform.IsChildOf(player.transform)) {
                            Destroy(item);
                            QuestObject.Remove(item);
                            dialouge.text = "thanks";
                        }
                    }
                }
                if (pressed == 1) {
                    dialouge.text = "I have a quest";
                }
                else if (pressed == 6) {
                    //logic to add quest to ui
                    pressed = 0;
                }
            }
          else if (gameObject.CompareTag(("NPC3"))) {
                gameObject.transform.LookAt(player.transform.position);
                if (trigger.action.IsPressed()) {
                    pressed++;
                }
                foreach (GameObject item in QuestObject) {
                    if (item.name == "QuestItem3") {
                        if (item.transform.IsChildOf(player.transform)) {
                            Destroy(item);
                            QuestObject.Remove(item);
                            dialouge.text = "thanks";
                        }
                    }
                }
                if (pressed == 1) {
                    dialouge.text = "I have a quest";
                }
                else if (pressed == 6) {
                    //logic to add quest to ui
                    pressed = 0;
                }
            }
        }
    }
    public void OnTriggerExit(Collider other) {
        if (other == player) {
           pressed = 0;
        }
    }
}
