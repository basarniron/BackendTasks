using System.Linq;
using System.Text.RegularExpressions;

namespace BackendTask.Business.Services.BinaryCheck
{
    /// <summary>
    /// BinaryCheckService
    /// </summary>
    public static class BinaryCheckService
    {
        /// <summary>
        /// Checks the specified binary data.
        /// </summary>
        /// <param name="binaryData">The binary data.</param>
        /// <returns></returns>
        public static bool Check(string binaryData)
        {
            //1. is null or empty
            if (string.IsNullOrEmpty(binaryData))
            {
                return false;
            }

            //2. check data is binary
            var isBinaryData = Regex.IsMatch(binaryData, "^[01]+$");
            if (!isBinaryData)
            {
                return false;
            }

            //3. check if length is odd number which makes it impossible to have equal number of 0s and 1s
            if (binaryData.Length % 2 != 0)
            {
                return false;
            }

            //4. Number of 0's and 1's are equal 
            //this will catch the cases for the 4th step up to 2 digits (0, 00)
            if (GetNumOfChars(binaryData, '1') != binaryData.Length / 2)
            {
                return false;
            }

            //5. Prefix check - number of 1's can not be less than 0's in each prefix
            //4th step covers the cases up to 2 digits
            //3rd step covers the full length check
            for (int i = 3; i < binaryData.Length; i++)
            {
                var temp = binaryData.Substring(0, i);
                if (GetNumOfChars(temp, '0') > GetNumOfChars(temp, '1'))
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetNumOfChars(string binaryData, char num)
        {
            return binaryData.Count(c => c == num);
        }
    }
}
