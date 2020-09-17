using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubePlaylists.Backend.Model;

namespace YouTubePlaylists.Backend.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _link;
        private ObservableCollection<Track> _informationAboutSong;
        private Playlist _informationAboutPlaylist;
        private MainModel _mainModel = new MainModel();
        public string Link
        {
            get => _link;
            set
            {
                _link = _mainModel.LinkParser(value);
                OnPropertyChanged(nameof(Link));
            }
        }

        public ObservableCollection<Track> InformationAboutSong
        {
            get => _informationAboutSong;
            set
            {
                _informationAboutSong = value;
                OnPropertyChanged(nameof(InformationAboutSong));
            }
        }

        public Playlist InformationAboutPlaylist 
        {
            get => _informationAboutPlaylist;
            set
            {
                _informationAboutPlaylist = value;
                OnPropertyChanged(nameof(InformationAboutPlaylist));
            }
        }


        private ICommand _parseCommand;
        public ICommand ParseCommand => _parseCommand ?? (_parseCommand = new RelayCommand(parameter =>
        {
            InformationAboutSong = _mainModel.GetSongInfo(Link);
            InformationAboutPlaylist = _mainModel.GetPlaylistInfo(Link);
        }));
    }
}

