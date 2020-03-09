using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPoint : MonoBehaviour {

    private GameObject mainCamera;

	// Use this for initialization
	void Start () {
        this.mainCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        if(this.transform.position.z < this.mainCamera.transform.position.z) {
            Destroy(this.gameObject);
        }
	}
}
