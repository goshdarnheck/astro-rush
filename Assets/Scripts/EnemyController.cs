using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 2f;
    public int scoreValue = 1;

    GameObject deathFX;
    Transform parentForFX;
    Transform target;
    Transform ground;
    PowerupBar powerupBar;

    void Start() {
        PlayerController playerController = FindObjectOfType<PlayerController>();

        if (playerController != null) {
            target = FindObjectOfType<PlayerController>().transform;
        } else {
            Destroy(gameObject);
            return;
        }

        powerupBar = FindObjectOfType<PowerupBar>();
        parentForFX = FindObjectOfType<RuntimeSpawn>().transform;
        deathFX = Resources.Load("Enemy Explosion") as GameObject;
        ground = FindObjectOfType<Ground>().transform;
    }
	
	void Update() {
        float step = speed * Time.deltaTime;

        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    void OnTriggerEnter(Collider other) {
        KillEnemy(false);
    }

    void OnParticleCollision(GameObject other) {
        Rect rect = new Rect(-Mathf.Abs(ground.GetComponent<Renderer>().bounds.extents.x), -Mathf.Abs(ground.GetComponent<Renderer>().bounds.extents.z), ground.GetComponent<Renderer>().bounds.extents.x * 2, ground.GetComponent<Renderer>().bounds.extents.z * 2);
        Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);

        if (rect.Contains(pos)) {
            KillEnemy(true);
        }
    }

    void KillEnemy(bool killedByParticle) {
        if (killedByParticle) {
            powerupBar.PowerUp(scoreValue);
        }
        
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentForFX;
        Destroy(gameObject);
    }
}
