namespace Botana
{
    internal class MorpionPlayer
    {
        public MorpionPlayer(string name, int value)
        {
            this.discordName = name;
            this.value = value;
        }

        public string discordName { get; private set; }
        public int value { get; private set; }
    }
}
