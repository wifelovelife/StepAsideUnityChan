using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    public GameObject carPrefab; // FreeCarPrefabオブジェクトを読み込む変数carprefabを公開
    public GameObject coinPrefab; // coinPrefabオブジェクトを読み込む変数coinPrefabを公開
    public GameObject conePrefab; // TrafficConePrefabオブジェクトを読み込む変数conePrefabを公開
    private int startPos = -160; //スタート地点を設定
    private int goalPos = 120; // ゴール地点を設定
    private float posRange = 3.4f; // アイテムを生成させるx軸の範囲

    // Use this for initialization
    void Start() {
        for (int i = startPos; i < goalPos; i += 15) { // 一定距離ごとにアイテムを生成
            int num = Random.Range(1, 11); // アイテム発生率の乱数
            if (num <= 2) { // アイテム発生率を設定（20％以下）
                for (float j = -1; j <= 1; j += 0.4f) {
                    GameObject cone = Instantiate(conePrefab) as GameObject; // conePrefabをゲームオブジェクト型として生成
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i); // coneをx軸に一直線に生成
                }
            } else {
                for (int j = -1; j <= 1; j++) {
                    int item = Random.Range(1, 11); // アイテム発生率の乱数
                    int offsetZ = Random.Range(-5, 6); // アイテムを置くz座標のオフセットをランダムに設定
                    if (1 <= item && item <= 6) { // 60%配置
                        GameObject coin = Instantiate(coinPrefab) as GameObject; // coinPrefabをゲームオブジェクト型として生成
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ); // coinPrefabをランダムに生成
                        //Debug.Log(coin.transform.position.z);
                    } else if (7 <= item && item <= 9) { // 30%配置
                        GameObject car = Instantiate(carPrefab) as GameObject; // carPrefabをゲームオブジェクト型として生成
                    }
                }
            }
        }
    }

    //  Update is called once per frame
    void Update() {

    }
}