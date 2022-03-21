#region Header
// *******************************************************************************************
// Copyright   : ©2013 Erik Molenaar
// Authors     : Erik Molenaar
// Date        : 27-01-2013
// Revision    : $Rev: 385 $
// RevDate     : $Date: 2013-01-27 10:49:47 +0100 (Sun, 27 Jan 2013) $
// Rep./File   : $URL: svn://localhost:48000/SVN-SmallProgs/ImageViewer/trunk/ImageViewer/CBR-Viewer/CBR-Viewer/View/SettingsWindow.xaml.cs $
// Worker      : $Author: xxx $
// Description : 
// *******************************************************************************************
#endregion // Header

using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace CBR_Viewer
{
    /// <summary>
    /// Description for SettingsWindow.
    /// </summary>
    public partial class SettingsWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the SettingsWindow class.
        /// </summary>
        public SettingsWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<NotificationMessage>(this, ReplyToMessage);
        }

        private void ReplyToMessage(NotificationMessage msg)
        {
            switch ((SendType)msg.Target)
            {
                case SendType.CloseSettings:
                    {
                        this.Close();
                        return;
                    }
            }

        }


    }
}