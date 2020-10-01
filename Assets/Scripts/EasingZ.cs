using UnityEngine;
using System.Collections;

public class EasingZ : Enemy {

	public float marginX;
	public float marginZ;
	public float count;

	protected override void Move() {
		float xPos = Mathf.Sin (spawned * speed) * marginX;
		float zPos = Mathf.Sin (spawned * speed / count) * marginZ;
		transform.localPosition = new Vector3 (xPos, transform.localPosition.y, zPos + 20);
		spawned += Time.deltaTime;
	}
}
