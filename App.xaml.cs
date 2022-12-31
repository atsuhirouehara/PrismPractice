using System.Windows;
using Prism.Ioc;

namespace PrismPractice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return this.Container.Resolve<Views.MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.MainWindow, ViewModels.MainWindow>();

            containerRegistry.RegisterForNavigation<Views.ItemControll, ViewModels.ItemControll>();
            
            containerRegistry.RegisterDialog<Views.Calculator, ViewModels.Calculator>();
        }
    }
}
