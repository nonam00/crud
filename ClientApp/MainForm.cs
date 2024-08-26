using Domain;

using System.Data;
using System.Net.Http.Json;

namespace ClientApp
{
    public partial class MainForm : Form
    {
        private const string apiUrl = "https://localhost:7291/";
        private readonly HttpClient _httpClient;
        public MainForm()
        {
            InitializeComponent();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(apiUrl),
            };

            GetEmployees();

            listBox.DisplayMember = "Name";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EmployeeForm addForm = new EmployeeForm(_httpClient);
            var dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                GetEmployees();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count == 1)
            {
                var employee = listBox.SelectedItems[0];
                EmployeeForm updateForm = new EmployeeForm(_httpClient, employee as Employee);
                var dialogResult = updateForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    GetEmployees();
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count > 0)
            {
                var employees = listBox.SelectedItems.Cast<Employee>();
                Task.Run(() => Parallel.ForEach(employees, (e) => DeleteEmployee(e.Id))).Wait();
            }
            GetEmployees();
        }

        private void GetEmployees()
        {
            using (var response = _httpClient.GetAsync("").Result)
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Request failed:\n" + response.Content.ReadAsStringAsync().Result);
                }
                listBox.DataSource = response.Content.ReadFromJsonAsync<List<Employee>>().Result
                    ?? throw new Exception("Failed on reading response");
            }
        }

        private async void DeleteEmployee(Guid id)
        {
            using (var response = await _httpClient.DeleteAsync($"{id}/"))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Request failed:\n" + await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
