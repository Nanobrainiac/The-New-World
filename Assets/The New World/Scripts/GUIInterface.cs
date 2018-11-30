using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIInterface : MonoBehaviour {

	public ObjectInstantiator InstantiateScriptObject;

	public void InstantiateWorldObject(string prefabName) {
		InstantiateScriptObject.InstantiateInteractive(prefabName);
	}
}
