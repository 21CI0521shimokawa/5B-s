using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] float EnemyMoveSpeed = 2.0f;
    private Rigidbody EnemyRigidBody;
    public Rigidbody _EnemyRigidBody
    {
        get { return EnemyRigidBody ?? (EnemyRigidBody = GetComponent<Rigidbody>()); }
    }
    /// <summary>
    /// Enemy移動関数
    /// </summary>
    /// <param name="gameObject"></param>
    public void _Move(GameObject gameObject)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            AdvanceMove(gameObject.transform, EnemyMoveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RecessionMove(this.transform, EnemyMoveSpeed);
        }
        else
        {
            AdvanceMove(gameObject.transform, 0.0f);
        }
    }

    /// <summary>
    ///前方にオブジェクトを進める
    /// </summary>
    /// <param name="SubjectTransFrom"></param>
    /// <param name="MoveSpeed_"></param>
    public void AdvanceMove(Transform SubjectTransFrom, float MoveSpeed_)
    {
        transform.Translate(-MoveSpeed_*Time.deltaTime, 0, 0);
    }
    /// <summary>
    /// 後方にオブジェクトを進める
    /// </summary>
    /// <param name="SubjectTransFrom"></param>
    /// <param name="MoveSpeed_"></param>
    public void RecessionMove(Transform SubjectTransFrom, float MoveSpeed_)
    {
        transform.Translate(MoveSpeed_*Time.deltaTime, 0, 0);
    }
}
