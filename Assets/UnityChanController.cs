using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {
   
    private Animator myAnimator; // アニメーションするためのAnimatorコンポーネントを取得する変数myAnimatorを宣言
    private Rigidbody myRigidbody; // UnityChanを移動させるRigidbodyコンポーネントを取得する変数myRigidbodyを宣言
    private float forwardForce = 800.0f; // 前進するための力
    private float turnForce = 500.0f; // 左右に移動するための力
    private float upForce = 500.0f; // ジャンプするための力
    private float movableRange = 3.4f; // 左右に移動できる範囲
    private float coefficient = 0.95f; // 動きを減速させる係数
    private bool isEnd = false; // ゲーム終了の判定（falseで無効設定）
    private GameObject stateText; // ゲーム終了時に表示テキストを取得する変数stateTextを宣言
    private GameObject scoreText; // スコアの表示テキストを取得する変数scoretextを宣言
    private int score = 0; // スコア計算用の変数scoreを宣言
    private bool isLButtonDown = false; // 左ボタン押下の判定（falseで無効設定）
    private bool isRButtonDown = false; // 右ボタン押下の判定（falseで無効設定）

    // Use this for initialization
    void Start () {
        this.myAnimator = GetComponent<Animator>(); // Animatorコンポーネントを取得
        this.myAnimator.SetFloat("Speed", 1.0f); // 走るアニメーションを開始
        this.myRigidbody = GetComponent<Rigidbody>(); // RigidBodyコンポーネントを取得
        this.stateText = GameObject.Find("GameResultText"); // GameResultTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText"); // Scoretextオブジェクトを取得
    }

    // Update is called once per frame
    void Update() {
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce); // UnityChanに前方向の力を加える
        if ((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x) { // UnityChanを矢印キーの方向に移動させる
            this.myRigidbody.AddForce(-this.turnForce, 0, 0); // 左移動
        } else if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange) {
            this.myRigidbody.AddForce(this.turnForce, 0, 0); // 右移動
        }

        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump")) {
            this.myAnimator.SetBool("Jump", false); // Jumpステートの場合はJumpにfalseをセットする
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f){ // ジャンプしていない時にスペースが押されたらジャンプする
            this.myAnimator.SetBool("Jump", true); // ジャンプアニメを再生
            this.myRigidbody.AddForce(this.transform.up * this.upForce); // UnityChanに上方向の力を加える
        }

        if (this.isEnd) { // もしゲーム終了なら減衰係数を乗算
            this.forwardForce *= this.coefficient; // 前進
            this.turnForce *= this.coefficient; // 左右移動
            this.upForce *= this.coefficient; // ジャンプ
            this.myAnimator.speed *= this.coefficient; // Animatorコンポーネントのspeed
        }
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag") { // 障害物に衝突した場合
            this.isEnd = true; // 変数isEndにtrueを渡す
            this.stateText.GetComponent<Text>().text = "GAME OVER"; // stateTextにGAME OVERを表示
        }

        if(other.gameObject.tag == "GoalTag") { // ゴール地点に到着した場合
            this.isEnd = true; // 変数isEndにtrueを渡す
            this.stateText.GetComponent<Text>().text = "CLEAR!!"; // statetextにCLEAR!!を表示
        }

        if(other.gameObject.tag == "CoinTag") { // コインに衝突した場合
            this.score += 10; // スコアを加算
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt"; // スコアを表示
            GetComponent<ParticleSystem>().Play(); // パーティクルを再生
            Destroy(other.gameObject); // コインを破棄
        }
    }

    //ジャンプボタンを押した場合の処理
    public void GetMyJumpButtonDown() {
        if(this.transform.position.y < 0.5f) {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }

    //左ボタンを押し続けた場合の処理
    public void GetMyLeftButtonDown() {
        this.isLButtonDown = true;
    }

    //左ボタンを離した場合の処理
    public void GetMyLeftButtonUp() {
        this.isLButtonDown = false;
    }
    

    //右ボタンを押し続けた場合の処理
    public void GetMyRightButtonDown() {
        this.isRButtonDown = true;
    }

    //右ボタンを離した場合の処理
    public void GetMyRightButtonUp() {
        this.isRButtonDown = false;
    }
}
