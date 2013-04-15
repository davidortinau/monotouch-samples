
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Example_CoreAnimation.Screens.iPad;
using MonoTouch.CoreGraphics;
using MonoTouch.CoreAnimation;
using System.Timers;

namespace Example_CoreAnimation
{
	public partial class InfoGraphicViewController : UIViewController, IDetailView
	{
		UIToolbar tlbrMain;

		UISlider slider;
		CAShapeLayer dot;

		UIView infoGraphic;
		Timer timer;

		protected UIBezierPath animationPath;

		protected UIImageView backgroundImage = null;

		private const float M_PI = (float)Math.PI;

		public InfoGraphicViewController () : base ("InfoGraphicViewController", null)
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
			startTimer();
		}

		void buildUI ()
		{
			createToolbar();
			createInfoGraphic();
			createSlider();
			createPath();
		}

		void startTimer ()
		{
			// add a new dot and kickoff animation of that dot every x
			timer = new Timer {
				Interval = 2000
			};
			timer.Elapsed += onTimerElapsed;
			timer.Start();
		}

		void createToolbar ()
		{
			tlbrMain = new UIToolbar {
				Frame = new RectangleF(0,0,View.Bounds.Width, 44)
			};
			View.AddSubview( tlbrMain );
			
		}

		void createInfoGraphic ()
		{
			infoGraphic = new UIView( new RectangleF( 0, 0, 768, 571) );

//			var bg = new CALayer();
//			bg.Contents = UIImage.FromBundle("Renewables.png").CGImage;
//			bg.Frame = new RectangleF(0, 0, bg.Contents.Width, bg.Contents.Height);
//			infoGraphic.Layer.AddSublayer( bg );

			infoGraphic.Layer.Contents = UIImage.FromBundle("Renewables.png").CGImage;

			View.AddSubview( infoGraphic );
		}

		void createSlider ()
		{
			slider = new UISlider {
				Frame = new RectangleF(500, 330, 250, 40),
				MaximumTrackTintColor = UIColor.Black,
				MinimumTrackTintColor = UIColor.Clear.FromHex(0xFAA851),
				MinValue = 0,
				MaxValue = 1,
				Value = 0
			};

			slider.SetThumbImage( UIImage.FromBundle("ScrollThumb"), UIControlState.Normal );

			CGAffineTransform trans = CGAffineTransform.MakeRotation(M_PI * -0.5f);
			slider.Transform = trans;

			View.AddSubview( slider );
		}

		void createPath ()
		{
//			var strokeColor = UIColor.FromRGB(red: 186, green: 220, blue: 232);
//			animationPath = new UIBezierPath ();
//			animationPath.MoveTo( new PointF(240,214) );
//			animationPath.AddLineTo( new PointF(188,234) );
//			animationPath.AddLineTo( new PointF(225,292) );
//			animationPath.AddCurveToPoint( new PointF(227,300), controlPoint1: new PointF(226,294), controlPoint2: new PointF(227,296));
//			animationPath.AddCurveToPoint( new PointF(227,305), controlPoint1: new PointF(227,302), controlPoint2: new PointF(227,304));
//			animationPath.AddLineTo( new PointF(227,341) );
//			animationPath.AddLineTo( new PointF(227,343) );
//			animationPath.AddCurveToPoint( new PointF(229,348), controlPoint1: new PointF(228,345), controlPoint2: new PointF(228,346));
//			animationPath.AddCurveToPoint( new PointF(239,349), controlPoint1: new PointF(230,351), controlPoint2: new PointF(234,352));
//			animationPath.AddCurveToPoint( new PointF(256,339), controlPoint1: new PointF(248,344), controlPoint2: new PointF(253,341));
//			animationPath.AddCurveToPoint( new PointF(260,335), controlPoint1: new PointF(258,338), controlPoint2: new PointF(260,336));
//			animationPath.AddLineTo( new PointF(261,333) );
//			animationPath.AddLineTo( new PointF(261,412) );
//			animationPath.AddCurveToPoint( new PointF(269,438), controlPoint1: new PointF(261,424), controlPoint2: new PointF(263,433));
//			animationPath.AddCurveToPoint( new PointF(294,445), controlPoint1: new PointF(274,442), controlPoint2: new PointF(282,445));
//			animationPath.AddLineTo( new PointF(738,445) );
//
//			animationPath.UsesEvenOddFillRule = true;
//
//			strokeColor.SetStroke();
//			animationPath.LineWidth = 4;
//			animationPath.Stroke();

			//// Color Declarations
			UIColor color = UIColor.FromRGBA(0.678f, 0.831f, 0.887f, 1.000f);
			
			//// Bezier Drawing
			UIBezierPath bezierPath = new UIBezierPath();
			bezierPath.MoveTo(new PointF(264.3f, 253.29f));
			bezierPath.AddLineTo(new PointF(206.7f, 275.09f));
			bezierPath.AddLineTo(new PointF(247.95f, 338.85f));
			bezierPath.AddCurveToPoint(new PointF(249.91f, 347.74f), new PointF(249.01f, 340.67f), new PointF(249.66f, 343.63f));
			bezierPath.AddCurveToPoint(new PointF(249.97f, 353.3f), new PointF(250.06f, 349.77f), new PointF(250.08f, 351.62f));
			bezierPath.AddLineTo(new PointF(249.97f, 392.54f));
			bezierPath.AddLineTo(new PointF(250.13f, 394.83f));
			bezierPath.AddCurveToPoint(new PointF(251.44f, 399.4f), new PointF(250.39f, 396.64f), new PointF(250.82f, 398.17f));
			bezierPath.AddCurveToPoint(new PointF(262.5f, 400.77f), new PointF(253.51f, 403.37f), new PointF(257.2f, 403.82f));
			bezierPath.AddCurveToPoint(new PointF(281.03f, 390.41f), new PointF(272.21f, 395.39f), new PointF(278.38f, 391.94f));
			bezierPath.AddCurveToPoint(new PointF(286.1f, 385.29f), new PointF(283.76f, 388.81f), new PointF(285.45f, 387.11f));
			bezierPath.AddLineTo(new PointF(286.27f, 383));
			bezierPath.AddLineTo(new PointF(286.27f, 469.44f));
			bezierPath.AddCurveToPoint(new PointF(295.2f, 497.78f), new PointF(286.27f, 482.88f), new PointF(289.24f, 492.33f));
			bezierPath.AddCurveToPoint(new PointF(322.56f, 505.25f), new PointF(300.69f, 502.76f), new PointF(309.81f, 505.25f));
			bezierPath.AddLineTo(new PointF(807.07f, 505.19f));

			bezierPath.UsesEvenOddFillRule = true;

			color.SetStroke();
			bezierPath.LineWidth = 4;
			bezierPath.Stroke();

			animationPath = bezierPath;
			

		}

