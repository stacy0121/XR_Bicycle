using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody bikeRigidbody;
    public TMP_Text speedText;
    public float updateInterval = 0.5f; // 업데이트 간격

    private bool isUpdating = false;

    public void call()
    {
        speedText.gameObject.SetActive(true);

        StartCoroutine(Start_velocity());
    }

    private IEnumerator Start_velocity()
    {

        yield return new WaitForSeconds(1f);
        isUpdating = true;

        while (isUpdating)
        {

            
            float speed_bike = bikeRigidbody.velocity.magnitude;
            float speed = speed_bike * 100;
            speedText.text = "Speed: " + speed.ToString("F2") + " m/s";

           

            yield return new WaitForSeconds(updateInterval);


        }
    }

    public void StopUpdating()
    {
        isUpdating = false;
    }
}
