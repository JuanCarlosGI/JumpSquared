using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour {
    private Transform _destructionPoint;

	// Use this for initialization
	void Start () {
        _destructionPoint = GameObject.Find("DestructionPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < _destructionPoint.position.x)
        {
            Destroy(gameObject);
        }
	}
}
