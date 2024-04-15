using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class RandomNumberDisplay : MonoBehaviour
{
    public TMP_Text[] numberTexts; // TMPro(TextMeshPro) 요소들을 배열로 저장

    public List<int> numbers = new List<int>(); // 생성된 숫자들을 저장할 리스트
    [SerializeField]
    UnityEvent fin_display; //바퀴 돌릴 때마다 실행
    public void call()
    {
        GenerateNumbers();
        DisplayNumbers();
        Debug.Log(1);

    }

    private void GenerateNumbers()
    {
        // 1부터 10까지의 숫자를 리스트에 추가
        for (int i = 1; i <= 10; i++)
        {
            numbers.Add(i);
        }

        Shuffle(numbers); // 리스트의 숫자들을 랜덤하게 섞음

        // 리스트에서 처음 3개의 숫자만 남기고 나머지는 제거
        numbers.RemoveRange(3, numbers.Count - 3);
    }

    private void DisplayNumbers()
    {
        // TMPro(TextMeshPro) 요소들에 숫자를 표시
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
