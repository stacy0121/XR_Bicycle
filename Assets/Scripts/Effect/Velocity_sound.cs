using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity_sound : MonoBehaviour
{
    public AudioSource audioSourceA; // a 오디오 소스 
    public AudioSource audioSourceB; // b 오디오 소스

    public Rigidbody rigidbody;

   

    public void StartAudio()
    {
        StartCoroutine(PlayAudioCoroutine());
    }

    private IEnumerator PlayAudioCoroutine()
    {
        while (true)
        {
            if (rigidbody.velocity.z <= 0)
            {
                if (!audioSourceA.isPlaying)
                {
                    audioSourceA.Play();
                    audioSourceB.Stop();
                }
            }
            else
            {
                if (!audioSourceB.isPlaying)
                {
                    audioSourceB.Play();
                    audioSourceA.Stop();
                }
            }

            yield return null; // 다음 프레임까지 대기
        }
    }
}