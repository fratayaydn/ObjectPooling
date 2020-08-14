using UniRx;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    void Start()
    {
        Observable.EveryFixedUpdate().Subscribe(OnNext);
    }

    private void OnNext(long obj)
    {
        ObjectPooler.Instance.SpawnFromPool("Sphere", transform.position, transform.rotation);
        
    }

}