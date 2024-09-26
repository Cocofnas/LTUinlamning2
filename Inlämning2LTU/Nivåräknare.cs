
namespace Inlämning2LTU
{
    public static class NivåRäknare
    {
        public static Dictionary<string, int> RäknaNivåer(List<Säljare> säljare)
        {
            Dictionary<string, int> nivåer = new Dictionary<string, int>
            {
                { "Under 50 artiklar", 0 },
                { "50-99 artiklar", 0 },
                { "100-199 artiklar", 0 },
                { "Över 199 artiklar", 0 }
            };

            foreach (var säljareItem in säljare)
            {
                if (säljareItem.AntalSåldaArtiklar < 50)
                {
                    nivåer["Under 50 artiklar"]++;
                }
                else if (säljareItem.AntalSåldaArtiklar < 100)
                {
                    nivåer["50-99 artiklar"]++;
                }
                else if (säljareItem.AntalSåldaArtiklar < 200)
                {
                    nivåer["100-199 artiklar"]++;
                }
                else
                {
                    nivåer["Över 199 artiklar"]++;
                }
            }

            return nivåer;
        }
    }
}
