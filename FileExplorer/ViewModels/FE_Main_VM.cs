using FileExplorer.General;
using FileExplorer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileExplorer.ViewModels
{
    public class FE_Main_VM : FE_Base_VM
    {
        #region Private Variables
        private ObservableCollection<FE_SpecialFolder_M> _SpecialFolders = new ObservableCollection<FE_SpecialFolder_M>();
        private ObservableCollection<FE_SpecialFolder_M> _ThisPCFolders = new ObservableCollection<FE_SpecialFolder_M>();
        private ObservableCollection<FE_DirectoryInfo_M> _Directories = new ObservableCollection<FE_DirectoryInfo_M>();
        private ObservableCollection<FE_DirectoryInfo_M> _DirectoriesWithHidden = new ObservableCollection<FE_DirectoryInfo_M>();
        private ObservableCollection<FE_LocalDriveInfo_M> _LocalDrives = new ObservableCollection<FE_LocalDriveInfo_M>();
        private Visibility _qacVisibility = Visibility.Collapsed;
        private Visibility _tpcVisibility = Visibility.Collapsed;
        private Visibility _ShowDirectories = Visibility.Collapsed;
        private Visibility _ShowLocalDrives = Visibility.Collapsed;
        private bool _IsHiddenfilesVisible = false;
        private int _UGRows = 3;
        #endregion

        #region Public Variables
        public ObservableCollection<FE_SpecialFolder_M> SpecialFolders
        {
            get
            {
                return _SpecialFolders;
            }

            set
            {
                if (_SpecialFolders != value)
                {
                    _SpecialFolders = value;
                    RaisePropertyChanged("SpecialFolders");
                }
            }
        }
        public ObservableCollection<FE_SpecialFolder_M> ThisPCFolders
        {
            get
            {
                return _ThisPCFolders;
            }

            set
            {
                if (_ThisPCFolders != value)
                {
                    _ThisPCFolders = value;
                    RaisePropertyChanged("ThisPCFolders");
                }
            }
        }
        public ObservableCollection<FE_DirectoryInfo_M> Directories
        {
            get
            {
                return _Directories;
            }

            set
            {
                if (_Directories != value)
                {
                    _Directories = value;
                    UGRows = (_Directories.Count / 3) + 1;
                    RaisePropertyChanged("Directories");
                }
            }
        }
        public ObservableCollection<FE_DirectoryInfo_M> DirectoriesWithHidden
        {
            get
            {
                return _DirectoriesWithHidden;
            }

            set
            {
                if (_DirectoriesWithHidden != value)
                {
                    _DirectoriesWithHidden = value;
                    RaisePropertyChanged("DirectoriesWithHidden");
                }
            }
        }
        public ObservableCollection<FE_LocalDriveInfo_M> LocalDrives
        {
            get
            {
                return _LocalDrives;
            }

            set
            {
                if (_LocalDrives != value)
                {
                    _LocalDrives = value;
                    RaisePropertyChanged("LocalDrives");
                }
            }
        }

        public int UGRows
        {
            get
            {
                return _UGRows;
            }

            set
            {
                if (_UGRows != value)
                {
                    _UGRows = value;
                    RaisePropertyChanged("UGRows");
                }
            }
        }
        public Visibility qacVisibility
        {
            get
            {
                return _qacVisibility;
            }

            set
            {
                if (_qacVisibility != value)
                {
                    _qacVisibility = value;
                    RaisePropertyChanged("qacVisibility");
                }
            }
        }
        public Visibility tpcVisibility
        {
            get
            {
                return _tpcVisibility;
            }

            set
            {
                if (_tpcVisibility != value)
                {
                    _tpcVisibility = value;
                    RaisePropertyChanged("tpcVisibility");
                }
            }
        }
        public Visibility ShowDirectories
        {
            get
            {
                return _ShowDirectories;
            }

            set
            {
                if (_ShowDirectories != value)
                {
                    _ShowDirectories = value;
                    ShowLocalDrives = value == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                    RaisePropertyChanged("ShowDirectories");
                }
            }
        }
        public Visibility ShowLocalDrives
        {
            get
            {
                return _ShowLocalDrives;
            }

            set
            {
                if (_ShowLocalDrives != value)
                {
                    _ShowLocalDrives = value;
                    ShowDirectories = Visibility.Collapsed == value ? Visibility.Visible : Visibility.Collapsed;
                    RaisePropertyChanged("ShowLocalDrives");
                }
            }
        }

        public FE_Command SpecialFolderClick { get; set; }
        public FE_Command GetDirectoryContents { get; set; }
        public FE_Command ToggleQacContents { get; set; }
        public FE_Command ToggleTPcContents { get; set; }
        public FE_Command ShowHiddenFiles { get; set; }
        #endregion

        #region Constructors
        public FE_Main_VM()
        {
            // adding desktop, downloads, documents, pictures
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String myPicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            SpecialFolders.Add(new FE_SpecialFolder_M
            {
                Name = "Desktop",
                Path = desktopPath
            });
            SpecialFolders.Add(new FE_SpecialFolder_M
            {
                Name = "Documents",
                Path = myDocumentsPath
            });
            SpecialFolders.Add(new FE_SpecialFolder_M
            {
                Name = "Pictures",
                Path = myPicturesPath
            });

            foreach (var folder in SpecialFolders)
            {
                ThisPCFolders.Add(folder);
            }

            var LogicalDrives = DriveInfo.GetDrives();

            foreach (var logicalDrive in LogicalDrives)
            {
                try
                {
                    ThisPCFolders.Add(new FE_SpecialFolder_M()
                    {
                        Name = (string.IsNullOrEmpty(logicalDrive.VolumeLabel) ? "Local Disk (" : logicalDrive.VolumeLabel + " (") + logicalDrive.Name.Remove(1) + ":)",
                        Path = logicalDrive.Name,
                        FolderImage = Convert.ToBase64String(File.ReadAllBytes("../../Resources/hdd.png"))
                    });
                }
                catch (IOException e)
                {
                    continue;
                }
                
            }

            SpecialFolderClick = new FE_Command(specialFolderClick);
            GetDirectoryContents = new FE_Command(getDirectoryContents);
            ToggleQacContents = new FE_Command(toggleQacContents);
            ToggleTPcContents = new FE_Command(toggleTPcContents);
            ShowHiddenFiles = new FE_Command(showHiddenFiles);
        }
        #endregion

        #region Methods
        private void showHiddenFiles(object parameter)
        {
            if (!_IsHiddenfilesVisible)
                Directories = DirectoriesWithHidden;
            else
                Directories = new ObservableCollection<FE_DirectoryInfo_M>(DirectoriesWithHidden.Where(d => !d.IsHidden).ToList());
            _IsHiddenfilesVisible = !_IsHiddenfilesVisible;

        }
        private void toggleTPcContents(object parameter)
        {
            tpcVisibility = tpcVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            ShowLocalDrives = Visibility.Visible;
            // get the local drives
            LocalDrives.Clear();
            DriveInfo[] localDrives = DriveInfo.GetDrives();

            foreach (var localDrive in localDrives)
            {
                if (localDrive.IsReady)
                {
                    LocalDrives.Add(new FE_LocalDriveInfo_M()
                    {
                        Name = (string.IsNullOrEmpty(localDrive.VolumeLabel) ? "Local Disk (" : localDrive.VolumeLabel + " (") + localDrive.Name.Remove(1) + ":)",
                        UsedSpacePercent = ((localDrive.TotalSize - localDrive.AvailableFreeSpace) * 100) / localDrive.TotalSize,
                        SpaceInfo = Math.Round((localDrive.AvailableFreeSpace / (1.074 * Math.Pow(10, 9)))).ToString() + " GB free of " +
                        Math.Round((localDrive.TotalSize / (1.074 * Math.Pow(10, 9)))).ToString() + " GB",
                        IsReady = localDrive.IsReady,
                        DriveImage = Convert.ToBase64String(File.ReadAllBytes("../../Resources/hdd.png"))

                    });
                } else
                {
                    LocalDrives.Add(new FE_LocalDriveInfo_M()
                    {
                        Name = localDrive.DriveType.ToString() + " (" + localDrive.Name.Substring(0, 1) + ":)",
                        IsReady = localDrive.IsReady,
                        DriveImage = Convert.ToBase64String(File.ReadAllBytes("../../Resources/hdd.png"))

                    });
                }
                
            }
        }
        private void toggleQacContents (object parameter)
        {
            qacVisibility = qacVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
        public void specialFolderClick(object parameter)
        {
            getFiles(parameter as string);
        }

        private void getDirectoryContents(object parameter)
        {
            clearDirectories();
            FE_DirectoryContents_M dirContents = parameter as FE_DirectoryContents_M;
            if (dirContents != null)
            {
                foreach (var dirContent in dirContents.Directories)
                {
                    DirectoriesWithHidden.Add(new FE_DirectoryInfo_M()
                    {
                        Name = dirContent.Name,
                        Contents = new FE_DirectoryContents_M()
                        {
                            Files = dirContent.GetFiles(),
                            Directories = dirContent.GetDirectories()
                        },
                        IsHidden = dirContent.Attributes.HasFlag(FileAttributes.Hidden),
                        FolderImage = Convert.ToBase64String(File.ReadAllBytes("../../Resources/folder.png"))
                    });
                }

                foreach (var dirContent in dirContents.Files)
                {
                    DirectoriesWithHidden.Add(new FE_DirectoryInfo_M()
                    {
                        Name = dirContent.Name,
                        Contents = null,
                        IsHidden = dirContent.Attributes.HasFlag(FileAttributes.Hidden),
                        FolderImage = Convert.ToBase64String(File.ReadAllBytes("../../Resources/folder.png"))
                    });
                }

                setDirectories();
            }

            
        }

        private void getFiles(string path)
        {
            ShowDirectories = Visibility.Visible;
            clearDirectories();
            if (path == null) throw new ArgumentNullException();
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                try
                {
                    FE_DirectoryInfo_M newDir = new FE_DirectoryInfo_M()
                    {
                        Name = dir.Name,
                        Contents = new FE_DirectoryContents_M()
                        {
                            Files = dir.GetFiles(),
                            Directories = dir.GetDirectories()
                        },
                        IsHidden = dir.Attributes.HasFlag(FileAttributes.Hidden),
                        FolderImage = Convert.ToBase64String(File.ReadAllBytes("../../Resources/folder.png"))
                    };
                    DirectoriesWithHidden.Add(newDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    continue;
                }
            }
            setDirectories();
        }

        private void clearDirectories()
        {
            Directories.Clear();
            DirectoriesWithHidden.Clear();
        }
        private void setDirectories()
        {
            Directories = _IsHiddenfilesVisible ? DirectoriesWithHidden :
            new ObservableCollection<FE_DirectoryInfo_M>(DirectoriesWithHidden.Where(d => !d.IsHidden).ToList());
        }
        #endregion
    }
}
