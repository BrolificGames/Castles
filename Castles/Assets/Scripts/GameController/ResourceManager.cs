using UnityEngine;
using System.Collections;

namespace Castles 
{
	public static class ResourceManager
	{
		public static float ScrollSpeed { get { return 25; } }
		public static float RotateSpeed { get { return 100; } }
		public static int ScrollWidth { get { return 15; } }
		public static int Wood { get; set; }
		public static int Stone { get; set; }
		public static int Food { get; set; }
	}
}
