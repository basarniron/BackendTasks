namespace BackendTasks.Entity.Models
{
    /// <summary>
    /// AdviserUserDetails model
    /// </summary>
    /// <seealso cref="BackendTasks.Entity.Models.UserDetails" />
    public class AdviserUserDetails : UserDetails
    {
        /// <summary>
        /// Gets or sets the nation insurance number.
        /// </summary>
        /// <value>
        /// The nation insurance number.
        /// </value>
        public string NationInsuranceNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }
    }
}
