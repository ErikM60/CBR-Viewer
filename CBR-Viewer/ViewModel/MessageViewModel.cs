#region Header
// *******************************************************************************************
// Copyright   : ©2012 Erik Molenaar
// Authors     : Erik Molenaar
// Date        : 17-09-2012
// Revision    : $Rev: 385 $
// RevDate     : $Date: 2013-01-27 10:49:47 +0100 (Sun, 27 Jan 2013) $
// Rep./File   : $URL: svn://localhost:48000/SVN-SmallProgs/ImageViewer/trunk/ImageViewer/CBR-Viewer/CBR-Viewer/ViewModel/MessageViewModel.cs $
// Worker      : $Author: xxx $
// Description : Databinding for Message
// *******************************************************************************************
#endregion // Header

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace CBR_Viewer.ViewModel
{
    public class MessageViewModel : ViewModelBase
    {
        public RelayCommand OKCommand { get; private set; }

        public string CaptionText { get; set; }
        public const string CaptionTextPropertyName = "CaptionText";
        public string ContentText { get; set; }
        public const string ContentTextPropertyName = "ContentText";


        /// <summary>
        /// Initializes a new instance of the MessageViewModel class.
        /// </summary>
        public MessageViewModel()
        {
            this.OKCommand = new RelayCommand(() =>
            {
            });
        }

    }
}