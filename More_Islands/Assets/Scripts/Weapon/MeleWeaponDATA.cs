using UnityEngine;
using UnityEngine.UI;

public class MeleWeaponDATA : MonoBehaviour, IWeapon
{
    public GameObject Model { get; set; }
    public string Name { get; set; }
    public Sprite Icon { get; set; }
    public float Damage { get; set; }
    public float CoolDown { get; set; }
    public void Hit() { }

    public void InitWeapon(Transform position)
    {
        foreach (Transform child in position)
        {
            Destroy(child.gameObject);
        }
        Instantiate(Model, position);
    }
}
