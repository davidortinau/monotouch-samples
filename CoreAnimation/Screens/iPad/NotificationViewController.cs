
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Example_CoreAnimation.Screens.iPad;

namespace Example_CoreAnimation
{
	public partial class NotificationViewController : UIViewController, IDetailView
	{
		UIView notification;
		UIButton btn;
		UIButton closeBtn;

		UIToolbar tlbrMain;

		public NotificationViewController () : base ("NotificationViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			buildUI();
			addListeners();
		}


		void buildUI ()
		{
			createToolbar();
			createNotification ();
			createButton ();
		}

		void addListeners ()
		{
			btn.TouchUpInside += toggleNotification;
		}

		void createToolbar ()
		{
			tlbrMain = new UIToolbar {
				Frame = new RectangleF(0,0,View.Bounds.Width, 44)
			};
			View.AddSubview( tlbrMain );

		}
		
		void createNotification ()
		{
			notification = new UIView (new RectangleF (0, -60, View.Bounds.Width, 60));
			notification.BackgroundColor = UIColor.DarkGray;
			
			UILabel label = new UILabel (new RectangleF (20, 20, 300, 20));
			label.Text = "Success!";
			label.BackgroundColor = UIColor.Clear;
			label.TextColor = UIColor.White;
			notification.AddSubview (label);

			closeBtn = new UIButton (UIButtonType.Custom);
			closeBtn.SetImage( UIImage.FromBundle("btnClose_normal.png"), UIControlState.Normal );
			closeBtn.SetImage( UIImage.FromBundle("btnClose_down.png"), UIControlState.Selected );
			closeBtn.Frame = new RectangleF (notification.Frame.Width - 80, (notification.Bounds.Height * 0.5f) - 37, 74, 74);
			closeBtn.TouchUpInside += (object sender, EventArgs e) => {
				Console.WriteLine("close it");
				toggleNotification(sender, e);
			};

			notification.AddSubview (closeBtn);


			
			this.View.AddSubview (notification);
		}
		
		void createButton ()
		{
			btn = new UIButton (UIButtonType.RoundedRect);
			btn.SetTitle ("Display Notification", UIControlState.Normal);
			btn.Frame = new RectangleF ((View.Bounds.Width * 0.5f) - 100, (View.Bounds.Height * 0.5f) - 20, 200, 40);
			this.View.AddSubview (btn);
		}
		
		void toggleNotification (object sender, EventArgs e)
		{
			Console.WriteLine("toggle");

			if (notification.Layer.PresentationLayer.Frame.Y < 0) {
				UIView.Animate (0.8, 0, UIViewAnimationOptions.CurveEaseIn | UIViewAnimationOptions.AllowUserInteraction, () => {
					notification.Frame = new RectangleF (new PointF (0, 0), notification.Frame.Size);					
				}, 
				()=>{
					UIView.Animate(1, 0, UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.AllowUserInteraction, ()=>{
						notification.BackgroundColor = UIColor.Red;
					}, ()=>{
						notification.BackgroundColor = UIColor.DarkGray;
						UIView.Animate (
							duration: 0.4, 
							delay: 4, 
							options: UIViewAnimationOptions.CurveEaseOut | UIViewAnimationOptions.AllowUserInteraction, 
							animation: () => {
								notification.Frame = new RectangleF (new PointF (0, -60), notification.Frame.Size);
							}, 
							completion:null
						);
					});
				});

				// Animation blocks can be nested, but sequentially you'll get unexpected behavior
				// also any interaction within the box with the button while animations are pending doesn't work without doing a hittest
				// using the presentationlayer

				
			} else {
				Console.WriteLine("kill last animation");
				notification.Layer.RemoveAllAnimations();
				notification.Frame = new RectangleF (new PointF (0, 0), notification.Frame.Size);
				UIView.Animate (1.2, 0, UIViewAnimationOptions.CurveEaseOut, () => {
					notification.Frame = new RectangleF (new PointF (0, -60), notification.Frame.Size);
				}, 
				null);
			}
			
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);

			UITouch touch = touches.AnyObject as UITouch;
			var touchPoint = touch.LocationInView(View);
			if(closeBtn.Layer.PresentationLayer.HitTest(touchPoint) != null){
				toggleNotification(null, null);
			}

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

