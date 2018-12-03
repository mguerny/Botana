namespace Botana
{
    internal class Stat
    {
        public string name { get; private set; }
        public int value { get; private set; }

        public Stat(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

    }
}