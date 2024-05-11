using MVVM_Museum.Model;
using MVVM_Museum.ViewModel;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Media3D;

namespace MVVM_Museum.View
{
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:5129");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region ACT

        private async void ButtonLoadActs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.GetStringAsync("/act");
                var acts = JsonConvert.DeserializeObject<List<Act>>(response);
                dgAct.ItemsSource = acts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonAddAct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int actId, exhibitId = Convert.ToInt32(tbExhibitId), exhibitionId = Convert.ToInt32(tbExhibitionId);

                if (!int.TryParse(textBoxActId.Text, out actId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newAct = new Act 
                { 
                    Id = actId, 
                    DateIssuing = dpDateIssuing.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateIssuing.SelectedDate.Value.Date) : DateOnly.MinValue,
                    DateAccepting = dpDateAccepting.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateAccepting.SelectedDate.Value.Date) : DateOnly.MinValue,
                    IdExhibit = exhibitId,
                    IdExhibition = exhibitionId 
                };

                var json = JsonConvert.SerializeObject(newAct);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/act", content);
                response.EnsureSuccessStatusCode();

                textBoxActId.Clear();
                tbExhibitId.Clear();
                tbExhibitionId.Clear();
                dpDateAccepting.SelectedDate = null;
                dpDateIssuing.SelectedDate = null;

