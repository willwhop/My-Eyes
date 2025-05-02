//Script by Jacob Thorley
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowPlayer : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private Transform itemAnchorPoint;
    [SerializeField] private AudioClip collectAudio;
    AudioSource source;

    private void OnTriggerEnter(Collider collider) {
        //if player enters trigger box, add gameObject as child and place on top of head
        if (collider.CompareTag("Player")) {
            player = collider.gameObject;
            gameObject.transform.parent = collider.transform;
            itemAnchorPoint = player.transform.GetChild(0).gameObject.transform;
            gameObject.transform.position = itemAnchorPoint.transform.position;
            source = GetComponentInParent<AudioSource>();
            source.PlayOneShot(collectAudio);
        }
    }
}
