using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GlobalContainer;

[RequireComponent(typeof(Timer))]
public class PlayerJump : MonoBehaviour {

    //public GameObject jumpTrigger;

    [SerializeField] private float maxHoldTime, fallGFactor, lowJumpGFactor;
    Timer jumpTimer;

    bool isOnGround;

    void Start() {
        jumpTimer = GetComponent<Timer>();
        jumpTimer.duration = maxHoldTime;
    }

    void Update() {
        
        //start jump
        if (Input.GetKeyDown(KeyCode.Space) && !jumpTimer.isActive && isOnGround) {
            jumpTimer.activate();
        }
        //holding down jump key
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimer.isActive) {

        }
        //if let go of jump key
        if (!Input.GetKeyDown(KeyCode.Space)) {
            jumpTimer.deactivate();
        }

        //DO gravity modification stuff


        isOnGround = false;
    }

    private void OnTriggerStay(Collider other) { //reset jump when on ground
        if (Global.ground_layers.Contains(other.gameObject.layer)) {
            isOnGround = true;
        }
    }
}
