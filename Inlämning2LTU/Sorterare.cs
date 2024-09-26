
namespace Inlämning2LTU
{
    public static class Sorterare
    {
        public static void SorteraSäljare(List<Säljare> säljare)
        {
            bool bytt;
            do
            {
                bytt = false;
                for (int i = 0; i < säljare.Count - 1; i++)
                {
                    if (säljare[i].AntalSåldaArtiklar > säljare[i + 1].AntalSåldaArtiklar)
                    {
                        var temp = säljare[i];
                        säljare[i] = säljare[i + 1];
                        säljare[i + 1] = temp;
                        bytt = true;
                    }
                }
            } while (bytt);
        }
    }
}
