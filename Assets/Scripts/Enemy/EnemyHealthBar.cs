using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateHealthBar(float current, float max)
    {

        slider.maxValue = max;
        slider.value = current;

    }

}
