namespace RpgTools.Characters
{
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    internal class AppearanceDataContractConverter : IConverter<AppearanceDataContract, Character.PhysicalAppearance>
    {
        private readonly IConverter<int, Character.PhysicalAppearance.Genders> gendersConverter;

        public AppearanceDataContractConverter()
            : this(new GenderConverter())
        {
        }

        public AppearanceDataContractConverter(IConverter<int, Character.PhysicalAppearance.Genders> gendersConverter)
        {
            this.gendersConverter = gendersConverter;
        }

        ///<inheritdoc /> 
        public Character.PhysicalAppearance Convert(AppearanceDataContract value)
        {
            Character.PhysicalAppearance appearance = new Character.PhysicalAppearance
            {
                Bust = value.Bust,
                CupSize = value.CupSize,
                EyeColour = value.EyeColour,
                Gender = this.gendersConverter.Convert(value.Gender),
                HairColour = value.HairColour,
                Height = value.Height,
                HeterochromiaIridum = value.HeterochromiaIridum,
                Hip = value.Hip,
                LipColour = value.LipColour,
                SkinColour = value.SkinColour,
                Waist = value.Waist,
                Weight = value.Weight
            };

            return appearance;
        }
    }
}