using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skydeo.ViewModels.Partials;

namespace Skydeo.ViewModels.Modals
{
    public class AddSkydiverModalViewModel : BaseModalViewModel
    {
        private string _drivePath;

        private SkydiverFormViewModel _skydiverFormViewModel;

        public SkydiverFormViewModel SkydiverFormViewModel
        {
            get => _skydiverFormViewModel;
            set
            {
                _skydiverFormViewModel = value;
                OnPropertyChanged();
            }
        }


        public string DrivePath
        {
            get => _drivePath;
            set
            {
                _drivePath = value;
                OnPropertyChanged();

                if (!string.IsNullOrWhiteSpace(value) && SkydiverFormViewModel == null)
                {
                    InitSkydiverViewModel(); 
                }
            }
        }

        private void InitSkydiverViewModel()
        {
            SkydiverFormViewModel = new SkydiverFormViewModel();
        }
    }
}
