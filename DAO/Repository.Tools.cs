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
		public int UpdateTool(Tools tool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				myDb.Tools.AddOrUpdate(tool);
				var t = myDb.SaveChanges();
				return t;
            }
		}

		//Metodo Update per tutti i tools
		public int UpdateAllTools(List<Tools> tools)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				foreach(var tool in tools) //per ogni tool nella lista
				{
					myDb.Tools.AddOrUpdate(tool); //viene chiamato il metodo AddOrUpdate del contesto del db, aggiunge un tool se non esiste, altrimenti lo aggiorna
				}
				return myDb.SaveChanges();
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

		public List<Tools> GetToolsByToolType(int toolType)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				return myDb.Tools.Where(t => t.ToolType == toolType).ToList();
			}
        }

    }
}
