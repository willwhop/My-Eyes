using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestGiverNPC : MonoBehaviour {

    public List<GameObject> QuestObjectList;

    public string[] dia;
    public TextMesh dialouge;
    public GameObject player;
    public InputActionReference trigger;

    private bool canSpeak;
    private float timer;
    private int ItemsHeld = 0;
    private string textNow;
    private int words;
    private int charas;
    private int charas2;

    private bool CanCheckQuestItem;

    public string FinalText;

    [Header ("Main NPCs")]
    private bool GiveBone;
    private bool GiveKey;
    public Collider QuestKey, DumpsterBotQuestKey;
    public Collider Bonereference, CareTakerKeyRef, DumpsterBotKeyRef;
    public Collider QuestBone;

    public bool ToiletRollForce;
    public GameObject toiletPaper;
    public GameObject ItemHolder;

    // Start is called before the first frame update
    void Awake() {
        timer = 0f;
        CanCheckQuestItem = true;
        canSpeak = true;
        ItemsHeld = 0;
        GiveBone = true;
        player = GameObject.FindWithTag("Player");
        ItemHolder = GameObject.Find("ItemAnchorPoint");       
    }

    private void OnEnable() {
        trigger.action.Enable();
    }

    private void OnDisable() {
        trigger.action.Disable();
    }

    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {            
            if (gameObject.CompareTag(("NPC1"))) {                
                if (gameObject.name != "ScrapBot") {
                    gameObject.transform.LookAt(player.transform.position);
                }                
                if (canSpeak == true) {
                    if (timer >= 0.03) {
                        if (words < dia.Length) {
                            textNow = dia[words];
                            if (charas < textNow.Length) {
                                char ch = textNow[charas];
                                timer = 0;
                                dialouge.text += ch;
                                charas++;
                            }
                        }
                    }
                }
                if (trigger.action.IsPressed()) {
                    if (canSpeak == true) {
                        if (dialouge.text.Length == textNow.Length) {
                            words++;
                            charas = 0;
                            dialouge.text = "";
                        }
                        if (words == dia.Length) {
                        }
                    }
                }
                if (canSpeak == false) {                   
                    if (charas2 < FinalText.Length) {
                        char ch = FinalText[charas2];
                        timer = 0;
                        dialouge.text += ch;
                        charas2++;
                    }
                    
                    if (gameObject.name == "ScrapBot") {
                        if (GiveBone == true) {                                                       
                            QuestBone = Instantiate(Bonereference);
                            ////ADDED BY JACOB
                            Transform itemAnchorPoint = player.transform.GetChild(0).gameObject.transform;
                            QuestBone.transform.position = itemAnchorPoint.transform.localPosition;
                            QuestBone.isTrigger = true;
                            QuestBone.transform.SetParent(player.transform, false);
                            GiveBone = false;
                        }                        
                    }
                    if (gameObject.name == "CareTaker") {
                        if (GiveKey == true) {
                            QuestKey = Instantiate(CareTakerKeyRef);
                            Transform itemAnchorPoint = player.transform.GetChild(0).gameObject.transform;
                            QuestKey.transform.position = itemAnchorPoint.transform.localPosition;
                            QuestKey.isTrigger = true;
                            QuestKey.transform.SetParent(player.transform, false);
                            GiveKey = false;
                        }                        
                    }
                    if (gameObject.name == "Troll") {
                        if (charas2 == FinalText.Length) {
                            gameObject.SetActive(false);
                        }
                    }
                    if (gameObject.name == "Dumpster Bot") {
                        if (GiveKey == true) {
                            DumpsterBotQuestKey = Instantiate(DumpsterBotKeyRef);
                            Transform itemAnchorPoint = player.transform.GetChild(0).gameObject.transform;
                            DumpsterBotQuestKey.transform.position = itemAnchorPoint.transform.localPosition;
                            DumpsterBotQuestKey.isTrigger = true;
                            DumpsterBotQuestKey.transform.SetParent(player.transform, false);
                            GiveKey = false;
                        }
                    }
                }
                if (trigger.action.IsPressed() && CanCheckQuestItem == true) {
                    foreach (GameObject item in QuestObjectList) {
                        if (item.transform.IsChildOf(player.transform)) {
                            //ItemsHeld += 1;
                            QuestObjectList.Remove(item);
                            Destroy(item);
                        }
                        if (QuestObjectList.Count == ItemsHeld) {                            
                            canSpeak = false;
                            CanCheckQuestItem = false;
                        }                   
                    }
                }
                
                if (gameObject.name == "CareTaker") {                     
                    if (toiletPaper.transform.IsChildOf(player.transform)) {
                        if (trigger.action.IsPressed()) {
                            charas2 = 0;
                            FinalText = "aah finally! Here take the key to leave.";
                            GiveKey = true;
                            Destroy(toiletPaper);
                        }                        
                    }
                    if (canSpeak == false) {
                        //play animation to destroy house
                        ToiletRollForce = true;
                    }
                }
            }            
        }
    }
    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            words = 0;
        }
    }
    public void DestroyAll() {
        foreach (GameObject item in QuestObjectList) {
            Destroy(item);
        }
    }
    private void FixedUpdate() {
        timer += Time.deltaTime;
    }
}