using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovable : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private Rigidbody _rb = null;
    public Rigidbody RigidBody {
        get { return _rb ?? (_rb = GetComponent<Rigidbody>()); }
    }

    private Quaternion cameraRotation;

    private void SetVelocity(float dir)
    {
        RigidBody.velocity = new Vector3(
            Mathf.Cos(dir),
            0,
            Mathf.Sin(dir)
        ) * _speed;
    }
    private void SetVelocityZero()
    {
        RigidBody.velocity = Vector3.zero;
    }
    public void SetRotation(float dir)
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(Mathf.Cos(dir), 0, Mathf.Sin(dir)));
    }

    // TODO: カメラ、InputManagerを直したあとに変更する必要がある
    // cameraが回転しているため今の状態だと見た目通りに動かない
    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        if (x == 0 && z == 0) {
            SetVelocityZero();
            return;
        }
        
        float dir = Mathf.Atan2(z, x);
        SetVelocity(dir);
        SetRotation(dir);
    }
}
