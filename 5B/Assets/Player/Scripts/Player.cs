using UnityEngine;


public class Player : MonoBehaviour
{
    private PlayerStatus _status;
    private PlayerMovable _move;

    // TODO: anim用のスクリプトを作るかここにそのまま書くか

    private void Awake()
    {   
        TryGetComponent(out _status);
        TryGetComponent(out _move);
    }

    private void Update()
    {
        switch(_status.State) {
            case PlayerStatus.PlayerState.IDLE:
                _move.Move();
                break;
            case PlayerStatus.PlayerState.Move:
                _move.Move();
                break;
            case PlayerStatus.PlayerState.Damaged:
                // コルーチンとかで無敵を作るかどうか
                break;
            case PlayerStatus.PlayerState.Death:
                // 
                break;
        }
    }

    // TODO: ボムとの当たり判定
    private void OnTriggerEnter(Collider other)
    {
        // ボム（タグ？）
        // if (other.CompareTag("????")) {
        //     ReceiveDamage();
        // }
    }

    private void ReceiveDamage()
    {
        // _status.ToDamaged();
    }
}