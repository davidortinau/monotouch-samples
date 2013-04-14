
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Example_CoreAnimation.Screens.iPad;
using MonoTouch.CoreAnimation;
using System.Timers;

namespace Example_CoreAnimation
{
	public partial class LittleBounceViewController : UIViewController, IDetailView
	{
		UIToolbar tlbrMain;

		UIView sidebarMenu;
		CALayer navHome;
		CALayer navAbout;
		CALayer navConnect;

		public LittleBounceViewController () : base ("LittleBounceViewController", null)
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
			
			draw();

			var timer = new System.Timers.Timer ();
			timer.Interval = 2000;
			timer.Elapsed += (object sender, ElapsedEventArgs e) => {
				((Timer)sender).Stop();
				InvokeOnMainThread(()=>{
					transitionIn();
				});
				
			};
			timer.Start();
		}

		void draw ()
		{
			createToolbar();
			createMenu();
		}

		void createMenu ()
		{
			sidebarMenu = new UIView( new RectangleF(0, 100, 300, 300) );
			View.AddSubview( sidebarMenu );

			navHome = new CALayer();
			navHome.Contents = UIImage.FromBundle("nav_home.png").CGImage;
			navHome.AnchorPoint = new PointF(0,0);
			navHome.Frame = new RectangleF(-295, 0, navHome.Contents.Width, navHome.Contents.Height);
			sidebarMenu.Layer.AddSublayer( navHome );


			navAbout = new CALayer();
			navAbout.Contents = UIImage.FromBundle("nav_about.png").CGImage;
			navAbout.AnchorPoint = new PointF(0,0);
			navAbout.Frame = new RectangleF(-295, 90, navAbout.Contents.Width, navAbout.Contents.Height);
			sidebarMenu.Layer.AddSublayer( navAbout );

			navConnect = new CALayer();
			navConnect.Contents = UIImage.FromBundle("nav_connect.png").CGImage;
			navConnect.AnchorPoint = new PointF(0,0);
			navConnect.Frame = new RectangleF(-295, 180, navConnect.Contents.Width, navConnect.Contents.Height);
			sidebarMenu.Layer.AddSublayer( navConnect );
		}

		void transitionIn ()
		{
			UIView.AnimationsEnabled = false;

			// timing is unnecessary since it'll be linear
			var localMediaTime = CAAnimation.CurrentMediaTime();

			var homeIn = new CAKeyFrameAnimation {
				KeyPath = "position.x",
				Duration = 1,
				BeginTime = localMediaTime,
				FillMode = CAFillMode.Forwards,
				RemovedOnCompletion = false,
				TimingFunction = CAMediaTimingFunction.FromName( CAMediaTimingFunction.Linear ),
				Values = createBounceValues()
			};

//			navHome.Frame = new RectangleF(new PointF(0,navHome.Frame.Y), navHome.Frame.Size);
			navHome.AddAnimation( homeIn, "homeIn" );

			var aboutIn = new CAKeyFrameAnimation {
				KeyPath = "position.x",
				Duration = 1,
				BeginTime = localMediaTime + 0.3,
				FillMode = CAFillMode.Forwards,
				RemovedOnCompletion = false,
				TimingFunction = CAMediaTimingFunction.FromName( CAMediaTimingFunction.Linear ),
				Values = createBounceValues()
			};
			
//			navAbout.Frame = new RectangleF(new PointF(0,navAbout.Frame.Y), navAbout.Frame.Size);
			navAbout.AddAnimation( aboutIn, "aboutIn" );

			var connectIn = new CAKeyFrameAnimation {
				KeyPath = "position.x",
				Duration = 1,
				BeginTime = localMediaTime + 0.6,
				FillMode = CAFillMode.Forwards,
				RemovedOnCompletion = false,
				TimingFunction = CAMediaTimingFunction.FromName( CAMediaTimingFunction.Linear ),
				Values = createBounceValues()
			};
			
//			navConnect.Frame = new RectangleF(new PointF(0,navConnect.Frame.Y), navConnect.Frame.Size);
			navConnect.AddAnimation( connectIn, "connectIn" );





		}

		NSObject[] createBounceValues ()
		{
			int steps = 100;
			NSObject[] values = new NSObject[steps];
			double value = 0;
			float fromValue = -295;// not used yet
			float toValue = 0;
			float e = 2.71f;
			for (int t = 0; t < steps; t++) {
				value = fromValue * Math.Pow(e, -0.055*t) * Math.Cos(0.08*t) + toValue;
				values[t] = NSNumber.FromDouble(value);
			}
			return values;
		}

		void createToolbar ()
		{
			tlbrMain = new UIToolbar {
				Frame = new RectangleF(0,0,View.Bounds.Width, 44)
			};
			View.AddSubview( tlbrMain );
			
		}

		/// <summary>
		/// 
		/// </summary>
		public void AddContentsButton (UIBarButtonItem button)
		{
			button.Title = "Contents";
			tlbrMain.SetItems(new UIBarButtonItem[] { button }, false );
		}
		
		public void RemoveContentsButton ()
		{
			tlbrMain.SetItems(new UIBarButtonItem[0], false);
		}

	}
}

