using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ManagementWPF.Models;
using System.Collections.ObjectModel;
using System.Windows;
using Newtonsoft.Json;

namespace ManagementWPF.Services
{
    public static class EmployeeService
    {
        private static string baseUrl = $"{Environments.Environment.apiRootUrl}employees";

        public static async Task<ObservableCollection<EmployeeModel>> GetAll()
        {
            try
            {
                var responseString = await App.client.GetStringAsync($"{baseUrl}");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<EmployeeModel>>(responseString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return null;
        }

        public static async Task<ObservableCollection<EmployeeModel>> GetAllByObjectId(int objectId)
        {
            try
            {
                var responseString = await App.client.GetStringAsync($"{baseUrl}/objectId={objectId}");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<EmployeeModel>>(responseString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return null;
        }

        public static async Task<EmployeeModel> Get(int id)
        {
            try
            {
                var responseString = await App.client.GetStringAsync($"{baseUrl}/{id}");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<EmployeeModel>(responseString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return null;
        }
        public static async Task Create(EmployeeModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var responseString = await App.client.PostAsync($"{baseUrl}", data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return;
        }
        public static async Task Delete(int id)
        {
            try
            {
                var responseString = await App.client.DeleteAsync($"{baseUrl}/{id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return;
        }
        public static async Task Update(EmployeeModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var responseString = await App.client.PutAsync($"{baseUrl}", data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return;
        }
    }
}
