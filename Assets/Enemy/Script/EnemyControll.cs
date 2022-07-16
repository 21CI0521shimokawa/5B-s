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

    //��ɕʃX�N���v�g�Ɉڍs�\��
    private float rayDistance;
    private GameObject NearObject;
    [SerializeField] Transform[] MoveTransform;
    void Start()
    {
        rayDistance = 1.0f;
    }
    private void FixedUpdate() //��ɕʃX�N���v�g�Ɉڍs�\��
    {
        var Directoin = transform.forward;
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        RaycastHit hit;
        Debug.DrawRay(rayPosition, Directoin * rayDistance * 6, Color.red * 6);
        if (Physics.Raycast(gameObject.transform.position, Directoin, out hit, 6.0f))
        {
            EnemyStatus._EnemyState = EnemyStatus.EnemyState.MOVE;
        }
        else
        {
            NearObject = MovingPositionSearch(this.gameObject, "MOVEPOSITON");
            EnemyStatus._EnemyState = EnemyStatus.EnemyState.IDOL;
            this.transform.DOMove(NearObject.transform.position, 3f)
                .OnUpdate(() =>
                {
                    this.transform.rotation = NearObject.transform.rotation;
                    EnemyStatus._EnemyState = EnemyStatus.EnemyState.MOVE;
                });
        }
    }
    void Update()
    {
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
    GameObject MovingPositionSearch(GameObject NowObj, string TagName)
    {
        float RangeWithObject = 0;
        float NearDistance = 0;

        GameObject targetObject = null;

        foreach (GameObject @object in GameObject.FindGameObjectsWithTag(TagName))
        {
            RangeWithObject = Vector3.Distance(@object.transform.position, NowObj.transform.position);
            if (NearDistance == 0 || NearDistance > RangeWithObject)
            {
                NearDistance = RangeWithObject;
                targetObject = @object;
            }
        }
        //�ł��߂������I�u�W�F�N�g��Ԃ�
        Debug.Log(targetObject);
        return targetObject;
    }
}
