using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "RangeWeaponDATA", menuName = "More_Islands/RangeWeaponDATA", order = 0)]
public class RangeWeaponDATA : ScriptableObject, IWeapon
{
    [SerializeField] private GameObject _model;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _damage;
    [SerializeField] private float _coolDown;

    #region IWeapon_fields
    public GameObject Model => _model;
    public string Name => _name;
    public Sprite Icon => _icon;
    public float Damage => _damage;
    public float CoolDown => _coolDown;

    #endregion
    public void Hit() { 
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