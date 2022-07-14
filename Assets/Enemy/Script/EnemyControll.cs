using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;


public class EnemyControll : MonoBehaviour
{
    [SerializeField] EnemyStatus EnemyStatus;
    [SerializeField] EnemyMove EnemyMove;
    [SerializeField] EnemyAttack EnemyAttack;
    [SerializeField] GameObject LookEye;
    [SerializeField] float MoveSpeed;
    [SerializeField] Rigidbody EnemyRigidBody;
    void Start()
    {
    }
    private void FixedUpdate()
    {
        var Directoin = transform.forward;
        RaycastHit hit;
        Debug.DrawRay(gameObject.transform.position,Directoin* 6, Color.blue, 0.1f);
        if (Physics.Raycast(gameObject.transform.position, Directoin, out hit, 6.0f))
        {
            EnemyStatus._EnemyState = EnemyStatus.EnemyState.MOVE;
        }
        else
        {
            EnemyStatus._EnemyState = EnemyStatus.EnemyState.IDOL;
            this.transform.LookAt(LookEye.transform);
            /* this.transform.DORotate(Vector3.up * 90f, 1f).OnComplete(() =>
             {//実行完了時のコールバック
             });*/
        }
    }
    void Update()
    {
        Debug.Log(EnemyStatus._EnemyState);
        switch (EnemyStatus._EnemyState)
        {
            case EnemyStatus.EnemyState.IDOL:
                break;
            case EnemyStatus.EnemyState.MOVE:
                EnemyMove._Move(gameObject);
                break;
            case EnemyStatus.EnemyState.ATTACK:
                EnemyAttack.StrengthDesignation();
                break;
            default:
                break;
        }
    }
    void LookStage()
    {
        this.transform.LookAt(LookEye.transform);
    }
}
