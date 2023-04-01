﻿namespace DbTesterApp.Services
{
    public class HashIdentifierService
    {
        private static char[] hashTab;
        
        public HashIdentifierService()
        {
            hashTab = PopulateHashTab();
        }
        private static void CheckSize(char c, int localId)
        {
            if (c == 'F' & localId == 0)
                throw new Exception("Max size exceeded");
        }
        public string GetHashId()
        {
            var localId = hashTab.Length - 1;
            while (hashTab[localId] == 'F')
            {
                CheckSize(hashTab[localId], localId);

                hashTab[localId] = '0';
                localId--;
            }
            var tempChar = (char)(hashTab[localId] + 1);
            if (tempChar == ':') tempChar= 'A';
            hashTab[localId] = tempChar;

            return new string(hashTab);
        }

        private static char[] PopulateHashTab()
        {
            var _hashTab = new char[24];
            for (int i = 0; i < 24; i++)
            {
                _hashTab[i] = 'A';
            }
            return _hashTab;
        }
    }

}
