using UnityEngine;
using System.Collections;

public class InfiniteWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			if (child.name == "Floor") {
				
			} else if (child.name == "Wall") {
				
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (tag == "World1") {
				transform.position = new Vector3 (0, -5, GameObject.FindGameObjectWithTag ("World2").transform.position.z + transform.localScale.z); 
			} else {
				transform.position = new Vector3 (0, -5, GameObject.FindGameObjectWithTag ("World1").transform.position.z + transform.localScale.z); 
			}
		}
	}
}
