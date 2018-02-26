using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class VrAutowalk : MonoBehaviour {
	public float speed = 3.0f;
	public bool moveForward;
	public CharacterController controller;
	private GvrViewer gvrViewer ;
	private Transform vrHead;
	private Vector3 spawnPoint;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		gvrViewer = transform.GetChild (0).GetComponent<GvrViewer> ();
			vrHead = Camera.main.transform;
		spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10.0f) {
			transform.position = spawnPoint;
			moveForward = false;
		}

		if (Input.GetButtonDown ("Fire1"))
			moveForward = !moveForward;
		
		if (moveForward) {
			Vector3 forward = vrHead.TransformDirection (Vector3.forward);
			controller.SimpleMove (forward * speed);
		}
	}
}
