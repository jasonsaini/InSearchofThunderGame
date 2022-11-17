using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image _healthBarSprite;

    public void updateHealthBar(float maxHealth, float curHealth)
    {
        _healthBarSprite.fillAmount = curHealth / maxHealth;
    }
}
