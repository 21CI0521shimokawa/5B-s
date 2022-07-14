using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class EnemyAttack : MonoBehaviour
{
   public void StrengthDesignation()
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
