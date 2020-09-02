using System;

namespace BackendTasks.Entity.Models
{
    /// <summary>
    /// Asset model
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        /// <value>
        /// The current value.
        /// </value>
        public decimal CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the allocation.
        /// </summary>
        /// <value>
        /// The allocation.
        /// </value>
        public decimal Allocation { get; set; }
    }
}
