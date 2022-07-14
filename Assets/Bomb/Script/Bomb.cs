using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    
    //ステージのレイヤー
    public LayerMask levelMask;

    //すでに爆発している場合連鎖しない
    private bool exploded = false;

    public void Start() {
        //爆発
        Invoke("Explode", 2f);

    }


    //爆発の関数
    private void Explode() {
        //爆弾の位置に爆発エフェクトを作成
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        //爆弾を非表示にする
        GetComponent<MeshRenderer>().enabled = false;

        //爆発した
        exploded = true;

        StartCoroutine(CreateExplosions(Vector3.forward));//爆風を上に広げる
        StartCoroutine(CreateExplosions(Vector3.back));//下に広げる
        StartCoroutine(CreateExplosions(Vector3.right));//右に広げる
        StartCoroutine(CreateExplosions(Vector3.left));//左に広げる

        transform.Find("Collider").gameObject.SetActive(false);

        //0.3秒後に非表示にした爆弾を削除
        Destroy(gameObject, 0.3f);
    }

    //爆風を広げる
    private IEnumerator CreateExplosions(Vector3 direction) {
        //2マス分ループする
        for(int i = 1; i < 3; i++) {
            //ブロックとの当たり判定の結果を格納する変数
            RaycastHit Hit;

            //爆風の広げた先に何か存在するのか確認
            Physics.Raycast
            (
                transform.position + new Vector3(0, 0.5f, 0),
                direction,
                out Hit,
                i,
                levelMask
            );

            //爆風を広げた先に何も存在しない場合
            if (!Hit.collider) {
                //爆風を広げるために、爆発エフェクトのオブジェクトを作成
                Instantiate
                    (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                    );
            }
            //爆風を広げた先にブロックが存在する場合
            else {
                //爆風をこれ以上広げない
                break;
            }

            //0.05秒待ってから、次のマスに爆風を広げる
            yield return new WaitForSeconds(0.05f);
        }
    }

    //連鎖
    //ほかのオブジェクトがこの爆弾に当たったら呼び出される
    public void OnTriggerEnter(Collider other) {
        //まだ爆発していない、かつ、この爆弾にぶつかったオブジェクトが爆発エフェクトの場合
        if (!exploded && other.CompareTag("Explosion")) {
            //2重に爆発処理が実行されないように、すでに爆発処理が実行されていない場合は止める
            CancelInvoke("Explode");

            //爆発する
            Explode();
        }
    }
}
