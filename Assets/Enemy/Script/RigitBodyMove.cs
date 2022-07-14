using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public static class RigitBodyMove
{
    /// <summary>
    ///�O���ɃI�u�W�F�N�g��i�߂�
    /// </summary>
    /// <param name="RigidBody"></param>
    /// <param name="SubjectTransFrom"></param>
    /// <param name="MoveSpeed_"></param>
    public static void AdvanceMove(this Rigidbody RigidBody,Transform SubjectTransFrom,float MoveSpeed_)
    {
        RigidBody.velocity = new Vector3(-MoveSpeed_, 0, 0);
    }
    /// <summary>
    /// ����ɃI�u�W�F�N�g��i�߂�
    /// </summary>
    /// <param name="RigidBody"></param>
    /// <param name="SubjectTransFrom"></param>
    /// <param name="MoveSpeed_"></param>
    public static void RecessionMove(this Rigidbody RigidBody, Transform SubjectTransFrom, float MoveSpeed_)
    {
        RigidBody.velocity=new Vector3(MoveSpeed_, 0, 0);
    }

}
