using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    PoolObjectType objectType;
    private void OnEnable()
    {
        Invoke("Disable", 30f);
    }
    public void Disable()
    {
        switch(objectType)
        {
            case PoolObjectType.BlueFood:
                ObjectPool.Instance.ReturnObject(PoolObjectType.BlueFood, gameObject);
                break;
            case PoolObjectType.BoraFood:
                ObjectPool.Instance.ReturnObject(PoolObjectType.BoraFood, gameObject);
                break;
            case PoolObjectType.CranberryFood:
                ObjectPool.Instance.ReturnObject(PoolObjectType.CranberryFood, gameObject);
                break;
            case PoolObjectType.GreenFood:
                ObjectPool.Instance.ReturnObject(PoolObjectType.GreenFood, gameObject);
                break;
            case PoolObjectType.IcingFood:
                ObjectPool.Instance.ReturnObject(PoolObjectType.IcingFood, gameObject);
                break;
            case PoolObjectType.MelonFood:
                ObjectPool.Instance.ReturnObject(PoolObjectType.MelonFood, gameObject);
                break;
            case PoolObjectType.SakuraFood:
                ObjectPool.Instance.ReturnObject(PoolObjectType.SakuraFood, gameObject);
                break;
            case PoolObjectType.YellowFood:
                ObjectPool.Instance.ReturnObject(PoolObjectType.YellowFood, gameObject);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("player")|| collision.gameObject.tag == ("MoveEnemy"))
        {
            switch (objectType)
            {
                case PoolObjectType.BlueFood:
                    ObjectPool.Instance.ReturnObject(PoolObjectType.BlueFood, gameObject);
                    break;
                case PoolObjectType.BoraFood:
                    ObjectPool.Instance.ReturnObject(PoolObjectType.BoraFood, gameObject);
                    break;
                case PoolObjectType.CranberryFood:
                    ObjectPool.Instance.ReturnObject(PoolObjectType.CranberryFood, gameObject);
                    break;
                case PoolObjectType.GreenFood:
                    ObjectPool.Instance.ReturnObject(PoolObjectType.GreenFood, gameObject);
                    break;
                case PoolObjectType.IcingFood:
                    ObjectPool.Instance.ReturnObject(PoolObjectType.IcingFood, gameObject);
                    break;
                case PoolObjectType.MelonFood:
                    ObjectPool.Instance.ReturnObject(PoolObjectType.MelonFood, gameObject);
                    break;
                case PoolObjectType.SakuraFood:
                    ObjectPool.Instance.ReturnObject(PoolObjectType.SakuraFood, gameObject);
                    break;
                case PoolObjectType.YellowFood:
                    ObjectPool.Instance.ReturnObject(PoolObjectType.YellowFood, gameObject);
                    break;
            }
        }
    }
}

