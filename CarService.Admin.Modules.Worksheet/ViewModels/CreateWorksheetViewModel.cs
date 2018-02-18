using CarService.Admin.Infrastructure.Events;
using CarService.Admin.Infrastructure.Prism;
using CarService.Admin.Infrastructure.Services;
using CarService.DTO;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Modules.Worksheet.ViewModels
{
    public class CreateWorksheetViewModel : BindableBase, INavigationAware
    {
        #region Fields

        /// <summary>
        /// Worksheet Service
        /// </summary>
        private readonly IWorksheetService _worksheetService;

        /// <summary>
        /// Navigation field
        /// </summary>
        private readonly INavigation _navigation;

        /// <summary>
        /// The worksheet that needs to be created
        /// </summary>
        private WorksheetDTO _worksheet;

        /// <summary>
        /// Indicates whether the page is loading or not
        /// </summary>
        private bool _isLoading;

        #endregion

        #region Default Constructor

        public CreateWorksheetViewModel(IWorksheetService worksheetService, INavigation navigation)
        {
            _worksheetService = worksheetService;
            _navigation = navigation;
            _worksheet = new WorksheetDTO();
            this.CreateWorksheetCommand = new DelegateCommand(async () => await this.CreateWorksheetAsync());
        }
       
        #endregion

        #region Public Properties

        /// <summary>
        /// Navigation command
        /// </summary>
        public DelegateCommand<string> NavigateCommand => _navigation.NavigateCommand;

        /// <summary>
        /// Command of creating a new worksheet
        /// </summary>
        public DelegateCommand CreateWorksheetCommand { get; set; }
        
        /// <summary>
        /// Property which indicates whether the page is loading or not
        /// </summary>
        public bool IsLoading
        {
            get { return this._isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        #endregion        

        #region Methods

        /// <summary>
        /// Creates a new worksheet
        /// </summary>
        private async Task CreateWorksheetAsync()
        {
            try
            {

                this.IsLoading = true;

                int createdWorksheetId = await _worksheetService.CreateWorksheetAsync(_worksheet, _worksheet.Mechanic.Token);
                _navigation.EventAggregator.GetEvent<WorksheetCreatedSuccessfullyEvent>()
                    .Publish(
                        $"Worksheet for " +
                        $"{_worksheet.Partner.FullName} on " +
                        $"{_worksheet.Reservation.Time.Date.ToString("d")} was created successfully!"
                        );
                _navigation.NavigateTo("Reservations", new NavigationParameters { { "UserDataChanged", true } });                

            } catch(Exception ex)
            {
                // navigates back to AddWorksheet page with error message
                _navigation.EventAggregator.GetEvent<CreateWorksheetFailedEvent>()
                    .Publish(ex.Message);
                _navigation.NavigateTo("AddWorksheet", new NavigationParameters());
            } finally
            {
                this.IsLoading = false;
            }
        }

        #endregion

        #region INavigationAware Methods

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            try
            {

                // getting the worksheet data
                _worksheet = (WorksheetDTO)navigationContext.Parameters["Worksheet"];

            } catch(Exception ex)
            {
                _navigation.EventAggregator.GetEvent<UnexpectedErrorEvent>()
                    .Publish($"An unexpected error has occurred: {ex.Message}");
                _navigation.NavigateTo("Reservations", new NavigationParameters());
            }
        }

        #endregion
    }
}
