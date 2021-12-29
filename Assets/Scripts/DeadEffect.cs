using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffect : MonoBehaviour
{
    [SerializeField]
    PoolObjectType objectType;

    private ParticleSystem deadParticle;
    void Start()
    {
        deadParticle = this.GetComponent<ParticleSystem>();
        deadParticle.Play();
    }
    void Update()
    {
        if(deadParticle.gameObject.activeSelf==false)
        {
            ObjectPool.Instance.ReturnObject(PoolObjectType.DeadPartice, gameObject);
        }
    }
}
