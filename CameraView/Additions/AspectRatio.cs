using Java.Lang;

namespace Com.Google.Android.Cameraview
{
	public partial class AspectRatio: Object, IComparable
	{
		int IComparable.CompareTo (Object obj)
		{
			return CompareTo ((AspectRatio)obj);
		}
	}
}
