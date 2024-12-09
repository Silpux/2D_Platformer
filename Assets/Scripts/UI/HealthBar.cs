using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour{

    [SerializeField] private GameObject healthBarGameObject;
    [SerializeField] private Image fill;
    private IHealthBar healthBar;

    private void Awake(){

        healthBar = healthBarGameObject.GetComponent<IHealthBar>();

        if(healthBar is null){
            throw new NullReferenceException("Game object doesn't implement IHealthBar");
        }

        healthBar.OnHealthChanged += HealthBar_OnHealthChanged;

    }

    private void HealthBar_OnHealthChanged(object s, IHealthBar.HealthChangedEventArgs eventArgs){
        fill.fillAmount = eventArgs.healthNormalized;
    }

}
