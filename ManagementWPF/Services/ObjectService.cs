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
    public static class ObjectService
    {
        private static string baseUrl = $"{Environments.Environment.apiRootUrl}objects";

        public static async Task<ObservableCollection<ObjectModel>> GetAllActive()
        {
            try
            {
                var responseString = await App.client.GetStringAsync($"{baseUrl}");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<ObjectModel>>(responseString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return null;
        }
        public static async Task<ObservableCollection<ObjectModel>> GetAllClosed()
        {
            try
            {
                var responseString = await App.client.GetStringAsync($"{baseUrl}/closed");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<ObjectModel>>(responseString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return null;
        }
        public static async Task<ObjectInformationModel> GetInformation(int id)
        {
            try
            {
                var responseString = await App.client.GetStringAsync($"{baseUrl}/{id}/informations");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectInformationModel>(responseString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return null;
        }
        public static async Task<int?> Create(ObjectModel model)
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
            return null;
        }
        public static async Task Closed(ObjectInformationModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var responseString = await App.client.PutAsync($"{baseUrl}/closed", data);
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
    }
}
