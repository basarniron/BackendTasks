using System;

namespace BackendTask.Business.Contracts
{
    /// <summary>
    /// Dob Helper
    /// </summary>
    public static class DobHelper
    {
        #region Constants

        private const string DateFormat = "yyyy-MM-dd";

        #endregion

        /// <summary>
        /// Formats the date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static string FormatDate(this DateTime date) 
        {
            return date.ToString(DateFormat);
        }
    }
}
