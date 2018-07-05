using Android.App;
using Android.Widget;
using Android.OS;
using Com.Google.Android.Cameraview.Vision;
using Android.Gms.Vision.Barcodes;
using Android.Content.PM;
using Android.Runtime;
using Android.Support.V4.Content;
using Android;
using Com.Google.Android.Cameraview;
using Android.Support.V4.App;
using System;
using Android.Util;

namespace Sample
{
	[Activity (Label = "Sample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		const int REQUEST_CAMERA_PERMISSION = 1;

		BarcodeScannerView camera;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var frameDelegate = new BarcodeProcessorDelegateImpl ();
			frameDelegate.OnBarcodeFound = x => Log.Debug ("Main", x.DisplayValue);
			frameDelegate.OnFailure = er => Log.Error ("Main", er.Message);

			// Get our button from the layout resource,
			// and attach an event to it
			camera = FindViewById<BarcodeScannerView> (Resource.Id.camera);
			camera.SetBarcodeType (BarcodeFormat.QrCode);
			camera.Scanning = true;
			camera.SetFrameDelegate (frameDelegate);
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			if (ContextCompat.CheckSelfPermission (this, Manifest.Permission.Camera) == Permission.Granted)
			{
				camera.Start ();
			}
			else if (ActivityCompat.ShouldShowRequestPermissionRationale (this, Manifest.Permission.Camera))
			{
				//	ConfirmationDialogFragment
				//			.newInstance (R.string.camera_permission_confirmation,
				//					new String[] { Manifest.permission.CAMERA },
				//					REQUEST_CAMERA_PERMISSION,
				//					R.string.camera_permission_not_granted)
				//			.show (getSupportFragmentManager (), FRAGMENT_DIALOG);
			}
			else
			{
				ActivityCompat.RequestPermissions (this, new string[] { Manifest.Permission.Camera }, REQUEST_CAMERA_PERMISSION);
			}
		}

		public override void OnRequestPermissionsResult (int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			switch (requestCode)
			{
				case REQUEST_CAMERA_PERMISSION:
					if (permissions.Length != 1 || grantResults.Length != 1)
					{
						throw new InvalidOperationException ("Error on requesting camera permission.");
					}
					if (grantResults[0] != Permission.Granted)
					{
						Toast.MakeText (this, "camera_permission_not_granted", ToastLength.Short).Show ();
					}
					// No need to start camera here; it is handled by onResume
					break;
			}
		}
	}
}

