/* #################################################################################################
 *
 *  Program.cs
 *
 *  [[ Summary ]]
 *    entry point for text-control
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
using System.Text;

namespace TextControl {

	class MainClass {

		/* #########################################################################################
		 *
		 *   entry point
		 *
		 * ###################################################################################### */

		public static void Main(string[] args) {

			TextControl.RegexText objRegex = new TextControl.RegexText();
			ArrayList lstMatch = objRegex.extractWord("/Users/minminmink/Documents/test.txt",
				"(CLASS) +(?<class>[^¥.]+)", "class");

			foreach (string strWord in lstMatch) {
				Console.WriteLine(strWord);
			}
		}
	}

	class RegexText {

		/* #########################################################################################
		 *
		 *   regex
		 *
		 * ###################################################################################### */

		public ArrayList extractWord(string strPathSrc, string strRegex, string strGroup) {

			// load text-file
			//StreamReader stmReader = new StreamReader(strPathSrc, 
			//	Encoding.GetEncoding("Shift_JIS"));
			StreamReader stmReader = new StreamReader(strPathSrc, 
				Encoding.GetEncoding("UTF-8"));
			string strTextFile = stmReader.ReadToEnd();
			stmReader.Close();

			// extract match's text
			ArrayList lstMatch = new ArrayList();
			Regex rexRegex = new Regex(strRegex,
				RegexOptions.IgnoreCase | RegexOptions.Multiline);
			for (Match mthMatch = rexRegex.Match(strTextFile);
				 mthMatch.Success;
				 mthMatch = mthMatch.NextMatch()) {
				lstMatch.Add(mthMatch.Groups[strGroup].Value);
			}

			return lstMatch;
		}
	}
}
