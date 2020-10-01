using UnityEngine;
using System.Collections;

public abstract class Ship : MonoBehaviour {

	public float speed;
	public float health;

	public GameObject missilePrefab;

	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Move ();
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	protected abstract void Move ();

	protected abstract void Fire ();

	protected virtual void TakeDamage(float damage) {
		health -= damage;
	}
}
