using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    [SerializeField] private Transform cam;

    void Update() {
        gameObject.transform.LookAt(cam);
    }
}
