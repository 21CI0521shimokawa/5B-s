using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] int _Life = 3; //‰¼
    public int Life
    {
        get { return _Life; }
    }
    public enum EnemyState
    {
        IDOL,
        MOVE,
        ATTACK,
    }
    private EnemyState _enemyState = EnemyState.IDOL;
    public EnemyState _EnemyState
    {
        get { return _enemyState; }
        set { _enemyState = value;}
    }
}
