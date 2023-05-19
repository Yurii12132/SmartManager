using ManagementWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementWPF.Services
{
    public static class PayoutService
    {
        private static string baseUrl = $"{Environments.Environment.apiRootUrl}payouts";

        public static async Task<ObservableCollection<PayoutModel>> GetAllByObjectId(int objectId)
        {
            try
            {
                var responseString = await App.client.GetStringAsync($"{baseUrl}/objectId={objectId}");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<PayoutModel>>(responseString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return null;
        }

        public static async Task Create(PayoutModel model)
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

        public static async Task<bool> Delete(int id)
        {
            try
            {
                var responseString = await App.client.DeleteAsync($"{baseUrl}/{id}");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
            return false;
        }

    }
}
