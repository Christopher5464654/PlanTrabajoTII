namespace PlanTrabajoTII.UIForms.ViewModels
{
    using PlanTrabajoTII.Common.Models;
    using PlanTrabajoTII.Common.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ClassroomsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Classroom> classrooms;

        public ObservableCollection<Classroom> Classrooms {
            get { return this.classrooms; }
            set { this.SetValue(ref this.classrooms, value); } }
        public ClassroomsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadClassrooms();
        }

        private async void LoadClassrooms()
        {
            var response = await this.apiService.GetListAsync<Classroom>("https://plantrabajotiiweb20211013120915.azurewebsites.net", "/api", "/Classrooms");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }
            var myClassrooms = (List<Classroom>)response.Result;
            this.Classrooms = new ObservableCollection<Classroom>(myClassrooms);
        }
    }
}
