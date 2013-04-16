using System;
using MonoTouch.UIKit;
using Example_CoreAnimation.Screens.iPad;

namespace Presentation
{
	public abstract class DemoViewController : UIViewController, IDetailView
	{
		public DemoViewController ()
		{
			View.BackgroundColor = UIColor.DarkGray;
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}

		#region IDetailView implementation

		public void AddContentsButton (UIBarButtonItem button)
		{
//			throw new NotImplementedException ();
		}

		public void RemoveContentsButton ()
		{
//			throw new NotImplementedException ();
		}

		#endregion
	}
}

