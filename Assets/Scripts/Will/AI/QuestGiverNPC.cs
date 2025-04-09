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

    //caretaker
    private bool GiveBone;
    private bool GiveKey;
    public Collider QuestKey;
    public Collider Bonereference;
    public Collider QuestBone;

    //public GameObject gravel;
    //public GameObject Recite;
    //public GameObject Leaf;
    public bool ToiletRollForce;
    public GameObject toiletPaper;

    // Start is called before the first frame update
    void Awake() {
        timer = 0f;
        CanCheckQuestItem = true;
        canSpeak = true;
        ItemsHeld = 0;
        GiveBone = true;
        player = GameObject.FindWithTag("Player");
    }

    private void OnEnable() {
        trigger.action.Enable();
    }

    private void OnDisable() {
        trigger.action.Disable();
    }

    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("shshsh1");
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

                    string text = FinalText;
                    if (charas2 < text.Length) {
                        char ch = text[charas2];
                        timer = 0;
                        dialouge.text += ch;
                        charas2++;
                    }
                    //if robot will give collider to player
                    if (gameObject.name == "ScrapBot") {
                        if (GiveBone == true) {
                            FinalText = "thanks for the bolt here take the bone";                            
                            QuestBone = Instantiate(Bonereference);                            
                            QuestBone.transform.position = new Vector3(0, 0, 0);
                            QuestBone.isTrigger = true;
                            QuestBone.transform.SetParent(player.transform, false);
                            GiveBone = false;
                        }
                        if (GiveBone == false) {
                            FinalText = "thanks for the item";
                        }
                    }
                    if (gameObject.name == "CareTaker") {
                        if (GiveKey == true) {
                            FinalText = "thanks for the toilet paper and such here take the key and leave";
                            //player.AddComponent<Collider>().name = "QuestKey";
                            //QuestKey = new Collider();
                            //QuestKey.name = "Key";
                            QuestKey.transform.position = new Vector3(0, 0, 0);

                            QuestKey.transform.SetParent(player.transform, false);
                            GiveKey = false;
                        }
                        if (GiveKey == false) {
                            FinalText = "thanks for the item";
                        }
                    }
                    else {
                        FinalText = "thanks for the item";
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
                        //if (!item.transform.IsChildOf(player.transform)) {
                        //    ItemsHeld -= 1;
                        //}
                        Debug.Log(ItemsHeld);
                    }

                }
                //caretaker in progress
                if (gameObject.name == "CareTaker") {
                    //if (gravel.transform.IsChildOf(player.transform)) {
                    //    dialouge.text = "eugh get that gravel away from me";
                    //    Destroy(gravel);
                    //}
                    //if (Recite.transform.IsChildOf(player.transform)) {
                    //    dialouge.text = "eugh get that Recite away from me";
                    //    Destroy(Recite);
                    //}
                    //if (Leaf.transform.IsChildOf(player.transform)) {
                    //    dialouge.text = "eugh get that Leaf away from me";
                    //    Destroy(Leaf);
                    //}
                    //if (Leaf.transform.IsChildOf(player.transform) && Recite.transform.IsChildOf(player.transform) && gravel.transform.IsChildOf(player.transform)) {
                    //    dialouge.text = "eugh get those away from me";
                    //    Destroy(Leaf);
                    //    Destroy(gravel);
                    //    Destroy(Recite);
                    //}
                    if (toiletPaper.transform.IsChildOf(player.transform)) {
                        GiveKey = true;
                        Destroy(toiletPaper);
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