using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentClass {

    private static int score = 0; //The most recent score
    private static int highScore = 0; //The highest score

    public static void setScore(int pScore)
    {
        score = pScore;
    }
    public static int getScore()
    {
        return score;
    }
    public static void setHighScore(int pScore)
    {
        highScore = pScore;
    }
    public static int getHighScore()
    {
        return highScore;
    }
}
