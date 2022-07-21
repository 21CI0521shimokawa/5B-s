using UnityEngine;


public class Player : MonoBehaviour
{
    public static Player instance;

    private PlayerStatus _status;
    private PlayerMovable _move;

    // TODO: anim用のスクリプトを作るかここにそのまま書くか

    private void Awake()
    {   
        if (instance == null) {
            instance = this;
        }

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
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blast")) {
            ReceiveDamage();
        }
    }

    private void ReceiveDamage()
    {
        _status.ToDamaged();
        Debug.Log("<color=red>プレイヤーダメージ</color>");
    }
}