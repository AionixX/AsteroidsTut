using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Score
{
    public Score(string _name, int _score) {
        name = _name;
        score = _score;
    }
    public string name;
    public int score;
}
