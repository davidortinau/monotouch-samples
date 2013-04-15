using System;
using MonoTouch.Foundation;

namespace Example_CoreAnimation
{
	public delegate float EasingFormula(float t, float start, float length);

	public class TweenBuilder
	{
		public static NSObject[] CreateKeyValues (float fromValue, float toValue, EasingFormula easingFormula, int steps = 100)
		{
			NSObject[] values = new NSObject[steps];
			double value = 0;
			float curTime = 0;
			for (int t = 0; t < steps; t++) {
				curTime = (float)t / (float)steps;
				var easingFactor = easingFormula(curTime, 0, 1);
				value = (toValue - fromValue) * easingFactor + fromValue;
				
				values[t] = NSNumber.FromDouble(value);
			}
			return values;
		}
	}
}

