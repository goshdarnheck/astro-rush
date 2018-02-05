using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    int score;

    [SerializeField] string scoreTextPrepend = "$";
    [SerializeField] Text scoreText;
    [SerializeField] Text healthText;

    void Start() {
        scoreText.text = "";
        healthText.text = "";
    }
	
	public void ScoreHit(int scoreValue = 1) {
        score += scoreValue;
        scoreText.text = scoreTextPrepend + score;
    }

    public void SetHealth(int healthValue) {
        string healthString = "";

        for (int i = 0; i < healthValue; i++) {
            healthString += "❤";
        }

        healthText.text = healthString;
    }
}
