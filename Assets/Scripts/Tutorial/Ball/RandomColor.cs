using UnityEngine;
using UnityEngine.Events;

public class RandomColor : MonoBehaviour
{
    Renderer capsuleColor;

    
    [SerializeField]
    private float hueMin = 0;
    [SerializeField]
    private float hueMax = 1;
    [SerializeField]
    private float saturationMin = 0.7f;
    [SerializeField]
    private float saturationMax = 1;
    [SerializeField]
    private float valueMin = 0.7f;
    [SerializeField]
    private float valueMax = 1;
    private void Awake()
    {
        capsuleColor = gameObject.GetComponent<Renderer>();
        capsuleColor.material.color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);
    }
}
