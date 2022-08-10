using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health")]
    public Slider slide;

    public Transform respawnpoint;
    public Transform player;

    private void Update()
    {
        if (slide.value == 0)
        {
            player.transform.position = respawnpoint.transform.position;
            Physics.SyncTransforms();
            slide.value = slide.maxValue;
        }
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
