#region Header
// *******************************************************************************************
// Copyright   : ©2013 Erik Molenaar
// Authors     : Erik Molenaar
// Date        : 27-01-2013
// Revision    : $Rev: 385 $
// RevDate     : $Date: 2013-01-27 10:49:47 +0100 (Sun, 27 Jan 2013) $
// Rep./File   : $URL: svn://localhost:48000/SVN-SmallProgs/ImageViewer/trunk/ImageViewer/CBR-Viewer/CBR-Viewer/Settings.cs $
// Worker      : $Author: xxx $
// Description : 
// *******************************************************************************************
#endregion // Header

namespace CBR_Viewer.Properties {
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings {
        
        public Settings() {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }
    }
}
