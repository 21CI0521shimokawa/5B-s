using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;

public class SampleScript : MonoBehaviour
{
    #region SerializeField
    [SerializeField] Transform CameraTransForm;//カメラの位置
    [SerializeField] GameObject CameraTarGet; //対象とするターゲット設定
    [SerializeField] GameObject[] NextPositions;//次の移動位置指定
    [SerializeField] PathType PathType;//DoPathが生成されたときの使いかた指定
    [SerializeField] Ease EaseType;//イージングのタイプ設定
    [SerializeField] float MoveTime;//移動時間設定

    [SerializeField] TextMeshProUGUI GameStateText;
    #endregion

    private void Awake()
    {
        GameStateText.text = "MainGame";
    }
    void Start()
    {
        Vector3[] path = NextPositions.Select(x => x.transform.position).ToArray();
        transform.position = path[0];
        this.transform.DOPath(path, MoveTime).SetDelay(3f)
            .OnStart(() =>
            {//実行開始時のコールバック
                #region 処理
                LookTarget(CameraTarGet);
                #endregion
            })
            .OnComplete(() =>
            {//実行完了時のコールバック
                #region 未処理
                GameStateText.text = "SideGame";
                #endregion
            })
            .SetOptions(false)//trueにするとpath[0]に戻る
            .SetEase(EaseType);//イージングタイプ指定
    }
    private void LookTarget(GameObject Target)
    {
        this.UpdateAsObservable()
       .Subscribe(_ =>
       {
           CameraTransForm.LookAt(Target.transform.position);
       });
    }
}
