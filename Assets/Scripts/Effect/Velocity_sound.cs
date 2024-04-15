using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity_sound : MonoBehaviour
{
    public AudioSource audioSourceA; // a ����� �ҽ� 
    public AudioSource audioSourceB; // b ����� �ҽ�

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

            yield return null; // ���� �����ӱ��� ���
        }
    }
}