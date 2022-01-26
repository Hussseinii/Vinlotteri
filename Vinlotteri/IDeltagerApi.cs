namespace Vinlotteri
{
    public interface IDeltagerApi
    {
        void AddDeltager(Deltager deltager);
        Deltager GetDeltager(string navn);
    }

}