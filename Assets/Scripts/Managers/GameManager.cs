using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Object dibuat singletone, artinya instance dari GameManager cuma ada 1 di scene yang sedang kita buka sekarang

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject playerPrefab;
    public GameObject activePlayer;
    public ScriptableInteger life;
    public ScriptableInteger coin;

    public EnemySpawner spawner;

    public List<GameObject> items;
    public bool isPlaying = false;
    
    public UnityAction OnGameOverAction;

    private void Awake()
    {
        if (instance == null) //Jika instance kosong
        {
            instance = this; //instance kita isi dengan script Game manager ini sendiri
        }
        else //jika instance tidak kosong
        {
            Destroy(gameObject);// Destroy gameObject yang sekarang sedang aktif dan ditempelin dengan script ini.
        }
        //Artinya jika instance sudah ada dan ada gamemanager yang baru, maka game manager yang baru harus dihapus karena hanya diinginkan satu instance game manager saja
    }
    void Start()
    {
        items = new List<GameObject>();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void spawnPlayer() //Player tidak dimunculkan dengan drag drop di Inspector, tapi dimunculkan melalui script ini
    {
        activePlayer = Instantiate(playerPrefab);
    }

    public Vector3 getPlayerPosition()
    {
        if (activePlayer != null)
        {
            return activePlayer.transform.position;
        }
        return Vector3.zero;
    }

    public void startGame()
    {
        isPlaying = true;
        spawnPlayer();
    }

    public void pauseGame()
    {
        isPlaying = false;
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        isPlaying = true;
        Time.timeScale = 1;
    }

    internal void gameOver()
    {
        isPlaying = false;
        OnGameOverAction?.Invoke();
        
    }

    internal void retry()
    {
        life.reset();
        coin.reset();
        spawner.clearEnemies();
        ObjectPool.GetInstance().deactivateAllObject();
        clearAllItem();
    }

    internal void addItem(GameObject gameObject)
    {
        items.Add(gameObject);
    }

    public void clearAllItem()
    {
        foreach(GameObject go  in items)
        {
            Destroy(go);
        }
        items.Clear();
    }

    // public void backToStart()
    // {
    //     isPlaying = false;
    //     Time.timeScale = 1;
    // }
}
