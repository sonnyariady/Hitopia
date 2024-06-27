namespace Hitopia.ModulFungsi
{
    public class LargestPalindrome
    {
        public string InputString { get; set; }
        public int K { get; set; }
        public string PalindromResult { get; set; }
        public LargestPalindrome(string inputstring, int k)
        {
            InputString = inputstring;
            K = k;
        }

        public void GenerateResult()
        {
            this.PalindromResult = MakeLargestPalindrome(InputString, K);
        }

        private string MakeLargestPalindrome(string s, int k)
        {
            char[] arr = s.ToCharArray();
            bool[] changed = new bool[arr.Length];

            if (!MakePalindrome(arr, 0, arr.Length - 1, k, changed))
            {
                return "-1";
            }

            MaximizePalindrome(arr, 0, arr.Length - 1, ref k, changed);
            return new string(arr);
        }

        private bool MakePalindrome(char[] arr, int left, int right, int k, bool[] changed)
        {
            if (left >= right)
            {
                return k >= 0;
            }

            if (arr[left] != arr[right])
            {
                if (k == 0)
                {
                    return false;
                }

                if (arr[left] > arr[right])
                {
                    arr[right] = arr[left];
                }
                else
                {
                    arr[left] = arr[right];
                }

                changed[left] = true;
                changed[right] = true;
                k--;
            }

            return MakePalindrome(arr, left + 1, right - 1, k, changed);
        }

        private void MaximizePalindrome(char[] arr, int left, int right, ref int k, bool[] changed)
        {
            if (left >= right || k <= 0)
            {
                return;
            }

            if (arr[left] < '9')
            {
                if (arr[left] == arr[right])
                {
                    if (changed[left] || changed[right])
                    {
                        arr[left] = '9';
                        arr[right] = '9';
                        k--;
                    }
                    else if (k >= 2)
                    {
                        arr[left] = '9';
                        arr[right] = '9';
                        k -= 2;
                    }
                }
                else
                {
                    if (k >= 1)
                    {
                        arr[left] = '9';
                        arr[right] = '9';
                        k--;
                    }
                }
            }

            MaximizePalindrome(arr, left + 1, right - 1, ref k, changed);
        }
    }
}
