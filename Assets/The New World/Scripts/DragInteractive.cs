using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameData;

public class DragInteractive : MonoBehaviour {

	static private DragInteractive selectedObject;
	private Plane yPosePlane;
	private Rigidbody2D rb;
		
	// Use this for initialization
	void Start () {
		selectedObject = null;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		if(!selectedObject) {
			selectedObject = this;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = 0f;
			rb.simulated = false;
			yPosePlane = new Plane(Vector3.forward, Vector3.forward * Constants.SIDEWALK_Y_POS);
		}
	}

	void OnMouseDrag() {
		// place object on new drag position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance;
		if(yPosePlane.Raycast(ray, out distance)) {
			transform.position = ray.GetPoint(distance);
		}
	}

	void OnMouseUp() {
		selectedObject = null;
		rb.simulated= true;
	}
}