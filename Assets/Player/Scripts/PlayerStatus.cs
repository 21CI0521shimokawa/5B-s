using UnityEngine;


public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int _life = 3;
    public int Life {
        get { return _life; }
    }

    public enum PlayerState {
        IDLE,
        Move,
        Damaged,
        Death,
    }
    private PlayerState _state = PlayerState.IDLE;
    public PlayerState State {
        get { return _state; }
    }

    public void ToDamaged()
    {
        _life--;
        _state = PlayerState.Damaged;
    }
}
