﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        StartHitSequence();
    }

    void StartHitSequence() {
        SendMessage("OnPlayerHit");
    }
}
