using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float speed;
	private float travelled;
	public float toTravel;
	public int maxEnemies;
	private Vector3 distancePerFrame;

	public GameObject[] ships;

	// Update is called once per frame
	void Update () {
		if (!Player.isDead) {
			distancePerFrame = Vector3.forward * speed * Time.deltaTime;
			transform.position += distancePerFrame;
			travelled += distancePerFrame.z;
			if (travelled >= toTravel) {
				if (GameObject.FindGameObjectsWithTag ("Enemy").Length < maxEnemies) {
					SpawnEnemy ();
					travelled = 0;
				}
			}
			UIManager.score += 10;
		}
	}

	void SpawnEnemy() {
		int randShip = Random.Range (0, ships.Length);
		GameObject ship = Instantiate (ships [randShip], Vector3.zero, Quaternion.identity) as GameObject;
		ship.transform.SetParent(transform);
		ship.transform.localPosition = new Vector3 (0, 10, 20);
	}
}
