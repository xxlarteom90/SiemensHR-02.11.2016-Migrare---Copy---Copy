//Autor:Muntean Raluca Cristina
//Data:16.11.2004
//Descriere:
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using SiemensHR.utils;
using System.Web.UI;
using System.IO;
using System.Collections;



namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for Comunicari.
	/// </summary>
	public class Comunicari: Salaries.Data.DbObject
	{
		//constructor
		public Comunicari(string newConnectionString): base (newConnectionString)
		{
		}
		/*#region inserare modificari/obtinere de informatii in/din baza de date

		//inserare modificari in baza de date referitoare la indexarea salariului brut al tuturor angajatilor
		//si la majorarea salariilor unei parti a angajatilor
		public void InserareIndexareMajorare(ArrayList idAngajati, ArrayList indexare, ArrayList majorare, ArrayList sumaMajSB, ArrayList sumaMajIC,int trim)
		{
			//procentele de inflatie
			DataSet dsProcInfl;
			//procentul final de inflatie, calculat in functie de cate luni a lucrat angajatul in trimestrul anterior
			float procentInflatie=0;
					
			for(int i=0; i<idAngajati.Count; i++)
			{
				if(bool.Parse(indexare[i].ToString()))
				{
					Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
					objAngajat.AngajatId = long.Parse(idAngajati[i].ToString());
					objAngajat.LoadAngajat();
					//returneaza procentele de inflatie de pe trimestrul anterior datei active
					dsProcInfl = GetProcInflPeTrim(objAngajat.AngajatorId);
					float procInfl1=float.Parse(dsProcInfl.Tables[0].Rows[0]["ProcentInflatie"].ToString());
					float procInfl2=float.Parse(dsProcInfl.Tables[0].Rows[1]["ProcentInflatie"].ToString());
					float procInfl3=float.Parse(dsProcInfl.Tables[0].Rows[2]["ProcentInflatie"].ToString());
					/*	in functie de perioada pe care a fost angajat se aplica un anumit 
					procent de indexare
						coeficientul care se aduna la procentul de inflatie, vaziaza in functie de 
					numarul de luni lucrate de angajat pe trimestrul anterior, astfel:
					* pentru trei luni lucrate coeficient=0,01
					* pentru doua luni lucrate coeficient=0,0067
					* pentru o luna lucrata coeficient=0,0033
					*/
					

					/*int nrLuni = GetLuniLucratePeTrim(int.Parse(idAngajati[i].ToString()),trim);
					switch(nrLuni)
					{
						case 1:
							procentInflatie = procInfl1+float.Parse("0.0033");
							break;
						case 2:
							procentInflatie = procInfl1*procInfl2+float.Parse("0.0067");
							break;
						case 3:
							procentInflatie = procInfl1*procInfl2*procInfl3+float.Parse("0.01");
							break;
					}

					InserareIndexare(int.Parse(idAngajati[i].ToString()),procentInflatie);
				}
				if(bool.Parse(majorare[i].ToString()))
					InserareMajorari(int.Parse(idAngajati[i].ToString()), decimal.Parse(sumaMajIC[i].ToString()), decimal.Parse(sumaMajSB[i].ToString()));
			}
		}


		//insereaza in baza de date(tabela Sal_SituatieLunaraAngajat) prima stabilita 
		//pentru angajatul cu id-ul angajatID, pe luna trimisa ca parametru(lunaID) 
		public void InserarePrima(int lunaID, int angajatID, decimal primaSpeciala)
		{
			//declarare parametrii
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int,4),
					new SqlParameter("@PrimeSpeciale",SqlDbType.Money)
				};
			
			//setare parametrii
			parameters[0].Value = lunaID;
			parameters[1].Value = angajatID;
			parameters[2].Value = primaSpeciala;
			
			//executie procedura stocata
			RunProcedure("sal_UpdatePrimaSpeciala", parameters);
		}
		
	
		//face update bazei de date(tabela Angajati) aplicand majorarea 
		//pentru angajatul cu id-ul angajatID 
		public void InserareMajorari(int angajatID, decimal majIndemnizatieConducere, decimal majSalariuBaza)
		{
			//declarare parametrii
			SqlParameter[] parameters =
				{
					new SqlParameter("@AngajatID", SqlDbType.Int,4),
					new SqlParameter("@MajIndemnizatieConducere",SqlDbType.Money),
					new SqlParameter("@MajSalariuBaza",SqlDbType.Money)
				};
			
			//setare parametrii
			parameters[0].Value = angajatID;
			parameters[1].Value = majIndemnizatieConducere;
			parameters[2].Value = majSalariuBaza;
			
			//executie procedura stocata
			RunProcedure("sal_UpdateMajorari", parameters);
		}
		
		
		//face update bazei de date(tabela Angajati) aplicand indexarea 
		//pentru angajatul cu id-ul angajatID 
		public void InserareIndexare(int angajatID, float procentInflatie)
		{
			//declarare parametrii
			SqlParameter[] parameters =
				{
					new SqlParameter("@AngajatID", SqlDbType.Int,4),
					new SqlParameter("@ProcentInflatie",SqlDbType.Float),
			};
			
			//setare parametrii
			parameters[0].Value = angajatID;
			parameters[1].Value = procentInflatie;
			
			//executie procedura stocata
			RunProcedure("sal_UpdateIndexare", parameters);
		}

	
		//returneaza numarul de luni lucrate de angajatul cu id-ul trimis ca parametru
		//pe trimestrul trimis ca parametru
		public int GetLuniLucratePeTrim(int angajatID, int trim)
		{
			//declarare parametrii
			SqlParameter[] parameters =
				{
					new SqlParameter("@AngajatID", SqlDbType.Int,4),
					new SqlParameter("@Trim",SqlDbType.Int,4),
					new SqlParameter("@NrLuni",SqlDbType.Int,4)
				};
			
			//setare parametrii
			parameters[0].Value = angajatID;
			parameters[1].Value = trim;
			parameters[2].Direction = ParameterDirection.Output;
			
			//executie procedura stocata
			RunProcedure("sal_GetLuniLucrPeTrim", parameters);
			
			return (int)parameters[2].Value;
		}

	
		//returneaza numarul de luni lucrate de angajatii angajatorului cu id-ul angajatorID
		//pe trimestrul trimis ca parametru
		public DataSet GetAllAngLuniLucratePeTrim(int trim, int angajatorID)
		{
			//declarare parametrii
			SqlParameter[] parameters =
				{
					new SqlParameter("@Trim",SqlDbType.Int,4),
					new SqlParameter("@AngajatorID",SqlDbType.Int,4)
				};
			
			//setare parametrii
			parameters[0].Value = trim;
			parameters[1].Value = angajatorID;
						
			//executie procedura stocata
			return RunProcedure("sal_GetAllAngLuniPeTrim", parameters,"AngLuniPeTrim");
			
			
		}

		
		/*returneaza procentele de inflatie din trimestrul anterior
		aceasta metoda este apelata dupa ce s-a verificat faptul 
		ca in luna activa se inceheie un semestru, adica e una din lunile:
		1,4,7 sau 10*/
		/*public DataSet GetProcInflPeTrim(int angajatorID)
		{
			//declarare parametrii
			SqlParameter[] parameters ={
										new SqlParameter("@AngajatorID",SqlDbType.Int,4),
									   };
				
			parameters[0].Value = angajatorID;

			//executie procedura stocata
			return 	RunProcedure("sal_GetProcInflTrim", parameters,"ProcInflatie");
		}
		#endregion*/
	}
}