		protected void DrawPathAsBackground ()
		{
			// create our offscreen bitmap context
			// size
			SizeF bitmapSize = new SizeF (View.Frame.Size);
			using (CGBitmapContext context = new CGBitmapContext (
				IntPtr.Zero,
				(int)bitmapSize.Width, (int)bitmapSize.Height, 8,
				(int)(4 * bitmapSize.Width), CGColorSpace.CreateDeviceRGB (),
				CGImageAlphaInfo.PremultipliedFirst)) {
				
				// convert to View space
				CGAffineTransform affineTransform = CGAffineTransform.MakeIdentity ();
				// invert the y axis
				affineTransform.Scale (1, -1);
				// move the y axis up
				affineTransform.Translate (0, View.Frame.Height);
				context.ConcatCTM (affineTransform);
				
				// actually draw the path
				context.AddPath (animationPath.CGPath);
				context.SetStrokeColor (UIColor.LightGray.CGColor);
				context.SetLineWidth (3);
				context.StrokePath ();
				
				// set what we've drawn as the backgound image
				backgroundImage = new UIImageView (View.Frame);
				View.AddSubview (backgroundImage);
				backgroundImage.Image = UIImage.FromImage (context.ToImage());
			}
		}

		void addDot ()
		{
			dot = new CAShapeLayer();
			dot.Path = UIBezierPath.FromOval( new RectangleF(-10, 10, 20, 20) ).CGPath;
			dot.FillColor = UIColor.Clear.FromHex(0xFAA851).CGColor;
			dot.LineWidth = 0;

			infoGraphic.Layer.AddSublayer( dot );

			animateDot();
		}

		void animateDot ()
		{
			CAKeyFrameAnimation keyFrameAnimation = (CAKeyFrameAnimation)CAKeyFrameAnimation.FromKeyPath ("position");
			keyFrameAnimation.Path =  animationPath.CGPath;
			keyFrameAnimation.Duration = 5;
			keyFrameAnimation.CalculationMode = CAKeyFrameAnimation.AnimationPaced;
			keyFrameAnimation.FillMode = CAFillMode.Forwards;
			
			keyFrameAnimation.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.Linear);
			
			dot.AddAnimation (keyFrameAnimation, "MoveImage");
			dot.Position = new PointF (222, 326);
		}

		void onTimerElapsed (object sender, ElapsedEventArgs e)
		{
			Console.WriteLine("onTimerElapsed");
			InvokeOnMainThread( ()=>{
				addDot();
			});
			timer.Stop();
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