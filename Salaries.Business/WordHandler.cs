/*
 * Author: Popa Ionel
 * Nume fisier: WordHandler.cs
 * Description: Contine o clasa wrapper pentru lucru cu aplicatia Word
 */

using System;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for WordHandler.
	/// </summary>
	public class WordHandler
	{
		private Word.ApplicationClass oWordApplic;	// a reference to Word application
		private Word.Document oDoc;					// a reference to the document
		
		public WordHandler()
		{
			// activate the interface with the COM object of Microsoft Word
			oWordApplic = new Word.ApplicationClass();
		}
		// Open a file (the file must exists) and activate it
		public void Open( string strFileName)
		{
			object fileName = strFileName;
			object readOnly = false;
			object isVisible = true;
			object missing = System.Reflection.Missing.Value;

			oDoc = oWordApplic.Documents.Open(ref fileName, ref missing,ref readOnly, 
				ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, 
				ref missing, ref missing, ref isVisible,ref missing,ref missing,ref missing, ref missing);

			oDoc.Activate();			
		}		


		// Open a new document
		public void Open( )
		{
			object missing = System.Reflection.Missing.Value;
			oDoc = oWordApplic.Documents.Add(ref missing, ref missing,ref missing, ref missing);

			oDoc.Activate();			
		}		


		//Quit the application
		public void Quit( )
		{
			object missing = System.Reflection.Missing.Value;
			oWordApplic.Application.Quit(ref missing, ref missing, ref missing);	
		}		


		//Saves the document
		public void Save( )
		{
			oDoc.Save();			
		}		


		//Saves the document as a different name
		public void SaveAs(string strFileName )
		{
			object missing = System.Reflection.Missing.Value;
			object fileName = strFileName;

			oDoc.SaveAs(ref fileName, ref missing,ref missing, ref missing,ref missing,ref missing,ref missing,
				ref missing,ref missing,ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
		}		


		// Save the document in HTML format
		public void SaveAsHtml(string strFileName )
		{
			object missing = System.Reflection.Missing.Value;
			object fileName = strFileName;
			object Format = (int)Word.WdSaveFormat.wdFormatHTML;
			oDoc.SaveAs(ref fileName, ref Format,ref missing, ref missing,ref missing,ref missing,ref missing,
				ref missing,ref missing,ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
		}		
		

		//Inserts text in one cell of a specific table
		public void AddCellInfo( int tableIndex, int cellRow, int cellCollumn, string info)
		{
			Word.Cell cell = oDoc.Tables[tableIndex].Cell(cellRow, cellCollumn);
			cell.Select();
			InsertText( info);
		}
		
		//Inserts a new row in the table
		public void AddRow( int tableIndex)
		{
			Object oMissing = System.Reflection.Missing.Value;
			oDoc.Tables[tableIndex].Rows.Add( ref oMissing);
		}

		public void InsertText( string strText)
		{
			oWordApplic.Selection.TypeText(strText);
		}

		public void InsertLineBreak( )
		{
			oWordApplic.Selection.TypeParagraph();
		}
		public void InsertLineBreak( int nline)
		{
			for (int i=0; i<nline; i++)
				oWordApplic.Selection.TypeParagraph();
		}

		// Change the paragraph alignement
		public void SetAlignment(string strType )
		{
			switch (strType)
			{
				case "Center" :
					oWordApplic.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
					break;
				case "Left" :
					oWordApplic.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
					break;
				case "Right" :
					oWordApplic.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
					break;
				case "Justify" :
					oWordApplic.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
					break;
			}
	
		}

		// if you use thif function to change the font you should call it again with 
		// no parameter in order to set the font without a particular format
		public void SetFont( string strType )
		{
			switch (strType)
			{
				case "Bold":
					oWordApplic.Selection.Font.Bold = 1;
					break;
				case "Italic":
					oWordApplic.Selection.Font.Italic = 1;
					break;
				case "Underlined":
					oWordApplic.Selection.Font.Subscript = 0;
					break;
			}			
		}
		
		// disable all the style 
		public void SetFont( )
		{
			oWordApplic.Selection.Font.Bold = 0;
			oWordApplic.Selection.Font.Italic = 0;
			oWordApplic.Selection.Font.Subscript = 0;
		}

		public void SetFontName( string strType )
		{
			oWordApplic.Selection.Font.Name = strType;
		} 

		public void SetFontSize( int nSize )
		{
			oWordApplic.Selection.Font.Size = nSize;
			
		} 

		public void InsertPagebreak()
		{
			object pBreak= (int)Word.WdBreakType.wdPageBreak;
			oWordApplic.Selection.InsertBreak(ref pBreak );
		}

		// Go to a predefined bookmark, if the bookmark doesn't exists the application will raise an error
		public void GotoBookMark( string strBookMarkName)
		{
			object missing = System.Reflection.Missing.Value;

			object Bookmark = (int)Word.WdGoToItem.wdGoToBookmark;
			object NameBookMark = strBookMarkName;
			oWordApplic.Selection.GoTo(ref Bookmark, ref missing, ref missing,ref NameBookMark);
		}

		public void GoToTheEnd( )
		{
			object missing = System.Reflection.Missing.Value;
			object unit ;
			unit = Word.WdUnits.wdStory ;
			oWordApplic.Selection.EndKey ( ref unit, ref missing);			
		}

		public void GoToTheBeginning( )
		{
			object missing = System.Reflection.Missing.Value;
			object unit ;
			unit = Word.WdUnits.wdStory ;
			oWordApplic.Selection.HomeKey ( ref unit, ref missing);			
		} 

		public void GoToTheTable(int ntable )
		{
			object missing = System.Reflection.Missing.Value;
			object what;
			what = Word.WdUnits.wdTable ;
			object which;
			which = Word.WdGoToDirection.wdGoToFirst;
			object count;
			count = 1 ;
			oWordApplic.Selection.GoTo( ref what, ref which, ref count, ref missing);
			oWordApplic.Selection.Find.ClearFormatting();

			oWordApplic.Selection.Text = "";			
		} 

		public void GoToRightCell( )
		{
			object missing = System.Reflection.Missing.Value;
			object direction;
			direction = Word.WdUnits.wdCell;
			oWordApplic.Selection.MoveRight(ref direction,ref missing,ref missing);
		} 

		public void GoToLeftCell( )
		{
			object missing = System.Reflection.Missing.Value;
			object direction;
			direction = Word.WdUnits.wdCell;
			oWordApplic.Selection.MoveLeft(ref direction,ref missing,ref missing);
		} 

		public void GoToDownCell( )
		{
			object missing = System.Reflection.Missing.Value;
			object direction;
			direction = Word.WdUnits.wdLine;
			oWordApplic.Selection.MoveDown(ref direction,ref missing,ref missing);
		} 

		public void GoToUpCell( )
		{
			object missing = System.Reflection.Missing.Value;
			object direction;
			direction = Word.WdUnits.wdLine;
			oWordApplic.Selection.MoveUp(ref direction,ref missing,ref missing);
		}
	}
}
