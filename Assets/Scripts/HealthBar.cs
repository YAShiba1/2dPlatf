using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Creature _creature;

    private void OnEnable()
    {
        SubscribeToHealthEvent();
    }

    private void OnDisable()
    {
        UnsubscribeFromHealthEvent();
    }

    protected virtual void SubscribeToHealthEvent() 
    {
        _creature.HealthChanged += OnHealthChanged;
    }

    protected virtual void UnsubscribeFromHealthEvent() 
    {
        _creature.HealthChanged -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged(float newHealth) { }
}