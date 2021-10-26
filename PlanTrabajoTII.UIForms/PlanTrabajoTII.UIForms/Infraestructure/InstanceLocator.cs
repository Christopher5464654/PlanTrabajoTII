using PlanTrabajoTII.UIForms.ViewModels;

namespace PlanTrabajoTII.UIForms.Infraestructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
