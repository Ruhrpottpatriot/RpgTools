namespace RpgTools.Characters
{
    using System.Diagnostics.Contracts;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    internal sealed class TagDataContractConverter : IConverter<TagDataContract, Tag>
    {
        /// <inheritdoc />
        public Tag Convert(TagDataContract value)
        {
            Contract.Assume(value != null);

            return new Tag { Id = value.Id, Value = value.Tag, Type = value.Type };
        }
    }
}