using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevelData : MonoBehaviour
{
    public int savedPosition;
    public Vector2[] spawnPoints;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Start()
    {

    }

    public void SaveLevelPosition(int loc)
    {
        savedPosition = loc;
    }


}
