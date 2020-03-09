using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAreaController : MonoBehaviour {

    private GameObject mainCamera; // Main Cameraの取得用変数

	// Use this for initialization
	void Start () {
		this.mainCamera = GameObject.Find("Main Camera"); // Main Cameraを検索
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(0, this.transform.position.y, this.mainCamera.transform.position.z); // Main Cameraのz方向を、DestroyAreaのz方向に代入
	}

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag") {
            Destroy(other.gameObject);
        }
    }
}
