using Java.Lang;

namespace Com.Google.Android.Cameraview
{
	public partial class Size : Object, IComparable
	{
		int IComparable.CompareTo (Object obj)
		{
			return CompareTo ((Size)obj);
		}
	}
}
