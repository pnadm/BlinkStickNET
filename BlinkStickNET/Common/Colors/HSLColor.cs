namespace BlinkStickNET.Common.Colors;

// http://en.wikipedia.org/wiki/HSL_color_space
public struct HSLColor 
{
	double _mHue;
	double _mSaturation;
	double _mLightness;

	public double Hue
	{
		get { return _mHue; }
		set { _mHue = value; }
	}
	public double Saturation
	{
		get { return _mSaturation; }
		set { _mSaturation = value; }
	}
	public double Lightness
	{
		get { return _mLightness; }
		set
		{ 
			_mLightness = value;
			if (_mLightness < 0)
				_mLightness = 0;
			if (_mLightness > 1)
				_mLightness = 1;
		}
	}
	public HSLColor(double hue, double saturation, double lightness)
	{
		_mHue = Math.Min(360, hue);
		_mSaturation = Math.Min(1, saturation);
		_mLightness = Math.Min(1, lightness);
	}
	public HSLColor(RgbColor color)
	{
		_mHue = 0;
		_mSaturation = 1;
		_mLightness = 1;
		FromRGB(color);
	}
	public RgbColor Color
	{
		get { return ToRGB(); }
		set { FromRGB(value); }
	}
	void FromRGB(RgbColor cc)
	{
		double r = cc.R / 255d;
		double g = cc.G / 255d;
		double b = cc.B / 255d;
			
		double min = Math.Min(Math.Min(r, g), b);
		double max = Math.Max(Math.Max(r, g), b);
		
		// calulate hue according formula given in
		// "Conversion from RGB to HSL or HSV"
		_mHue = 0;
		if (min != max)
		{
			if (r == max && g >= b)
			{
				_mHue = 60 * ((g - b) / (max - min)) + 0;
			}
			else if (r == max && g < b)
			{
				_mHue = 60 * ((g - b) / (max - min)) + 360;
			}
			else if (g == max)
			{
				_mHue = 60 * ((b - r) / (max - min)) + 120;
			}
			else if (b == max)
			{
				_mHue = 60 * ((r - g) / (max - min)) + 240;
			}
		}
		
		// find lightness
		_mLightness = (min+max)/2;

		// find saturation
		if (_mLightness == 0 || min.Equals(max))
			_mSaturation = 0;
		else if (_mLightness > 0 && _mLightness <= 0.5)
			_mSaturation = (max-min)/(2*_mLightness);
		else if (_mLightness > 0.5)
			_mSaturation = (max-min)/(2-2*_mLightness);
	}
	
	RgbColor ToRGB()
	{
		// convert to RGB according to
		// "Conversion from HSL to RGB"
		double r = _mLightness;
		double g = _mLightness;
		double b = _mLightness;
		if (_mSaturation == 0)
			return RgbColor.FromRgb((int)(r*255), (int)(g*255), (int)(b*255));

		double q;
		if (_mLightness < 0.5)
			q = _mLightness * (1 + _mSaturation);
		else
			q = _mLightness + _mSaturation - (_mLightness * _mSaturation);
		double p = 2 * _mLightness - q;
		double hk = _mHue / 360;

		// r,g,b colors
		double[] tc = { hk + (1d/3d), hk, hk-(1d/3d)};
		double[] colors = {0, 0, 0};

		for (int color = 0; color < colors.Length; color++)
		{
			if (tc[color] < 0)
				tc[color] += 1;
			
			if (tc[color] > 1)
				tc[color] -= 1;

			if (tc[color] < (1d/6d))
				colors[color] = p + ((q-p)*6*tc[color]);
			else if (tc[color] >= (1d/6d) && tc[color] < (1d/2d))
				colors[color] = q;
			else if (tc[color] >= (1d/2d) && tc[color] < (2d/3d))
				colors[color] = p + ((q-p)*6*(2d/3d - tc[color]));
			else
				colors[color] = p;

			colors[color] *= 255; // convert to value expected by Color
		}
		
		return RgbColor.FromRgb((int)colors[0], (int)colors[1], (int)colors[2]);
	}

	public static bool operator != (HSLColor left, HSLColor right) => !(left == right);
	public static bool operator == (HSLColor left, HSLColor right) =>
		left.Hue == right.Hue 
		&& left.Lightness == right.Lightness 
		&& left.Saturation == right.Saturation;

	public override string ToString() =>
		$"HSL({Hue:f2}, {Saturation:f2}, {Lightness:f2}) " +
		$"RGB({Color.R:x2}, {Color.G:x2}, {Color.B:x2})"; 
}