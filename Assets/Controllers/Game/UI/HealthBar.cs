using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetHealth(int value)
    {
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(int value)
    {
        slider.maxValue = value;
        slider.value = value;
        fill.color = gradient.Evaluate(1f);
    }
}
