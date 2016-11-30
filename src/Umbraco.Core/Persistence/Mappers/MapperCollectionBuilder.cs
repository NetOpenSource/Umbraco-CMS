﻿using LightInject;
using Umbraco.Core.DI;

namespace Umbraco.Core.Persistence.Mappers
{
    public class MapperCollectionBuilder : LazyCollectionBuilderBase<MapperCollectionBuilder, MapperCollection, BaseMapper>
    {
        public MapperCollectionBuilder(IServiceContainer container) 
            : base(container)
        { }

        protected override MapperCollectionBuilder This => this;

        protected override void Initialize()
        {
            base.Initialize();

            // default initializer registers
            // - service MapperCollectionBuilder, returns MapperCollectionBuilder
            // - service MapperCollection, returns MapperCollectionBuilder's collection
            // we want to register extra
            // - service IMapperCollection, returns MappersCollectionBuilder's collection

            Container.Register<IMapperCollection>(factory => factory.GetInstance<MapperCollection>());
        }

        public MapperCollectionBuilder AddCore()
        {
            Add<AccessMapper>();
            Add<AuditItemMapper>();
            Add<ContentMapper>();
            Add<ContentTypeMapper>();
            Add<DataTypeDefinitionMapper>();
            Add<DictionaryMapper>();
            Add<DictionaryTranslationMapper>();
            Add<DomainMapper>();
            Add<LanguageMapper>();
            Add<MacroMapper>();
            Add<MediaMapper>();
            Add<MediaTypeMapper>();
            Add<MemberGroupMapper>();
            Add<MemberMapper>();
            Add<MemberTypeMapper>();
            Add<MigrationEntryMapper>();
            Add<PropertyGroupMapper>();
            Add<PropertyMapper>();
            Add<PropertyTypeMapper>();
            Add<RelationMapper>();
            Add<RelationTypeMapper>();
            Add<ServerRegistrationMapper>();
            Add<TagMapper>();
            Add<TaskTypeMapper>();
            Add<TemplateMapper>();
            Add<UmbracoEntityMapper>();
            Add<UserMapper>();
            Add<ExternalLoginMapper>();
            Add<UserTypeMapper>();
            return this;
        }
    }
}
