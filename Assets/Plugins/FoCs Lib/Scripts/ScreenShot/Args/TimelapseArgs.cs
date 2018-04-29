using System;

public class TimelapseArgs: ScreenShotArgs
{
	private DateTime Start;
	public int LoopCount = 0;

	public TimelapseArgs(ScreenShotArgs args, DateTime start)
		: base(args)
	{
		Start = start;
	}

	public override string GetFileName()
	{
		if(string.IsNullOrEmpty(fileName))
		{
			var strPath = "";

			strPath = string.Format("{0}/Timelapse[{3:yyyy-MM-dd(hh-mm-ss)}][{1}x{2}]px_Frame_{4}.png", Path, FrameWidth, FrameHeight, Start, LoopCount);

			return strPath;
		}
		return string.Format(fileName, LoopCount);
	}
}
