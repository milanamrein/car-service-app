using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Prism
{
    /// <summary>
    /// Interface for navigation
    /// </summary>
    public interface INavigation
    {
        /// <summary>
        /// The navigation command
        /// </summary>
        DelegateCommand<string> NavigateCommand { get; set; }

        /// <summary>
        /// The event aggregator property
        /// </summary>
        IEventAggregator EventAggregator { get; }

        /// <summary>
        /// Default navigation function within <see cref="RegionNames.CONTENT_REGION"/>
        /// </summary>
        /// <param name="uri">The page uri to navigate to</param>
        /// <param name="navigationParameters">Data to pass during navigation</param>
        void NavigateTo(string uri, NavigationParameters navigationParameters);

        /// <summary>
        /// Navigation function within <see cref="RegionNames.NAVBAR_REGION"/>
        /// </summary>
        /// <param name="uri">The page uri to navigate to</param>
        void NavigateToWithinNavbarRegion(string uri);

        /// <summary>
        /// Navigation function within <see cref="RegionNames.PROFILE_REGION"/>
        /// </summary>
        /// <param name="uri">The page uri to navigate to</param>
        /// <param name="navigationParameters">Data to pass during navigation</param>
        void NavigateToWithinProfileRegion(string uri, NavigationParameters navigationParameters);

        /// <summary>
        /// Removes a view from <see cref="RegionNames.CONTENT_REGION"/>
        /// </summary>
        /// <param name="viewName">The view's name</param>
        void RemoveFromContentRegion(string viewName);

        /// <summary>
        /// Removes a view from <see cref="RegionNames.PROFILE_REGION"/>
        /// </summary>
        /// <param name="viewName">The view's name</param>
        void RemoveFromProfileRegion(string viewName);
    }
}
