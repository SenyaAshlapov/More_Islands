using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]private List<Image> _healtIcons = new List<Image>();

    public void UpdateHealthBar(float newHealth){
        foreach(Image child in _healtIcons){
            child.gameObject.SetActive(false);
        }

        for(int i = 0; i < newHealth; i++){
            _healtIcons[i].gameObject.SetActive(true);
        }
    }
 }
