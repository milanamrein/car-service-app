using CarService.Admin.Infrastructure.Events;
using CarService.Admin.Infrastructure.Prism;
using CarService.Admin.Infrastructure.Services;
using CarService.DTO;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Modules.Worksheet.ViewModels
{
    /// <summary>
    /// AddWorksheet page ViewModel
    /// </summary>
    public class AddWorksheetViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        #region Fields

        /// <summary>
        /// Materials Service
        /// </summary>
        private readonly IMaterialService _materialService;

        /// <summary>
        /// Navigation field
        /// </summary>
        private readonly INavigation _navigation;

        /// <summary>
        /// The authenticated user
        /// </summary>
        private UserDTO _user;

        /// <summary>
        /// Reservation which the worksheet will be created for
        /// </summary>
        private ReservationDTO _reservation;

        /// <summary>
        /// The list of materials
        /// </summary>
        private ObservableCollection<MaterialDTO> _materials;

        /// <summary>
        /// The list of added materials
        /// </summary>
        private ObservableCollection<MaterialDTO> _addedMaterials;

        /// <summary>
        /// The total order price
        /// </summary>
        private double _totalPrice;

        /// <summary>
        /// An error message
        /// </summary>
        private string _errorMessage;

        /// <summary>
        /// Indicates whether the page is loading or not
        /// </summary>
        private bool _isLoading;

        #endregion

        #region Default Constructor

        public AddWorksheetViewModel(IMaterialService materialService, INavigation navigation)
        {
            _materialService = materialService;
            _navigation = navigation;
            _materials = new ObservableCollection<MaterialDTO>();            
            _addedMaterials = new ObservableCollection<MaterialDTO>();            
            this.AddSelectedMaterialCommand = new DelegateCommand<MaterialDTO>((material) => AddSelectedMaterial(material));
            this.RemoveSelectedMaterialCommand = new DelegateCommand<MaterialDTO>((material) => RemoveSelectedMaterial(material));
            this.ConfirmWorksheetCommand = new DelegateCommand(ConfirmWorksheet);
            _navigation.EventAggregator.GetEvent<CreateWorksheetFailedEvent>().Subscribe(message => this.ErrorMessage = message);
            _totalPrice = 0;            
        }        

        #endregion

        #region Public Properties

        /// <summary>
        /// The authenticated user property
        /// </summary>
        public UserDTO User
        {
            get { return this._user; }
            set { SetProperty(ref _user, value); }
        }        

        /// <summary>
        /// Reservation property which the worksheet will be created for
        /// </summary>
        public ReservationDTO Reservation
        {
            get { return this._reservation; }
            set { SetProperty(ref _reservation, value); }
        }

        /// <summary>
        /// Property list of materials 
        /// </summary>
        public ObservableCollection<MaterialDTO> Materials
        {
            get { return this._materials; }
            set { SetProperty(ref _materials, value); }
        }

        /// <summary>
        /// Property list of added materials 
        /// </summary>
        public ObservableCollection<MaterialDTO> AddedMaterials
        {
            get { return this._addedMaterials; }
            set { SetProperty(ref _addedMaterials, value); }
        }

        /// <summary>
        /// The total order price property
        /// </summary>
        public double TotalPrice
        {
            get { return this._totalPrice; }
            set { SetProperty(ref _totalPrice, value); }
        }

        /// <summary>
        /// Navigation command
        /// </summary>
        public DelegateCommand<string> NavigateCommand => _navigation.NavigateCommand;

        /// <summary>
        /// Command of adding a new material to the
        /// AddedMaterials list
        /// </summary>
        public DelegateCommand<MaterialDTO> AddSelectedMaterialCommand { get; set; }

        /// <summary>
        /// Command of removing a material from the
        /// AddedMaterials list
        /// </summary>
        public DelegateCommand<MaterialDTO> RemoveSelectedMaterialCommand { get; set; }

        /// <summary>
        /// Command of confirming the worksheet
        /// </summary>
        public DelegateCommand ConfirmWorksheetCommand { get; set; }

        /// <summary>
        /// Error message property
        /// </summary>
        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }
        
        /// <summary>
        /// Property which indicates whether the page is loading or not
        /// </summary>
        public bool IsLoading
        {
            get { return this._isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }        

        /// <summary>
        /// Indicates whether the VM object should be destroyed
        /// after it reaches from activated to deactivated state
        /// </summary>
        public bool KeepAlive => true;

        #endregion

        #region Methods

        /// <summary>
        /// Gets all the materials if it has not already done so
        /// </summary>
        private async Task GetAllMaterialsAsync()
        {
            try
            {

                if(_materials.Count <= 0)
                {
                    List<MaterialDTO> materialsList = await _materialService.GetMaterialsAsync(_user.Token);
                    if(materialsList.Count > 0)
                        foreach (MaterialDTO material in materialsList)                    
                            _materials.Add(material);                    
                }                

            } catch(Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }            
        }

        /// <summary>
        /// Adds a new material to the
        /// AddedMaterials list
        /// </summary>
        /// <param name="material">The material to add</param>
        private void AddSelectedMaterial(MaterialDTO material)
        {
            // check if the material is added
            bool isMaterialAlreadyAdded = _addedMaterials.Any(mat => mat.Id.Equals(material.Id));
            if (!isMaterialAlreadyAdded)
            {
                // if not, add it
                material.Quantity = 1;
                _addedMaterials.Add(material);
            }
            else
            {
                // if it has been added, increase its quantity with one
                MaterialDTO addedMaterial = _addedMaterials
                    .FirstOrDefault<MaterialDTO>(mat => mat.Id.Equals(material.Id));
                addedMaterial.Quantity++;
            }

            // calculate the new total price
            this.TotalPrice = this.CalculateTotalPrice();
        }

        /// <summary>
        /// Removes a material frome the
        /// AddedMaterials list
        /// </summary>
        /// <param name="material">The material to remove</param>
        private void RemoveSelectedMaterial(MaterialDTO material)
        {
            if (material.Quantity > 1)
            {      
                // decrease its quantity with one
                MaterialDTO selectedMaterial = _addedMaterials
                    .FirstOrDefault<MaterialDTO>(mat => mat.Id.Equals(material.Id));
                selectedMaterial.Quantity--;
            }
            else
            {
                // remove it, if its quantity is 1
                _addedMaterials.Remove(material);
            }

            // calculate the new total price
            this.TotalPrice = this.CalculateTotalPrice();
        }

        /// <summary>
        /// Calculates the total price
        /// of the order
        /// </summary>
        /// <returns>The total price</returns>
        private double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (MaterialDTO material in _addedMaterials)
            {
                totalPrice += (material.Quantity * material.Price);
            }
            
            return totalPrice;
        }

        /// <summary>
        /// Confirms the worksheet
        /// </summary>
        private void ConfirmWorksheet()
        {
            // creating worksheet object as navigation parameter
            NavigationParameters navigationParameters = new NavigationParameters
            {
                {
                    "Worksheet", new WorksheetDTO
                    {
                        Partner = this.Reservation.Partner,
                        Mechanic = this.User,
                        Reservation = this.Reservation,
                        Materials = _addedMaterials
                    }
                }
            };

            // navigate to confirmation page
            _navigation.NavigateTo("CreateWorksheet", navigationParameters);
        }

        #endregion

        #region INavigationAwareMethods

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            try
            {
                
                if (navigationContext.Parameters["NewWorksheet"] != null)
                {
                    this.IsLoading = true;

                    _user = new UserDTO();
                    _reservation = new ReservationDTO();
                    _addedMaterials.Clear();
                    this.TotalPrice = 0;

                    this.User = (UserDTO)navigationContext.Parameters["User"];
                    this.Reservation = (ReservationDTO)navigationContext.Parameters["Reservation"];
                    await this.GetAllMaterialsAsync();
                }

            } catch(Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
            finally
            {
                this.IsLoading = false;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.ErrorMessage = string.Empty;            
        }

        #endregion
    }
}
