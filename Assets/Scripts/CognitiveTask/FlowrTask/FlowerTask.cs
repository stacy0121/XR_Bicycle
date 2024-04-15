using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class FlowerTask : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer success;
    [SerializeField]
    private MeshRenderer failure;

    [SerializeField]
    private UnityEvent _whenTaskEnd;

    [SerializeField]
    UnityEvent onSuc; // 성공

    [SerializeField]
    UnityEvent onFai; // 실패
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flower")   // 꽃을 넣었을 때
        {
            success.enabled = true;   // 성공 문구 활성화
            _whenTaskEnd.Invoke();
            onSuc?.Invoke();
        }

        if (other.tag != "flower")   // 꽃을 넣었을 때
        {
            failure.enabled = true;   // 실패 문구 활성화
            _whenTaskEnd.Invoke();
            onFai?.Invoke();
            Debug.Log(other.tag);
        }
        StartCoroutine(DisableTextAfterDelay(3f));
    }
    private IEnumerator DisableTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        success.enabled = false;
        failure.enabled = false;
    }

    public void equal()
    {
        onSuc?.Invoke();
    }
}
