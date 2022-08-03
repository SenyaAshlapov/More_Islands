using UnityEngine;


[CreateAssetMenu(fileName = "RangeWeaponDATA", menuName = "More_Islands/RangeWeaponDATA", order = 0)]
public class RangeWeaponDATA : ScriptableObject, IWeapon
{
    [SerializeField] private GameObject _model;
    [SerializeField] private Damager _damager;
    [SerializeField] private string _name;
    [SerializeField] private float _damage;
    [SerializeField] private WeaponTypes.weaponType _weaponType;

    

    #region IWeapon_fields
    public GameObject Model => _model;
    public Damager Damager => _damager;
    public string Name => _name;
    public float Damage => _damage;
    public WeaponTypes.weaponType Type => _weaponType;

    #endregion
    public void Hit(Transform shotPoint) { 
        var damager = Instantiate(Damager, shotPoint.position, shotPoint.rotation);
        damager.InitDamager(Damage);
        damager.SetVelocity();

        Debug.Log("pistol attack");
    }

    public void InitWeapon(Transform position)
    {
        foreach (Transform child in position)
        {
            Destroy(child.gameObject);
        }
        Instantiate(Model, position);
       
    }
}