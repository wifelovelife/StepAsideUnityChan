using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {
    private GameObject unitychan; // UnityChanオブジェクトを取得するための変数unitychan
    private float difference; // UnityChanとMainCameraの距離を扱うための変数difference

	// Use this for initialization
	void Start () {
        this.unitychan = GameObject.Find("unitychan"); // UnityChanオブジェクトを取得
        this.difference = unitychan.transform.position.z - this.transform.position.z; // UnityChanとMainCameraの位置（z座標）の差を求める
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference); // UnityChanの位置に合わせてMainCameraの位置を移動
	}
}
