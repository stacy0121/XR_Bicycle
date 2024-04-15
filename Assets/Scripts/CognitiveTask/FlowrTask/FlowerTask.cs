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
    UnityEvent onSuc; // ����

    [SerializeField]
    UnityEvent onFai; // ����
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flower")   // ���� �־��� ��
        {
            success.enabled = true;   // ���� ���� Ȱ��ȭ
            _whenTaskEnd.Invoke();
            onSuc?.Invoke();
        }

        if (other.tag != "flower")   // ���� �־��� ��
        {
            failure.enabled = true;   // ���� ���� Ȱ��ȭ
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
