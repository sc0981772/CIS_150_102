namespace Module_1___High_Scores;

using System;
public class Player
{
    //private feilds
    private string initials;
    private int score;

    //public properties with get and set accessors
    public string Initials
    {
        get { return initials; }
        set { initials = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    //constructor
    public Player(string initials, int score)
    {
        Initials = initials;
        Score = score;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        //creating a Player object
        Player player = new Player("SDC", 100);

        //a couple of lines to display player details
        Console.WriteLine("Player initials: " + player.Initials);
        Console.WriteLine("Player score: " + player.Score);
    }
}
