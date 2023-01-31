using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class RaceTimer : MonoBehaviour
{
    [Header("Timer UI :")]
    [SerializeField] private Image fillimage;
    [SerializeField] private Text uiText;

    public int Duration { get; private set; }

    private int remainingDuration;

    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        uiText.text = "00:00";
        fillimage.fillAmount = 0f;

        Duration = remainingDuration = 0;
    }

    public RaceTimer SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration > -1)
        {
            UpdateUI(remainingDuration);
            remainingDuration++;
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    private void UpdateUI(int seconds)
    {
        uiText.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
        fillimage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }

    public void End()
    {
        ResetTimer();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
