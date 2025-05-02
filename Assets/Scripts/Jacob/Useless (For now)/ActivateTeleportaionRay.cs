//Script by Jacob Thorley
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportaionRay : MonoBehaviour {

    public GameObject rightTeleport;

    public InputActionProperty rightActivate;
    public InputActionProperty rightCancel;

    // Update is called once per frame
    void Update() {
        //show teleport ray on right analogue stick movement
        rightTeleport.SetActive(rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
