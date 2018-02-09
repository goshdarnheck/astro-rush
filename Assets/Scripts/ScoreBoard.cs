using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] Text healthText;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start() {
        healthText.text = "";
    }

    public void SetHealth(int healthValue) {
        string healthString = "";

        for (int i = 0; i < healthValue; i++) {
            healthString += "❤";
        }

        healthText.text = healthString;
    }
}
