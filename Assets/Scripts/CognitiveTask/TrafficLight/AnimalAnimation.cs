using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    public GameObject objectPrefab;  // 프리팹
    public AnimationClip animationClip;  // 애니메이션 클립

    private void Awake()
    {
        // 프리팹을 인스턴스화하여 게임 오브젝트 생성
        GameObject spawnedObject = Instantiate(objectPrefab);

        // 애니메이션 컴포넌트 가져오기
        Animation animation = spawnedObject.GetComponent<Animation>();

        // 애니메이션 클립 추가 및 재생
        animation.AddClip(animationClip, "MyAnimation");  // 애니메이션 클립 추가
        animation.Play("MyAnimation");  // 애니메이션 재생
    }
}
