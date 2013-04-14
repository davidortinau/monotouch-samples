
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
			
			if (notification.Frame.Y < 0) {
				UIView.Animate (
					duration: 4, 
					delay: 0, 
					options: UIViewAnimationOptions.CurveEaseIn, 
					animation: () => {
						notification.Frame = new RectangleF (new PointF (0, 0), notification.Frame.Size);
					},
					completion: ()=>{
//						UIView.Animate(1, 0, UIViewAnimationOptions.Repeat, ()=>{
//							notification.BackgroundColor = UIColor.Red;
//						}, null);
					}
				);

				UIView.Animate (
					duration: 0.4, 
					delay: 10, 
					options: UIViewAnimationOptions.CurveEaseOut, 
					animation: () => {
						notification.Frame = new RectangleF (new PointF (0, -60), notification.Frame.Size);
					}, 
					completion: null
				);
				
			} else {
				UIView.Animate (0.4, 0, UIViewAnimationOptions.CurveEaseOut, () => {
					notification.Frame = new RectangleF (new PointF (0, -60), notification.Frame.Size);
				}, 
				null);
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

