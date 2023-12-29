using System.Collections;
using UnityEngine;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private float _speed;

    private Coroutine _changeValueOfBarJob;

    private void Start()
    {
        _slider.maxValue = _creature.MaxHealth;
        _slider.minValue = _creature.MinHealth;
        _slider.value = _slider.maxValue;
    }

    protected override void OnHealthChanged(float newHealth)
    {
        if (_changeValueOfBarJob != null)
        {
            StopCoroutine(_changeValueOfBarJob);
        }

        _changeValueOfBarJob = StartCoroutine(ChangeSliderValue(newHealth));
    }

    private IEnumerator ChangeSliderValue(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }
    }
}