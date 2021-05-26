using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHealth(int maxhealth)
    {
        slider.value = 100;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
