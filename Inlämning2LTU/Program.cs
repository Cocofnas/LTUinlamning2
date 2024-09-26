
namespace Inlämning2LTU
{
    class Program
    {
        static void Main(string[] args)
        {
            // Läs in säljaruppgifter
            List<Säljare> säljare = Input.LäsInSäljare();

            // Sortera säljarna efter antal sålda artiklar
            Sorterare.SorteraSäljare(säljare);

            // Räkna nivåer
            Dictionary<string, int> nivåer = NivåRäknare.RäknaNivåer(säljare);

            // Skriv ut resultatet
            Output.SkrivUtResultat(säljare, nivåer);
        }
    }
}
