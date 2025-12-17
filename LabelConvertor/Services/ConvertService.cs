using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static System.Resources.ResXFileRef;

namespace LabelConvertor.Services
{
	public static class ConvertService
	{
		private static readonly Dictionary<string, Action<FormMain>> _map
			= new Dictionary<string, Action<FormMain>>
		{
			["VOC2COCO"] = f => VocToCocoConverter.Convert(f.VocPath, f.CocoPath),
			["VOC2YOLO"] = f => VocToYoloConverter.Convert(f.VocPath, f.YoloPath),
			["YOLO2VOC"] = f => new YoloToVOC(f.ImagePath, f.YoloPath, f.VocPath).StartConvertion(),
			["YOLO2COCO"] = f => new YoloToCoco().Convert(f.ImagePath, f.YoloPath, f.CocoPath),
			["COCO2VOC"] = f => CocoToVocConverter.Convert(f.CocoPath, f.VocPath),
			["COCO2YOLO"] = f => CocoToYoloConverter.Convert(f.CocoPath, f.YoloPath),
		};

		public static void Execute(string mode, FormMain form)
		{
			if (_map.TryGetValue(mode, out var action))
				action(form);
			else
				throw new NotSupportedException(mode);
		}
	}
}
