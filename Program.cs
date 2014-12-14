/* #################################################################################################
 *
 *  Program.cs
 *
 *  [[ Summary ]]
 *    entory point for text-control
 *
 *  [[ Object Related figure ]]
 *
 *    Program
 *
 * ############################################################################################## */
		/* #########################################################################################
		 * ###################################################################################### */
		/* *****************************************************************************************
		 * ****************************************************************************************/
		/* =========================================================================================
		 * ====================================================================================== */
		/* -----------------------------------------------------------------------------------------
		 * -------------------------------------------------------------------------------------- */

using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace TextControl {

	class MainClass {

		/* #########################################################################################
		 *
		 *   entori point
		 *
		 * ###################################################################################### */

		public static void Main(string[] args) {

			Console.WriteLine("Hello World!");
		}
	}

	class Regex {

		/* #########################################################################################
		 *
		 *   regex
		 *
		 * ###################################################################################### */

		public ArrayList extractWord(string strPathSrc, string strMatch, string strGroup) {

			// load text-file
			StreamReader stmReader = new StreamReader(strPathSrc, 
				Encoding.GetEncoding ("Shift_JIS"));
			string strTextFile = stmReader.ReadToEnd();
			stmReader.Close();

			// extract
			ArrayList lstMatch = new ArrayList();
			Regex rexRegex = new Regex("(CLASS) +(?<class>.+)¥.",
				RegexOptions.IgnoreCase | RegexOptions.Singleline);
			for (Match mthMatch = rexRegex.Match(strMatch);
				 mthMatch.Success;
				 mthMatch.NextMatch()) {
				lstMatch.Add(mthMatch.Groups[strGroup].Value);
			}
		}

	}
}
