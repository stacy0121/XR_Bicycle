using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight1 : MonoBehaviour
{
    [SerializeField]
    private GameObject Light;
    [SerializeField]
    private Material redMaterial;
    [SerializeField]
    private Material yellowMaterial;
    [SerializeField]
    private Material greenMaterial;
    [SerializeField]
    private Material normalMaterial;
    private Renderer Renderer;

    private void Awake()
    {
        Renderer = Light.GetComponent<Renderer>();

        Renderer.material = greenMaterial;
    }

    /*public void TrafficSignal_cor ()
    {
        StartCoroutine(TrafficSignal());
    }*/

    public void TrafficSignal_close()
    {
        StartCoroutine(TrafficSignalClose());
    }

    public void TrafficSignal_open()
    {
        StartCoroutine(TrafficSignalOpen());
    }


  /*  public IEnumerator TrafficSignal()
    {
        //while (true)
        //{
            
            Renderer.material = yellowMaterial;
            yield return new WaitForSeconds(2f);

            Renderer.material = redMaterial;
            yield return new WaitForSeconds(5f);

            Renderer.material = yellowMaterial;
            yield return new WaitForSeconds(2f);

            Renderer.material = greenMaterial;
            yield return new WaitForSeconds(60f);
        //}
    }
*/
    public IEnumerator TrafficSignalClose()
    {
        Renderer.material = yellowMaterial;
        yield return new WaitForSeconds(2f);

        Renderer.material = redMaterial;
        yield return new WaitForSeconds(5f); ;
    }

    public IEnumerator TrafficSignalOpen()
    {
        Renderer.material = yellowMaterial;
        yield return new WaitForSeconds(2f);

        Renderer.material = greenMaterial;
        yield return new WaitForSeconds(60f);
    }
}
