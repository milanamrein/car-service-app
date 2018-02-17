using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Linq;

namespace CarService.Admin.Infrastructure.Prism
{
    /// <summary>
    /// Base class for navigation
    /// </summary>
    public class Navigation : INavigation
    {
        #region Fields

        /// <summary>
        /// Region manager to make navigation requests
        /// </summary>
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// Aggregator for publishing and subscribing to events 
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// <see cref="RegionNames.CONTENT_REGION"/>
        /// </summary>
        private IRegion _contentRegion;

        /// <summary>
        /// <see cref="RegionNames.PROFILE_REGION"/>
        /// </summary>
        private IRegion _profileRegion;

        #endregion

        #region Default Constructor

        public Navigation(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _contentRegion = _regionManager.Regions[RegionNames.CONTENT_REGION];
            _profileRegion = _regionManager.Regions[RegionNames.PROFILE_REGION];
            this.NavigateCommand = new DelegateCommand<string>((uri) => 
                this.NavigateTo(uri, new NavigationParameters()));
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The navigation command property
        /// </summary>
        public DelegateCommand<string> NavigateCommand { get; set; }

        /// <summary>
        /// The event aggregator property
        /// </summary>
        public IEventAggregator EventAggregator => _eventAggregator;

        #endregion

        #region Methods

        /// <summary>
        /// Default navigation function within <see cref="RegionNames.CONTENT_REGION"/>
        /// </summary>
        /// <param name="uri">The page uri to navigate to</param>
        /// <param name="navigationParameters">Data to pass during navigation</param>
        public void NavigateTo(string uri, NavigationParameters navigationParameters)
        {
            _regionManager.RequestNavigate(RegionNames.CONTENT_REGION, uri, navigationParameters);
        }

        /// <summary>
        /// Navigation function within <see cref="RegionNames.NAVBAR_REGION"/>
        /// </summary>
        /// <param name="uri">The page uri to navigate to</param>
        public void NavigateToWithinNavbarRegion(string uri)
        {
            _regionManager.RequestNavigate(RegionNames.NAVBAR_REGION, uri);
        }

        /// <summary>
        /// Navigation function within <see cref="RegionNames.PROFILE_REGION"/>
        /// </summary>
        /// <param name="uri">The page uri to navigate to</param>
        /// <param name="navigationParameters">Data to pass during navigation</param>
        public void NavigateToWithinProfileRegion(string uri, NavigationParameters navigationParameters)
        {
            _regionManager.RequestNavigate(RegionNames.PROFILE_REGION, uri, navigationParameters);
        }

        /// <summary>
        /// Removes a view from <see cref="RegionNames.CONTENT_REGION"/>
        /// </summary>
        /// <param name="viewName">The view's name</param>
        public void RemoveFromContentRegion(string viewName)
        {
            var contentView = _contentRegion.Views.Single(v => v.GetType().Name.Equals(viewName));
            _contentRegion.Remove(contentView);            
        }

        /// <summary>
        /// Removes a view from <see cref="RegionNames.PROFILE_REGION"/>
        /// </summary>
        /// <param name="viewName">The view's name</param>
        public void RemoveFromProfileRegion(string viewName)
        {
            var profileView = _profileRegion.Views.Single(v => v.GetType().Name.Equals(viewName));
            _profileRegion.Remove(profileView);            
        }

        #endregion
    }
}
