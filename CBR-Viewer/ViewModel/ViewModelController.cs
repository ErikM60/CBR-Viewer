#region Header
// *******************************************************************************************
// Copyright   : ©2012 Erik Molenaar
// Authors     : Erik Molenaar
// Date        : 17-09-2012
// Revision    : $Rev:  $
// RevDate     : $Date:  $
// Rep./File   : $URL:  $
// Worker      : $Author:  $
// Description : Databinding Controller
// *******************************************************************************************
#endregion // Header

using GalaSoft.MvvmLight;

namespace CBR_Viewer.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class ViewModelController : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelController class.
        /// </summary>
        public ViewModelController()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real": Connect to service, etc...
            ////}
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean own resources if needed

        ////    base.Cleanup();
        ////}
    }
}