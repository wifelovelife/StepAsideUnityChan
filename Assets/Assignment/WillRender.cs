using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillRender : MonoBehaviour {
    // オブジェクトを削除
    void Destroy() {
        GameObject.Destroy(this.gameObject);
    }

    // カメラを指定（指定カメラで映っているシーンからオブジェクトが削除される）
    void OnWillRenderObject() {
        if(Camera.current.name == "Main Camera") {
            Destroy();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
