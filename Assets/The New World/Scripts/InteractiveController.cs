using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveController : MonoBehaviour {

	public static GameObject[] selectedObjects;
	public MonoBehaviour activeScript;
	private DragInteractive dragScript;
	private MultiSelectInteractive multiSelectScript;

	// Use this for initialization
	void Start () {
		dragScript = GetComponent<DragInteractive>();
	}
	
	void OnMouseDown() {
		if(Input.GetKey("shift") && !activeScript) activeScript = multiSelectScript.activate(selectedObjects);
		else if(!activeScript) activeScript = dragScript.activate();
	}
}
