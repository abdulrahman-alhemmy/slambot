using System;

namespace SLAM
{
	/// <summary>
	/// Map view.
	/// </summary>
	public class MapView
	{
		private Map map; // Map model that this view represents.
		private RobotView robotView;
		private LandmarkView landmarkView;

		// Some dimensions and coordinates related to drawing the map.
		private int viewWidth;
		private int viewHeight;
		private int centerX;
		private int centerY;

		#region Public Properties

		/// <summary>
		/// Gets or sets the map.
		/// </summary>
		/// <value>The map.</value>
		public Map Map
		{
			get
			{
				return map;
			}
			set
			{
				map = value;
			}
		}

		/// <summary>
		/// Gets or sets the robot view.
		/// </summary>
		/// <value>The robot view.</value>
		public RobotView RobotView
		{
			get
			{
				return robotView;
			}
			set
			{
				robotView = value;
			}
		}

		/// <summary>
		/// Gets or sets the width of the view.
		/// </summary>
		/// <value>The width of the view.</value>
		public int ViewWidth
		{
			get
			{
				return viewWidth;
			}
			set
			{
				viewWidth = value;
			}
		}

		/// <summary>
		/// Gets or sets the height of the view.
		/// </summary>
		/// <value>The height of the view.</value>
		public int ViewHeight
		{
			get
			{
				return viewHeight;
			}
			set
			{
				viewHeight = value;
			}
		}

		#endregion

		#region Public Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SLAM.MapView"/> class.
		/// </summary>
		/// <param name="mapModel">Map model.</param>
		public MapView (Map mapModel)
		{
			map = mapModel;
			robotView = new RobotView (map.Robot);
			landmarkView = new LandmarkView (map.Landmarks);

			// Map width and height is specified in meters, and we are using
			// 1 pixel to every centimeter, so scale up by 100.
			viewWidth = (int)(map.Width * 100);
			viewHeight = (int)(map.Height * 100);
			centerX = (int)((map.Width / 2) * 100);
			centerY = (int)((map.Height / 2) * 100);
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Draw the map and all of the sub elements.
		/// </summary>
		/// <param name="cairoContext">Cairo context.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public void Draw (Cairo.Context cairoContext, int x, int y)
		{
			// Draw the background.
			cairoContext.Rectangle (x, y, viewWidth, viewHeight);
			cairoContext.SetSourceRGB(255, 255, 255);
			cairoContext.StrokePreserve ();
			cairoContext.Fill ();

			robotView.Draw (cairoContext, centerX + x, centerY + y, 1.0);
			landmarkView.Draw (cairoContext, centerX + x, centerY + y, 1.0);
		}

		#endregion
	}
}
