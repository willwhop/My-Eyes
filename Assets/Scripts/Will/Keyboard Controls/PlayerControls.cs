using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
//Made by William Hopton
public class PlayerControls : MonoBehaviour {
    public Camera Camera1;
    public Camera Camera2;
    public Color mat1;
    //public Mesh mesh1;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Color mat2;
   // public Mesh mesh2;
    private GameObject[] InteractableObjects;
    // Start is called before the first frame update
    void Start() {
        InteractableObjects = GameObject.FindGameObjectsWithTag("Interactable");
        foreach (GameObject Obj in InteractableObjects) {
            Obj.GetComponent<SpriteRenderer>().color = mat2;
            Obj.GetComponent<SpriteRenderer>().sprite = Sprite2;
        }
    }
    // Update is called once per frame
    void Update() {

        InteractableObjects = GameObject.FindGameObjectsWithTag("Interactable");
        if (Input.GetKeyDown("1")) {
            Camera1.enabled = false;
            Camera2.enabled = true;
            foreach (GameObject Obj in InteractableObjects) {
                Obj.GetComponent<SpriteRenderer>().color = mat1;
                Obj.GetComponent<SpriteRenderer>().sprite = Sprite1;
                Collider collider = Obj.GetComponent<Collider>();
                DestroyImmediate(Obj.GetComponent<Collider>());
                
                if (collider.IsDestroyed()) {
                    Obj.AddComponent<BoxCollider>();
                }
            }
        }
        else if (Input.GetKeyDown("2")) {
            Camera1.enabled = true;
            Camera2.enabled = false;
            foreach (GameObject Obj in InteractableObjects) {
                Obj.GetComponent<SpriteRenderer>().color = mat2;
                Obj.GetComponent<SpriteRenderer>().sprite = Sprite2;
                Collider collider = Obj.GetComponent<Collider>();
                DestroyImmediate(Obj.GetComponent<Collider>());
                if (collider.IsDestroyed()) {
                    Obj.AddComponent<SphereCollider>();
                }
            }
        }
        //Destroy(Obj.GetComponent<BoxCollider>());
        //if (collider.IsDestroyed()) {
        //    Obj.AddComponent<SphereCollider>();
        //}
        //if (Input.GetKeyDown("1")) {
        //    Camera1.enabled = false;
        //    Camera2.enabled = true;
        //    foreach (GameObject Obj in InteractableObjects) {
        //        Obj.GetComponent<Renderer>().material = mat1;
        //        Obj.GetComponent<MeshFilter>().mesh = mesh1;
        //    }
        //}
        //if (Input.GetKeyDown("2")) {
        //    Camera1.enabled = true;
        //    Camera2.enabled = false;
        //    foreach (GameObject Obj in InteractableObjects) {
        //        Obj.GetComponent<Renderer>().material = mat2;
        //        Obj.GetComponent<MeshFilter>().mesh = mesh2;
        //    }
        //}

    }
}