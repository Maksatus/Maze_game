using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]private float speed = 5f;
    [SerializeField]private float lifeTime = 10f;
    protected void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    protected void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime);
    }
}
