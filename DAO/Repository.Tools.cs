using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public partial class Repository
    {
		public List<Tools> GetAllTools()
		{
			using (MyDBContext myDb = new MyDBContext())
			{

				return myDb.Tools.ToList();

			}
		}

		//Metodo Get By Id (aggiunto)
		public Tools GetToolsById(string idTool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				return myDb.Tools.Find(idTool);
			}
		}

		//Metodo Insert (aggiunto)
		public void InsertTools(Tools tool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				myDb.Tools.Add(tool);
				myDb.SaveChanges();
			}
		}

		//Metodo Update (aggiunto)
		public void UpdateTools(Tools tool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				myDb.Tools.AddOrUpdate(tool);
				myDb.SaveChanges();
			}
		}

		//Metodo Delete per id (aggiunto)
		public void DeleteTools(string idTool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				var tool = myDb.Tools.FirstOrDefault(t => t.IdTool == idTool);
				if (tool != null)
				{
					myDb.Tools.Remove(tool);
					myDb.SaveChanges();
				}
			}
		}
	}
}
