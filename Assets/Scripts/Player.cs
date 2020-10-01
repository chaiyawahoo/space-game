using UnityEngine;
using System.Collections;

public class Player : Ship {

	float distance;
	float passed;

	public static bool isDead;

	public float timeToShoot;

	public float xBound;

	// Use this for initialization
	void Start () {
		passed = 0;
		float z = Camera.main.transform.position.z - transform.position.z;
		float y = Camera.main.transform.position.y - transform.position.y;
		distance = Mathf.Sqrt (Mathf.Pow (z, 2) + Mathf.Pow (y, 2));
	}
	
	// Update is called once per frame
	protected override void Update () {
		if (health <= 0) {
			Destroy (this.gameObject);
			isDead = true;
		}
		base.Update ();
		passed += Time.deltaTime;
		Fire ();
	}

	protected override void Move () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, 0, distance));

		if (mousePos.x < -xBound) {
			mousePos.x = -xBound;
		} else if (mousePos.x > xBound) {
			mousePos.x = xBound;
		}

		Vector3 actualPos = new Vector3 (mousePos.x, -10, 1);

		transform.localPosition = Vector3.Lerp (transform.localPosition, actualPos, speed * Time.deltaTime);
		transform.rotation = Quaternion.identity;
	}

	protected override void Fire () {
		if (Input.GetMouseButtonDown (0) && passed >= timeToShoot) {
			GetComponent<AudioSource> ().Play ();
			for (int i = -1; i < 2; i += 2) {
				GameObject missile = Instantiate (missilePrefab, transform.position, Quaternion.identity) as GameObject;
				missile.transform.SetParent (transform);
				missile.transform.localScale = new Vector3 (5, 5, 40);
				missile.transform.localPosition = new Vector3 (15 * i, 0, 24.5f);
				missile.transform.SetParent (transform.parent.transform);
			}
			passed = 0;
		}
	}
}
