using System.Windows.Input;
using Skydeo.Wpf.Commands;

namespace Skydeo.Wpf.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private string _title;
        private string _appDescription;

        public WelcomeViewModel()
        {
            Title = "Welcome";
            AppDescription = "Lorem Elsass ipsum Verdammi libero, messti de Bischheim chambon mamsell ullamcorper suspendisse hopla hop wurscht hopla Mauris Carola Gal. consectetur tellus non bissame dui dignissim tristique et Oberschaeffolsheim lacus condimentum gal eleifend habitant vulputate knepfle sed turpis sit blottkopf, mänele sagittis amet rhoncus gravida salu senectus rossbolla jetz gehts los leverwurscht id, schneck id Christkindelsmärik placerat DNA, Chulia Roberstau barapli dolor hopla sit ornare quam. hoplageiss amet, gewurztraminer pellentesque bredele eget Chulien ornare Hans Huguette leo ac yeuh. météor ac Spätzle quam, semper adipiscing auctor, Heineken Coopé de Truchtersheim elementum leo und geht's Salu bissame porta flammekueche Miss Dahlias knack purus tellus Pellentesque  rucksack Oberschaeffolsheim merci vielmols non tchao bissame ante wie commodo aliquam kuglopf Richard Schirmeck schpeck hopla varius Racing. in, turpis, risus, kartoffelsalad Salut bisamme picon bière libero, morbi munster vielmols, Wurschtsalad Gal ! Yo dû. baeckeoffe nullam elit sit Pfourtz ! mollis Strasbourg so Morbi Kabinetpapier geïz réchime sed libero. s'guelt nüdle ftomi! kougelhopf ch'ai schnaps lotto-owe amet";
        }
        
        public string AppDescription
        {
            get => _appDescription;
            set
            {
                _appDescription = value;
                OnPropertyChanged();
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public ICommand NaviguateToDebriefViewCommand { get; set; }

        private void InitCommands()
        {
            NaviguateToDebriefViewCommand = new Command(_ =>
            {

            });
        }
    }
}