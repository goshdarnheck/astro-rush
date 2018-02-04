using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parentForFX;
    [SerializeField] Transform target;
    [Tooltip("If above this object, can be killed.")][SerializeField] Transform ground;
    [SerializeField] float speed = 5f;

	void Start() {
        
    }
	
	void Update() {
        float step = speed * Time.deltaTime;

        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnTriggerEnter(Collider other) {
        KillEnemy();
    }

    void OnParticleCollision(GameObject other) {
        Rect rect = new Rect(-Mathf.Abs(ground.GetComponent<Renderer>().bounds.extents.x), -Mathf.Abs(ground.GetComponent<Renderer>().bounds.extents.z), ground.GetComponent<Renderer>().bounds.extents.x * 2, ground.GetComponent<Renderer>().bounds.extents.z * 2);
        Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);

        if (rect.Contains(pos)) {
            KillEnemy();
        }
    }

    void KillEnemy() {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentForFX;
        Destroy(gameObject);
    }
}
