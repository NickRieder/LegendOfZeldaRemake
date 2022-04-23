using System;
using System.IO;

namespace Sprint2
{
    public class QuitCommand : ICommand
    {
        private Game1 game;
        private string projectDirectory;

        public QuitCommand(Game1 game)
        {
            this.game = game;
            string workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            projectDirectory = projectDirectory.Replace((char)92, '/');
        }

        public void Execute()
        {
            if (File.Exists(projectDirectory + "/Content/Levels/EndlessRooms/EndlessRoom1.xml"))
            {
                File.Delete(projectDirectory + "/Content/Levels/EndlessRooms/EndlessRoom1.xml");
            }
            if (File.Exists(projectDirectory + "/Content/Levels/EndlessRooms/EndlessRoom2.xml"))
            {
                File.Delete(projectDirectory + "/Content/Levels/EndlessRooms/EndlessRoom2.xml");
            }
            if (File.Exists(projectDirectory + "/Content/Levels/EndlessRooms/EndlessRoom3.xml"))
            {
                File.Delete(projectDirectory + "/Content/Levels/EndlessRooms/EndlessRoom3.xml");
            }
            if (File.Exists(projectDirectory + "/Content/Levels/EndlessRooms/EndlessSecretRoom.xml"))
            {
                File.Delete(projectDirectory + "/Content/Levels/EndlessRooms/EndlessSecretRoom.xml");
            }
            game.Exit();
        }
    }
}
