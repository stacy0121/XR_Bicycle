using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bike_cnt_bar : MonoBehaviour
{
    public GameObject gaugeBar;
    public TMP_Text tmp;
    private int cnt = 0;
    private float maxCount = 3f; // 최대 카운트 값
    private Image gaugeFill;

    // Start is called before the first frame update
    public void cnt_start()
    {
        gaugeBar.SetActive(true);
        gaugeFill = gaugeBar.GetComponent<Image>();
        UpdateGauge();
    }

    public void UpdateCount(int count)
    {
        cnt = count;
        UpdateGauge();
    }

    private void UpdateGauge()
    {
        float fillAmount = cnt / maxCount;
        gaugeFill.fillAmount = fillAmount;
    }
}
