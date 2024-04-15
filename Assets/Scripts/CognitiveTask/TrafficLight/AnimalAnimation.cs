using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    public GameObject objectPrefab;  // ������
    public AnimationClip animationClip;  // �ִϸ��̼� Ŭ��

    private void Awake()
    {
        // �������� �ν��Ͻ�ȭ�Ͽ� ���� ������Ʈ ����
        GameObject spawnedObject = Instantiate(objectPrefab);

        // �ִϸ��̼� ������Ʈ ��������
        Animation animation = spawnedObject.GetComponent<Animation>();

        // �ִϸ��̼� Ŭ�� �߰� �� ���
        animation.AddClip(animationClip, "MyAnimation");  // �ִϸ��̼� Ŭ�� �߰�
        animation.Play("MyAnimation");  // �ִϸ��̼� ���
    }
}
