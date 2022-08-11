using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health")]
    public Slider slide;

    private void Update()
    {
    }
    public void MaxHealth(int health)
    {
        slide.maxValue = health;
        slide.value = health;
    }
    public void SetHealth(int health)
    {
        slide.value = health;
    }
}
