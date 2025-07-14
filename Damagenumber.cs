using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damagenumber : MonoBehaviour
{
    [SerializeField] private TMP_Text damagetext;
    private float speed;
    void Start()
    {
        speed = Random.Range(0.1f, 1.5f);
        Destroy(gameObject,1);
    }
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }
    public void setvalue(int value)
    {
        damagetext.text = value.ToString();
    }
}
