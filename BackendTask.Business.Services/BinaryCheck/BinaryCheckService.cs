using System.Linq;
using System.Text.RegularExpressions;

namespace BackendTask.Business.Services.BinaryCheck
{
    /// <summary>
    /// BinaryCheckService
    /// </summary>
    public class BinaryCheckService
    {

        /// <summary>
        /// Checks the specified binary data.
        /// </summary>
        /// <param name="binaryData">The binary data.</param>
        /// <returns></returns>
        public bool Check(string binaryData)
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

            //3. Number of 0's and 1's are equal 
            //this will catch the cases for the 4th step up to 2 digits (0, 00)
            var numOfZeros = GetNumOfChars(binaryData, '0');
            var numOfOnes = GetNumOfChars(binaryData, '1');
            if (numOfOnes != numOfZeros)
            {
                return false;
            }

            //4. Prefix check - number of 1's can not be less than 0's in each prefix
            //3rd step covers the cases up to 2 digits (0, 00)
            //2nd step covers the whole length check
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
