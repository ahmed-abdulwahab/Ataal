//using Ataal.DAL.Data.Context;
//using Ataal.DAL.Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ataal.DAL.Data
//{
//	public class SeedClass
//	{
//		public static void Initialize(AtaalContext context)
//		{
//			if (!context.Sections.Any())
//			{
//				context.Sections.Add(new Section { Section_ID = 1, Section_Name = "Car sectoin", Description = "A Sectoin specialized in repairing and diagnosing all car malfunctions , complete team specializing in repairing and detecting malfunction served by a distinguished and experienced work for more than 20 years", Photo = null });
//				context.Sections.Add(new Section { Section_ID = 2, Section_Name = "Plumber section", Description = "A Sectoin specialized in repairing and diagnosing all car malfunctions , complete team specializing in repairing and detecting malfunction served by a distinguished and experienced work for more than 20 years", Photo = null });
//				context.Sections.Add(new Section { Section_ID = 3, Section_Name = "Electrical devices section", Description = "A Section specialized in plumbing work. There is a full team specialized in repairing, detecting faults, and establishing plumbing work. More than 20 years of experience.", Photo = null });
//				context.Sections.Add(new Section { Section_ID = 4, Section_Name = "electric section", Description = "A Section specialized in repairing and detecting electrical faults, including installation, maintenance and lighting of the entire house , complete team specializing in repairing and detecting malfunction served by a distinguished and experienced work for more than 20 years" });
//				context.Sections.Add(new Section { Section_ID = 5, Section_Name = "Carpentry department", Description = "A Section specializing in disclosure of cracks and lack of furniture A complete team working on your comfort more than 20 years", Photo = null });
//				context.Sections.Add(new Section { Section_ID = 6, Section_Name = "Blacksmithing Section", Description = "A Section specializing in detecting and repairing malfunctions related to the mourning of the formation and welding of metals is a , complete team specializing in repairing and detecting malfunction served by a distinguished and experienced work for more than 20 years", Photo = null });
//				context.SaveChanges();
//			}




//			if (!context.KeyWords.Any())
//			{
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 1, KeyWord_Name = "Oil", Section_ID = 1 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 2, KeyWord_Name = "Battery ", Section_ID = 1 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 3, KeyWord_Name = "Brakes", Section_ID = 1 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 4, KeyWord_Name = "Air filter", Section_ID = 1 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 5, KeyWord_Name = "Seats", Section_ID = 1 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 6, KeyWord_Name = "Tires", Section_ID = 1 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 7, KeyWord_Name = "Wheels", Section_ID = 1 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 8, KeyWord_Name = "Timing belt", Section_ID = 1 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 9, KeyWord_Name = "Steering system", Section_ID = 1 });

//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 10, KeyWord_Name = "Pipes", Section_ID = 2 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 11, KeyWord_Name = "Faucets ", Section_ID = 2 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 12, KeyWord_Name = "Drains	", Section_ID = 2 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 13, KeyWord_Name = "Water heaters", Section_ID = 2 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 14, KeyWord_Name = "Valves", Section_ID = 2 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 15, KeyWord_Name = "Pumps", Section_ID = 2 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 16, KeyWord_Name = "Sewer lines", Section_ID = 2 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 17, KeyWord_Name = "Wheels", Section_ID = 2 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 18, KeyWord_Name = "Sump pumps ", Section_ID = 2 });

//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 19, KeyWord_Name = "Power cord", Section_ID = 3 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 20, KeyWord_Name = "Battery ", Section_ID = 3 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 21, KeyWord_Name = "Circuit board", Section_ID = 3 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 22, KeyWord_Name = "Switches", Section_ID = 3 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 23, KeyWord_Name = "Heating elements", Section_ID = 3 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 24, KeyWord_Name = "Motors", Section_ID = 3 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 25, KeyWord_Name = "Sensors", Section_ID = 3 });


//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 26, KeyWord_Name = "Electrical panel", Section_ID = 4 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 27, KeyWord_Name = "Wiring ", Section_ID = 4 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 28, KeyWord_Name = "Outlets and switches", Section_ID = 4 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 29, KeyWord_Name = "Appliances and equipment", Section_ID = 4 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 30, KeyWord_Name = "Lighting fixtures", Section_ID = 4 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 31, KeyWord_Name = "Grounding system:", Section_ID = 4 });


//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 32, KeyWord_Name = "Flooring ", Section_ID = 5 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 33, KeyWord_Name = "Framing", Section_ID = 5 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 34, KeyWord_Name = "Trim and molding", Section_ID = 5 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 35, KeyWord_Name = "Doors ", Section_ID = 5 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 36, KeyWord_Name = "windows", Section_ID = 5 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 37, KeyWord_Name = "Cabinets ", Section_ID = 5 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 38, KeyWord_Name = "furniture", Section_ID = 5 });


//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 39, KeyWord_Name = "Forge ", Section_ID = 6 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 40, KeyWord_Name = "Anvil ", Section_ID = 6 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 41, KeyWord_Name = "Hammers", Section_ID = 6 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 42, KeyWord_Name = "tongs", Section_ID = 6 });
//				context.KeyWords.Add(new KeyWords { KeyWord_ID = 43, KeyWord_Name = "Metal stock", Section_ID = 6 });


//				context.SaveChanges();
//			}

//		}
//	}
//}
