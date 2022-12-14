using UnityEngine;


public class Damager : MonoBehaviour
{
    private float _damage;

    [SerializeField]private Rigidbody _rigidBody;
    [SerializeField]private float _speed;

    public void InitDamager(float damage){
        _damage = damage;

    }

    public void SetVelocity(){
        _rigidBody.velocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().GetDamage(_damage);
            Destroy(this.gameObject);
        }
            
        
    }
}
