using WarRogue;

internal class Program
{
    private static void Main(string[] args)
    {
        Game game = new( "Player 1", "Player 2" );
        game.Play();
    }
}