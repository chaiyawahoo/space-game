using UnityEngine;
using System.Collections;

public class EnemyMissile : Missile {

	public float followSpeed;

	protected override void Update() {
		base.Update ();
		GameObject player = GameObject.Find ("Player");
		Vector3 dir = player.transform.position - transform.position;
		Quaternion rot = Quaternion.LookRotation (dir);
		transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime * followSpeed);
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
	}

	protected override void OnCollisionEnter(Collision other) {
		base.OnCollisionEnter (other);
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage ("TakeDamage", damage);
			Destroy (this.gameObject);
		}
	}
}
