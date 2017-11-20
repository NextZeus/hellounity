// Properties

using UnityEngine;
using System.Collection;

public class Player
{
    private int experience;

    public int Experienct
    {
        get
        {
            return experience;
        }
        set
        {
            experience = value;
        }
    }

    public int Level
    {
        get
        {
            return experience / 1000;
        }
        set
        {
            experience = value * 1000;
        }
    }
    
    // auto-implemented
    public int Health(get; set;)
}

public class Game: MonoBehaviour
{
    void Start()
    {
        Player myPlayer = new Player();
        myPlayer.Experienct = 5;
        int x = myPlayer.Experienct;
    }
}