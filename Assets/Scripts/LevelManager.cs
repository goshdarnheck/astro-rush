using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    Wave[] waves;
    EnemyController[] enemies;
    PlayerController playerController;
    PowerupBar powerupBar;
    ScoreBoard scoreBoard;

    void Start() {
        waves = FindObjectsOfType<Wave>();
        playerController = FindObjectOfType<PlayerController>();
        powerupBar = FindObjectOfType<PowerupBar>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
	
	void Update() {
        int totalEnemiesToEmit = 0;

        foreach (Wave wave in waves) {
            totalEnemiesToEmit += wave.remaining;
        }

        if (totalEnemiesToEmit <= 0) {
            enemies = FindObjectsOfType<EnemyController>();

            if (enemies.Length <= 0) {
                Invoke("LoadNextLevel", 2f);
            }
        }
    }

    private void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) {
            LoadFirstScene();
        } else {
            SceneManager.LoadScene(nextSceneIndex);
            scoreBoard.SetLevelText(nextSceneIndex.ToString());
        }
    }

    public void LoadFirstScene() {
        int nextSceneIndex = 0;

        Destroy(playerController.gameObject);
        Destroy(scoreBoard.gameObject);
        powerupBar.Reset();

        playerController.transform.Translate(new Vector3(0, 0, 0));

        SceneManager.LoadScene(nextSceneIndex);
        scoreBoard.SetLevelText(nextSceneIndex.ToString());
    }
}
