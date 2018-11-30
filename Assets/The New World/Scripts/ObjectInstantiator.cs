using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiator : MonoBehaviour {
	public string InteractivesPath;
	public Vector3 InstantiateAt;
	public Object[] interactives;

	void Start () {
		interactives = Resources.LoadAll(InteractivesPath);;
	}
	
	void Update () {
		
	}

	public void InstantiateInteractive(string prefabName) {
		foreach (GameObject prefab in interactives) {
			if(prefab.name == prefabName) {
				Instantiate(prefab, InstantiateAt, Quaternion.identity);
			}
		}
	}
}
