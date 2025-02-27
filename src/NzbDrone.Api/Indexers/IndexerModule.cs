using NzbDrone.Core.Indexers;

namespace NzbDrone.Api.Indexers
{
    public class IndexerModule : ProviderModuleBase<IndexerResource, IIndexer, IndexerDefinition>
    {
        public IndexerModule(IndexerFactory indexerFactory)
            : base(indexerFactory, "indexer")
        {
        }

        protected override void MapToResource(IndexerResource resource, IndexerDefinition definition)
        {
            base.MapToResource(resource, definition);
            
            resource.EnableRss = definition.EnableRss;
            resource.EnableSearch = definition.EnableAutomaticSearch || definition.EnableInteractiveSearch;
            resource.SupportsRss = definition.SupportsRss;
            resource.SupportsSearch = definition.SupportsSearch;
            resource.Protocol = definition.Protocol;
            resource.Priority = definition.Priority;
        }

        protected override void MapToModel(IndexerDefinition definition, IndexerResource resource)
        {
            base.MapToModel(definition, resource);

            definition.EnableRss = resource.EnableRss;
            definition.EnableAutomaticSearch = resource.EnableSearch;
            definition.EnableInteractiveSearch = resource.EnableSearch;
            definition.Priority = resource.Priority;
        }
    }
}
