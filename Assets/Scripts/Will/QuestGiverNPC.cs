using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;

public class QuestGiverNPC : MonoBehaviour {
    
    public List<GameObject> QuestObjectList;
    
    public string[] dia;
    public TextMesh dialouge;
    public Collider player;
    public InputActionReference trigger;
   
    private bool canSpeak;
    private float timer;
    private int ItemsHeld;
    private string textNow;
    private int words;
    private int charas;
    private int charas2;
  
    private bool CanCheckQuestItem;
    // Start is called before the first frame update
    void Awake() {
        timer = 0f;       
        CanCheckQuestItem = true;
        canSpeak = true;
        ItemsHeld = 0;
    }

    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("playerCharacter")) {            
            if (gameObject.CompareTag(("NPC1"))) {
                gameObject.transform.LookAt(player.transform.position);
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
                if (Input.GetKey(KeyCode.Space)/*trigger.action.IsPressed()*/) {
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
                    
                    string text = "thanks for the item";
                    if (charas2 < text.Length) {
                        char ch = text[charas];
                        timer = 0;
                        dialouge.text += ch;
                        charas2++;
                    }                    
                }                
                if (Input.GetKey(KeyCode.Space) && CanCheckQuestItem == true/*trigger.action.IsPressed()*/) {
                    foreach (GameObject item in QuestObjectList) {
                        if (item.transform.IsChildOf(player.transform)) {
                            ItemsHeld += 1;                            
                        }
                        if (QuestObjectList.Count == ItemsHeld) {
                            Destroy(item);
                            canSpeak = false;
                            CanCheckQuestItem = false;
                        }
                        if (!item.transform.IsChildOf(player.transform)) {
                            ItemsHeld -= 1;
                        }
                        Debug.Log(ItemsHeld);
                    }                    
                                     
                }
                
            }
            
        }
    }
    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("playerCharacter")) {
            words = 0;
        }
    }
    private void FixedUpdate() {
        timer += Time.deltaTime;
    }
}
