namespace Botana
{
    internal class MorpionPlayer
    {
        public MorpionPlayer(string name)
        {
            discordName = name;
        }

        public string discordName { get; private set; }
    }
}
