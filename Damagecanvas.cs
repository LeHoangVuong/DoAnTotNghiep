using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagecanvas : MonoBehaviour
{
    public static Damagecanvas dame;
    public Damagenumber damagenumber;
    private void Awake()
    {
        if (dame != null && dame != this)
        {
            Destroy(this);
        }
        else
        {
            dame = this;
        }
    }
    public void number(float value, Vector3 location)
    {
        Damagenumber Damagenumber = Instantiate(damagenumber, location, transform.rotation, transform);
        Damagenumber.setvalue(Mathf.RoundToInt(value));
    }
}
