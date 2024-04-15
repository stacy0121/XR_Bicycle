using UnityEngine;

public class RaceTracker : MonoBehaviour
{
    private RailMove railMove;
    private RectTransform rectTransform;

    public GameObject player;
    private float startPosition = -277.6f, endPosition = 279.51f;
    private float desiredPosition;

    private float vehicleSpeed;

    // Add a new variable for rotation speed.
    public float movementSpeed = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        railMove = GetComponent<RailMove>();
        rectTransform = player.GetComponent<RectTransform>();
        desiredPosition = startPosition - endPosition;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        vehicleSpeed = railMove.currentSpeedMPS;
        updatePosition();
    }

    private void updatePosition()
    {
        float temp = vehicleSpeed / 180;
        // Calculate the target position.
        float targetPositionX = startPosition - temp * desiredPosition;

        Vector3 currentPosition = rectTransform.anchoredPosition;

        // Only move if the target position is greater than the current position.
        if (targetPositionX >= currentPosition.x)
        {
            // Smoothly interpolate between current and target positions.
            currentPosition.x = Mathf.Lerp(currentPosition.x, targetPositionX, Time.deltaTime * movementSpeed);

            rectTransform.anchoredPosition = currentPosition;
        }
    }
}
