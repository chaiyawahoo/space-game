using UnityEngine;
using System.Collections;

public class Enemy : Ship {

	protected float spawned;
	public float fireInterval;

	// Use this for initialization
	void Start () {
		spawned = 0;
		InvokeRepeating ("Fire", 0, fireInterval);
	}
	
	// Update is called once per frame
	protected override void Update () {
		if (!Player.isDead) {
			if (health <= 0) {
				UIManager.score += 1000;
				Destroy (this.gameObject);
			}
			Move ();
			if (transform.localPosition.y > -10) {
				transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3 (0, -10, 20), 20 * Time.deltaTime);
			}
		} else {
			CancelInvoke ();
		}
	}

	protected override void Move() { }

	protected override void Fire() {
		GetComponent<AudioSource> ().Play ();
		GameObject missile = Instantiate (missilePrefab, transform.position, Quaternion.Euler(new Vector3(180, 0, 0))) as GameObject;
		missile.transform.SetParent (transform);
		missile.transform.localScale = new Vector3(5, 5, 40);
		missile.transform.SetParent (transform.parent.transform);
	}
}
