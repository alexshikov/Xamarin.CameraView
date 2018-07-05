using System;
using Android.Gms.Vision.Barcodes;

namespace Com.Google.Android.Cameraview.Vision
{
	public class BarcodeProcessorDelegateImpl: BarcodeProcessorDelegate
	{
		public Action<Barcode> OnBarcodeFound;

		public Action<Exception> OnFailure;

		public override void OnBarcodeDetected (Barcode p0)
		{
			OnBarcodeFound?.Invoke (p0);
		}

		public override void OnError (Java.Lang.Exception p0)
		{
			OnFailure?.Invoke (p0);
		}
	}
}
