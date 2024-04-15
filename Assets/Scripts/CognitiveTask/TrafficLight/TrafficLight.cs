using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [SerializeField]
    private GameObject redLight;
    [SerializeField]
    private GameObject yellowLight;
    [SerializeField]
    private GameObject greenLight;
    [SerializeField]
    private Material redMaterial;
    [SerializeField]
    private Material yellowMaterial;
    [SerializeField]
    private Material greenMaterial;
    [SerializeField]
    private Material normalMaterial;
    private Renderer redRenderer;
    private Renderer yellowRenderer;
    private Renderer greenRenderer;

    private void Awake()
    {
        redRenderer = redLight.GetComponent<Renderer>();
        yellowRenderer = yellowLight.GetComponent<Renderer>();
        greenRenderer = greenLight.GetComponent<Renderer>();

        redRenderer.material = normalMaterial;
        yellowRenderer.material = normalMaterial;
        greenRenderer.material = greenMaterial;
    }

    public void stop_left()
    {
        StartCoroutine(TrafficSignal_stop());
    }

    public void open_left()
    {
        StartCoroutine(TrafficSignal_open());
    }

    public IEnumerator TrafficSignal_stop()
    {
        redRenderer.material = normalMaterial;
        yellowRenderer.material = yellowMaterial;
        greenRenderer.material = normalMaterial;
        yield return new WaitForSeconds(2f);

        redRenderer.material = redMaterial;
        yellowRenderer.material = normalMaterial;
        greenRenderer.material = normalMaterial;
        yield return new WaitForSeconds(5f);

    }

    public IEnumerator TrafficSignal_open()
    {
        redRenderer.material = normalMaterial;
        yellowRenderer.material = yellowMaterial;
        greenRenderer.material = normalMaterial;
        yield return new WaitForSeconds(2f);

        redRenderer.material = normalMaterial;
        yellowRenderer.material = normalMaterial;
        greenRenderer.material = greenMaterial;
        yield return new WaitForSeconds(60f);

    }

    /*public IEnumerator TrafficSignal()
    {
        //while (true)
        //{
            redRenderer.material = normalMaterial;
            yellowRenderer.material = yellowMaterial;
            greenRenderer.material = normalMaterial;
            yield return new WaitForSeconds(2f);

            redRenderer.material = redMaterial;
            yellowRenderer.material = normalMaterial;
            greenRenderer.material = normalMaterial;
            yield return new WaitForSeconds(5f);

            redRenderer.material = normalMaterial;
            yellowRenderer.material = yellowMaterial;
            greenRenderer.material = normalMaterial;
            yield return new WaitForSeconds(2f);

            redRenderer.material = normalMaterial;
            yellowRenderer.material = normalMaterial;
            greenRenderer.material = greenMaterial;
            yield return new WaitForSeconds(60f);
        //}
    }*/
}
