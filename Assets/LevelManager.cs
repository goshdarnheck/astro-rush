using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    Wave[] waves;
    EnemyController[] enemies;

    void Start() {
        waves = FindObjectsOfType<Wave>();
    }
	
	void Update() {
        int totalEnemiesToEmit = 0;

        foreach (Wave wave in waves) {
            totalEnemiesToEmit += wave.remaining;
        }

        if (totalEnemiesToEmit <= 0) {
            enemies = FindObjectsOfType<EnemyController>();

            if (enemies.Length <= 0) {
                LoadNextLevel();
            }
        }
    }

    private void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
