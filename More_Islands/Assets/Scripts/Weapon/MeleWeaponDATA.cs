using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "MeleWeaponDATA", menuName = "More_Islands/MeleWeaponDATA", order = 0)]
public class MeleWeaponDATA : ScriptableObject, IWeapon 
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
        Debug.Log("sword attack");
    }

    public void InitWeapon(Transform position)
    {
        foreach (Transform child in position)
        {
            Destroy(child.gameObject);
        }
        Instantiate(Model, position);
        var damager = Instantiate(Damager, position);
        damager.InitDamager(Damage);
    }
}