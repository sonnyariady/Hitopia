using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitopia.ModulFungsi
{
    public class StringWeight
    {
        public string InputString { get; set; }
        public string ArrayQuery { get; set; }
        public List<string> ListInvalid { get; set; } = new List<string>();
        public string[] ArrQueryResult { get; set; }

        public bool IsValid
        {
            get
            {
                return ListInvalid.Count == 0;
            }
        }

        public StringWeight(string inputstring, string arrayquery)
        {
            InputString = inputstring;
            ArrayQuery = arrayquery;
        }

        public void GenerateResult()
        {
            List<string> lstInvalid = new List<string>();
            if (string.IsNullOrWhiteSpace(InputString))
            {
                ListInvalid.Add("InputString cannot be blank");
            }
            if (string.IsNullOrWhiteSpace(ArrayQuery))
            {
                ListInvalid.Add("ArrayQuery cannot be blank");
            }
            else
            {
                try
                {
                    int[] query = ArrayQuery.Split(',').Select(Int32.Parse).ToArray();
                    
                }
                catch (Exception)
                {
                    ListInvalid.Add("The string query input is not valid!");
                }
            }

            if (ListInvalid.Count == 0)
            {
                int[] query = ArrayQuery.Split(',').Select(Int32.Parse).ToArray();
                var arrsub = GenerateArrayQuery(InputString);
                ArrQueryResult = GenerateQueryResult(query, arrsub);
            }

        }

        public static string[] GenerateQueryResult(int[] arrqry, int[] arrsubQuery)
        {
            List<string> qryResult = new List<string>();
            foreach (int intitem in arrqry)
            {
                qryResult.Add(arrsubQuery.Contains(intitem) ? "Yes" : "No");

            }
            return qryResult.ToArray();
        }

        public int[] GenerateArrayQuery(string str)
        {
            List<int> lstSubquery = new List<int>();
            foreach (var ch in str)
            {
                int iCh = 1;
                bool IsHasSubs = true;
                while (IsHasSubs)
                {
                    string strsubcheck = new String(ch, iCh);
                    if (str.Contains(strsubcheck))
                    {
                        int weightcombination = CalculateStringWeight(strsubcheck);
                        if (lstSubquery.IndexOf(weightcombination) == -1)
                            lstSubquery.Add(CalculateStringWeight(strsubcheck));
                    }
                    else
                        IsHasSubs = false;
                    iCh++;
                }
            }

            return lstSubquery.ToArray();
        }

        public int CalculateCharacterWeight(char c)
        {
            // Ensure the character is lowercase to handle both uppercase and lowercase input
            c = char.ToLower(c);
            // Calculate the weight: 'a' = 1, 'b' = 2, ..., 'z' = 26
            return c - 'a' + 1;
        }

        public int CalculateStringWeight(string input)
        {
            int totalWeight = 0;

            foreach (char c in input)
            {
                totalWeight += CalculateCharacterWeight(c);
            }

            return totalWeight;
        }
    }
}
