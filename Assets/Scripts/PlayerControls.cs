using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class PlayerControls : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;
    public Material mat1;
    public Mesh mesh1;
    public Material mat2;
    public Mesh mesh2;
    // Start is called before the first frame update
    void Start()
    {
        Camera2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] InteractableObjects = GameObject.FindGameObjectsWithTag("Interactable");
        if (Input.GetKeyDown("1")) {
            Camera1.enabled = false;
            Camera2.enabled = true;
            foreach (GameObject Obj in InteractableObjects) {
                Obj.GetComponent<Renderer>().material = mat1;
                Obj.GetComponent<MeshFilter>().mesh = mesh1;
            }
        }
        if (Input.GetKeyDown("2")) {
            Camera1.enabled = true;
            Camera2.enabled = false;
            foreach (GameObject Obj in InteractableObjects) {
                Obj.GetComponent<Renderer>().material = mat2;
                Obj.GetComponent<MeshFilter>().mesh = mesh2;
               



            }
        }
        //xrinput
    }
}
