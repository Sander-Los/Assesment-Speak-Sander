namespace Kaartspel
{
    class Kaart<T>
    {
        private T waarde;
        public T Waarde { get { return waarde; } }

        public Kaart(T waarde)
        {
            this.waarde = waarde;
        }
    }
}
