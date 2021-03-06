
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Example_CoreAnimation.Screens.iPad;

namespace Example_CoreAnimation
{
	public partial class GlowPulseViewController : UIViewController, IDetailView
	{
		UIToolbar tlbrMain;

		UIView menuBar;

		UIButton btn1;
		UIButton btn2;
		UIButton btn3;
		UIButton btn4;
		UIButton btn5;

		UIView glow;

		public GlowPulseViewController ()
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
			

		}

		public override void ViewWillAppear (bool animated)
		{
			buildUI();

		}

		public override void ViewDidAppear (bool animated)
		{
			doGlowPulse();
		}

		public override void ViewWillDisappear (bool animated)
		{
			glow.Layer.RemoveAllAnimations();
			glow.Alpha = 0;

		}

		void buildUI ()
		{
			if(tlbrMain == null){
				createToolbar();
				createBackground();
				createButtons();
			}
		}

		void createToolbar ()
		{
			tlbrMain = new UIToolbar {
				Frame = new RectangleF(0,0,View.Bounds.Width, 44)
			};
			View.AddSubview( tlbrMain );
			
		}

		void createBackground ()
		{
			View.Layer.Contents = UIImage.FromBundle("page_bkg.png").CGImage;
		}

		void createButtons ()
		{
			menuBar = new UIView {
				Frame = new RectangleF( 300, 90, 668, 100),
				BackgroundColor = UIColor.Clear.FromHex(0x666666)
			};

			menuBar.Layer.ShadowColor = UIColor.DarkGray.CGColor;
			menuBar.Layer.ShadowOpacity = 1.0f;
//			menuBar.Layer.ShadowRadius = 6.0f;
			menuBar.Layer.ShadowOffset = new System.Drawing.SizeF(0f, 3f);

			View.AddSubview( menuBar );

			btn1 = new UIButton (UIButtonType.Custom);
			btn1.Frame = new RectangleF(40, 17, 65, 65);
			btn1.SetImage( UIImage.FromBundle("discButtons/button1_small.png"), UIControlState.Normal );
			menuBar.AddSubview( btn1 );

			btn2 = new UIButton (UIButtonType.Custom);
			btn2.Frame = new RectangleF(120, 17, 65, 65);
			btn2.SetImage( UIImage.FromBundle("discButtons/button2_small.png"), UIControlState.Normal );
			menuBar.AddSubview( btn2 );

			btn3 = new UIButton (UIButtonType.Custom);
			btn3.Frame = new RectangleF(200, 17, 65, 65);
			btn3.SetImage( UIImage.FromBundle("discButtons/button3_small.png"), UIControlState.Normal );
			menuBar.AddSubview( btn3 );

			btn4 = new UIButton (UIButtonType.Custom);
			btn4.Frame = new RectangleF(280, 17, 65, 65);
			btn4.SetImage( UIImage.FromBundle("discButtons/button4_small.png"), UIControlState.Normal );
			menuBar.AddSubview( btn4 );

			glow = new UIView( new RectangleF(350, 6, 85, 85) );
			glow.Layer.Contents = UIImage.FromBundle("discButtons/button5_small_glow.png").CGImage;
			glow.Alpha = 0;
			menuBar.AddSubview( glow );

			btn5 = new UIButton (UIButtonType.Custom);
			btn5.Frame = new RectangleF(360, 17, 65, 65);
			btn5.SetImage( UIImage.FromBundle("discButtons/button5_small.png"), UIControlState.Normal );
			menuBar.AddSubview( btn5 );



		}

		void doGlowPulse ()
		{
			Console.WriteLine("do pulse");
//			UIView.Animate(0, ()=>{ glow.Alpha = 0;});

			UIView.Animate(
				duration: 1,
				delay: 0,
				options: UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.Repeat,
				animation: ()=>{
					glow.Alpha = 1;
				},
				completion: null
			);

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

