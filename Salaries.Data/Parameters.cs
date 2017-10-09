using System;
using System.Data;
using System.Web.UI.WebControls;
//using Microsoft.Office.Interop.Owc11; // for office 2003
//using OWC;  // for office 2007

namespace Salaries.Data
{
	/// <summary>
	///1. Pastreaza numele departamentului pentru user-ul logat
	///2. Pastreaza Info angajat curent selectat in lista din pagina ManagersOptions_EvolutieSal
	///3. Functii de formatare a datei pentru rapoate (DateAdjust si MKConv)
	///4. Chart control si functii de lucru(Chart_SetData si Chart_GetPicture)
	///5. 
	/// </summary>
	public class Parameters
	{
		private static bool error;
		private static string errorMessage;
		private static string numeDepartament;
		private static ListItem dataAngajat;
		private static int timeSpan;

		#region Proprietati
		public static int TimeSpan
		{
			get
			{
				return timeSpan;
			}
			set
			{
				timeSpan=value;
			}
		}
		public static string NumeDepartament
		{
			get
			{
				return numeDepartament;
			}
			set
			{
				numeDepartament = value;
			}
		}
		public static ListItem DataAngajat
		{
			set
			{
				dataAngajat=value;
			}
			get
			{
				return dataAngajat;
			}
		}

		#endregion

		#region Chart Elements (Members and Methods)
		//private static ChartSpace cs; // office 2003
		//private static ChChart cc;  // for office 2003
		//private static  WCChart cc;	// office 2007
		private static bool inited=false;
		private static int hasvalues;
		
		private static void Chart_Init()
		{
			hasvalues=0;
//			cs=new ChartSpaceClass();
//			cc=cs.Charts.Add(0);
//			cc.Type=ChartChartTypeEnum.chChartTypeBarStacked;
//			cc.HasTitle=true;
			// cc.Title.Font.Bold=true;  //office 2003
//			cc.HasLegend=false;
//			cc.SeriesCollection.Add(0);
//			cc.Axes[0].HasTitle=true;
			//cc.Axes[0].Title.Font.Bold=true;  // office 2003
			//cc.Axes[0].Title.Font.Size=16;    // office 2003
			//cc.Axes[0].Title.Font.Color="Green";	// office 2003
			//ChDataLabels dl=cc.SeriesCollection[0].DataLabelsCollection.Add();  // office 2003
//			WCDataLabels dl=cc.SeriesCollection[0].DataLabelsCollection.Add();	// office 2007
			//dl.Font.Color="white";  // office 2003
			//dl.Font.Bold=true;	// office 2003
//			cc.Axes[1].HasTitle=true;
			//cc.Axes[1].Title.Font.Color="Green";  // office 2003
			//cc.Axes[1].Title.Font.Bold=true;	// office 2003
			//cc.Axes[1].Title.Font.Size=16;  // office 2003
			inited=true;
		}
	
		///<summary>
		/// Sets the data for the chart in order for it to create the image. Must be called before Chart_MakePicture
		/// </summary>
		/// <param name="dt">DataTable containing required values</param>
		/// <param name="CategoriesField">Name of the category field</param>
		/// <param name="ValuesField">name of the value field</param>
		/// <param name="Title">The title of the chart</param>
		/// <param name="Ax0Title">The title of the Y axis</param>
		/// <param name="Ax1Title">The Title of the X axis</param>
		public static void Chart_SetData(DataTable dt,string CategoriesField,string ValuesField,string Title,string Ax0Title,string Ax1Title)
		{
			if(!inited)
				Chart_Init();
			if (dt.Rows.Count==0)
			{
				dt.Rows.Add(dt.NewRow());
				dt.Rows[0][CategoriesField]="Nici o valoare selectata";
				dt.Rows[0][ValuesField]=0;
//				cc.Title.Caption="Va rugam alegeti o alta perioada de timp";
//				cc.Axes[0].Title.Caption="";
//				cc.Axes[1].Title.Caption="";
				hasvalues=0;
			}
			else
			{
//				cc.Title.Caption=Title;
//				cc.Axes[0].Title.Caption=Ax0Title;
//				cc.Axes[1].Title.Caption=Ax1Title;
				hasvalues=1;
			}
			string Categories="",Values="";
			foreach(DataRow d in dt.Rows)
			{
				Categories+=d[CategoriesField].ToString()+", ";
				Values+=d[ValuesField].ToString()+", ";
			}
			Categories=Categories.Substring(0,Categories.Length-2);
			Values=Values.Substring(0,Values.Length-2);
//			cc.SeriesCollection[0].SetData (ChartDimensionsEnum.chDimCategories,(int)ChartSpecialDataSourcesEnum.chDataLiteral, Categories);
//			cc.SeriesCollection[0].SetData (ChartDimensionsEnum.chDimValues,(int)ChartSpecialDataSourcesEnum.chDataLiteral, Values);
		}

		/// <summary>
		/// Creates an image file with the current chart
		/// </summary>
		/// <param name="format">Image Format(GIF,JPG,BMP,etc.)</param>
		/// <param name="width">Image width</param>
		/// <param name="height">Image height</param>
		/// <returns></returns>
		public static byte [] Chart_MakePicture(string format,int width, int height)
		{
			if(inited)
				if(hasvalues==1)
					//return (byte[]) cs.GetPicture(format,width,height);  // office 2003
					return null;
				else
					//return (byte [])cs.GetPicture(format,400,200); // office 2003
					return null;
			else
				return null;
		}

		#endregion
		
		#region Long running Tasks insight
		private static string actionStatus;
		private static int percentDone;
		private static bool taskRunning;
		private static bool taskIsOK;
		private static string taskErrorMessage;

		public static int Task_PercentDone{
			get
			{
				return percentDone;
			}
			set
			{
			    percentDone=value;
				if (percentDone>100) {
					percentDone=100;
				}
			}
		}

		public static string Task_ActionStatus{
			get
			{
				return actionStatus;   
			}
			set
			{
			    actionStatus=value;
			}
		}

		public static bool TaskRunning{
			set
			{
				taskRunning=value;
			}
			get
			{
			    return taskRunning;
			}
		}
		public static string Task_ErrorMessage
		{
			get
			{
				return taskErrorMessage;
			}
			set
			{
				taskErrorMessage=value;   
			}
		}
		public static bool Task_IsOK{
			get
			{
				return taskIsOK;   
			}
			set
			{
			    taskIsOK=value;
				if (value) 
					taskErrorMessage="";
			}
		}
		#endregion

		#region Formatare datei pentru rapoarte
		/// <summary>
		/// 
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static string DateAdjust(string date)
		{
			string rez="";
			try
			{
				DateTime d=Convert.ToDateTime(date);
				rez=d.Month+"."+d.Day+"."+d.Year;
			}
			catch(Exception e)
			{
				error=true;
				errorMessage=e.Message;
			}
			return rez;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static string MKConv(string date)
		{
			string rez="";
			try
			{
				int a=date.IndexOf('.'),b=date.LastIndexOf('.');
				rez=date.Substring(b+1)+"/"+date.Substring(a+1,b-a-1)+"/"+date.Substring(0,a);
			}
			catch(Exception e)
			{
				error=true;
				errorMessage=e.Message;
			}
			return rez;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lbl"></param>
		public static void ProcessErrors(Label lbl)
		{
			if(error)
			{
				lbl.Text=errorMessage;
			}
			error=false;
		}

		#endregion	
		
	}
}
