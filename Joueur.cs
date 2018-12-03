namespace Botana
{
    internal class Joueur
    {
        public Joueur(string name)
        {
            discordName = name;
        }

        public string discordName { get; private set; }
    }
}
