
using System;
using Android.Runtime;

namespace Com.Google.Android.Cameraview.Vision
{
	public class FrameProcessorDelegate<T> : Java.Lang.Object, IFrameProcessorDelegate
		where T: class, IJavaObject
	{
		public Action<Exception> OnError;
		public Action<T> OnSuccess;

		void IFrameProcessorDelegate.OnError (Java.Lang.Exception p0)
		{
			OnError?.Invoke (p0);
		}

		void IFrameProcessorDelegate.OnSuccess (Java.Lang.Object p0)
		{
			OnSuccess.Invoke (p0.JavaCast<T> ());
		}
	}
}
