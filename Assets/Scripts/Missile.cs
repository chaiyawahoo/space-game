using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public float damage;
	public float speed;
	
	// Update is called once per frame
	protected virtual void Update () {
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	protected virtual void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "ObjectBounds") {
			Destroy (this.gameObject);
		}
	}
}
