using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using TMPro;

public class TweenSample : MonoBehaviour
{
    [Header("효과를 위한 UI, Object 타겟")]
    public RectTransform UITarget;
    public GameObject ObjectTarget;

    [Header("글자 연출")]
    public TMP_Text countText;
    public int currentValue = 0;
    public int addValue = 100;

    private int targetValue;

    [Header("색 변형 연출")]
    public Color FlashColor = Color.yellow;
    private Color originalColor = Color.white;

    [Header("페이즈 UI 연출")]
    public CanvasGroup fadeTarget;

    void Start()
    {
        countText.text = currentValue.ToString();
        originalColor = countText.color;
    }

    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            PlayPunchUIScale();
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            PlayPunchObjectScale();
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            PlayUIShake();
        }
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            PlayCountUp();
        }
        if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            PlayColorFlash();
        }
        if (Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            PlayFade();
        }
    }

    public void PlayPunchUIScale()
    {
        if (UITarget == null) return;
        UITarget.DOKill();
        UITarget.localScale = Vector3.one;
        UITarget.DOPunchScale(Vector3.one * 0.3f, 0.25f, 8, 1.0f);
    }

    public void PlayPunchObjectScale()
    {
        if (UITarget == null) return;
        ObjectTarget.transform.DOKill();
        ObjectTarget.transform.localScale = Vector3.one;
        ObjectTarget.transform.DOPunchScale(Vector3.one * 0.3f, 0.25f, 8, 1.0f);
    }

    public void PlayUIShake()
    {
        if (UITarget == null) return;
        UITarget.DOKill();
        UITarget.DOShakeAnchorPos(0.3f, 20f, 20, 90f);
    }

    public void PlayCountUp()
    {
        if (countText == null) return;

        targetValue += addValue;
        DOTween.Kill("CountTween", true);

        DOTween.To(
            () => currentValue,
            value =>
            {
                currentValue = value;
                countText.text = currentValue.ToString();
            },
            targetValue,
            0.5f
        )
        .SetEase(Ease.OutQuad)
        .SetId("CountTween");
    }

    public void PlayColorFlash()
    {
        if (countText == null) return;
        countText.DOKill();
        countText.color = originalColor;

        countText.DOColor(FlashColor, 0.1f)
            .OnComplete(() =>
            {
                countText.DOColor(originalColor, 0.2f);
            });
    }

    public void PlayFade()
    {
        if (fadeTarget == null) return;
        fadeTarget.DOKill();
        fadeTarget.alpha = 0;

        Sequence seq = DOTween.Sequence();

        seq.Append(fadeTarget.DOFade(1f, 0.2f));
        seq.AppendInterval(0.5f);
        seq.Append(fadeTarget.DOFade(0f, 0.3f));
    }
}
