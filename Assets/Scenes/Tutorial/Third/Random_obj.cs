using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Random_obj : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject strawberryPrefab;
    public GameObject orangePrefab;
    public Transform playerHeadTransform;
    public int fruitCount = 3;
    public float fruitSpacing = 1f;

    private List<GameObject> fruits = new List<GameObject>();

    [SerializeField]
    UnityEvent make_fin; // 생성 완료 이벤트

   /*private void Start()
    {
        Call();
    }*/

    public void Call()
    {
        
        GenerateFruits();
    }



    private void GenerateFruits()
    {
        List<GameObject> fruitPrefabs = new List<GameObject>() { applePrefab, strawberryPrefab, orangePrefab };
        Shuffle(fruitPrefabs);

        Vector3 playerHeadPosition = playerHeadTransform.position;
        Vector3 playerRight = playerHeadTransform.right;

        float totalWidth = fruitSpacing * (fruitCount - 1);
        float startX = playerHeadPosition.x - totalWidth / 2f;

        Transform parentTransform = transform; // 현재 스크립트가 적용된 오브젝트의 Transform을 가져옴

        for (int i = 0; i < fruitCount; i++)
        {
            Vector3 spawnPosition = new Vector3(startX + fruitSpacing * i, playerHeadPosition.y, playerHeadPosition.z);
            Quaternion spawnRotation = Quaternion.Euler(fruitPrefabs[i].transform.rotation.eulerAngles);  // No rotation
            GameObject fruit = Instantiate(fruitPrefabs[i], spawnPosition, spawnRotation, parentTransform); // 부모 오브젝트 지정

            fruit.SetActive(true); // Activate the fruit object
            fruits.Add(fruit);
        }

        make_fin.Invoke(); // 생성 완료 이벤트 실행
    }

    private void DestroyFruits()
    {
        foreach (GameObject fruit in fruits)
        {
            Destroy(fruit);
        }
        fruits.Clear();
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
}
