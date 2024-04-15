using UnityEngine;

public class Speedometer : MonoBehaviour
{
    private RailMove railMove;

    public GameObject needle;
    private float startPosition = 145.78f, endPosition = -118.4f;
    private float desiredPosition;

    private float vehicleSpeed;

    // Add a new variable for rotation speed.
    public float rotationSpeed = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        railMove = GetComponent<RailMove>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        vehicleSpeed = railMove.currentSpeedMPS;
        updateNeedle();
    }

    private void updateNeedle()
    {
        desiredPosition = startPosition - endPosition;
        float temp = vehicleSpeed / 180;
        // Calculate the target angle.
        float targetAngle = startPosition - temp * desiredPosition;
        // Get the current angle.
        float currentAngle = needle.transform.eulerAngles.z;

        // Smoothly interpolate between current and target angles.
        float smoothedAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * rotationSpeed);
        needle.transform.eulerAngles = new Vector3(0, 0, smoothedAngle);
    }
}
