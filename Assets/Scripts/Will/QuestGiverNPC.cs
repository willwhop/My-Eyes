using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class QuestGiverNPC : MonoBehaviour {
    public GameObject npc;
    public List<GameObject> QuestObject;
    public string[] dia;
    public TextMesh dialouge;
    public Collider player;
    public InputActionReference trigger;
    private int pressed;
    private bool canSpeak;
    private float timer;
    private string textNow;
    private int words;
    private int charas;
    private float wait;
    // Start is called before the first frame update
    void Awake() {
        timer = 0f;
        wait = 0f;
        //Add string array for dialouge
        pressed = 0;
        //QuestObject = GameObject.FindGameObjectsWithTag("QuestObject");

        Debug.Log(QuestObject.Count);
        canSpeak = true;
    }

    private void OnTriggerStay(Collider other) {
        if (other == player) {
            if (gameObject.CompareTag(("NPC1"))) {
                gameObject.transform.LookAt(player.transform.position);
                if (trigger.action.IsPressed()) {
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
    private void FixedUpdate() {


        timer += Time.deltaTime;

        if (timer >= 0.2f) {

            
            if (words < dia.Length) {
                textNow = dia[words];
                
                if (charas < textNow.Length) {
                    char ch = textNow[charas];
                    timer = 0;
                    dialouge.text += ch;
                    charas++;
                }
                
                if (dialouge.text.Length == textNow.Length) {
                    wait += Time.deltaTime;
                    if(wait >= 1) {
                        words++;
                        charas = 0;
                        dialouge.text += "";
                        wait = 0f;
                    }
                }
            }
        }   
    }
}