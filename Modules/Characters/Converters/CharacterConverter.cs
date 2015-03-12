namespace Characters.Converters
{
    using Characters.DataContracts;

    using RpgTools.Core.Common;
    using RpgTools.Core.Models.Characters;

    internal sealed class CharacterConverter : IConverter<CharacterDataContract, Character>
    {
        public Character Convert(CharacterDataContract value)
        {
            throw new System.NotImplementedException();
        }
    }
}