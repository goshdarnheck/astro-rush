using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] Text healthText;
    [SerializeField] Text levelText;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start() {
        healthText.text = "";
        levelText.text = "1";
    }

    public void SetHealth(int healthValue) {
        string healthString = "";

        for (int i = 0; i < healthValue; i++) {
            healthString += "❤";
        }

        healthText.text = healthString;
    }

    public void SetLevelText(string newLevelText) {
        levelText.text = newLevelText;
    }
}
