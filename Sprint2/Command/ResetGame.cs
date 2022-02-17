namespace Sprint2
{
    internal class ResetGame : ICommand
    {
        private Game1 game;

        public ResetGame(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Reset();
        }
    }
}