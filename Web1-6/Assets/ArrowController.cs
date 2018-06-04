using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    GameObject player;

	void Start () {
        this.player = GameObject.Find("player");
	}
	
	void Update () {
        transform.Translate(0, -0.1f, 0);
        if (transform.position.y < -5.0f){
            Destroy(gameObject);
        }

        //当たり判定（追加）
        Vector2 p1 = transform.position;                //　矢の中心座標
        Vector2 p2 = this.player.transform.position;    //　プレイヤの中心座標
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;　//　矢の半径
        float r2 = 1.0f;　//　プレイヤの半径

        if(d < r1 + r2){
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            //衝突した場合は矢を消す
            Destroy(gameObject);

        }


    }
}
