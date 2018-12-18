using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameData;

public class DragInteractive : MonoBehaviour {

	private bool active;
	private Plane yPosPlane;
	private Rigidbody2D rb;
		
	public MonoBehaviour activate() {
		active = true;
		stopRigidbody();
		createYPosPlane();
		return this;
	}	

	public void deactivate() {
		active = false;
		startRigidBody();
	}

	void Start () {
		active = false;
		rb = GetComponent<Rigidbody2D>();
	}

	void OnMouseDrag() {
		if(active) dragObject();
	}

	void stopRigidbody() {
		rb.simulated= true;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
		rb.simulated = false;
	}

	void startRigidBody() {
		rb.simulated = true;
	}

	void createYPosPlane() {
		yPosPlane = new Plane(Vector3.forward, Vector3.forward * Constants.SIDEWALK_Y_POS);
	}

	void dragObject() {
		// place object on new drag position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance;
		if(yPosPlane.Raycast(ray, out distance)) {
			transform.position = ray.GetPoint(distance);
		}
	}
}