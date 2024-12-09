using System;
using UnityEngine;

public interface IHealthBar{

    event EventHandler<HealthChangedEventArgs> OnHealthChanged;

    public class HealthChangedEventArgs : EventArgs{

        public HealthChangedEventArgs(float value){
            healthNormalized = value;
        }

        public float healthNormalized;
    }

}
