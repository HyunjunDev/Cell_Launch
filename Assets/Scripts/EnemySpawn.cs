using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject moveEnemy;

    public GameObject player;

    public float currTime;

    void Update()
    {
        if(player==null)
        {
            return;
        }
        else
        {
            currTime += Time.deltaTime;

            if (currTime >= 8)
            {
                //float newX = Random.Range(-137f, 137f), newY = Random.Range(-141f, 142f), newZ = Random.Range(-100f, 100f);
                float newX = Random.Range(-50f, 50f), newY = Random.Range(-50f, 50f);
                moveEnemy = ObjectPool.Instance.GetObject(PoolObjectType.MoveEnemy);

                moveEnemy.transform.position = new Vector3(newX, newY, 0);

                currTime = 0;
            }
        }
    }
}
