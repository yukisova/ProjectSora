namespace MainMenu
{
    public class PanelRoot
    {
        APanel startGame;
        APanel exitGame;

        public PanelRoot()
        {
            startGame = new StartButton();
            exitGame = new ExitButton();
        }
    }
}