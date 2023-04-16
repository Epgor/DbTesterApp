using Microsoft.IdentityModel.Tokens;

namespace DbTesterApp.Services
{
    public class HashIdentifierService
    {
        private static int[] intTab;
        private static Dictionary<int, string> intMap;
        private ulong fastId = 10000000000000000000;
        static object idLock = new object();
        static object idFastLock = new object();
        public HashIdentifierService()
        {
            intTab = PopulateIntTab();
            intMap = PopulateIntMap();
        }
        public async Task<string> GetFastHashId()
        {
            lock (idFastLock)
            {
                fastId++;
                return $"A000{fastId}";
            }
        }
        public async Task<string> GetHashId()
        {
            string hashId;
            int[] _intTab;
            lock(idLock)
            {
                PushNextId();
                _intTab = intTab;
            }
            hashId = await GetString(_intTab);
            return hashId;
        }
        private void PushNextId()
        {
            int currentPosition = intTab.Length - 1;

            while (currentPosition > 0)
            {
                if (intTab[currentPosition] >= 15)
                {
                    intTab[currentPosition] = 0;
                    currentPosition--;
                }
                else { break; }
            }

            intTab[currentPosition]++;
        }
           
        private async Task<string> GetString(int[] tab)
        {
            string resultString = "";
            await Task.Run(() =>
            {
                for (int i = 0; i < intTab.Length; i++)
                {
                    resultString += intMap[intTab[i]];
                };
            });

            return resultString;
        }

        private int[] PopulateIntTab()
        {
            return new int[]
            {
                1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,0,
                0,0,0,0
            };
        }

        private Dictionary<int, string> PopulateIntMap()
        {
            return new Dictionary<int, string>()
            {
                {0, "0"},
                {1, "1"},
                {2, "2"},
                {3, "3"},
                {4, "4"},
                {5, "5"},
                {6, "6"},
                {7, "7"},
                {8, "8"},
                {9, "9"},
                {10, "A"},
                {11, "B"},
                {12, "C"},
                {13, "D"},
                {14, "E"},
                {15, "F"}
            };
        }

        public async Task<T> SetId<T>(T oldObject, bool isFast=false)
        {
            var newObject = oldObject;
            var id = "";
            if (isFast)
                id = await GetFastHashId();
            else
                id = await GetHashId();
            Type type = typeof(T);

            var idProperty = type.GetProperty("Id");

            if (idProperty == null)
                return oldObject;

            idProperty.SetValue(newObject, id);

            return newObject;
        }
    }

}
