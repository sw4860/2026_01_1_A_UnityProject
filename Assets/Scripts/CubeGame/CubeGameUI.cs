using UnityEngine;
using TMPro;

public class CubeGameUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float Timer = 0.0f;

    void Update()
    {
        Timer += Time.deltaTime;
        timerText.text = $"생존 시간: {Timer:F2}초";
    }
}
