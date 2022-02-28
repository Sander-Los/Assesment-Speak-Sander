using System.Collections.Generic;

namespace Kaartspel
{
    abstract class Ronde
    {
        public abstract List<Kaart<int>> VerdeelKaarten(int winnaar);
        public abstract int VoerUit();
    }
}
