using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parentForFX;

    void OnTriggerEnter(Collider other) {
        StartDeathSequence();
        Invoke("ReloadScene", levelLoadDelay);
        KillPlayer();
    }

    void StartDeathSequence() {
        SendMessage("OnPlayerDeath");
    }

    void ReloadScene() { // string referenced
        SceneManager.LoadScene(1);
    }

    void KillPlayer() {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentForFX;

        transform.Translate(Vector3.down * 90);
    }
}
