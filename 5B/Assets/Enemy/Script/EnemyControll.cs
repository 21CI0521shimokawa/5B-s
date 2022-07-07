using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;


public class EnemyControll : MonoBehaviour
{
    private enum EnemyState
    {
        IDOL,
        MOVE,
        ATTACK,
    }
    EnemyState NowState;
    private int EnemyHP_;
    public int EnemyHP
    {
        get { return EnemyHP_; }
        set { EnemyHP_ = value; }
    }

    [SerializeField] float MoveSpeed;
    [SerializeField] Rigidbody EnemyRigidBody;
    void Start()
    {
        NowState = EnemyState.MOVE;
    }
    void Update()
    {
        switch (NowState)
        {
            case EnemyState.IDOL:
                break;
            case EnemyState.MOVE:
                Move();
                break;
            case EnemyState.ATTACK:
                StrengthDesignation();
                break;
            default:
                break;
        }
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            EnemyRigidBody.AdvanceMove(this.transform, MoveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            EnemyRigidBody.RecessionMove(this.transform, MoveSpeed);
        }
        else
        {
            EnemyRigidBody.AdvanceMove(this.transform, 0.0f);
        }
    }
    void StrengthDesignation()
    {
        var SpaceDownStream = this.UpdateAsObservable().Where(_ => Input.GetKeyDown(KeyCode.Space));
        var SpaceUpStream = this.UpdateAsObservable().Where(_ => Input.GetKeyUp(KeyCode.Space));

        SpaceDownStream
            .SelectMany(_ => Observable.Interval(System.TimeSpan.FromSeconds(1f)))
            .TakeUntil(SpaceUpStream)
            .DoOnCompleted(() =>
            {
                Debug.Log("ƒpƒ[ƒ{ƒ€");
            })
            .RepeatUntilDestroy(this)
            .Subscribe(_ =>
            {
                Debug.Log("ŽžŠÔ‚ª‘«‚è‚Ü‚¹‚ñ");
            });
    }
}
