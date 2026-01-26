using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static System.Resources.ResXFileRef;

namespace LabelConverter.Services
{
	public static class ConvertService
	{
		private static void RunBySplit (
			LabelConverterControl f,
			Action train,
			Action val = null,
			Action test = null)
		{
			train ();
			if (f.useVal && val != null)
			{
				val ();
			}

			if (f.useTest && test != null)
			{
				test ();
			}
		}

		private static readonly Dictionary<string, Action<LabelConverterControl>> _map2
			= new Dictionary<string, Action<LabelConverterControl>>
			{
				["VOC to COCO"] = f =>
				{
					RunBySplit(
						f,
						() => VocToCocoConverter.Convert(f.LabelVocTrain, f.JsonFileTrain, f.Classes),
						() => VocToCocoConverter.Convert(f.LabelVocVal,   f.JsonFileVal,   f.Classes),
						() => VocToCocoConverter.Convert(f.LabelVocTest,  f.JsonFileTest,  f.Classes)
					);
				},

				["VOC to YOLO"] = f =>
					RunBySplit(
						f,
						() => VocToYoloConverter.Convert(f.LabelVocTrain, f.LabelYoloTrain, f.Classes),
						() => VocToYoloConverter.Convert(f.LabelVocVal,	  f.LabelYoloVal,   f.Classes),
						() => VocToYoloConverter.Convert(f.LabelVocTest,  f.LabelYoloTest,  f.Classes)
					),
				
				["YOLO to VOC"] = f =>
					RunBySplit(
						f,
						() => new YoloToVOC(f.ImageTrain, f.LabelYoloTrain, f.LabelVocTrain).StartConvertion(),
						() => new YoloToVOC(f.ImageVal,   f.LabelYoloVal,   f.LabelVocVal).StartConvertion(),
						() => new YoloToVOC(f.ImageTest,  f.LabelYoloTest,  f.LabelVocTest).StartConvertion()
					),
				
				["YOLO to COCO"] = f =>
					RunBySplit(
						f,
						() => new YoloToCoco().Convert(f.ImageTrain, f.LabelYoloTrain, f.JsonFileTrain, f.Classes),
						() => new YoloToCoco().Convert(f.ImageVal,   f.LabelYoloVal,   f.JsonFileVal,   f.Classes),
						() => new YoloToCoco().Convert(f.ImageTest,  f.LabelYoloTest,  f.JsonFileTest,  f.Classes)
					),
				
				["COCO to VOC"] = f =>
					RunBySplit(
						f,
						() => CocoToVocConverter.Convert(f.JsonFileTrain, f.LabelVocTrain),
						() => CocoToVocConverter.Convert(f.JsonFileVal,   f.LabelVocVal),
						() => CocoToVocConverter.Convert(f.JsonFileTest,  f.LabelVocTest)
					),
				
				["COCO to YOLO"] = f =>
					RunBySplit(
						f,
						() => CocoToYoloConverter.Convert(f.JsonFileTrain, f.LabelYoloTrain, f.Classes),
						() => CocoToYoloConverter.Convert(f.JsonFileVal,   f.LabelYoloVal,   f.Classes),
						() => CocoToYoloConverter.Convert(f.JsonFileTest,  f.LabelYoloTest,  f.Classes)
					)
			};

		public static void Execute(string mode, LabelConverterControl userControl)
		{
			if (_map2.TryGetValue(mode, out var action))
				action(userControl);
			else
				throw new NotSupportedException(mode);
		}
	}
}
