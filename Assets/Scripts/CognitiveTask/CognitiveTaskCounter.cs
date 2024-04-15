using UnityEngine;

public class CognitiveTaskCounter : MonoBehaviour
{
    private int successCount = 0;
    private int failureCount = 0;

    // Start is called before the first frame update
    public void SuccessCount()
    {
        successCount++;
    }

    public void FailureCount()
    {
        failureCount++;
    }
}
