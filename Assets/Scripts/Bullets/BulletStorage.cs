using System;
using UnityEngine;

public class BulletStorage : MonoBehaviour{

    [SerializeField] private int initialBulletCount;

    private int bulletCount;

    public bool HasBullets => bulletCount > 0;

    public event Action<int> OnBulletCountChanged = delegate{ };

    private void Start(){

        bulletCount = initialBulletCount;
        OnBulletCountChanged?.Invoke(bulletCount);

    }

    public void AddBullets(int amount){

        bulletCount += amount;
        OnBulletCountChanged?.Invoke(bulletCount);

    }

    public bool ConsumeBullet(){

        if(bulletCount > 0){

            bulletCount--;
            OnBulletCountChanged?.Invoke(bulletCount);
            return true;

        }

        return false;

    }

}
