using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PSG;

public class Apple : MonoBehaviour {

	public Material material;
	private CircleMesh script;

	// Use this for initialization
	void Start () {
		script = this.gameObject.AddComponent<CircleMesh>();
		script.Build(1, 30, true, material);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}