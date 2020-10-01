using UnityEngine;
using System.Collections;

public class PlayerMissile : Missile {

	protected override void OnCollisionEnter(Collision other) {
		base.OnCollisionEnter (other);
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.SendMessage ("TakeDamage", damage);
			Destroy (this.gameObject);
		}
	}
}
