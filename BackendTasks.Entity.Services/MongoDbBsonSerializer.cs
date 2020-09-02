using MongoDB.Bson.Serialization.Conventions;

namespace BackendTasks.Entity.Services
{
    /// <summary>
    /// 
    /// </summary>
    public static class MongoDbBsonSerializer
    {
        /// <summary>
        /// Configures this instance.
        /// </summary>
        public static void Configure()
        {
            var conventionPack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("Backend task convention pack", conventionPack, t => true);
        }
    }
}
