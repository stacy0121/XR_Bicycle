using UnityEngine;
using UnityEngine.VFX;

public class VFXVisibilityController : MonoBehaviour
{
    public VisualEffect visualEffect;
    public Camera mainCamera;
    public float distanceThreshold = 10f;

    private void Update()
    {
        // 이펙트와 카메라 사이의 거리 계산
        float distance = Vector3.Distance(transform.position, mainCamera.transform.position);

        // 거리가 임계값보다 크면 이펙트를 비활성화
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