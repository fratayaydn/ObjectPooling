using UniRx;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    void Start()
    {
        Observable.EveryFixedUpdate().Subscribe(OnNext);
    }

    private void OnNext(long obj)
    {
        ObjectPooler.Instance.SpawnFromPool("Cube", transform.position, transform.rotation);
        
    }

}
