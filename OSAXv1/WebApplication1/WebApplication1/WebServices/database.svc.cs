using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebApplication1.Controllers;

namespace WebApplication1.WebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "database" en el código, en svc y en el archivo de configuración a la vez.
    public class database : Idatabase
    {
        public void DoWork()
        {
            return;
        }

        public bool CreateDatabase(string databaseName)
        {
            Connection cn = new Connection();
            DBM sql = new DBM(cn);
            return sql.createDataBase(databaseName);
        }
    }
}
