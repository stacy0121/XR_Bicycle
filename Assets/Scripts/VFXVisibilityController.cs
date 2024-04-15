using UnityEngine;
using UnityEngine.VFX;

public class VFXVisibilityController : MonoBehaviour
{
    public VisualEffect visualEffect;
    public Camera mainCamera;
    public float distanceThreshold = 10f;

    private void Update()
    {
        // ����Ʈ�� ī�޶� ������ �Ÿ� ���
        float distance = Vector3.Distance(transform.position, mainCamera.transform.position);

        // �Ÿ��� �Ӱ谪���� ũ�� ����Ʈ�� ��Ȱ��ȭ
        if (distance > distanceThreshold)
        {
            visualEffect.enabled = false;
        }
        else
        {
            visualEffect.enabled = true;
        }
    }
}