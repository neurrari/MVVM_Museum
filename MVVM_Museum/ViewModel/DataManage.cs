using MVVM_Museum.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM_Museum.ViewModel
{
    public class DataManage : Notify
    {
        #region ACT

        private ObservableCollection<Act> _acts;

        private Act _selectedAct;

        private readonly SendAct _sendAct;

        public ObservableCollection<Act> Acts
        {
            get => _acts;
            set
            {
                _acts = value;
                OnPropertyChanged(nameof(Acts));
            }
        }

        public Act SelectedAct
        {
            get => _selectedAct;
            set
            {
                _selectedAct = value;
                OnPropertyChanged(nameof(SelectedAct));
            }
        }

        public ICommand LoadActsCommand { get; }
        public ICommand AddActCommand { get; }
        public ICommand UpdateActCommand { get; }
        public ICommand DeleteActCommand { get; }


        private async void LoadActs()
        {
            Acts = new ObservableCollection<Act>(await _sendAct.GetActs());
        }

        private async void AddAct()
        {
            await _sendAct.AddAct(SelectedAct);
            LoadActs();
        }

        private async void UpdateAct()
        {
            await _sendAct.UpdateAct(SelectedAct);
            LoadActs();
        }

        private async void DeleteAct()
        {
            await _sendAct.DeleteAct(SelectedAct.Id);
            LoadActs();
        }

        #endregion

        #region EMPLOYEE

        private ObservableCollection<Employee> _employees;

        private Employee _selectedEmployee;

        private readonly SendEmployee _sendEmployee;

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public ICommand LoadEmployeesCommand { get; }
        public ICommand AddEmployeeCommand { get; }
        public ICommand UpdateEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }

        private async void LoadEmployees()
        {
            Employees = new ObservableCollection<Employee>(await _sendEmployee.GetEmployees());
        }

        private async void AddEmployee()
        {
            await _sendEmployee.AddEmployee(SelectedEmployee);
            LoadEmployees();
        }

        private async void UpdateEmployee()
        {
            await _sendEmployee.UpdateEmployee(SelectedEmployee);
            LoadEmployees();
        }

        private async void DeleteEmployee()
        {
            await _sendEmployee.DeleteEmployee(SelectedEmployee.Id);
            LoadEmployees();
        }

        #endregion

        #region EXHIBIT

        private ObservableCollection<Exhibit> _exhibits;

        private Exhibit _selectedExhibit;

        private readonly SendExhibit _sendExhibit;

        public ObservableCollection<Exhibit> Exhibits
        {
            get => _exhibits;
            set
            {
                _exhibits = value;
                OnPropertyChanged(nameof(Exhibits));
            }
        }

        public Exhibit SelectedExhibit
        {
            get => _selectedExhibit;
            set
            {
                _selectedExhibit = value;
                OnPropertyChanged(nameof(SelectedExhibit));
            }
        }

        public ICommand LoadExhibitsCommand { get; }
        public ICommand AddExhibitCommand { get; }
        public ICommand UpdateExhibitCommand { get; }
        public ICommand DeleteExhibitCommand { get; }


        private async void LoadExhibits()
        {
            Exhibits = new ObservableCollection<Exhibit>(await _sendExhibit.GetExhibits());
        }

        private async void AddExhibit()
        {
            await _sendExhibit.AddExhibit(SelectedExhibit);
            LoadExhibits();
        }

        private async void UpdateExhibit()
        {
            await _sendExhibit.UpdateExhibit(SelectedExhibit);
            LoadExhibits();
        }

        private async void DeleteExhibit()
        {
            await _sendExhibit.DeleteExhibit(SelectedExhibit.Id);
            LoadExhibits();
        }

        #endregion

        #region EXHIBITION

        private ObservableCollection<Exhibition> _exhibitions;

        private Exhibition _selectedExhibition;

        private readonly SendExhibition _sendExhibition;

        public ObservableCollection<Exhibition> Exhibitions
        {
            get => _exhibitions;
            set
            {
                _exhibitions = value;
                OnPropertyChanged(nameof(Exhibitions));
            }
        }

        public Exhibition SelectedExhibition
        {
            get => _selectedExhibition;
            set
            {
                _selectedExhibition = value;
                OnPropertyChanged(nameof(SelectedExhibition));
            }
        }

        public ICommand LoadExhibitionsCommand { get; }
        public ICommand AddExhibitionCommand { get; }
        public ICommand UpdateExhibitionCommand { get; }
        public ICommand DeleteExhibitionCommand { get; }


        private async void LoadExhibitions()
        {
            Exhibitions = new ObservableCollection<Exhibition>(await _sendExhibition.GetExhibitions());
        }

        private async void AddExhibition()
        {
            await _sendExhibition.AddExhibition(SelectedExhibition);
            LoadExhibitions();
        }

        private async void UpdateExhibition()
        {
            await _sendExhibition.UpdateExhibition(SelectedExhibition);
            LoadExhibitions();
        }

        private async void DeleteExhibition()
        {
            await _sendExhibition.DeleteExhibition(SelectedExhibition.Id);
            LoadExhibitions();
        }

        #endregion

        #region MUSEUM  HALL

        private ObservableCollection<MuseumHall> _museumHalls;

        private MuseumHall _selectedMuseumHall;

        private readonly SendMuseumHall _sendMuseumHall;

        public ObservableCollection<MuseumHall> MuseumHalls
        {
            get => _museumHalls;
            set
            {
                _museumHalls = value;
                OnPropertyChanged(nameof(MuseumHalls));
            }
        }

        public MuseumHall SelectedMuseumHall
        {
            get => _selectedMuseumHall;
            set
            {
                _selectedMuseumHall = value;
                OnPropertyChanged(nameof(SelectedMuseumHall));
            }
        }

        public ICommand LoadMuseumHallsCommand { get; }
        public ICommand AddMuseumHallCommand { get; }
        public ICommand UpdateMuseumHallCommand { get; }
        public ICommand DeleteMuseumHallCommand { get; }

        private async void LoadMuseumHalls()
        {
            MuseumHalls = new ObservableCollection<MuseumHall>(await _sendMuseumHall.GetMuseumHalls());
        }

        private async void AddMuseumHall()
        {
            await _sendMuseumHall.AddMuseumHall(SelectedMuseumHall);
            LoadMuseumHalls();
        }

        private async void UpdateMuseumHall()
        {
            await _sendMuseumHall.UpdateMuseumHall(SelectedMuseumHall);
            LoadMuseumHalls();
        }

        private async void DeleteMuseumHall()
        {
            await _sendMuseumHall.DeleteMuseumHall(SelectedMuseumHall.Id);
            LoadMuseumHalls();
        }

        #endregion

        #region POSITION

        private ObservableCollection<Position> _positions;

        private Position _selectedPosition;

        private readonly SendPosition _sendPosition;

        public ObservableCollection<Position> Positions
        {
            get => _positions;
            set
            {
                _positions = value;
                OnPropertyChanged(nameof(Positions));
            }
        }

        public Position SelectedPosition
        {
            get => _selectedPosition;
            set
            {
                _selectedPosition = value;
                OnPropertyChanged(nameof(SelectedPosition));
            }
        }

        public ICommand LoadPositionsCommand { get; }
        public ICommand AddPositionCommand { get; }
        public ICommand UpdatePositionCommand { get; }
        public ICommand DeletePositionCommand { get; }

        private async void LoadPositions()
        {
            Positions = new ObservableCollection<Position>(await _sendPosition.GetPositions());
        }

        private async void AddPosition()
        {
            await _sendPosition.AddPosition(SelectedPosition);
            LoadPositions();
        }

        private async void UpdatePosition()
        {
            await _sendPosition.UpdatePosition(SelectedPosition);
            LoadPositions();
        }

        private async void DeletePosition()
        {
            await _sendPosition.DeletePosition(SelectedPosition.Id);
            LoadPositions();
        }

        #endregion

        #region RECEPTION WAY

        private ObservableCollection<ReceptionWay> _recepWays;

        private ReceptionWay _selectedReceptionWay;

        private readonly SendReceptionWay _sendReceptionWay;

        public ObservableCollection<ReceptionWay> ReceptionWays
        {
            get => _recepWays;
            set
            {
                _recepWays = value;
                OnPropertyChanged(nameof(ReceptionWays));
            }
        }

        public ReceptionWay SelectedReceptWay
        {
            get => _selectedReceptionWay;
            set
            {
                _selectedReceptionWay = value;
                OnPropertyChanged(nameof(SelectedReceptWay));
            }
        }

        public ICommand LoadReceptionWaysCommand { get; }

        private async void LoadReceptionWays()
        {
            ReceptionWays = new ObservableCollection<ReceptionWay>(await _sendReceptionWay.GetReceptionWays());
        }

        #endregion

        #region STORAGE

        private ObservableCollection<Storage> _storages;

        private Storage _selectedStorage;

        private readonly SendStorage _sendStorage;

        public ObservableCollection<Storage> Storages
        {
            get => _storages;
            set
            {
                _storages = value;
                OnPropertyChanged(nameof(Storages));
            }
        }

        public Storage SelectedStorage
        {
            get => _selectedStorage;
            set
            {
                _selectedStorage = value;
                OnPropertyChanged(nameof(SelectedStorage));
            }
        }

        public ICommand LoadStoragesCommand { get; }
        public ICommand AddStorageCommand { get; }
        public ICommand UpdateStorageCommand { get; }
        public ICommand DeleteStorageCommand { get; }

        private async void LoadStorages()
        {
            Storages = new ObservableCollection<Storage>(await _sendStorage.GetStorages());
        }

        private async void AddStorage()
        {
            await _sendStorage.AddStorage(SelectedStorage);
            LoadStorages();
        }

        private async void UpdateStorage()
        {
            await _sendStorage.UpdateStorage(SelectedStorage);
            LoadStorages();
        }

        private async void DeleteStorage()
        {
            await _sendStorage.DeleteStorage(SelectedStorage.Id);
            LoadStorages();
        }

        #endregion

        #region TYPE OF STORING

        private ObservableCollection<TypeOfStoring> _typesOfStoring;

        private TypeOfStoring _selectedTypeOfStoring;

        private readonly SendTypeOfStoring _sendTypeOfStoring;

        public ObservableCollection<TypeOfStoring> TypesOfStoring
        {
            get => _typesOfStoring;
            set
            {
                _typesOfStoring = value;
                OnPropertyChanged(nameof(TypesOfStoring));
            }
        }

        public TypeOfStoring SelectedTypeOfStoring
        {
            get => _selectedTypeOfStoring;
            set
            {
                _selectedTypeOfStoring = value;
                OnPropertyChanged(nameof(SelectedTypeOfStoring));
            }
        }

        public ICommand LoadTypesOfStoringCommand { get; }

        private async void LoadTypesOfStoring()
        {
            TypesOfStoring = new ObservableCollection<TypeOfStoring>(await _sendTypeOfStoring.GetTypesOfStoring());
        }

        #endregion

        #region WORK TECHNIQUE

        private ObservableCollection<WorkTechnique> _workTechniques;

        private WorkTechnique _selectedWorkTechnique;

        private readonly SendWorkTechnique _sendWorkTechnique;

        public ObservableCollection<WorkTechnique> WorkTechniques
        {
            get => _workTechniques;
            set
            {
                _workTechniques = value;
                OnPropertyChanged(nameof(WorkTechniques));
            }
        }

        public WorkTechnique SelectedWorkTechnique
        {
            get => _selectedWorkTechnique;
            set
            {
                _selectedWorkTechnique = value;
                OnPropertyChanged(nameof(SelectedWorkTechnique));
            }
        }

        public ICommand LoadWorkTechniquesCommand { get; }
        public ICommand AddWorkTechniqueCommand { get; }
        public ICommand UpdateWorkTechniqueCommand { get; }
        public ICommand DeleteWorkTechniqueCommand { get; }

        private async void LoadWorkTechniques()
        {
            WorkTechniques = new ObservableCollection<WorkTechnique>(await _sendWorkTechnique.GetWorkTechniques());
        }

        private async void AddWorkTechnique()
        {
            await _sendWorkTechnique.AddWorkTechnique(SelectedWorkTechnique);
            LoadWorkTechniques();
        }

        private async void UpdateWorkTechnique()
        {
            await _sendWorkTechnique.UpdateWorkTechnique(SelectedWorkTechnique);
            LoadWorkTechniques();
        }

        private async void DeleteWorkTechnique()
        {
            await _sendWorkTechnique.DeleteWorkTechnique(SelectedWorkTechnique.Id);
            LoadWorkTechniques();
        }

        #endregion

        public DataManage(SendAct sendAct, SendEmployee sendEmployee, SendExhibit sendExhibit, SendExhibition sendExhibition,
                         SendMuseumHall sendMuseumHall, SendPosition sendPosition, SendReceptionWay sendReceptionWay,
                         SendStorage sendStorage, SendTypeOfStoring sendTypeOfStoring, SendWorkTechnique sendWorkTechnique)
        {
            _sendAct = sendAct;
            _sendEmployee = sendEmployee;
            _sendExhibit = sendExhibit;
            _sendExhibition = sendExhibition;
            _sendMuseumHall = sendMuseumHall;
            _sendPosition = sendPosition;
            _sendReceptionWay = sendReceptionWay;
            _sendStorage = sendStorage;
            _sendTypeOfStoring = sendTypeOfStoring;
            _sendWorkTechnique = sendWorkTechnique;

            LoadActsCommand = new RelayCommand(LoadActs);
            AddActCommand = new RelayCommand(AddAct);
            UpdateActCommand = new RelayCommand(UpdateAct);
            DeleteActCommand = new RelayCommand(DeleteAct);

            LoadEmployeesCommand = new RelayCommand(LoadEmployees);
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            UpdateEmployeeCommand = new RelayCommand(UpdateEmployee);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployee);

            LoadExhibitsCommand = new RelayCommand(LoadExhibits);
            AddExhibitCommand = new RelayCommand(AddExhibit);
            UpdateExhibitCommand = new RelayCommand(UpdateExhibit);
            DeleteExhibitCommand = new RelayCommand(DeleteExhibit);

            LoadExhibitionsCommand = new RelayCommand(LoadExhibitions);
            AddExhibitionCommand = new RelayCommand(AddExhibition);
            UpdateExhibitionCommand = new RelayCommand(UpdateExhibition);
            DeleteExhibitionCommand = new RelayCommand(DeleteExhibition);

            LoadMuseumHallsCommand = new RelayCommand(LoadMuseumHalls);
            AddMuseumHallCommand = new RelayCommand(AddMuseumHall);
            UpdateMuseumHallCommand = new RelayCommand(UpdateMuseumHall);
            DeleteMuseumHallCommand = new RelayCommand(DeleteMuseumHall);

            LoadPositionsCommand = new RelayCommand(LoadPositions);
            AddPositionCommand = new RelayCommand(AddPosition);
            UpdatePositionCommand = new RelayCommand(UpdatePosition);
            DeletePositionCommand = new RelayCommand(DeletePosition);

            LoadReceptionWaysCommand = new RelayCommand(LoadReceptionWays);

            LoadStoragesCommand = new RelayCommand(LoadStorages);
            AddStorageCommand = new RelayCommand(AddStorage);
            UpdateStorageCommand = new RelayCommand(UpdateStorage);
            DeleteStorageCommand = new RelayCommand(DeleteStorage);

            LoadTypesOfStoringCommand = new RelayCommand(LoadTypesOfStoring);

            LoadWorkTechniquesCommand = new RelayCommand(LoadWorkTechniques);
            AddWorkTechniqueCommand = new RelayCommand(AddWorkTechnique);
            UpdateWorkTechniqueCommand = new RelayCommand(UpdateWorkTechnique);
            DeleteWorkTechniqueCommand = new RelayCommand(DeleteWorkTechnique);
        }
    }
}