using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameData;
using cakeslice;

public class MouseControl : MonoBehaviour {

	private Plane yPosPlane;
	private Rigidbody2D rb;
	private enum actions {idle, dragging, multiSelect};
	private actions curAction;
	private Outline outline;
	private MouseControl[] selectedObjects;

	void Start () {
		curAction = actions.idle;
		rb = GetComponent<Rigidbody2D>();
		yPosPlane = new Plane(Vector3.forward, Vector3.forward * Constants.SIDEWALK_Y_POS);
		outline = GetComponent<Outline>();
		selectedObjects = new MouseControl[2];
	}

	void OnMouseOver() {
		outline.enabled = true;
	}

	void OnMouseExit() {
		outline.enabled = false;
	}

	void OnMouseDown() {
		setAction();
		stopRigidbody();
	}

	void OnMouseUp() {
		switch (curAction)
		{
			case actions.dragging: 
				curAction = actions.idle;
				startRigidBody();
				break;
		}
	}

	void Update() {
		switch (curAction)
		{
			case actions.dragging: 
				positionAtMouse();
				break;
			case actions.multiSelect:
				
				break;
		}
	}

	void setAction() {
		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) curAction = actions.multiSelect;
		else curAction = actions.dragging;
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

	void positionAtMouse() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance;
		if(yPosPlane.Raycast(ray, out distance)) {
			transform.position = ray.GetPoint(distance);
		}
	}
}
