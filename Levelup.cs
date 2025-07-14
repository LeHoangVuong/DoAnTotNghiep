using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Levelup : MonoBehaviour
{
    public TMP_Text weaponname;
    public Image weaponicon;
    public TMP_Text weapondescription;
    public void choosebutton(Weapon weapon)
    {
        weaponname.text = weapon.name; 
        weapondescription.text = weapon.start[weapon.weaponlevel].desscription;
        weaponicon.sprite = weapon.weaponimage;
    }
}
