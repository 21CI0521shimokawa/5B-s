using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    
    //�X�e�[�W�̃��C���[
    public LayerMask levelMask;

    //���łɔ������Ă���ꍇ�A�����Ȃ�
    private bool exploded = false;

    public void Start() {
        //����
        Invoke("Explode", 2f);

    }


    //�����̊֐�
    private void Explode() {
        //���e�̈ʒu�ɔ����G�t�F�N�g���쐬
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        //���e���\���ɂ���
        GetComponent<MeshRenderer>().enabled = false;

        //��������
        exploded = true;

        StartCoroutine(CreateExplosions(Vector3.forward));//��������ɍL����
        StartCoroutine(CreateExplosions(Vector3.back));//���ɍL����
        StartCoroutine(CreateExplosions(Vector3.right));//�E�ɍL����
        StartCoroutine(CreateExplosions(Vector3.left));//���ɍL����

        transform.Find("Collider").gameObject.SetActive(false);

        //0.3�b��ɔ�\���ɂ������e���폜
        Destroy(gameObject, 0.3f);
    }

    //�������L����
    private IEnumerator CreateExplosions(Vector3 direction) {
        //2�}�X�����[�v����
        for(int i = 1; i < 3; i++) {
            //�u���b�N�Ƃ̓����蔻��̌��ʂ��i�[����ϐ�
            RaycastHit Hit;

            //�����̍L������ɉ������݂���̂��m�F
            Physics.Raycast
            (
                transform.position + new Vector3(0, 0.5f, 0),
                direction,
                out Hit,
                i,
                levelMask
            );

            //�������L������ɉ������݂��Ȃ��ꍇ
            if (!Hit.collider) {
                //�������L���邽�߂ɁA�����G�t�F�N�g�̃I�u�W�F�N�g���쐬
                Instantiate
                    (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                    );
            }
            //�������L������Ƀu���b�N�����݂���ꍇ
            else {
                //����������ȏ�L���Ȃ�
                break;
            }

            //0.05�b�҂��Ă���A���̃}�X�ɔ������L����
            yield return new WaitForSeconds(0.05f);
        }
    }

    //�A��
    //�ق��̃I�u�W�F�N�g�����̔��e�ɓ���������Ăяo�����
    public void OnTriggerEnter(Collider other) {
        //�܂��������Ă��Ȃ��A���A���̔��e�ɂԂ������I�u�W�F�N�g�������G�t�F�N�g�̏ꍇ
        if (!exploded && other.CompareTag("Explosion")) {
            //2�d�ɔ������������s����Ȃ��悤�ɁA���łɔ������������s����Ă��Ȃ��ꍇ�͎~�߂�
            CancelInvoke("Explode");

            //��������
            Explode();
        }
    }
}
