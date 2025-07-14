using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponlevel;
    public List<weaponstart> start;
    public Sprite weaponimage;
}
[System.Serializable]
public class weaponstart
{
    public float countdown;
    public float duration;
    public float damage;
    public float speed;
    public float ranger;
    public string desscription;
} 