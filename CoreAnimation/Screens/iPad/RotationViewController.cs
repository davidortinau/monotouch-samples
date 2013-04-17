
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Example_CoreAnimation.Screens.iPad;
using MonoTouch.CoreAnimation;

namespace Example_CoreAnimation
{
	public partial class RotationViewController : UIViewController, IDetailView
	{
		UIToolbar tlbrMain;

		UIView spinner;

		public RotationViewController () : base ("RotationViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			buildUI();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			startSpinning();
		}

		void buildUI ()
		{
			createToolbar();
			createSpinner();
		}
		
		void createToolbar ()
		{
			tlbrMain = new UIToolbar {
				Frame = new RectangleF(0,0,View.Bounds.Width, 44)
			};
			View.AddSubview( tlbrMain );
			
		}

		void createSpinner ()
		{
			spinner = new UIView( new RectangleF(View.Center.X-50, View.Center.Y-50, 100, 100) );
			spinner.BackgroundColor = UIColor.Black;
			View.AddSubview( spinner );
		}

		void startSpinning ()
		{
			var spinAnim = new CABasicAnimation {
				KeyPath = "transform.rotation.z",
				To = NSNumber.FromDouble( Math.PI ),
				Duration = 0.4,
				Cumulative = true,
				RepeatCount = 999
			};

			spinner.Layer.AddAnimation( spinAnim, "spinMeRightRoundBabyRightRound" );
		}

		#region IDetailView implementation
		
		public void AddContentsButton (UIBarButtonItem button)
		{
			button.Title = "Contents";
			tlbrMain.SetItems(new UIBarButtonItem[] { button }, false );
		}
		
		public void RemoveContentsButton ()
		{
			tlbrMain.SetItems(new UIBarButtonItem[0], false);
		}
		
		#endregion
	}
}

