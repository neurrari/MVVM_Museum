using MVVM_Museum.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace MVVM_Museum.ViewModel
{
    public class SendAct
    {
        private readonly HttpClient _client;

        public SendAct(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Act>> GetActs()
        {
            var response = await _client.GetStringAsync("/act");
            return JsonConvert.DeserializeObject<List<Act>>(response);
        }

        public async Task AddAct(Act act)
        {
            var json = JsonConvert.SerializeObject(act);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("/act", content);
        }

        public async Task UpdateAct(Act act)
        {
            var json = JsonConvert.SerializeObject(act);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PutAsync($"/act/{act.Id}", content);
        }

        public async Task DeleteAct(int actId)
        {
            await _client.DeleteAsync($"/act/{actId}");
        }
    }

    public class SendEmployee
    {
        private readonly HttpClient _client;

        public SendEmployee(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var response = await _client.GetStringAsync("/employee");
            return JsonConvert.DeserializeObject<List<Employee>>(response);
        }

        public async Task AddEmployee(Employee employee)
        {
            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("/employee", content);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PutAsync($"/employee/{employee.Id}", content);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await _client.DeleteAsync($"/employee/{employeeId}");
        }
    }

    public class SendExhibit
    {
        private readonly HttpClient _client;

        public SendExhibit(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Exhibit>> GetExhibits()
        {
            var response = await _client.GetStringAsync("/exhibit");
            return JsonConvert.DeserializeObject<List<Exhibit>>(response);
        }

        public async Task AddExhibit(Exhibit exhibit)
        {
            var json = JsonConvert.SerializeObject(exhibit);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("/exhibit", content);
        }

        public async Task UpdateExhibit(Exhibit exhibit)
        {
            var json = JsonConvert.SerializeObject(exhibit);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PutAsync($"/exhibit/{exhibit.Id}", content);
        }

        public async Task DeleteExhibit(int exhibitId)
        {
            await _client.DeleteAsync($"/exhibit/{exhibitId}");
        }
    }

    public class SendExhibition
    {
        private readonly HttpClient _client;

        public SendExhibition(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Exhibition>> GetExhibitions()
        {
            var response = await _client.GetStringAsync("/exhibition");
            return JsonConvert.DeserializeObject<List<Exhibition>>(response);
        }

        public async Task AddExhibition(Exhibition exhibition)
        {
            var json = JsonConvert.SerializeObject(exhibition);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("/exhibition", content);
        }

        public async Task UpdateExhibition(Exhibition exhibition)
        {
            var json = JsonConvert.SerializeObject(exhibition);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PutAsync($"/exhibition/{exhibition.Id}", content);
        }

        public async Task DeleteExhibition(int exhibitionId)
        {
            await _client.DeleteAsync($"/exhibition/{exhibitionId}");
        }
    }

    public class SendMuseumHall
    {
        private readonly HttpClient _client;

        public SendMuseumHall(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<MuseumHall>> GetMuseumHalls()
        {
            var response = await _client.GetStringAsync("/museumHall");
            return JsonConvert.DeserializeObject<List<MuseumHall>>(response);
        }

        public async Task AddMuseumHall(MuseumHall museumHall)
        {
            var json = JsonConvert.SerializeObject(museumHall);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("/museumHall", content);
        }

        public async Task UpdateMuseumHall(MuseumHall museumHall)
        {
            var json = JsonConvert.SerializeObject(museumHall);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PutAsync($"/museumHall/{museumHall.Id}", content);
        }

        public async Task DeleteMuseumHall(int museumHallId)
        {
            await _client.DeleteAsync($"/museumHall/{museumHallId}");
        }
    }

    public class SendPosition
    {
        private readonly HttpClient _client;

        public SendPosition(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Position>> GetPositions()
        {
            var response = await _client.GetStringAsync("/position");
            return JsonConvert.DeserializeObject<List<Position>>(response);
        }

        public async Task AddPosition(Position position)
        {
            var json = JsonConvert.SerializeObject(position);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("/position", content);
        }

        public async Task UpdatePosition(Position position)
        {
            var json = JsonConvert.SerializeObject(position);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PutAsync($"/position/{position.Id}", content);
        }

        public async Task DeletePosition(int positionId)
        {
            await _client.DeleteAsync($"/position/{positionId}");
        }
    }

    public class SendReceptionWay
    {
        private readonly HttpClient _client;

        public SendReceptionWay(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ReceptionWay>> GetReceptionWays()
        {
            var response = await _client.GetStringAsync("/receptWay");
            return JsonConvert.DeserializeObject<List<ReceptionWay>>(response);
        }
    }

    public class SendStorage
    {
        private readonly HttpClient _client;

        public SendStorage(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Storage>> GetStorages()
        {
            var response = await _client.GetStringAsync("/storage");
            return JsonConvert.DeserializeObject<List<Storage>>(response);
        }

        public async Task AddStorage(Storage storage)
        {
            var json = JsonConvert.SerializeObject(storage);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("/storage", content);
        }

        public async Task UpdateStorage(Storage storage)
        {
            var json = JsonConvert.SerializeObject(storage);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PutAsync($"/storage/{storage.Id}", content);
        }

        public async Task DeleteStorage(int storageId)
        {
            await _client.DeleteAsync($"/storage/{storageId}");
        }
    }

    public class SendTypeOfStoring
    {
        private readonly HttpClient _client;

        public SendTypeOfStoring(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<TypeOfStoring>> GetTypesOfStoring()
        {
            var response = await _client.GetStringAsync("/receptWay");
            return JsonConvert.DeserializeObject<List<TypeOfStoring>>(response);
        }
    }

    public class SendWorkTechnique
    {
        private readonly HttpClient _client;

        public SendWorkTechnique(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<WorkTechnique>> GetWorkTechniques()
        {
            var response = await _client.GetStringAsync("/workTech");
            return JsonConvert.DeserializeObject<List<WorkTechnique>>(response);
        }

        public async Task AddWorkTechnique(WorkTechnique workTech)
        {
            var json = JsonConvert.SerializeObject(workTech);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("/workTech", content);
        }

        public async Task UpdateWorkTechnique(WorkTechnique workTech)
        {
            var json = JsonConvert.SerializeObject(workTech);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PutAsync($"/workTech/{workTech.Id}", content);
        }

        public async Task DeleteWorkTechnique(int workTechId)
        {
            await _client.DeleteAsync($"/workTech/{workTechId}");
        }
    }
}
