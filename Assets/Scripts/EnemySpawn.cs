using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject moveEnemy;

    public float currTime;

    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > 20)
        {
            //float newX = Random.Range(-137f, 137f), newY = Random.Range(-141f, 142f), newZ = Random.Range(-100f, 100f);
            float newX = Random.Range(-30f, 30f), newY = Random.Range(-30f, 30f), newZ = Random.Range(-30f, 30f);
            moveEnemy = ObjectPool.Instance.GetObject(PoolObjectType.MoveEnemy);

            moveEnemy.transform.position = new Vector3(newX, newY, newZ);

            currTime = 0;
        }
    }
}
