using System.Collections.Generic;

namespace BackendTask.Business.Contracts.Messages
{
    public class ResponseMessage
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the validation messages.
        /// </summary>
        /// <value>
        /// The validation messages.
        /// </value>
        public List<string> ValidationMessages { get; set; }
    }
}