                MessageBox.Show("Act added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadActs_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonUpdateAct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int actId, exhibitId = Convert.ToInt32(tbExhibitId), exhibitionId = Convert.ToInt32(tbExhibitionId);

                if (!int.TryParse(textBoxActId.Text, out actId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var updatedAct = new Act
                {
                    Id = actId,
                    DateIssuing = dpDateIssuing.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateIssuing.SelectedDate.Value.Date) : DateOnly.MinValue,
                    DateAccepting = dpDateAccepting.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateAccepting.SelectedDate.Value.Date) : DateOnly.MinValue,
                    IdExhibit = exhibitId,
                    IdExhibition = exhibitionId
                };

                textBoxActId.Clear();
                tbExhibitId.Clear();
                tbExhibitionId.Clear();
                dpDateAccepting.SelectedDate = null;
                dpDateIssuing.SelectedDate = null;

                var json = JsonConvert.SerializeObject(updatedAct);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"/act/{actId}", content);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Act updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadActs_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonDeleteAct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int actIdToDelete;
                if (int.TryParse(textBoxActIdToDelete.Text, out actIdToDelete))
                {
                    var response = await client.DeleteAsync($"/act/{actIdToDelete}");
                    response.EnsureSuccessStatusCode();
                    textBoxActIdToDelete.Clear();

                    MessageBox.Show("Act deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ButtonLoadActs_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Invalid act ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region EMPLOYEE
        private async void ButtonLoadEmployees_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.GetStringAsync("/employee");
                var employees = JsonConvert.DeserializeObject<List<Employee>>(response);
                dgEmployee.ItemsSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int employeeId, positionId = Convert.ToInt32(tbPositionId);

                if (!int.TryParse(textBoxEmployeeId.Text, out employeeId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newEmployee = new Employee
                {
                    Id = employeeId,
                    Lastname = tbLastname.Text,
                    Firstname = tbFirstname.Text,
                    Middlename = tbMiddlename.Text,
                    DateOfBirth = dpDateOfBirth.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateOfBirth.SelectedDate.Value.Date) : DateOnly.MinValue,
                    Address = tbAddress.Text,
                    PhoneNumber = tbPhone.Text,
                    IdPosition = positionId
                };

                var json = JsonConvert.SerializeObject(newEmployee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/employee", content);
                response.EnsureSuccessStatusCode();

                textBoxEmployeeId.Clear();
                tbLastname.Clear();
                tbFirstname.Clear();
                tbMiddlename.Clear();
                dpDateOfBirth.SelectedDate = null;
                tbAddress.Clear();
                tbPhone.Clear();
                tbPositionId.Clear();

                MessageBox.Show("Act added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadEmployees_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int employeeId, positionId = Convert.ToInt32(tbPositionId);

                if (!int.TryParse(textBoxEmployeeId.Text, out employeeId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var updatedEmployee = new Employee
                {
                    Id = employeeId,
                    Lastname = tbLastname.Text,
                    Firstname = tbFirstname.Text,
                    Middlename = tbMiddlename.Text,
                    DateOfBirth = dpDateOfBirth.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateOfBirth.SelectedDate.Value.Date) : DateOnly.MinValue,
                    Address = tbAddress.Text,
                    PhoneNumber = tbPhone.Text,
                    IdPosition = positionId
                };

                textBoxEmployeeId.Clear();
                tbLastname.Clear();
                tbFirstname.Clear();
                tbMiddlename.Clear();
                dpDateOfBirth.SelectedDate = null;
                tbAddress.Clear();
                tbPhone.Clear();
                tbPositionId.Clear();

                var json = JsonConvert.SerializeObject(updatedEmployee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"/employee/{employeeId}", content);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Employee updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadEmployees_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int employeeIdToDelete;
                if (int.TryParse(textBoxActIdToDelete.Text, out employeeIdToDelete))
                {
                    var response = await client.DeleteAsync($"/employee/{employeeIdToDelete}");
                    response.EnsureSuccessStatusCode();
                    textBoxEmployeeIdToDelete.Clear();

                    MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ButtonLoadEmployees_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Invalid employee ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region EXHIBIT
        private async void ButtonLoadExhibits_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.GetStringAsync("/exhibit");
                var exhibits = JsonConvert.DeserializeObject<List<Exhibit>>(response);
                dgExhibit.ItemsSource = exhibits;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonAddExhibit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int exhibitId;

                if (!int.TryParse(textBoxExhibitId.Text, out exhibitId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newExhibit = new Exhibit
                {
                    Id = exhibitId,
                    NameExhibit = tbNameExhibit.Text,
                    Author = tbAuthor.Text,
                    DateCreate = Convert.ToInt32(tbDateCreate.Text),
                    IdTechnique = Convert.ToInt32(tbWorkTechniqueId.Text),
                    IdEmployee = Convert.ToInt32(tbEmployeeIdExhibit.Text),
                    IdStorage = Convert.ToInt32(tbStorageId.Text),
                    IdMuseumHall = Convert.ToInt32(tbMuseumHallId.Text),
                    IdReceptionWay = Convert.ToInt32(tbReceptionWayId.Text),
                    IdTypeOfStoring = Convert.ToInt32(tbTypeOfStoringId.Text)
                };

                var json = JsonConvert.SerializeObject(newExhibit);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/exhibit", content);
                response.EnsureSuccessStatusCode();

                textBoxExhibitId.Clear();
                tbNameExhibit.Clear();
                tbAuthor.Clear();
                tbDateCreate.Clear();
                tbWorkTechniqueId.Clear();
                tbEmployeeIdExhibit.Clear();
                tbStorageId.Clear();
                tbMuseumHallId.Clear();
                tbReceptionWayId.Clear();
                tbTypeOfStoringId.Clear();

                MessageBox.Show("Exhibit added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadExhibits_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonUpdateExhibit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int actId, exhibitId = Convert.ToInt32(tbExhibitId), exhibitionId = Convert.ToInt32(tbExhibitionId);

                if (!int.TryParse(textBoxExhibitId.Text, out actId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var updatedExhibit = new Exhibit
                {
                    Id = exhibitId,
                    NameExhibit = tbNameExhibit.Text,
                    Author = tbAuthor.Text,
                    DateCreate = Convert.ToInt32(tbDateCreate.Text),
                    IdTechnique = Convert.ToInt32(tbWorkTechniqueId.Text),
                    IdEmployee = Convert.ToInt32(tbEmployeeIdExhibit.Text),
                    IdStorage = Convert.ToInt32(tbStorageId.Text),
                    IdMuseumHall = Convert.ToInt32(tbMuseumHallId.Text),
                    IdReceptionWay = Convert.ToInt32(tbReceptionWayId.Text),
                    IdTypeOfStoring = Convert.ToInt32(tbTypeOfStoringId.Text)
                };

                var json = JsonConvert.SerializeObject(updatedExhibit);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"/exhibit/{exhibitId}", content);
                response.EnsureSuccessStatusCode();

                textBoxExhibitId.Clear();
                tbNameExhibit.Clear();
                tbAuthor.Clear();
                tbDateCreate.Clear();
                tbWorkTechniqueId.Clear();
                tbEmployeeIdExhibit.Clear();
                tbStorageId.Clear();
                tbMuseumHallId.Clear();
                tbReceptionWayId.Clear();
                tbTypeOfStoringId.Clear();

                MessageBox.Show("Exhibit updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadExhibits_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonDeleteExhibit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int exhibitIdToDelete;
                if (int.TryParse(textBoxExhibitIdToDelete.Text, out exhibitIdToDelete))
                {
                    var response = await client.DeleteAsync($"exhibit/{exhibitIdToDelete}");
                    response.EnsureSuccessStatusCode();
                    textBoxExhibitIdToDelete.Clear();

                    MessageBox.Show("Exhibit deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ButtonLoadExhibits_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Invalid exhibit ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region EXHIBITION
        private async void ButtonLoadExhibitions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.GetStringAsync("/exhibition");
                var exhibitions = JsonConvert.DeserializeObject<List<Exhibition>>(response);
                dgExhibition.ItemsSource = exhibitions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonAddExhibition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int exhibitionId;

                if (!int.TryParse(textBoxExhibitionId.Text, out exhibitionId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newExhibition = new Exhibition
                {
                    Id = exhibitionId,
                    NameExhibition = tbNameExhibition.Text,
                    Arranger = tbArranger.Text,
                    DateOpen = dpDateOpen.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateOpen.SelectedDate.Value.Date) : DateOnly.MinValue,
                    DateClose = dpDateClose.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateClose.SelectedDate.Value.Date) : DateOnly.MinValue
                };

                var json = JsonConvert.SerializeObject(newExhibition);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/exhibition", content);
                response.EnsureSuccessStatusCode();

                textBoxExhibitId.Clear();
                tbNameExhibition.Clear();
                tbArranger.Clear();
                dpDateOpen.SelectedDate = null;
                dpDateClose.SelectedDate = null;

                MessageBox.Show("Exhibition added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadExhibitions_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonUpdateExhibition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int exhibitionId;

                if (!int.TryParse(textBoxExhibitionId.Text, out exhibitionId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var updatedExhibition = new Exhibition
                {
                    Id = exhibitionId,
                    NameExhibition = tbNameExhibition.Text,
                    Arranger = tbArranger.Text,
                    DateOpen = dpDateOpen.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateOpen.SelectedDate.Value.Date) : DateOnly.MinValue,
                    DateClose = dpDateClose.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateClose.SelectedDate.Value.Date) : DateOnly.MinValue
                };

                var json = JsonConvert.SerializeObject(updatedExhibition);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"/exhibition/{exhibitionId}", content);
                response.EnsureSuccessStatusCode();

                textBoxExhibitId.Clear();
                tbNameExhibition.Clear();
                tbArranger.Clear();
                dpDateOpen.SelectedDate = null;
                dpDateClose.SelectedDate = null;

                MessageBox.Show("Exhibition updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadExhibitions_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonDeleteExhibition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int exhibitionIdToDelete;
                if (int.TryParse(textBoxExhibitionIdToDelete.Text, out exhibitionIdToDelete))
                {
                    var response = await client.DeleteAsync($"exhibition/{exhibitionIdToDelete}");
                    response.EnsureSuccessStatusCode();
                    textBoxExhibitionIdToDelete.Clear();

                    MessageBox.Show("Exhibition deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ButtonLoadExhibitions_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Invalid exhibition ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region MUSEUM HALL
        private async void ButtonLoadMuseumHalls_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.GetStringAsync("/museumHall");
                var positions = JsonConvert.DeserializeObject<List<MuseumHall>>(response);
                dgMuseumHall.ItemsSource = positions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonAddMuseumHall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int museumHallId, employeeId = Convert.ToInt32(tbEmployeeIdHall);

                if (!int.TryParse(textBoxMuseumHallId.Text, out museumHallId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newMuseumHall = new MuseumHall
                {
                    Id = museumHallId,
                    NumberOfHall = tbNumberOfHall.Text,
                    AmountOfPlaces = Convert.ToInt32(tbAmountOfPlacesHall.Text),
                    IdEmployee = employeeId
                };

                var json = JsonConvert.SerializeObject(newMuseumHall);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/museumHall", content);
                response.EnsureSuccessStatusCode();

                textBoxMuseumHallId.Clear();
                tbNumberOfHall.Clear();
                tbAmountOfPlacesHall.Clear();
                tbEmployeeIdHall.Clear();

                MessageBox.Show("MuseumHall added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadMuseumHalls_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonUpdateMuseumHall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int museumHallId, employeeId = Convert.ToInt32(tbEmployeeIdHall);

                if (!int.TryParse(textBoxMuseumHallId.Text, out museumHallId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var updatedMuseumHall = new MuseumHall
                {
                    Id = museumHallId,
                    NumberOfHall = tbNumberOfHall.Text,
                    AmountOfPlaces = Convert.ToInt32(tbAmountOfPlacesHall.Text),
                    IdEmployee = employeeId
                };

                var json = JsonConvert.SerializeObject(updatedMuseumHall);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"/musemHall/{museumHallId}", content);
                response.EnsureSuccessStatusCode();

                textBoxMuseumHallId.Clear();
                tbExhibitId.Clear();
                tbExhibitionId.Clear();
                dpDateAccepting.SelectedDate = null;
                dpDateIssuing.SelectedDate = null;

                MessageBox.Show("Hall updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadMuseumHalls_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonDeleteMuseumHall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int hallIdToDelete;
                if (int.TryParse(textBoxMuseumHallIdToDelete.Text, out hallIdToDelete))
                {
                    var response = await client.DeleteAsync($"/museumHall/{hallIdToDelete}");
                    response.EnsureSuccessStatusCode();
                    textBoxMuseumHallIdToDelete.Clear();

                    MessageBox.Show("Hall deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ButtonLoadMuseumHalls_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Invalid hall ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region POSITION
        private async void ButtonLoadPositions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.GetStringAsync("/position");
                var positions = JsonConvert.DeserializeObject<List<Position>>(response);
                dgPosition.ItemsSource = positions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonAddPosition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int positionId;

                if (!int.TryParse(textBoxPositionId.Text, out positionId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newPosition = new Position
                {
                    Id = positionId,
                    NamePosition = tbNamePosition.Text,
                    Salary = Convert.ToInt32(tbSalary.Text)
                };

                var json = JsonConvert.SerializeObject(newPosition);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/position", content);
                response.EnsureSuccessStatusCode();

                textBoxPositionId.Clear();
                tbNamePosition.Clear();
                tbSalary.Clear();

                MessageBox.Show("Position added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadPositions_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonUpdatePosition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int positionId;

                if (!int.TryParse(textBoxPositionId.Text, out positionId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var updatedPosition = new Position
                {
                    Id = positionId,
                    NamePosition = tbNamePosition.Text,
                    Salary = Convert.ToInt32(tbSalary.Text)
                };

                var json = JsonConvert.SerializeObject(updatedPosition);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"/position/{positionId}", content);
                response.EnsureSuccessStatusCode();

                textBoxPositionId.Clear();
                tbNamePosition.Clear();
                tbSalary.Clear();

                MessageBox.Show("punisment updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadPositions_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonDeletePosition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int positionIdToDelete;
                if (int.TryParse(textBoxPositionIdToDelete.Text, out positionIdToDelete))
                {
                    var response = await client.DeleteAsync($"/position/{positionIdToDelete}");
                    response.EnsureSuccessStatusCode();
                    textBoxPositionIdToDelete.Clear();

                    MessageBox.Show("Position deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ButtonLoadPositions_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Invalid position ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region RECEPTION WAY
        private async void ButtonLoadReceptionWays_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.GetStringAsync("/act");
                var recepWays = JsonConvert.DeserializeObject<List<ReceptionWay>>(response);
                dgReceptionWay.ItemsSource = recepWays;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region STORAGE
        private async void ButtonLoadStorages_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.GetStringAsync("/storage");
                var storages = JsonConvert.DeserializeObject<List<Storage>>(response);
                dgStorage.ItemsSource = storages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonAddStorage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int storageId;

                if (!int.TryParse(textBoxStorageId.Text, out storageId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newStorage = new Storage
                {
                    Id = storageId,
                    NumberOfStorage = tbNumberOfStorage.Text,
                    AmountOfPlaces = Convert.ToInt32(tbAmountOfPlacesStorage.Text)
                };

                var json = JsonConvert.SerializeObject(newStorage);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/storage", content);
                response.EnsureSuccessStatusCode();

                textBoxStorageId.Clear();
                tbNumberOfStorage.Clear();
                tbAmountOfPlacesStorage.Clear();

                MessageBox.Show("Storage added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadStorages_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonUpdateStorage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int storageId;

                if (!int.TryParse(textBoxStorageId.Text, out storageId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var updatedStorage = new Storage
                {
                    Id = storageId,
                    NumberOfStorage = tbNumberOfStorage.Text,
                    AmountOfPlaces = Convert.ToInt32(tbAmountOfPlacesStorage.Text)
                };

                var json = JsonConvert.SerializeObject(updatedStorage);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"/storage/{storageId}", content);
                response.EnsureSuccessStatusCode();

                textBoxStorageId.Clear();
                tbNumberOfStorage.Clear();
                tbAmountOfPlacesStorage.Clear();

                MessageBox.Show("Storage updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadStorages_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonDeleteStorage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int storageIdToDelete;
                if (int.TryParse(textBoxStorageIdToDelete.Text, out storageIdToDelete))
                {
                    var response = await client.DeleteAsync($"storage/{storageIdToDelete}");
                    response.EnsureSuccessStatusCode();
                    textBoxStorageIdToDelete.Clear();

                    MessageBox.Show("Storage deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ButtonLoadStorages_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Invalid storage ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region TYPE OF STORING
        private async void ButtonLoadTypesOfStoring_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.GetStringAsync("/typeOfStoring");
                var positions = JsonConvert.DeserializeObject<List<TypeOfStoring>>(response);
                dgTypeOfStoring.ItemsSource = positions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region WORK TECHNIQUE
        private async void ButtonLoadWorkTechniques_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.GetStringAsync("/workTech");
                var worktechs = JsonConvert.DeserializeObject<List<WorkTechnique>>(response);
                dgAct.ItemsSource = worktechs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonAddWorkTechnique_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int worktechId;

                if (!int.TryParse(textBoxWorkTechniqueId.Text, out worktechId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newWorkTechnique = new WorkTechnique
                {
                    Id = worktechId,
                    NameTechnique = tbNameTechnique.Text,
                    Material = tbMaterial.Text
                };

                var json = JsonConvert.SerializeObject(newWorkTechnique);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/workTech", content);
                response.EnsureSuccessStatusCode();

                textBoxWorkTechniqueId.Clear();
                tbNameTechnique.Clear();
                tbMaterial.Clear();

                MessageBox.Show("Act added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadActs_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonUpdateWorkTechnique_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int worktechId;

                if (!int.TryParse(textBoxWorkTechniqueId.Text, out worktechId))
                {
                    MessageBox.Show("Invalid Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var updatedWorkTechnique = new WorkTechnique
                {
                    Id = worktechId,
                    NameTechnique = tbNameTechnique.Text,
                    Material = tbMaterial.Text
                };

                var json = JsonConvert.SerializeObject(updatedWorkTechnique);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"/workTech/{worktechId}", content);
                response.EnsureSuccessStatusCode();

                textBoxWorkTechniqueId.Clear();
                tbNameTechnique.Clear();
                tbMaterial.Clear();

                MessageBox.Show("punisment updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ButtonLoadActs_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ButtonDeleteWorkTechnique_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int workTechIdToDelete;
                if (int.TryParse(textBoxWorkTechniqueIdToDelete.Text, out workTechIdToDelete))
                {
                    var response = await client.DeleteAsync($"/workTech/{workTechIdToDelete}");
                    response.EnsureSuccessStatusCode();
                    textBoxWorkTechniqueIdToDelete.Clear();

                    MessageBox.Show("Act deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ButtonLoadWorkTechniques_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Invalid technique ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        private void comboBoxFilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterData();
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }

        private void FilterData()
        {
            if (dgExhibit.ItemsSource != null)
            {
                string selectedField = (comboBoxFilterBy.SelectedItem as ComboBoxItem)?.Content.ToString();

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgExhibit.ItemsSource);
                view.Filter = item =>
                {
                    if (item is Exhibit exhibit)
                    {
                        switch (selectedField)
                        {
                            case "Id":
                                return exhibit.Id.ToString().Contains(textBoxFilter.Text);
                            case "Название":
                                return exhibit.NameExhibit.Contains(textBoxFilter.Text);
                            case "Автор":
                                return exhibit.Author.Contains(textBoxFilter.Text);
                            default:
                                return false;
                        }
                    }

                    return false;
                };
            }
        }
    }
}