using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportaionRay : MonoBehaviour {

    public GameObject rightTeleport;

    public InputActionProperty rightActivate;
    public InputActionProperty rightCancel;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        rightTeleport.SetActive(rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
