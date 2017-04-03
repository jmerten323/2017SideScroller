using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {
    private int _Lives = 3;
    public int points;

    public Text healthValue;
    public Text pointsValue;


    public void SetLives(int newValue)
    {
        _Lives = newValue;
        Debug.Log("Lives now equals:" + _Lives);
        healthValue.text = _Lives.ToString();
    }

    public int GetLives()
    {
        return _Lives;
    }
	}

