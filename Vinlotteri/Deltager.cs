using System.Collections.Generic;

namespace Vinlotteri
{
    public class Deltager
    {
        public string Navn { get; set; }
        public IList<Lodd> Lodd { get; set; }
    }
}