using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Identity.Client;
using Android.Content;

namespace UserDetailsClient.Droid
{
    [Activity(Label = "UserDetailsClient", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            App.PCA.RedirectUri = "msala7d8cef0-4145-49b2-a91d-95c54051fa3f://auth";
            App.UiParent = new UIParent(this);

            #region Web browsers for MSAL.NET Android
            // To activate embedded webview, remove '//' from line 30 below, 
            // and comment out line 24 above -> App.UiParent = new UIParent(this);

            //App.UiParent = new UIParent(this, true);

            // Use helper method to determine first if Chrome or Chrome Custom Tabs
            // are installed on the device. 
            // Remove /* */ below, and
            // make sure lines 50 and 56 above are commented out.
            // Return false, launch with embedded webview -> or developer could include a custom
            // error message here for the user
            // Return true, launch with system browser
            /*bool useEmbeddedWebview = UIParent.IsSystemWebviewAvailable();
            if (useEmbeddedWebview)
            {
                // Chrome present on device, use system browser
                App.UiParent = new UIParent(this);
            }
            else
            {
                // Chrome not present on device, use embedded webview
                App.UiParent = new UIParent(this, true);
            }*/
            #endregion
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
        }
    }
}

