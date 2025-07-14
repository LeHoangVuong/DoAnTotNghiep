using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UIplayer : MonoBehaviour
{
    public static UIplayer ui;
    [SerializeField] private Slider playerhealthslider;
    [SerializeField] private TMP_Text hptext;
    [SerializeField] private Slider playerexpslider;
    [SerializeField] private TMP_Text exptext;
    [SerializeField] private TMP_Text timetext;
    [SerializeField] private TMP_Text wavetext;
    bool waverunning = true;
    public int currenwave = 0;
    int currenwavetime;
    public GameObject gameoverpanel;
    public GameObject pausepanel;
    public GameObject leveluppanel;
    public Levelup[] levelupbutton;
    void Awake()
    {
        if (ui != null && ui != this)
        {
            Destroy(this);
        }
        else
        {
            ui = this;
        }
    }
    private void Start()
    {
        startnewwave();
    }
    private void startnewwave()
    {
        StopAllCoroutines();
        currenwave++;
        waverunning = true;
        currenwavetime = 30;
        wavetext.text = "Wave: " + currenwave;
        StartCoroutine(wavetime());
    }
    IEnumerator wavetime()
    {
        while (waverunning)
        {
            yield return new WaitForSeconds(1f);
            currenwavetime--;
            timetext.text = currenwavetime.ToString();
            if (currenwavetime <= 0)
                wavecomplete();
        }
        yield return null;
    }
    private void wavecomplete()
    {
        StopAllCoroutines();
        clearenemy();
        waverunning = false;
        currenwavetime = 30;
        timetext.text = currenwavetime.ToString();
    }
    private void clearenemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }
    public void Updatehealthslider()
    {
        playerhealthslider.maxValue = Playercontrol.playerA.playermaxhealth;
        playerhealthslider.value = Playercontrol.playerA.playerhealth;
        hptext.text = playerhealthslider.value + " / " + playerhealthslider.maxValue;
    }
    public void Updateexpslider()
    {
        playerexpslider.maxValue = Playercontrol.playerA.playerlevel[Playercontrol.playerA.currentlevel-1];
        playerexpslider.value = Playercontrol.playerA.experience;
        exptext.text = playerexpslider.value + " / " + playerexpslider.maxValue;
    }
    public void levelupopen()
    {
        leveluppanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void levelupclose()
    {
        leveluppanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
