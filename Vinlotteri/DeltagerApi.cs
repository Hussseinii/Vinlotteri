namespace Vinlotteri
{
    public class DeltagerApi : IDeltagerApi
    {
        private readonly IList<Deltager> _deltager;
        public IList<Deltager> Deltager { get => _deltager; }
        public DeltagerApi()
        {
            _deltager = new List<Deltager>();
        }
        public void AddDeltager(Deltager deltager)
        {
          
          if(deltager!=null)
          _deltager.Add(deltager);
        }

        public Deltager GetDeltager(string navn)
        {
           return _deltager.FirstOrDefault(x => x.Navn == navn);
        }
    }

}