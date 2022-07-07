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
    [SerializeField] Transform CameraTransForm;//�J�����̈ʒu
    [SerializeField] GameObject CameraTarGet; //�ΏۂƂ���^�[�Q�b�g�ݒ�
    [SerializeField] GameObject[] NextPositions;//���̈ړ��ʒu�w��
    [SerializeField] PathType PathType;//DoPath���������ꂽ�Ƃ��̎g�������w��
    [SerializeField] Ease EaseType;//�C�[�W���O�̃^�C�v�ݒ�
    [SerializeField] float MoveTime;//�ړ����Ԑݒ�

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
            {//���s�J�n���̃R�[���o�b�N
                #region ����
                LookTarget(CameraTarGet);
                #endregion
            })
            .OnComplete(() =>
            {//���s�������̃R�[���o�b�N
                #region ������
                GameStateText.text = "SideGame";
                #endregion
            })
            .SetOptions(false)//true�ɂ����path[0]�ɖ߂�
            .SetEase(EaseType);//�C�[�W���O�^�C�v�w��
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
