using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using Example_CoreAnimation.Code.NavigationTable;

namespace Example_CoreAnimation.Screens.iPad.NavTable
{
	public class MasterNavTableViewController : UITableViewController
	{		
		public event EventHandler<RowClickedEventArgs> RowClicked;
		
		// declare vars
		List<NavItemGroup> navItems = new List<NavItemGroup> ();
		NavItemTableSource tableSource;
		
		public MasterNavTableViewController () : base (UITableViewStyle.Grouped)
		{
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			// hide the nav bar when this controller appears
			//this.NavigationController.SetNavigationBarHidden (true, true);
		}
		
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			// show the nav bar when other controllers appear
			//this.NavigationController.SetNavigationBarHidden (false, true);
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// create the navigation items
			NavItemGroup navGroup = new NavItemGroup ("UIView Animations");
			navItems.Add (navGroup);
			navGroup.Items.Add (new NavItem ("Flash Notification", "", typeof (NotificationViewController)));
			navGroup.Items.Add (new NavItem ("Pulse Glow", "", typeof (GlowPulseViewController)));

//			navGroup.Items.Add (new NavItem ("Basic Animation", "", typeof (BasicUIViewAnimation.BasicUIViewAnimationScreen)));
//			navGroup.Items.Add (new NavItem ("Animation Customizer", "", typeof (CustomizableAnimationViewer.CustomizableAnimationViewerScreen)));
//			navGroup.Items.Add (new NavItem ("Transitions", "", typeof (ViewTransitions.Controller)));
//			navGroup.Items.Add (new NavItem ("Implicit Layer Animation", "", typeof (LayerAnimation.ImplicitAnimationScreen)));
//			navGroup.Items.Add (new NavItem ("Explicit Layer Animation", "", typeof (LayerAnimation.LayerAnimationScreen)));

			NavItemGroup caGroup = new NavItemGroup("CA Animations");
			navItems.Add( caGroup );
			caGroup.Items.Add (new NavItem ("Attraction Loop", "", typeof (AttractionLoopViewController)));
			caGroup.Items.Add (new NavItem ("Infographic", "", typeof (InfoGraphicViewController)));
			caGroup.Items.Add (new NavItem ("Little Bounce", "", typeof (LittleBounceViewController)));


			NavItemGroup overtimeGroup = new NavItemGroup("Overtime");
			navItems.Add( overtimeGroup );
			overtimeGroup.Items.Add (new NavItem ("Rotation", "", typeof (RotationViewController)));
//			overtimeGroup.Items.Add (new NavItem ("Custom Property", "", typeof (Presentation.AnimationPresentation.ExplicitCustom)));

			
			// create a table source from our nav items
			tableSource = new NavItemTableSource (navItems);
			
			// set the source on the table to our data source
			base.TableView.Source =  tableSource;
			
			tableSource.RowClicked += (object sender, RowClickedEventArgs e) => {
				if(this.RowClicked != null)
					this.RowClicked(sender, e);
			};
		}

	}


}

