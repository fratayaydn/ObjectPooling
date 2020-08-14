using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    private float upForce = 1f;
    [SerializeField]
    private float sideForce = .1f;
    [SerializeField]
    private float lifeSeconds = 1f;

    private IDisposable deathTimer;
    // Start is called before the first frame update
    public void OnEnable()
    {
        deathTimer = Observable.Timer(TimeSpan.FromSeconds(lifeSeconds)).Subscribe(OnDeath);
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);
        
        Vector3 force = new Vector3(xForce,yForce,zForce);

        GetComponent<Rigidbody>().velocity = force;

    }
    
    public void OnDisable()
    {
        deathTimer.Dispose();
    }

    private void OnDeath(long obj)
    {

        ObjectPooler.Instance.ReturnToPool("Sphere", gameObject);
    }
    
}