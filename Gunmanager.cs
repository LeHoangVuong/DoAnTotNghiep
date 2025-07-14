using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunmanager : MonoBehaviour
{
    [SerializeField] GameObject guncraft;
    Transform player;
    List<Vector2> gunposition = new List<Vector2>();
    int spawngun = 0;
    public void Start()
    {
        player = GameObject.Find("Player").transform;
        gunposition.Add(new Vector2(0.5f, 0.5f));
        gunposition.Add(new Vector2(-0.5f, 0.5f));
        gunposition.Add(new Vector2(-0.8f, 0f));
        gunposition.Add(new Vector2(0.8f, 0f));
        gunposition.Add(new Vector2(-0.5f, -0.5f));
        gunposition.Add(new Vector2(0.5f, -0.5f));
        addgun();
    }
    void addgun()
    {
        var gunpos = gunposition[spawngun];
        var newgun = Instantiate(guncraft, gunpos, Quaternion.identity);
        newgun.GetComponent<Gun>().SetOffset(gunpos);
        spawngun++;
    }
    void Update()
    {
        
    }
}
