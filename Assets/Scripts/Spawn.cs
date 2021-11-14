using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> foods = new List<GameObject>();
    public float Speed;
    int random = 0;
    void Start()
    {
        InvokeRepeating("Generate", 0, Speed);
    }
    void Generate()
    {
        int x = Random.Range(-1000, 2500);
        int y = Random.Range(-1000, 2500);
        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;
        random = Random.Range(0, 8);
        switch(random)
        {
            case 0:
                foods[random] = ObjectPool.Instance.GetObject(PoolObjectType.BlueFood);
                break;
            case 1:
                foods[random] = ObjectPool.Instance.GetObject(PoolObjectType.BoraFood);
                break;
            case 2:
                foods[random] = ObjectPool.Instance.GetObject(PoolObjectType.CranberryFood);
                break;
            case 3:
                foods[random] = ObjectPool.Instance.GetObject(PoolObjectType.GreenFood);
                break;
            case 4:
                foods[random] = ObjectPool.Instance.GetObject(PoolObjectType.IcingFood);
                break;
            case 5:
                foods[random] = ObjectPool.Instance.GetObject(PoolObjectType.MelonFood);
                break;
            case 6:
                foods[random] = ObjectPool.Instance.GetObject(PoolObjectType.SakuraFood);
                break;
            case 7:
                foods[random] = ObjectPool.Instance.GetObject(PoolObjectType.YellowFood);
                break;
        }
        foods[random].transform.position = Target;
        foods[random].transform.rotation = Quaternion.identity;
    }
}
