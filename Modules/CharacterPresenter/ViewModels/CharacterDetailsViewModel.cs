namespace CharacterPresenter.ViewModels
{
    using Caliburn.Micro;
    using RpgTools.Core.Common;
    using RpgTools.Core.Models;

    public class CharacterDetailsViewModel : Screen
    {
        private ICharacterRepository characterRepository;

        private IWindowManager windowManager;

        private IEventAggregator eventAggregator;

        public CharacterDetailsViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            this.eventAggregator = eventAggregator;
            this.windowManager = windowManager;
            
        }

        public Character Chracter { get; set; }
    }
}