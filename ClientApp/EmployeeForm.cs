using Domain;

using System.Net.Http.Json;

namespace ClientApp
{
    enum ActionType
    {
        Add,
        Update
    }
    public partial class EmployeeForm : Form
    {
        private ActionType actionType;
        private readonly Guid _employeeId;
        private readonly HttpClient _httpClient;
        public EmployeeForm(HttpClient httpClient, Employee? employee = null)
        {
            InitializeComponent();

            _httpClient = httpClient;

            if (employee == null)
            {
                actionType = ActionType.Add;
                buttonAction.Text = "Add new employee";
            }
            else
            {
                actionType = ActionType.Update;
                _employeeId = employee.Id; 
                textBoxName.Text = employee.Name;
                textBoxAge.Text = employee.Age.ToString();
                buttonAction.Text = "Update employee info";
            }
        }

        private async void buttonAction_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string ageT = textBoxAge.Text.Trim();
            if (name.Length > 0 &&
                ageT.Length > 0 &&
                UInt32.TryParse(ageT, out uint age))
            {
                switch (actionType)
                {
                    case ActionType.Add:
                        await Task.Run(() => AddEmployee(name, age));
                        break;
                    case ActionType.Update:
                        await Task.Run(() => UpdateEmployee(_employeeId, name, age));
                        break;
                    default:
                        throw new Exception("Failed");
                }
            }
        }

        private async void AddEmployee(string name, uint age)
        {
            using (var response = await _httpClient.PostAsJsonAsync("", new
            {
                name = name,
                age = age
            }))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Request failed");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async void UpdateEmployee(Guid id, string name, uint age)
        {
            using (var response = await _httpClient.PutAsJsonAsync($"{id}/", new
            {
                name = name,
                age = age
            }))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Request failed");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
