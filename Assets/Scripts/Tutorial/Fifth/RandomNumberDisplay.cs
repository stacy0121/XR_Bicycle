using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class RandomNumberDisplay : MonoBehaviour
{
    public TMP_Text[] numberTexts; // TMPro(TextMeshPro) ��ҵ��� �迭�� ����

    public List<int> numbers = new List<int>(); // ������ ���ڵ��� ������ ����Ʈ
    [SerializeField]
    UnityEvent fin_display; //���� ���� ������ ����
    public void call()
    {
        GenerateNumbers();
        DisplayNumbers();
        Debug.Log(1);

    }

    private void GenerateNumbers()
    {
        // 1���� 10������ ���ڸ� ����Ʈ�� �߰�
        for (int i = 1; i <= 10; i++)
        {
            numbers.Add(i);
        }

        Shuffle(numbers); // ����Ʈ�� ���ڵ��� �����ϰ� ����

        // ����Ʈ���� ó�� 3���� ���ڸ� ����� �������� ����
        numbers.RemoveRange(3, numbers.Count - 3);
    }

    private void DisplayNumbers()
    {
        // TMPro(TextMeshPro) ��ҵ鿡 ���ڸ� ǥ��
        for (int i = 0; i < numberTexts.Length; i++)
        {
            if (i < numbers.Count)
            {
                numberTexts[i].text = numbers[i].ToString();
            }
            else
            {
                numberTexts[i].text = "";
            }
        }
        fin_display?.Invoke();
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void SortNumbers()
    {
        numbers.Sort();
    }
}
