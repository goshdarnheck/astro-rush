using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public float lifeTime = 5f;
    Transform ground;

    private void Start() {
        StartCoroutine(DeathSentence());
        ground = FindObjectOfType<Ground>().transform;
    }

    IEnumerator DeathSentence() {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }

    void OnParticleCollision(GameObject other) {
        Rect rect = new Rect(-Mathf.Abs(ground.GetComponent<Renderer>().bounds.extents.x), -Mathf.Abs(ground.GetComponent<Renderer>().bounds.extents.z), ground.GetComponent<Renderer>().bounds.extents.x * 2, ground.GetComponent<Renderer>().bounds.extents.z * 2);
        Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);

        if (rect.Contains(pos)) {
            YouGotThatPowerup();
        }
    }

    void YouGotThatPowerup() {
        print("YouGotThatPowerup");
        var playerController = FindObjectOfType<PlayerController>();

        playerController.PlayerHealthUp();

        Destroy(gameObject);
    }
}
