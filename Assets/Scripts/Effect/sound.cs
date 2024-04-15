using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
	[SerializeField]
	private float minPitch = 0.8f;
	[SerializeField]
	private float maxPitch = 1.2f;
	private AudioSource target;

	private void Awake()
	{
		target = GetComponent<AudioSource>();
	}

	public void Call()
	{
		target.pitch = Random.Range(minPitch, maxPitch);
		target.Play();
	}
}