
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Example_CoreAnimation.Screens.iPad;
using MonoTouch.CoreAnimation;
using System.Timers;
using V2DRuntime.Tween;

namespace Example_CoreAnimation
{
	public partial class LittleBounceViewController : UIViewController, IDetailView
	{

		UIToolbar tlbrMain;

		UIButton btn;

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

			addListeners();
		}

		void draw ()
		{
			createToolbar();
			createMenu();
			createButton ();
		}

		void createButton ()
		{
			btn = new UIButton (UIButtonType.RoundedRect);
			btn.SetTitle ("Replay", UIControlState.Normal);
			btn.Frame = new RectangleF ((View.Bounds.Width * 0.5f) - 100, (View.Bounds.Height * 0.5f) - 20, 200, 40);
			this.View.AddSubview (btn);
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

			NSObject[] keyframes = TweenBuilder.CreateKeyValues(-295, 0, Easing.EaseOutBounce);

			var homeIn = new CAKeyFrameAnimation {
				KeyPath = "position.x",
				Duration = 1.4,
				BeginTime = localMediaTime,
				FillMode = CAFillMode.Forwards,
				RemovedOnCompletion = false,
				TimingFunction = CAMediaTimingFunction.FromName( CAMediaTimingFunction.Linear ),
				Values = keyframes
			};

//			navHome.Frame = new RectangleF(new PointF(0,navHome.Frame.Y), navHome.Frame.Size);
			navHome.AddAnimation( homeIn, "homeIn" );

			var aboutIn = new CAKeyFrameAnimation {
				KeyPath = "position.x",
				Duration = 1.4,
				BeginTime = localMediaTime + 0.3,
				FillMode = CAFillMode.Forwards,
				RemovedOnCompletion = false,
				TimingFunction = CAMediaTimingFunction.FromName( CAMediaTimingFunction.Linear ),
				Values = keyframes
			};
			
//			navAbout.Frame = new RectangleF(new PointF(0,navAbout.Frame.Y), navAbout.Frame.Size);
			navAbout.AddAnimation( aboutIn, "aboutIn" );

			var connectIn = new CAKeyFrameAnimation {
				KeyPath = "position.x",
				Duration = 1.4,
				BeginTime = localMediaTime + 0.6,
				FillMode = CAFillMode.Forwards,
				RemovedOnCompletion = false,
				TimingFunction = CAMediaTimingFunction.FromName( CAMediaTimingFunction.Linear ),
				Values = keyframes
			};
			
//			navConnect.Frame = new RectangleF(new PointF(0,navConnect.Frame.Y), navConnect.Frame.Size);
			navConnect.AddAnimation( connectIn, "connectIn" );





		}

		void createToolbar ()
		{
			tlbrMain = new UIToolbar {
				Frame = new RectangleF(0,0,View.Bounds.Width, 44)
			};
			View.AddSubview( tlbrMain );
			
		}

		void addListeners ()
		{
			btn.TouchUpInside += replay;
		}

		void replay (object sender, EventArgs e)
		{
			UIView.AnimationsEnabled = false;
			navHome.Frame = new RectangleF(new PointF(-295, navHome.Frame.Y), navHome.Frame.Size);
			navAbout.Frame = new RectangleF(new PointF(-295, navAbout.Frame.Y), navAbout.Frame.Size);
			navConnect.Frame = new RectangleF(new PointF(-295, navConnect.Frame.Y), navConnect.Frame.Size);

			transitionIn();
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

